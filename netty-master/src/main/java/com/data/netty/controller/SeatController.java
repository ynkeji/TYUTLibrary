package com.data.netty.controller;

import com.data.netty.Bean.ClientToSpring.DateBean;
import com.data.netty.Bean.ClientToSpring.SeatList;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetDate;
import com.data.netty.Bean.TcpToSpring.Date.Date;
import com.data.netty.Bean.TcpToSpring.Date.Dateum;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatDate;
import com.data.netty.Util.jwt;
import com.data.netty.service.GetDateService;
import com.data.netty.service.GetSeatService;
import com.data.netty.tcp.NettyClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.web.bind.annotation.*;

@RestController
public class SeatController {


    @Autowired
    private GetSeatService getSeatService;

    @RequestMapping(value = "/GetSeat",method = RequestMethod.POST)
    public ResponseBean<String> GetData(@RequestBody SeatList seatList,@RequestHeader("token") String token){
        if (token == null || !jwt.verify(token)) {
            ResponseBean<String> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            return responseBean;
        }
        return getSeatService.GetSeat(seatList);
    }
    @RequestMapping(value = "/GetSeat_",method = RequestMethod.GET)
    public ResponseBean<SeatDate[]> GetData_(@RequestParam("userTime")String userTime,@RequestHeader("token") String token){
        if (token == null || !jwt.verify(token)) {
            ResponseBean<SeatDate[]> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            responseBean.setData(null);
            return responseBean;
        }
        return getSeatService.GetSeat_(userTime);
    }
}
