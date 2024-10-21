package com.data.netty.Bean;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Data {
    @JsonProperty("DeptName")
    private String deptName;
    @JsonProperty("Email")
    private Object email;
    @JsonProperty("FlagName")
    private String flagName;
    @JsonProperty("Id")
    private String id;
    @JsonProperty("Mobile")
    private Object mobile;
    @JsonProperty("Name")
    private String name;

    public String getRoleName() {
        return roleName;
    }

    public void setRoleName(String roleName) {
        this.roleName = roleName;
    }

    public String getDeptName() {
        return deptName;
    }

    public void setDeptName(String deptName) {
        this.deptName = deptName;
    }

    public Object getEmail() {
        return email;
    }

    public void setEmail(Object email) {
        this.email = email;
    }

    public String getFlagName() {
        return flagName;
    }

    public void setFlagName(String flagName) {
        this.flagName = flagName;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Object getMobile() {
        return mobile;
    }

    public void setMobile(Object mobile) {
        this.mobile = mobile;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @JsonProperty("RoleName")
    private String roleName;
}