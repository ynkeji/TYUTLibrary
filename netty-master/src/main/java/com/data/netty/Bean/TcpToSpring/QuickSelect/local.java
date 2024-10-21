package com.data.netty.Bean.TcpToSpring.QuickSelect;

import com.fasterxml.jackson.annotation.*;

public class local {
    private Area[] area;
    private String[] date;
    private Premises[] premises;
    private Storey[] storey;

    @JsonProperty("area")
    public Area[] getArea() { return area; }
    @JsonProperty("area")
    public void setArea(Area[] value) { this.area = value; }

    @JsonProperty("date")
    public String[] getDate() { return date; }
    @JsonProperty("date")
    public void setDate(String[] value) { this.date = value; }

    @JsonProperty("premises")
    public Premises[] getPremises() { return premises; }
    @JsonProperty("premises")
    public void setPremises(Premises[] value) { this.premises = value; }

    @JsonProperty("storey")
    public Storey[] getStorey() { return storey; }
    @JsonProperty("storey")
    public void setStorey(Storey[] value) { this.storey = value; }
}