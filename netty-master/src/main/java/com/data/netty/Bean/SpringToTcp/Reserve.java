package com.data.netty.Bean.SpringToTcp;

public class Reserve {

    private String Op="Confirm" ;
    private String Username ;
    private String Password ;
    private String seg;
    private String area ;
    private String Token ;
    private String UserTime ;

    public String getUserTime() {
        return UserTime;
    }

    public void setUserTime(String userTime) {
        UserTime = userTime;
    }

    public String getOp() {
        return Op;
    }

    public void setOp(String op) {
        Op = op;
    }

    public String getUsername() {
        return Username;
    }

    public void setUsername(String username) {
        Username = username;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
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

    public String getToken() {
        return Token;
    }

    public void setToken(String token) {
        Token = token;
    }
}
