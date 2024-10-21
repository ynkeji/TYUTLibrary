package com.data.netty.Bean;

import io.swagger.annotations.ApiModelProperty;

/**
 * 描述：统一返回前端的实体类
 *
 * @author caojing
 * @create 2020-11-27-13:56
 */
public class ResponseBean<T> {
    /**
     * 状态码，0 success,1 fail 3第一次登陆
     */
    @ApiModelProperty("状态码，0 success,1 fail,2 wait")
    private long code = 0;

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    private String token;

    /**
     * 返回信息
     */
    @ApiModelProperty("返回信息")
    private String msg;

    /**
     * 返回的数据
     */
    @ApiModelProperty("返回数据")
    private T data;

    public ResponseBean() {

    }

    public ResponseBean(int code, String msg, T data) {
        this.code = code;
        this.msg = msg;
        this.data = data;
    }

    public void buildSuccessResponse(T data) {
        this.code = 0;
        this.data = data;
        this.msg = "成功";
    }

    public void buildFailedResponse() {
        this.code = 1;
        this.msg = "失败";
    }

    public void buildFailedResponse(String msg) {
        this.code = 1;
        this.msg = msg;
    }

    public long getCode() {
        return code;
    }

    public void setCode(long code) {
        this.code = code;
    }

    public String getMsg() {
        return msg;
    }

    public void setMsg(String msg) {
        this.msg = msg;
    }

    public T getData() {
        return data;
    }

    public void setData(T data) {
        this.data = data;
    }
}
