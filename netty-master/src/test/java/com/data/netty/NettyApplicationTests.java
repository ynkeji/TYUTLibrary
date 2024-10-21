package com.data.netty;

import com.data.netty.Util.JedisUtil;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.data.redis.core.ValueOperations;

@Slf4j
@SpringBootTest
class NettyApplicationTests {


        @Autowired
        private StringRedisTemplate redisTemplate;

        @Test
        void test01() {
            System.out.println("44444444444444444444");
//            ValueOperations<String, String> opsForValue = redisTemplate.opsForValue();
//            //查询key
//            String value1 = opsForValue.get("test-key");
//            System.out.println("写入前值为："+value1);
//            opsForValue.set("test-key","123456");
//            String value2 = opsForValue.get("test-key");
//            System.out.println("写入后值为："+value2);
            JedisUtil instance = JedisUtil.getInstance();
            instance.set("key","测试一下",30);
            System.out.println(instance.get("key"));

        }

    }


