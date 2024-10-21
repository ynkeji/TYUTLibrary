package com.data.netty.service.impl;

import com.data.netty.Bean.MysqlBean.UserBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetDate;
import com.data.netty.Bean.SpringToTcp.MyBook;
import com.data.netty.Bean.TcpBean;
import com.data.netty.Bean.TcpToSpring.GetSeat.Seat;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatConverter;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatDate;
import com.data.netty.Bean.TcpToSpring.subscribe.MySubscribe;
import com.data.netty.Bean.TcpToSpring.subscribe.subConvert;
import com.data.netty.Bean.TcpToSpring.subscribe.subscribeRoot;
import com.data.netty.Dao.User;
import com.data.netty.service.SubscribeService;
import com.data.netty.tcp.NettyClient;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

@Service
public class SubscribeServiceImpl implements SubscribeService {
    @Autowired
    private NettyClient nettyClient;
    @Autowired
    private StringRedisTemplate redisTemplate;
    @Autowired
    private User user;

    @Override
    public ResponseBean<String> subscribe(String userTime, String username) {
        ResponseBean<String> responseBean = new ResponseBean<String>();
        MyBook myBook = new MyBook();
        String token = redisTemplate.opsForValue().get(username + "token");
        if (token == null) {
            //token过期，重新登录
            UserBean userBean = user.getUser(username);
            System.out.println(username + " " + userTime);
            myBook.setPassword(userBean.getPassword());
        }
        else {
            myBook.setToken(token);
        }
        myBook.setUsername(username);
        myBook.setUserTime(userTime);

        TcpBean tcpBean = new TcpBean();
        tcpBean.setUserTime("op");
        JSONObject jsonObject = new JSONObject(myBook);
        tcpBean.setData(jsonObject.toString());
        JSONObject  jsonObject2 = new JSONObject(tcpBean);
        nettyClient.start(jsonObject2.toString() + "<END>");
        redisTemplate.opsForValue().set(myBook.getUserTime(), "WAIT", 3600, java.util.concurrent.TimeUnit.SECONDS);
        responseBean.setCode(200);
        responseBean.setMsg("请求成功");
        responseBean.setData(null);
        return responseBean;
    }

    @Override
    public ResponseBean<MySubscribe[]> subscribe_(String userTime) {
        ResponseBean<MySubscribe[]> responseBean = new ResponseBean<>();
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
                    subscribeRoot r =  subConvert.fromJsonString(value);
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
