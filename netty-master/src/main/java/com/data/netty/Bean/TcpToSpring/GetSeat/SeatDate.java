package com.data.netty.Bean.TcpToSpring.GetSeat;

import com.fasterxml.jackson.annotation.*;

public class SeatDate {
    private String area;
    private Object areaColor;
    private String areaLevels;
    private String areaName;
    private String areaType;
    private String category;
    private String height;
    private String id;
    private long inLabel;
    private String name;
    private String no;
    private String pointX;
    private Object pointX2;
    private Object pointX3;
    private Object pointX4;
    private String pointY;
    private Object pointY2;
    private Object pointY3;
    private Object pointY4;
    private String status;
    private String statusName;
    private String width;

    @JsonProperty("area")
    public String getArea() { return area; }
    @JsonProperty("area")
    public void setArea(String value) { this.area = value; }

    @JsonProperty("area_color")
    public Object getAreaColor() { return areaColor; }
    @JsonProperty("area_color")
    public void setAreaColor(Object value) { this.areaColor = value; }

    @JsonProperty("area_levels")
    public String getAreaLevels() { return areaLevels; }
    @JsonProperty("area_levels")
    public void setAreaLevels(String value) { this.areaLevels = value; }

    @JsonProperty("area_name")
    public String getAreaName() { return areaName; }
    @JsonProperty("area_name")
    public void setAreaName(String value) { this.areaName = value; }

    @JsonProperty("area_type")
    public String getAreaType() { return areaType; }
    @JsonProperty("area_type")
    public void setAreaType(String value) { this.areaType = value; }

    @JsonProperty("category")
    public String getCategory() { return category; }
    @JsonProperty("category")
    public void setCategory(String value) { this.category = value; }

    @JsonProperty("height")
    public String getHeight() { return height; }
    @JsonProperty("height")
    public void setHeight(String value) { this.height = value; }

    @JsonProperty("id")
    public String getid() { return id; }
    @JsonProperty("id")
    public void setid(String value) { this.id = value; }

    @JsonProperty("in_label")
    public long getInLabel() { return inLabel; }
    @JsonProperty("in_label")
    public void setInLabel(long value) { this.inLabel = value; }

    @JsonProperty("name")
    public String getName() { return name; }
    @JsonProperty("name")
    public void setName(String value) { this.name = value; }

    @JsonProperty("no")
    public String getNo() { return no; }
    @JsonProperty("no")
    public void setNo(String value) { this.no = value; }

    @JsonProperty("point_x")
    public String getPointX() { return pointX; }
    @JsonProperty("point_x")
    public void setPointX(String value) { this.pointX = value; }

    @JsonProperty("point_x2")
    public Object getPointX2() { return pointX2; }
    @JsonProperty("point_x2")
    public void setPointX2(Object value) { this.pointX2 = value; }

    @JsonProperty("point_x3")
    public Object getPointX3() { return pointX3; }
    @JsonProperty("point_x3")
    public void setPointX3(Object value) { this.pointX3 = value; }

    @JsonProperty("point_x4")
    public Object getPointX4() { return pointX4; }
    @JsonProperty("point_x4")
    public void setPointX4(Object value) { this.pointX4 = value; }

    @JsonProperty("point_y")
    public String getPointY() { return pointY; }
    @JsonProperty("point_y")
    public void setPointY(String value) { this.pointY = value; }

    @JsonProperty("point_y2")
    public Object getPointY2() { return pointY2; }
    @JsonProperty("point_y2")
    public void setPointY2(Object value) { this.pointY2 = value; }

    @JsonProperty("point_y3")
    public Object getPointY3() { return pointY3; }
    @JsonProperty("point_y3")
    public void setPointY3(Object value) { this.pointY3 = value; }

    @JsonProperty("point_y4")
    public Object getPointY4() { return pointY4; }
    @JsonProperty("point_y4")
    public void setPointY4(Object value) { this.pointY4 = value; }

    @JsonProperty("status")
    public String getStatus() { return status; }
    @JsonProperty("status")
    public void setStatus(String value) { this.status = value; }

    @JsonProperty("status_name")
    public String getStatusName() { return statusName; }
    @JsonProperty("status_name")
    public void setStatusName(String value) { this.statusName = value; }

    @JsonProperty("width")
    public String getWidth() { return width; }
    @JsonProperty("width")
    public void setWidth(String value) { this.width = value; }
}