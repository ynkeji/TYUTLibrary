package com.data.netty.Bean.TcpToSpring;

import com.fasterxml.jackson.annotation.JsonProperty;

public class AreaDataRoot {

    private long code;
    private Datum[] data;
    private String msg;

    @JsonProperty("code")
    public long getCode() { return code; }
    @JsonProperty("code")
    public void setCode(long value) { this.code = value; }

    @JsonProperty("data")
    public Datum[] getData() { return data; }
    @JsonProperty("data")
    public void setData(Datum[] value) { this.data = value; }

    @JsonProperty("msg")
    public String getMsg() { return msg; }
    @JsonProperty("msg")
    public void setMsg(String value) { this.msg = value; }

}

// Area.java
