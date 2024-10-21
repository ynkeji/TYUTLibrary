package com.data.netty.service.impl;

import com.data.netty.Bean.ClientToSpring.DateBean;
import com.data.netty.Bean.MysqlBean.UserBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetDate;
import com.data.netty.Bean.TcpBean;
import com.data.netty.Bean.TcpToSpring.Date.Date;
import com.data.netty.Bean.TcpToSpring.Date.DateConverter;
import com.data.netty.Bean.TcpToSpring.Date.Dateum;
import com.data.netty.Bean.TcpToSpring.QuickSelect.Get;
import com.data.netty.Bean.TcpToSpring.QuickSelect.local;
import com.data.netty.Bean.TcpToSpring.QuickSelect.root;
import com.data.netty.Dao.User;
import com.data.netty.service.GetDateService;
import com.data.netty.tcp.NettyClient;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

@Service
public class GetDateimpl implements GetDateService {
    @Autowired
    private NettyClient nettyClient;
    @Autowired
    private StringRedisTemplate redisTemplate;
    @Autowired
    private User user;

    @Override
    public ResponseBean<String> GetDate(DateBean dateBean) {
        ResponseBean<String> responseBean = new ResponseBean<String>();
        GetDate getDate = new GetDate();
        String token = redisTemplate.opsForValue().get(dateBean.getUsername() + "token");
        if (token == null) {
            //token过期，重新登录
            UserBean userBean = user.getUser(dateBean.getUsername());
            getDate.setPassword(userBean.getPassword());
        }
        else {
            getDate.setToken(token);
        }
        getDate.setUsername(dateBean.getUsername());
        getDate.setUserTime(dateBean.getUserTime());
        getDate.setBuild(dateBean.getBuild());

        TcpBean tcpBean = new TcpBean();
        tcpBean.setUserTime("op");
        JSONObject jsonObject = new JSONObject(getDate);
        tcpBean.setData(jsonObject.toString());
        JSONObject  jsonObject2 = new JSONObject(tcpBean);
        nettyClient.start(jsonObject2.toString() + "<END>");
        redisTemplate.opsForValue().set(dateBean.getUserTime(), "WAIT", 3600, java.util.concurrent.TimeUnit.SECONDS);
        responseBean.setCode(200);
        responseBean.setMsg("请求成功");
        responseBean.setData(null);
        return responseBean;
    }

    @Override
    public ResponseBean<Dateum[]> GetDate_(String userTime) {
        ResponseBean<Dateum[]> responseBean = new ResponseBean<>();
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
                    Date r = DateConverter.fromJsonString(value);
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
