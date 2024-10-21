package com.data.netty.Dao;

import com.data.netty.Bean.MysqlBean.UserBean;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;
import org.apache.ibatis.annotations.Update;
import org.mapstruct.Mapper;
import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

@Mapper
public interface User {
   //用户登录
    @Select("select username,password,name from User where username = #{username}")
    UserBean getUser(String username);
    @Update("update User set password = #{password} and name = #{name} where username = #{username}")
    void UpdataUser(String username, String password,String name);
    @Insert("insert into User(username,password,name) values(#{username},#{password})")
    void insertUser(String username, String password, String name);
    @Insert("insert into wxLogin(openid,userID) values(#{openid},#{userID})")
    //微信登录
    void insertWxLogin(String openid, String userID);
    @Select("select userID from wxLogin where openid = #{openid}")
    String getUserID(String openid);
    @Update("update wxLogin set userID = #{userID} where openid = #{openid}")
    void updateUserID(String openid, String userID);
}
