package com.data.netty.Bean.MysqlBean;

import lombok.Data;
import org.springframework.stereotype.Repository;

@Repository
@Data
public class UserBean {

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    //姓名
    private String name;
    //学号
    private String username;
//    密码
    private String password;

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }


}
