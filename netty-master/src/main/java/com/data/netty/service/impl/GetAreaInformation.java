package com.data.netty.service.impl;

import com.data.netty.Bean.ClientToSpring.QuickSelectBean;
import com.data.netty.Bean.MysqlBean.UserBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetAreaInformationBean;
import com.data.netty.Bean.TcpBean;
import com.data.netty.Bean.TcpToSpring.AreaDataRoot;
import com.data.netty.Bean.TcpToSpring.QuickSelect.Get;
import com.data.netty.Bean.TcpToSpring.QuickSelect.local;
import com.data.netty.Bean.TcpToSpring.QuickSelect.root;
import com.data.netty.Dao.User;
import com.data.netty.service.GetareaInformationService;
import com.data.netty.tcp.NettyClient;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestBody;

import java.io.IOException;
import java.util.Locale;
import java.util.concurrent.TimeUnit;

@Service
public class GetAreaInformation implements GetareaInformationService {

    @Autowired
    private StringRedisTemplate redisTemplate;

    @Autowired
    private User user;
    @Autowired
    private NettyClient nettyClient;
    @Override
    public ResponseBean<String> getAreaInformation(QuickSelectBean getareaInformation) {
        redisTemplate.opsForValue().set(getareaInformation.getUserTime(), "WAIT",3600, TimeUnit.SECONDS);
        GetAreaInformationBean getAreaInformationBean = new GetAreaInformationBean();
        if (redisTemplate.opsForValue().get(getareaInformation.getUsername() + "token") == null) {
            //取不到token，重新登录
            System.out.println(user.getUser(getareaInformation.getUsername()).getUsername());

            UserBean user1= user.getUser(getareaInformation.getUsername());
            getAreaInformationBean.setPassword(user1.getPassword());

        }else {
            getAreaInformationBean.setToken(redisTemplate.opsForValue().get(getareaInformation.getUsername() + "token"));
        }
        getAreaInformationBean.setUsername(getareaInformation.getUsername());
        getAreaInformationBean.setUserTime(getareaInformation.getUserTime());
        getAreaInformationBean.setTime(getareaInformation.getTime());
        TcpBean tcpBean = new TcpBean();
        tcpBean.setUserTime("op");
        JSONObject jsonObject = new JSONObject(getAreaInformationBean);
        tcpBean.setData(jsonObject.toString());
        JSONObject  jsonObject2 = new JSONObject(tcpBean);
        nettyClient.start(jsonObject2.toString() + "<END>");
        ResponseBean<String> responseBean = new ResponseBean<>();
        responseBean.setCode(200);
        responseBean.setMsg("请求成功");
        responseBean.setData(null);
        return responseBean;
    }


    public ResponseBean<local> getAreaInformation_(String userTime) {
        ResponseBean<local> responseBean = new ResponseBean<>();
        if (redisTemplate.opsForValue().get(userTime) == null) {
            responseBean.setCode(404);
            responseBean.setMsg("请求失败");
            responseBean.setData(null);
            return responseBean;
        }
        int t = 0;
        while (t <= 10) {
            String value = redisTemplate.opsForValue().get(userTime);
            if (!value.equals("WAIT")) {
                try {
                    root r = Get.fromJsonString(value);
                    responseBean.setCode(r.getCode());
                    responseBean.setMsg(r.getMsg());
                    responseBean.setData(r.getData());
                    return responseBean;
                } catch (Exception e) {
                    responseBean.setCode(300);
                    responseBean.setMsg(e.toString());
                    responseBean.setData(null);
                    return responseBean;
                }
            }
            try {
                Thread.sleep(1000);
                t++;
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        if (t >= 10) {
            responseBean.setCode(500);
            responseBean.setMsg("请求超时");
            responseBean.setData(null);
            return responseBean;
        }
        return responseBean;
    }
}
