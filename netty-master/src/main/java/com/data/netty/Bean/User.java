package com.data.netty.Bean;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

@Component
@ConfigurationProperties(prefix = "user")
public class User {
    private User phy;
    public void SetUser(User phy) {
        this.phy = phy;
    }
}
