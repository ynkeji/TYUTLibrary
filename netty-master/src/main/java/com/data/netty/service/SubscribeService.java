package com.data.netty.service;


import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.TcpToSpring.subscribe.MySubscribe;
import org.springframework.stereotype.Service;

@Service
public interface SubscribeService {
    public ResponseBean<String> subscribe(String userTime, String username);

    public ResponseBean<MySubscribe[]> subscribe_(String userTime);
}
