package com.data.netty.Bean.TcpToSpring.Date;

import com.fasterxml.jackson.annotation.*;

public class Dateum {
    private String day;
    private Time[] times;

    @JsonProperty("day")
    public String getDay() { return day; }
    @JsonProperty("day")
    public void setDay(String value) { this.day = value; }

    @JsonProperty("times")
    public Time[] getTimes() { return times; }
    @JsonProperty("times")
    public void setTimes(Time[] value) { this.times = value; }
}