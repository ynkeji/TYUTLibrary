package com.data.netty.Bean.TcpToSpring.Confirm;

import com.fasterxml.jackson.annotation.*;

/**
 * ApifoxModel
 */
public class ConfirmData {
    private String area;
    private long code;
    private String msg;
    private String newTime;
    private String no;
    private String seat;
    private String time;

    @JsonProperty("area")
    public String getArea() { return area; }
    @JsonProperty("area")
    public void setArea(String value) { this.area = value; }

    @JsonProperty("code")
    public long getCode() { return code; }
    @JsonProperty("code")
    public void setCode(long value) { this.code = value; }

    @JsonProperty("msg")
    public String getMsg() { return msg; }
    @JsonProperty("msg")
    public void setMsg(String value) { this.msg = value; }

    @JsonProperty("new_time")
    public String getNewTime() { return newTime; }
    @JsonProperty("new_time")
    public void setNewTime(String value) { this.newTime = value; }

    @JsonProperty("no")
    public String getNo() { return no; }
    @JsonProperty("no")
    public void setNo(String value) { this.no = value; }

    @JsonProperty("seat")
    public String getSeat() { return seat; }
    @JsonProperty("seat")
    public void setSeat(String value) { this.seat = value; }

    @JsonProperty("time")
    public String getTime() { return time; }
    @JsonProperty("time")
    public void setTime(String value) { this.time = value; }
}