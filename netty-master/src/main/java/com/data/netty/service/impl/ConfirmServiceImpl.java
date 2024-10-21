package com.data.netty.service.impl;

import com.data.netty.Bean.ClientToSpring.Confirm;
import com.data.netty.Bean.MysqlBean.UserBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetAreaInformationBean;
import com.data.netty.Bean.SpringToTcp.Reserve;
import com.data.netty.Bean.TcpBean;
import com.data.netty.Bean.TcpToSpring.Confirm.ConfirmConvert;
import com.data.netty.Bean.TcpToSpring.Confirm.ConfirmData;
import com.data.netty.Bean.TcpToSpring.QuickSelect.Get;
import com.data.netty.Bean.TcpToSpring.QuickSelect.local;
import com.data.netty.Bean.TcpToSpring.QuickSelect.root;
import com.data.netty.Dao.User;
import com.data.netty.service.ConfirmService;
import com.data.netty.tcp.NettyClient;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

import java.util.concurrent.TimeUnit;


@Service
public class ConfirmServiceImpl implements ConfirmService {

    @Autowired
    private StringRedisTemplate redisTemplate;

    @Autowired
    private User user;
    @Autowired
    private NettyClient nettyClient;


    @Override
    public ResponseBean<String> Reserve(Confirm confirm) {
        System.out.println(confirm.getUsername());
        System.out.println(confirm.getUserTime());
        System.out.println(confirm.getSeg());
        System.out.println(confirm.getArea());

        redisTemplate.opsForValue().set(confirm.getUserTime(), "WAIT",3600, TimeUnit.SECONDS);
        Reserve reserve = new Reserve();
        if (redisTemplate.opsForValue().get(confirm.getUsername() + "token") == null) {
            //取不到token，重新登录
            System.out.println(this.user.getUser(confirm.getUsername()).getUsername());
            UserBean user1= this.user.getUser(confirm.getUsername());
            reserve.setPassword(user1.getPassword());
        }else {
            reserve.setToken(redisTemplate.opsForValue().get(confirm.getUsername() + "token"));
        }
        reserve.setUsername(confirm.getUsername());
        reserve.setUserTime(confirm.getUserTime());
        reserve.setSeg(confirm.getSeg());
        reserve.setArea(confirm.getArea());
        TcpBean tcpBean = new TcpBean();
        tcpBean.setUserTime("op");
        JSONObject jsonObject = new JSONObject(reserve);
        tcpBean.setData(jsonObject.toString());
        JSONObject  jsonObject2 = new JSONObject(tcpBean);
        nettyClient.start(jsonObject2.toString() + "<END>");
        ResponseBean<String> responseBean = new ResponseBean<>();
        responseBean.setCode(200);
        responseBean.setMsg("请求成功");
        responseBean.setData(null);
        return responseBean;
    }

    @Override
    public ResponseBean<ConfirmData> Reserve_(String userTime) {
        ResponseBean<ConfirmData> responseBean = new ResponseBean<>();
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
                    ConfirmData r = ConfirmConvert.fromJsonString(value);
                    responseBean.setCode(r.getCode());
                    responseBean.setMsg(r.getMsg());
                    responseBean.setData(r);
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
