package com.data.netty.tcp;

import io.netty.bootstrap.Bootstrap;
import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.Channel;
import io.netty.channel.ChannelFuture;
import io.netty.channel.EventLoopGroup;
import io.netty.channel.nio.NioEventLoopGroup;
import io.netty.channel.socket.nio.NioSocketChannel;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
@Component
public class NettyClient {

    public void start(String name){
        //启动TCP服务
        EventLoopGroup group = new NioEventLoopGroup();
        try{
            Bootstrap bootstrap = new Bootstrap();
            bootstrap.group(group)
                    .channel(NioSocketChannel.class)
                    .handler(new NettyTcpServerChannelInitializer());
//            ChannelFuture f = bootstrap.connect("10.0.4.7", 5200).sync();
            ChannelFuture f = bootstrap.connect("127.0.0.1", 5200).sync();
            Channel channel = f.channel();
            ByteBuf buf = Unpooled.copiedBuffer(name.getBytes());
            channel.writeAndFlush(buf).addListener(future -> {
                if (future.isSuccess()) {
                    channel.close();
                }
            });

        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } finally {
            group.shutdownGracefully();
        }
    }
}
