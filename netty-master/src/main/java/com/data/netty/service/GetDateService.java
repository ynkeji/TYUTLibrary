package com.data.netty.service;

import com.data.netty.Bean.ClientToSpring.DateBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.TcpToSpring.Date.Date;
import com.data.netty.Bean.TcpToSpring.Date.Dateum;
import org.springframework.stereotype.Service;

@Service
public interface GetDateService {
    public ResponseBean<String> GetDate(DateBean dateBean);
    public ResponseBean<Dateum[]> GetDate_(String userTime);

}
