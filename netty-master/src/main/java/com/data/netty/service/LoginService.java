package com.data.netty.service;

import com.data.netty.Bean.ClientToSpring.Login;
import com.data.netty.Bean.ClientToSpring.wxLogin;
import com.data.netty.Bean.Data;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.UserData;
import org.springframework.stereotype.Service;

@Service
public interface LoginService {
    public ResponseBean<String> login(Login login);
    public ResponseBean<Data> login_(String userTime);
    public ResponseBean<String> wxlogin(wxLogin wxCode);
}
