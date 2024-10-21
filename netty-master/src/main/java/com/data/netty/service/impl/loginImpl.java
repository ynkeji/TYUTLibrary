package com.data.netty.service.impl;

import com.data.netty.Bean.ClientToSpring.Login;
import com.data.netty.Bean.ClientToSpring.wxLogin;
import com.data.netty.Bean.Data;
import com.data.netty.Bean.MysqlBean.UserBean;
import com.data.netty.Bean.SpringToTcp.login;
import com.data.netty.Bean.TcpBean;
import com.data.netty.Bean.UserData;
import com.data.netty.Dao.User;
import com.data.netty.Util.jwt;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.json.JsonMapper;
import org.json.JSONObject;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.service.LoginService;
import com.data.netty.tcp.NettyClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

import java.util.concurrent.TimeUnit;

import static com.data.netty.Util.WeChatUtil.getSessionKeyOrOpenId;

@Service
public class loginImpl implements LoginService {
    @Autowired
    private StringRedisTemplate redisTemplate;

    @Autowired
    private User user;
    @Autowired
    private NettyClient nettyClient;
    public ResponseBean<String> login(Login login1) {
        redisTemplate.opsForValue().set(login1.getUserTime(), "WAIT",3600, TimeUnit.SECONDS);
        if (redisTemplate.opsForValue().get(login1.getUsername() + "pass") != null) {
            redisTemplate.delete(login1.getUsername() + "pass");
        }
        redisTemplate.opsForValue().set(login1.getUsername() + "pass", login1.getPassword(),3600, TimeUnit.SECONDS);
        login login2 = new login();
        login2.setPassword(login1.getPassword());
        login2.setUsername(login1.getUsername());
        login2.setUserTime(login1.getUserTime());
        TcpBean tcpBean = new TcpBean();
        tcpBean.setUserTime("op");
        JSONObject  jsonObject = new JSONObject(login2);
        tcpBean.setData(jsonObject.toString());
        JSONObject  jsonObject2 = new JSONObject(tcpBean);
        nettyClient.start(jsonObject2.toString() + "<END>");
        ResponseBean<String> responseBean = new ResponseBean<>();
        responseBean.setCode(200);
        responseBean.setMsg("请求成功请稍后~");
        return responseBean;
    }

    public ResponseBean<Data> login_(String userTime) {
        int time = 0;
        ResponseBean<Data> responseBean = new ResponseBean<>();
        while (true) {
            String value = redisTemplate.opsForValue().get(userTime);
            if (value == null) {
                responseBean.setCode(404);
                responseBean.setMsg("请求失败");
                responseBean.setData(null);
                return responseBean;
            }
            if (!value.equals("WAIT")) {
                JsonMapper jsonMapper = new JsonMapper();
                try {
                    System.out.println(value);
                    UserData userData = jsonMapper.readValue(value, UserData.class);
                    responseBean.setCode(userData.getCode());
                    responseBean.setMsg(userData.getMsg());
                    responseBean.setData(userData.getData());
                    if (userData.getMsg().equals("用户名或密码错误~")){
                        return responseBean;
                    }
                    if (userData.getMsg().equals("登录成功")){
                        Data data = userData.getData();
                        String password = redisTemplate.opsForValue().get(data.getName() + "pass");
                        String name = data.getName();
                        UserBean userBean = user.getUser(data.getId());
                        if (userBean != null){
                            user.UpdataUser(data.getId(), password, name);
                        }
                        if (userBean == null){
                            user.insertUser(data.getId(), password, name);
                        }
                        String token = jwt.sign(data.getId(), name);
                        responseBean.setToken(token);
                    }
                    return responseBean;
                } catch (JsonProcessingException e) {
                    responseBean.setCode(300);
                    responseBean.setMsg(e.toString());
                    responseBean.setData(null);
                    return responseBean;
                }
            }
            try {
                Thread.sleep(1000);
                time++;
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            if (time > 10) {
                responseBean.setCode(500);
                responseBean.setMsg("请求超时");
                responseBean.setData(null);
                return responseBean;
            }
        }
    }

    @Override
    public ResponseBean<String> wxlogin(wxLogin wx) {
        ResponseBean<String> responseBean = new ResponseBean<>();
        if (wx.getUsername() == null || wx.getCode() == null || wx.getToken() == null) {
            responseBean.setCode(400);
            responseBean.setMsg("请求参数错误");
            responseBean.setData(null);
            return responseBean;
        }
        UserBean userBean = user.getUser(wx.getUsername());
        if (userBean == null) {
            responseBean.setCode(1001);
            responseBean.setMsg("用户不存在");
            responseBean.setData(null);
            return responseBean;
        }
        String wxCode = wx.getCode();
        String openId =  getSessionKeyOrOpenId(wxCode);
        if(user.getUserID(openId) == null){
            user.insertWxLogin(openId, userBean.getUsername());
        }
        else{
            user.updateUserID(openId, userBean.getUsername());
        }
        String tk = jwt.sign(userBean.getUsername(), userBean.getName());
        responseBean.setCode(200);
        responseBean.setMsg("请求成功");
        responseBean.setData(tk);
        return responseBean;
    }
}
