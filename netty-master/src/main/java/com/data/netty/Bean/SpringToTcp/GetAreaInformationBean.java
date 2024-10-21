package com.data.netty.Bean.SpringToTcp;

public class GetAreaInformationBean {

    private String op = "GetAreaInformation";
    private String password;
    private String token;
    private String userTime;
    private String username;
    private String Time;

    public String getOp() { return op; }
    public void setOp(String value) { this.op = value; }

    public String getPassword() { return password; }
    public void setPassword(String value) { this.password = value; }

    public String getToken() { return token; }
    public void setToken(String value) { this.token = value; }

    public String getUserTime() { return userTime; }
    public void setUserTime(String value) { this.userTime = value; }

    public String getUsername() { return username; }
    public void setUsername(String value) { this.username = value; }

    public String getTime() {return Time;}

    public void setTime(String time) {Time = time;}

}
