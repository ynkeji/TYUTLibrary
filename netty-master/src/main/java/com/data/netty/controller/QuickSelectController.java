package com.data.netty.controller;

import com.data.netty.Bean.ClientToSpring.QuickSelectBean;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.TcpToSpring.AreaDataRoot;
import com.data.netty.Bean.TcpToSpring.AreaDataTool;
import com.data.netty.Bean.TcpToSpring.QuickSelect.local;
import com.data.netty.Util.jwt;
import com.data.netty.service.GetareaInformationService;
import com.data.netty.service.impl.GetAreaInformation;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;

@RestController
public class QuickSelectController { ;

    @Autowired
    private GetareaInformationService getareaInformationService;

    @RequestMapping(value = "/quickSelect", method = RequestMethod.POST)
    public ResponseBean<String> quickSelect(@RequestBody QuickSelectBean quickSelectBean,@RequestHeader("token") String token) {
        if (token == null) {
            ResponseBean<String> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            return responseBean;
        }
        return getareaInformationService.getAreaInformation(quickSelectBean);
    }

    @RequestMapping(value = "/quick", method = RequestMethod.GET)
    public ResponseBean<local> quick(@RequestParam("userTime") String userTime,@RequestHeader("token") String token) throws IOException {
        if (token == null || !jwt.verify(token)) {
            ResponseBean<local> responseBean = new ResponseBean<>();
            responseBean.setCode(401);
            responseBean.setMsg("请重新登录");
            responseBean.setData(null);
            return responseBean;
        }
        return getareaInformationService.getAreaInformation_(userTime);
    }

}
