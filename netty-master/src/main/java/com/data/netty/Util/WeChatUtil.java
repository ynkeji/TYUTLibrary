package com.data.netty.Util;
import cn.hutool.core.codec.Base64;
import cn.hutool.http.HttpUtil;
import cn.hutool.json.JSONObject;
import cn.hutool.json.JSONUtil;
import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import java.security.AlgorithmParameters;
import java.security.Security;
import java.util.Arrays;
import java.util.HashMap;

public class WeChatUtil {

    public static String getSessionKeyOrOpenId(String code) {
        //微信小程序官方接口
        String requestUrl = "https://api.weixin.qq.com/sns/jscode2session";
        //接口所需参数
        HashMap<String, Object> requestUrlParam = new HashMap<>();
        //小程序appId
        requestUrlParam.put("appid", "wx08613a542bab");
        //小程序secret
        requestUrlParam.put("secret", "5f929f8894a2f7d58ef5d0ef1d6");
        //小程序端返回的code
        requestUrlParam.put("js_code", code);
        //默认参数，固定写死即可
        requestUrlParam.put("grant_type", "authorization_code");
        //发送post请求读取调用微信接口获取openid用户唯一标识
        String result = HttpUtil.get(requestUrl, requestUrlParam);
        JSONObject jsonObject = JSONUtil.parseObj(result);
        System.out.println(jsonObject);
        return jsonObject.get("openid", String.class);
    }
}
