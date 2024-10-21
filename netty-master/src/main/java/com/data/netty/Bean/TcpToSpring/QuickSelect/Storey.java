package com.data.netty.Bean.TcpToSpring.QuickSelect;

import com.fasterxml.jackson.annotation.*;

public class Storey {
    private String enname;
    private String ennameMerge;
    private long freeNum;
    private String id;
    private String name;
    private String nameMerge;
    private String parentId;
    private String sort;
    private String topId;
    private long totalNum;
    private long typeCategory;

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

    @JsonProperty("sort")
    public String getSort() { return sort; }
    @JsonProperty("sort")
    public void setSort(String value) { this.sort = value; }

    @JsonProperty("topId")
    public String getTopId() { return topId; }
    @JsonProperty("topId")
    public void setTopId(String value) { this.topId = value; }

    @JsonProperty("total_num")
    public long getTotalNum() { return totalNum; }
    @JsonProperty("total_num")
    public void setTotalNum(long value) { this.totalNum = value; }

    @JsonProperty("typeCategory")
    public long getTypeCategory() { return typeCategory; }
    @JsonProperty("typeCategory")
    public void setTypeCategory(long value) { this.typeCategory = value; }
}
