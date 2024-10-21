package com.data.netty.controller;


import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatDate;
import com.data.netty.Bean.TcpToSpring.subscribe.MySubscribe;
import com.data.netty.Util.jwt;
import com.data.netty.service.SubscribeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class subscribeController {


    @Autowired
    private SubscribeService subscribeService;

    @RequestMapping(value = "/subscribe",method = RequestMethod.GET)
    public ResponseBean<String> subscribe(@RequestParam("userTime") String userTime,
                                          @RequestParam("username") String username,
                                          @RequestHeader("token") String token){
        if (token == null || !jwt.verify(token)) {
            ResponseBean<String> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            responseBean.setData(null);
            return responseBean;
        }
        return subscribeService.subscribe(userTime,username);
    }

    @RequestMapping(value = "/subscribe_",method = RequestMethod.GET)
    public ResponseBean<MySubscribe[]> subscribe_(@RequestParam("userTime") String userTime
                                                    ,@RequestHeader("token") String token){
        if (token == null || !jwt.verify(token)) {
            ResponseBean<MySubscribe[]> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            responseBean.setData(null);
            return responseBean;
        }
        return subscribeService.subscribe_(userTime);
    }
}
