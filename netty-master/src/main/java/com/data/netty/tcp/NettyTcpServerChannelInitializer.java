package com.data.netty.tcp;

import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelInitializer;
import io.netty.channel.socket.SocketChannel;
import io.netty.handler.codec.DelimiterBasedFrameDecoder;
import io.netty.handler.codec.string.StringEncoder;

public class NettyTcpServerChannelInitializer extends ChannelInitializer<SocketChannel> {

    @Override
    protected void initChannel(SocketChannel socketChannel) throws Exception {
        ByteBuf delimiter = Unpooled.copiedBuffer("<END>".getBytes());
        socketChannel.pipeline().addLast(new DelimiterBasedFrameDecoder(124899, delimiter));
        socketChannel.pipeline().addLast("decoder", new MyDecoder());
        socketChannel.pipeline().addLast("encoder", new MyDecoder());
        socketChannel.pipeline().addLast(new StringEncoder());
        socketChannel.pipeline().addLast(new NettyTcpServerHandler());
    }

}
