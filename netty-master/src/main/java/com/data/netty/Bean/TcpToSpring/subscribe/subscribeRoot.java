package com.data.netty.Bean.TcpToSpring.subscribe;

import com.fasterxml.jackson.annotation.*;

/**
 * ApifoxModel
 */
public class subscribeRoot {
    private long code;
    private MySubscribe[] data;
    private String msg;

    @JsonProperty("code")
    public long getCode() { return code; }
    @JsonProperty("code")
    public void setCode(long value) { this.code = value; }

    @JsonProperty("data")
    public MySubscribe[] getData() { return data; }
    @JsonProperty("data")
    public void setData(MySubscribe[] value) { this.data = value; }

    @JsonProperty("msg")
    public String getMsg() { return msg; }
    @JsonProperty("msg")
    public void setMsg(String value) { this.msg = value; }
}