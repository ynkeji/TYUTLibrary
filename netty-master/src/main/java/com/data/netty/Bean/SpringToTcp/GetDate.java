package com.data.netty.Bean.SpringToTcp;

public class GetDate {

    private String Op="GetDate";
    private String Password;

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public String getUserTime() {
        return UserTime;
    }

    public void setUserTime(String userTime) {
        UserTime = userTime;
    }

    public String getToken() {
        return Token;
    }

    public void setToken(String token) {
        Token = token;
    }

    public String getUsername() {
        return Username;
    }

    public void setUsername(String username) {
        Username = username;
    }

    public String getBuild() {
        return build;
    }

    public void setBuild(String build) {
        this.build = build;
    }

    public String getOp() {
        return Op;
    }

    public void setOp(String op) {
        Op = op;
    }

    private String Token;
    private String UserTime;
    private String Username;
    private String build;
}
