package com.data.netty.service.impl;

import com.data.netty.Bean.ClientToSpring.SeatList;
import com.data.netty.Bean.MysqlBean.UserBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetAreaInformationBean;
import com.data.netty.Bean.SpringToTcp.SeatGet;
import com.data.netty.Bean.SpringToTcp.login;
import com.data.netty.Bean.TcpBean;
import com.data.netty.Bean.TcpToSpring.GetSeat.Seat;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatConverter;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatDate;
import com.data.netty.Bean.TcpToSpring.QuickSelect.Get;
import com.data.netty.Bean.TcpToSpring.QuickSelect.local;
import com.data.netty.Bean.TcpToSpring.QuickSelect.root;
import com.data.netty.Dao.User;
import com.data.netty.service.GetSeatService;
import com.data.netty.tcp.NettyClient;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

import java.util.concurrent.TimeUnit;

@Service
public class GetSeatServiceImpl implements GetSeatService {
    @Autowired
    private NettyClient nettyClient;

    @Autowired
    private StringRedisTemplate redisTemplate;

    @Autowired
    private User user;

    @Override
    public ResponseBean<String> GetSeat(SeatList seatList) {
        redisTemplate.opsForValue().set(seatList.getUserTime(), "WAIT", 3600, TimeUnit.SECONDS);
        SeatGet seatGet = new SeatGet();
        if (redisTemplate.opsForValue().get(seatList.getUsername() + "token") == null) {
            //取不到token，重新登录
            System.out.println(user.getUser(seatList.getUsername()).getUsername());

            UserBean user1 = user.getUser(seatList.getUsername());
            seatGet.setPassword(user1.getPassword());

        } else {
            seatGet.setToken(redisTemplate.opsForValue().get(seatList.getUsername() + "token"));
        }
        seatGet.setUsername(seatList.getUsername());
        seatGet.setUserTime(seatList.getUserTime());
        seatGet.setArea(seatList.getArea());
        seatGet.setStartTime(seatList.getStartTime());
        seatGet.setEndTime(seatList.getEndTime());
        seatGet.setSegment(seatList.getSeg());
        seatGet.setDay(seatList.getDay());
        TcpBean tcpBean = new TcpBean();
        tcpBean.setUserTime("op");
        JSONObject jsonObject = new JSONObject(seatGet);
        tcpBean.setData(jsonObject.toString());
        JSONObject jsonObject2 = new JSONObject(tcpBean);
        nettyClient.start(jsonObject2.toString() + "<END>");
        ResponseBean<String> responseBean = new ResponseBean<>();
        responseBean.setCode(200);
        responseBean.setMsg("请求成功");
        responseBean.setData(null);
        return responseBean;
    }

    @Override
    public ResponseBean<SeatDate[]> GetSeat_(String userTime) {
        ResponseBean<SeatDate[]> responseBean = new ResponseBean<>();
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
                    Seat r = SeatConverter.fromJsonString(value);
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

