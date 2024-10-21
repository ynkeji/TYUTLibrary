package com.data.netty.Bean.TcpToSpring.QuickSelect;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Premises {
    private String enname;
    private String ennameMerge;
    private Long freeNum;
    private String id;
    private String name;
    private String nameMerge;
    private Long parentId;
    private String sort;
    private String topId;
    private Long totalNum;
    private Long typeCategory;

    @JsonProperty("enname")
    public String getEnname() { return enname; }
    @JsonProperty("enname")
    public void setEnname(String value) { this.enname = value; }

    @JsonProperty("ennameMerge")
    public String getEnnameMerge() { return ennameMerge; }
    @JsonProperty("ennameMerge")
    public void setEnnameMerge(String value) { this.ennameMerge = value; }

    @JsonProperty("free_num")
    public Long getFreeNum() { return freeNum; }
    @JsonProperty("free_num")
    public void setFreeNum(Long value) { this.freeNum = value; }

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
    public Long getParentId() { return parentId; }
    @JsonProperty("parentId")
    public void setParentId(Long value) { this.parentId = value; }

    @JsonProperty("sort")
    public String getSort() { return sort; }
    @JsonProperty("sort")
    public void setSort(String value) { this.sort = value; }

    @JsonProperty("topId")
    public String getTopId() { return topId; }
    @JsonProperty("topId")
    public void setTopId(String value) { this.topId = value; }

    @JsonProperty("total_num")
    public Long getTotalNum() { return totalNum; }
    @JsonProperty("total_num")
    public void setTotalNum(Long value) { this.totalNum = value; }

    @JsonProperty("typeCategory")
    public Long getTypeCategory() { return typeCategory; }
    @JsonProperty("typeCategory")
    public void setTypeCategory(Long value) { this.typeCategory = value; }
}