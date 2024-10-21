package com.data.netty.Bean;

import com.fasterxml.jackson.annotation.JsonProperty;

public class UserData {
     public long getCode() {
          return code;
     }

     public void setCode(long code) {
          this.code = code;
     }

     public String getMsg() {
          return Msg;
     }

     public void setMsg(String msg) {
          Msg = msg;
     }

     public Data getData() {
          return data;
     }

     public void setData(Data data) {
          this.data = data;
     }

     @JsonProperty("Code")
     private long code;
     @JsonProperty("Data")
     private Data data;

     @JsonProperty("Msg")
     private String Msg;

}
