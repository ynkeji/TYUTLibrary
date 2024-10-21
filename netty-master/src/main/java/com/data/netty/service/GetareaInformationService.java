package com.data.netty.service;


import com.data.netty.Bean.ClientToSpring.QuickSelectBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SpringToTcp.GetAreaInformationBean;
import com.data.netty.Bean.TcpToSpring.AreaDataRoot;
import com.data.netty.Bean.TcpToSpring.QuickSelect.local;
import org.springframework.stereotype.Service;

@Service
public interface GetareaInformationService {
    public ResponseBean<String> getAreaInformation(QuickSelectBean quickSelectBean);
    public ResponseBean<local> getAreaInformation_(String userTime);
}
