package com.data.netty.controller;

import com.data.netty.Bean.ClientToSpring.Confirm;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.TcpToSpring.Confirm.ConfirmData;
import com.data.netty.Util.jwt;
import com.data.netty.service.ConfirmService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@RestController
public class ConfirmController {

    @Autowired
    private ConfirmService confirmService;

    @RequestMapping(value = "/Confirm",method = RequestMethod.POST)
    public ResponseBean<String> Reserve(@RequestBody Confirm confirm,@RequestHeader("token") String token){
        if (token == null || !jwt.verify(token)) {
            ResponseBean<String> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            return responseBean;
        }
        return confirmService.Reserve(confirm);
    }

    @RequestMapping(value = "/Confirm_",method = RequestMethod.GET)
    public ResponseBean<ConfirmData> Reserve_(@RequestParam("userTime") String userTime,@RequestHeader("token") String token){
        if (token == null || !jwt.verify(token)) {
            ResponseBean<ConfirmData> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            responseBean.setData(null);
            return responseBean;
        }
        return confirmService.Reserve_(userTime);
    }
}
