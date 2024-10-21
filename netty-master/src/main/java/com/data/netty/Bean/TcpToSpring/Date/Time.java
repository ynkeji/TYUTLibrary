package com.data.netty.Bean.TcpToSpring.Date;

import com.fasterxml.jackson.annotation.*;

public class Time {
    private String end;
    private String id;
    private String start;
    private long status;

    @JsonProperty("end")
    public String getEnd() { return end; }
    @JsonProperty("end")
    public void setEnd(String value) { this.end = value; }

    @JsonProperty("id")
    public String getid() { return id; }
    @JsonProperty("id")
    public void setid(String value) { this.id = value; }

    @JsonProperty("start")
    public String getStart() { return start; }
    @JsonProperty("start")
    public void setStart(String value) { this.start = value; }

    @JsonProperty("status")
    public long getStatus() { return status; }
    @JsonProperty("status")
    public void setStatus(long value) { this.status = value; }
}
