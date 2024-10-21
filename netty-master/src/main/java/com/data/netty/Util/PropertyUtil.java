package com.data.netty.Util;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

/**
 * 属性文件加载工具类
 * @author xdy
 */
public class PropertyUtil {

    //加载property文件到io流里面
    public static Properties loadProperties(String propertyFile) {
        Properties properties = new Properties();
        try {
            InputStream is = PropertyUtil.class.getClassLoader().getResourceAsStream(propertyFile);
            if(is == null){
                is = PropertyUtil.class.getClassLoader().getResourceAsStream("properties/" + propertyFile);
            }
            properties.load(is);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return properties;
    }
}
