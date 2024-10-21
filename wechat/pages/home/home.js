import {request} from '../../utils/util';
import {SubscribeApi} from '../../utils/SubscribeApi';

Page({
    data: {
        properties: {
            //可移动的方向
            direction: {
                type: String,
                value: 'all'
            },
            //按钮的icon
            button_img: {
                type: String,
                value: '/static/wodekaquan.png'
            },
            //按钮图片的宽度，单位rpx
            button_img_width: {
                type: Number,
                value: 150
            },
            //按钮图片的高度，单位rpx
            button_img_height: {
                type: Number,
                value: 150
            },
            //移动按钮的初始x轴坐标
            btn_x: {
                type: String,
                value: '580rpx'
            },
            //移动按钮的初始y轴坐标
            btn_y: {
                type: String,
                value: '750rpx'
            }
        },
        current: 0,
        visible: true,
        autoplay: true,
        duration: 500,
        interval: 5000,

        //预约状态框
        notice: false,
        reserve: true,
        common: true,
        area: '',
        statusName: '',
        showTime:'',
        flag_leave: false,
        flag_msg2: true,
        msg2: '',
        //预约状态框-button-txt
        button1: '签到',
        button2: '取消预约',


        swiperList: [
            "https://img2.imgtp.com/2024/05/15/4UBZqA5G.jpg",
            "https://img2.imgtp.com/2024/05/15/4UBZqA5G.jpg",
            "https://img2.imgtp.com/2024/05/15/4UBZqA5G.jpg"
        ],
        icon_seat: "https://img2.imgtp.com/2024/05/15/ZkajuQJr.png",
        icon_ofen: "https://img2.imgtp.com/2024/05/15/g4NP83SY.png",
        icon_notice: "https://img2.imgtp.com/2024/05/15/kFSdK0Cy.png",
        value: 'label_1',
        list: [
            {value: 'label_1', icon: 'home', ariaLabel: '首页'},
            {value: 'label_4', icon: 'user', ariaLabel: '我的'},
        ],
        content: []
    },

    onChange(e) {
        console.log('onChange', e)
        this.setData({
            current: e.detail.key,
        })
    },


    onTap(e) {
        wx.redirectTo({
            url: '/pages/Seat/Seat',
        })
    },

    onImageLoad(e) {
        console.log(e.detail.index);
    },

    onShow(e) {
        let that = this
        var date = Date.parse(new Date())
        wx.getStorage({
            key: 'user',
            success(res) {
                SubscribeApi(res.data.Id)
                    .then(r => {
                        console.log("subscribe")
                        console.log(r)
                        if (r.data.length === 0) {
                            console.log("没有预约")
                            that.setData({
                                notice: false,
                                reserve: true
                            })
                        }
                        if (r.data.length !== 0) {
                            if (r.data[0].flag_leave === 1){
                                that.setData({
                                    button1: "返回签到",
                                    button2: "完全预约",
                                    flag_msg2: false,
                                    msg2: r.data[0].needBackTime,
                                })
                            }
                            if (r.data[0].flag_out === 1){
                                that.setData({
                                    button1: "临时离开",
                                    button2: "完全离开",
                                    flag_leave: true
                                })
                            }
                            that.setData({
                                showTime: r.data[0].showTime,
                                statusName: r.data[0].statusName,
                                area: r.data[0].areaName + ": " + r.data[0].spaceName,
                                common: false,
                                notice: true,
                                reserve: false
                            })
                        }
                    })
                    .catch(err => {
                        console.log(err)
                    })
            },
            fail(res) {
                wx.redirectTo({
                    url: '/pages/login/login',
                })
            }

        })
    },

    //页面加载执行
    onLoad(options) {


    },

    //取当前预约轮询函数
    subscribe(d) {
        let that = this
        request({
            url: 'subscribe_?userTime=' + d,
            data: {},
            method: 'GET',
        }).then(res => {
            console.log(res)
            if (res.msg === "操作成功") {
                var t = ["你的预约是："]
                if (res.data.length === 0) {
                    console.log("没有预约")
                    return;
                }
                t.push(res.data.data)
                that.setData({
                    content: t
                })
            }
            if (res.code === 404 || res.code === 300) {
                wx.showLoading({
                    title: 'ERROR',
                    duration: 1000
                })
            }
            if (res.code === 500) {
                that.subscribe(d)
            }
        }).catch(err => {
            console.log(err)
        })
    },
})



