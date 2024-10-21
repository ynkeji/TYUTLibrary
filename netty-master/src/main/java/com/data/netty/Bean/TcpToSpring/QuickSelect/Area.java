package com.data.netty.Bean.TcpToSpring.QuickSelect;

import com.fasterxml.jackson.annotation.*;

public class Area {
    private String enname;
    private String ennameMerge;
    private long freeNum;
    private String id;
    private String name;
    private String nameMerge;
    private String parentId;
    private String thumbImg;
    private String topId;
    private String totalNum;
    private String typeCategory;

    @JsonProperty("enname")
    public String getEnname() { return enname; }
    @JsonProperty("enname")
    public void setEnname(String value) { this.enname = value; }

    @JsonProperty("ennameMerge")
    public String getEnnameMerge() { return ennameMerge; }
    @JsonProperty("ennameMerge")
    public void setEnnameMerge(String value) { this.ennameMerge = value; }

    @JsonProperty("free_num")
    public long getFreeNum() { return freeNum; }
    @JsonProperty("free_num")
    public void setFreeNum(long value) { this.freeNum = value; }

    @JsonProperty("id")
    public String getid() { return id; }
    @JsonProperty("id")
    public void setid(String value) { this.id = value; }

    @JsonProperty("name")
    public String getName() { return name; }
    @JsonProperty("name")
    public void setName(String value) { this.name = value; }

    @JsonProperty("nameMerge")
    public String getNameMerge() { return nameMerge; }
    @JsonProperty("nameMerge")
    public void setNameMerge(String value) { this.nameMerge = value; }

    @JsonProperty("parentId")
    public String getParentId() { return parentId; }
    @JsonProperty("parentId")
    public void setParentId(String value) { this.parentId = value; }

    @JsonProperty("thumb_img")
    public String getThumbImg() { return thumbImg; }
    @JsonProperty("thumb_img")
    public void setThumbImg(String value) { this.thumbImg = value; }

    @JsonProperty("topId")
    public String getTopId() { return topId; }
    @JsonProperty("topId")
    public void setTopId(String value) { this.topId = value; }

    @JsonProperty("total_num")
    public String getTotalNum() { return totalNum; }
    @JsonProperty("total_num")
    public void setTotalNum(String value) { this.totalNum = value; }

    @JsonProperty("typeCategory")
    public String getTypeCategory() { return typeCategory; }
    @JsonProperty("typeCategory")
    public void setTypeCategory(String value) { this.typeCategory = value; }
}