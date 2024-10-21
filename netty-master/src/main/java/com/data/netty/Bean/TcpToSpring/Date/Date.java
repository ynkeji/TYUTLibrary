package com.data.netty.Bean.TcpToSpring.Date;

import com.fasterxml.jackson.annotation.*;

/**
 * ApifoxModel
 */
public class Date {
    private long code;
    private Dateum[] data;
    private String msg;

    @JsonProperty("code")
    public long getCode() { return code; }
    @JsonProperty("code")
    public void setCode(long value) { this.code = value; }

    @JsonProperty("data")
    public Dateum[] getData() { return data; }
    @JsonProperty("data")
    public void setData(Dateum[] value) { this.data = value; }

    @JsonProperty("msg")
    public String getMsg() { return msg; }
    @JsonProperty("msg")
    public void setMsg(String value) { this.msg = value; }
}

