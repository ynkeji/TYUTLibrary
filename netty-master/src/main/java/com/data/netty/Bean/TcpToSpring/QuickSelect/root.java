package com.data.netty.Bean.TcpToSpring.QuickSelect;

import com.fasterxml.jackson.annotation.*;

/**
 * GetArea
 */
public class root {
    private long code;
    private local data;
    private String msg;

    @JsonProperty("code")
    public long getCode() { return code; }
    @JsonProperty("code")
    public void setCode(long value) { this.code = value; }

    @JsonProperty("data")
    public local getData() { return data; }
    @JsonProperty("data")
    public void setData(local value) { this.data = value; }

    @JsonProperty("msg")
    public String getMsg() { return msg; }
    @JsonProperty("msg")
    public void setMsg(String value) { this.msg = value; }
}