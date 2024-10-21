package com.data.netty.Bean.ClientToSpring;

public class Login
{
    private String password;
    private String userTime;
    private String username;
    public String getSign() {
        return sign;
    }

    public void setSign(String sign) {
        this.sign = sign;
    }

    private String sign;
    public String getPassword() { return password; }
    public void setPassword(String value) { this.password = value; }

    public String getUserTime() { return userTime; }
    public void setUserTime(String value) { this.userTime = value; }

    public String getUsername() { return username; }
    public void setUsername(String value) { this.username = value; }
}
