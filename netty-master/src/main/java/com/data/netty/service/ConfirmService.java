package com.data.netty.service;

import com.data.netty.Bean.ClientToSpring.Confirm;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.TcpToSpring.Confirm.ConfirmData;
import org.springframework.stereotype.Service;

@Service
public interface ConfirmService {

    public ResponseBean<String> Reserve(Confirm confirm);

    public ResponseBean<ConfirmData> Reserve_(String userTime);
}
