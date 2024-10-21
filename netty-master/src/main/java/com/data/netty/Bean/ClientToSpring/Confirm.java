package com.data.netty.Bean.ClientToSpring;

public class Confirm {
    private String Username ;
    private String seg;
    private String area ;
    private String UserTime ;




    public String getUserTime() {
        return UserTime;
    }
    public void setUserTime(String userTime) {
        UserTime = userTime;
    }

    public String getUsername() {
        return Username;
    }

    public void setUsername(String username) {
        Username = username;
    }


    public String getSeg() {
        return seg;
    }

    public void setSeg(String seg) {
        this.seg = seg;
    }

    public String getArea() {
        return area;
    }

    public void setArea(String area) {
        this.area = area;
    }
}
