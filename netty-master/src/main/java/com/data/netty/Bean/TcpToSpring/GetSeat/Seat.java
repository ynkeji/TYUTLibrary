package com.data.netty.Bean.TcpToSpring.GetSeat;

import com.fasterxml.jackson.annotation.*;

/**
 * ApifoxModel
 */
public class Seat {
    private long code;
    private SeatDate[] data;
    private String msg;

    @JsonProperty("code")
    public long getCode() { return code; }
    @JsonProperty("code")
    public void setCode(long value) { this.code = value; }

    @JsonProperty("data")
    public SeatDate[] getData() { return data; }
    @JsonProperty("data")
    public void setData(SeatDate[] value) { this.data = value; }

    @JsonProperty("msg")
    public String getMsg() { return msg; }
    @JsonProperty("msg")
    public void setMsg(String value) { this.msg = value; }
}
