package com.data.netty.tcp;

import com.data.netty.Bean.TcpBean;
import com.data.netty.Util.JedisUtil;
import com.fasterxml.jackson.databind.ObjectMapper;
import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelId;
import io.netty.channel.ChannelInboundHandlerAdapter;
import io.netty.handler.timeout.IdleState;
import io.netty.handler.timeout.IdleStateEvent;
import io.netty.util.CharsetUtil;
import lombok.extern.slf4j.Slf4j;
import org.json.JSONObject;
import org.springframework.stereotype.Service;

import java.net.InetSocketAddress;
import java.util.concurrent.ConcurrentHashMap;

@Slf4j
@Service
public class NettyTcpServerHandler extends ChannelInboundHandlerAdapter {

    private ChannelId idClient;
    /**
     * 管理一个全局map，保存.连接进服务端的通道数量
     */
    public static final ConcurrentHashMap<ChannelId, ChannelHandlerContext> CHANNEL_MAP = new ConcurrentHashMap<>();
    public static final ConcurrentHashMap<ChannelId, ChannelHandlerContext> CHANNEL_MAP_client = new ConcurrentHashMap<>();

    /**
     * @param ctx
     * @author xiongchuan on 2019/4/28 16:10
     * @DESCRIPTION: 有客户端连接服务器会触发此函数
     * @return: void
     */
    @Override
    public void channelActive(ChannelHandlerContext ctx) {
        InetSocketAddress insocket = (InetSocketAddress) ctx.channel().remoteAddress();
        String clientIp = insocket.getAddress().getHostAddress();
        int clientPort = insocket.getPort();
        ChannelId id = ctx.channel().id();
        //如果map中不包含此连接，就保存连接
        if (CHANNEL_MAP.containsKey(id)) {
            log.info("客户端【" + id + "】是连接状态，连接通道数量: " + CHANNEL_MAP.size());
        } else {
            //保存连接
            CHANNEL_MAP.put(id, ctx);
            log.info("客户端【" + id + "】连接netty服务器[IP:" + clientIp + "--->PORT:" + clientPort + "]");
            log.info("连接通道数量: " + "用户端===>>" + CHANNEL_MAP.size() + "   客户端===>>" + CHANNEL_MAP_client.size());
        }
    }

    /**
     * @param ctx
     * @author xiongchuan on 2019/4/28 16:10
     * @DESCRIPTION: 有客户端终止连接服务器会触发此函数
     * @return: void
     */
    @Override
    public void channelInactive(ChannelHandlerContext ctx) {

        InetSocketAddress insocket = (InetSocketAddress) ctx.channel().remoteAddress();

        String clientIp = insocket.getAddress().getHostAddress();

        ChannelId channelId = ctx.channel().id();

        //包含此客户端才去删除
        if (CHANNEL_MAP_client.containsKey(channelId)) {
            //删除连接
            CHANNEL_MAP_client.remove(channelId);
        }
        if (CHANNEL_MAP.containsKey(channelId)) {
            //删除连接
            CHANNEL_MAP.remove(channelId);
        }
        log.info("客户端【" + channelId + "】退出netty服务器[IP:" + clientIp + "--->PORT:" + insocket.getPort() + "]");
        log.info("连接通道数量: " + "用户端===>>" + CHANNEL_MAP.size() + "   客户端===>>" + CHANNEL_MAP_client.size());
    }

    /**
     * @param ctx
     * @author xiongchuan on 2019/4/28 16:10
     * @DESCRIPTION: 有客户端发消息会触发此函数
     * @return: void
     */
    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) {
        String str = (String) msg;
        System.out.println("收到消息：" + str);
        try {
            if (str.startsWith("ping")) {
                System.out.println("收到心跳包");
                this.channelWrite("pong" + str.replace("ping", ""));
                return;
            }
            System.out.println("收到消息：" + str);
            System.out.println(str);
            ObjectMapper objectMapper = new ObjectMapper();
            TcpBean tcpBean = objectMapper.readValue(str, TcpBean.class);
            if (tcpBean.getUserTime().equals("00000")) {
                this.idClient = ctx.channel().id();
                if (!CHANNEL_MAP_client.isEmpty()) {
                    CHANNEL_MAP_client.clear();
                }
                CHANNEL_MAP_client.put(ctx.channel().id(), ctx);
                System.out.println("客户端连接成功");
                this.channelWrite("{\"msg\":\"连接成功！\"}");
                return;
            }
            if (CHANNEL_MAP_client.isEmpty()) {
                System.out.println("客户端异常为空");
                JSONObject jsonObj = new JSONObject(tcpBean.getData());
                String usertime = jsonObj.getString("userTime");
                System.out.println(usertime);
                JedisUtil instance = JedisUtil.getInstance();
                instance.del(usertime);
                instance.set(usertime, "{\"Code\":-1,\"Msg\":\"客户端异常\",\"Data\":null}", 3600);
                return;
            }
            if (tcpBean.getUserTime().equals("op")) {
                this.channelWrite(tcpBean.getData());
                return;
            }
            JedisUtil instance = JedisUtil.getInstance();
            if (tcpBean.getUserTime().contains("token")) {
                instance.set(tcpBean.getUserTime(), tcpBean.getData(), 3600);
                return;
            }
            instance.del(tcpBean.getUserTime());
            JSONObject jsonObject = new JSONObject(tcpBean.getData());
            String data = jsonObject.toString();
            instance.set(tcpBean.getUserTime(), data, 3600);
            if (this.CHANNEL_MAP_client.size() > 1) {
                System.out.println("客户端异常！系统重连终...");
                this.channelWrite("error,ReConnect");
                this.CHANNEL_MAP_client.clear();
            }
        } catch (Exception e) {
            System.out.println(e.toString());
        }
    }

    /**
     * @param msg 消息转发
     * @author xiongchuan on 2019/4/28 16:10
     * @DESCRIPTION: 服务端给客户端发送消息
     * @return: void
     */
    public void channelWrite(String msg) throws Exception {
        if (CHANNEL_MAP_client.isEmpty()) {
            log.info("客户端异常！请联系管理员");
            return;
        }
        CHANNEL_MAP_client.forEach((k, v) -> {
            this.idClient = k;
        });
        ChannelHandlerContext ctx = CHANNEL_MAP_client.get(this.idClient);
        System.out.println(msg);
        String m = msg;
        byte[] bytes = null;
        if (m != null) {
            bytes = m.getBytes(CharsetUtil.UTF_8);
        }
        ByteBuf buf = Unpooled.wrappedBuffer(bytes);
        ctx.writeAndFlush(buf);
    }

    @Override
    public void userEventTriggered(ChannelHandlerContext ctx, Object evt) throws Exception {

        String socketString = ctx.channel().remoteAddress().toString();

        if (evt instanceof IdleStateEvent) {
            IdleStateEvent event = (IdleStateEvent) evt;
            if (event.state() == IdleState.READER_IDLE) {
                log.info("Client: " + socketString + " READER_IDLE 读超时");
                ctx.disconnect();
            } else if (event.state() == IdleState.WRITER_IDLE) {
                log.info("Client: " + socketString + " WRITER_IDLE 写超时");
                ctx.disconnect();
            } else if (event.state() == IdleState.ALL_IDLE) {
                log.info("Client: " + socketString + " ALL_IDLE 总超时");
                ctx.disconnect();
            }
        }
    }

    /**
     * @param ctx
     * @author xiongchuan on 2019/4/28 16:10
     * @DESCRIPTION: 发生异常会触发此函数
     * @return: void
     */
    @Override
    public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause) throws Exception {

        System.out.println();
        ctx.close();
        if (CHANNEL_MAP_client.containsKey(ctx.channel().id())) {
            CHANNEL_MAP_client.clear();
        }
        if (CHANNEL_MAP.containsKey(ctx.channel().id())) {
            CHANNEL_MAP.remove(ctx.channel().id());
        }
        log.info(ctx.channel().id() + " 发生了错误,此连接被关闭");
        log.info("连接通道数量: " + "用户端===>>" + CHANNEL_MAP.size() + "   客户端===>>" + CHANNEL_MAP_client.size());

    }
}
