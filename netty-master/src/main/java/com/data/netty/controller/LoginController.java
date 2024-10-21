package com.data.netty.controller;
import com.data.netty.Bean.*;
import com.data.netty.Bean.ClientToSpring.Login;
import com.data.netty.Bean.ClientToSpring.wxLogin;
import com.data.netty.service.LoginService;
import com.data.netty.tcp.NettyClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


@RestController
public class LoginController {
    @Autowired
    private NettyClient nettyClient;

    @Autowired
    private LoginService loginService;


    @RequestMapping("/hello")
    public String hello(String name) throws Exception {
        return "软件2140 潘慧宇 2021006311";
    }

    @RequestMapping(value = "/login",method = RequestMethod.POST)
    public ResponseBean<String> login(@RequestBody Login login){
        return loginService.login(login);
    }

    @RequestMapping(value = "/login_",method = RequestMethod.GET)
    public ResponseBean<Data> login_(@RequestParam("userTime") String userTime){
        return loginService.login_(userTime);
    }

    @RequestMapping(value = "/wxlogin",method = RequestMethod.POST)
    public ResponseBean<String> wxlogin(@RequestBody wxLogin code){
        return loginService.wxlogin(code);
    }
//
}
