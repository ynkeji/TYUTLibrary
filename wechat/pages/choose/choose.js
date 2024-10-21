Page({
    data: {
        //座位列表未处理
        seatList: [],
        //座位列表已处理
        seat: [],
        //座位样式
        style: [],
        //该楼层的座位背景
        floorImg:"",
        floor: "",
        area: "",
        day: [],
        SelelctSeatIndex: 0,
        selectedTimeIndex: 0,
        selectedDayIndex: 0,
        build: "",
        handleSeatTap: "",
        //列表模式
        patternList:true,
        //地图模式
        patternMap:false,
        seatId:"",
        t: -1,
    },

    handleSeatTap(e) {
        this.setData({
            SelectSeatIndex: e.currentTarget.dataset.index,
            current: this.data.seatList[e.currentTarget.dataset.index].name,
            seatId: this.data.seatList[e.currentTarget.dataset.index].id
        });

    },

    handleDayTap(e) {
        console.log(this.data.day)
        this.setData({
            selectedDayIndex: e.currentTarget.dataset.index,
        });
        if (this.data.day[this.data.selectedDayIndex].times.length == 1){
            if (this.data.day[this.data.selectedDayIndex].times[0].start == this.data.day[this.data.selectedDayIndex].times[0].end) {
                this.setData({
                    seatList: []
                })
                return
            }
            this.setData({
                selectedTimeIndex: 0
            })
            this.getSeat()
        }
        if (this.data.day[this.data.selectedDayIndex].times.length == 2){
            this.setData({
                selectedTimeIndex: 1
            })
            this.getSeat()
        }
    },
    handleTimeTap(e) {
        if (this.data.day[this.data.selectedDayIndex].times[e.currentTarget.dataset.index].start == this.data.day[this.data.selectedDayIndex].times[e.currentTarget.dataset.index].end) {
            this.setData({
                seatList: []
            })
            wx.showLoading({
                title: '该时间段禁止预约',
                mask: true,
                duration: 2000
            })
            return
        }
        console.log(e)
        this.setData({
            selectedTimeIndex: e.currentTarget.dataset.index,
        });
        this.getSeat()
    },

    confirm() {
        console.log(this.data.seatId,)
        wx.getStorage({
            key: 'user',
            success: (res) => {
                var username = res.data.Id
                var t = Date.parse(new Date())
                wx.request({
                    url: 'https://netty.fak588.cn/Confirm',
                    method: 'POST',
                    data: {
                        username: username,
                        userTime: t,
                        area: this.data.seatId,
                        seg: this.data.day[this.data.selectedDayIndex].times[this.data.selectedTimeIndex].id,
                    },
                    success: (res) => {
                        if (res.data.code === 200) {
                            console.log(res)
                            this.confirm_(t)
                        } else {
                            wx.hideLoading()
                        }
                    }
                })
            }
        })
    },
    ///预约函数
    confirm_(t) {
        let that = this
        wx.request({
            url: 'https://netty.fak588.cn/Confirm_?userTime=' + t,
            method: 'GET',
            success: (res) => {
                if (res.data.code === 404) {
                    wx.hideLoading()
                    wx.showLoading({
                        title: '加载失败',
                        mask: true,
                        duration: 2000

                    })
                    return
                }
                if (res.data.code == 300) {
                    return
                }
                if (res.data.code == 500) {
                    that.confirm_(t)
                }
                if (res.data.code == 1) {
                    wx.hideLoading()
                    wx.showLoading({
                        title: res.data.msg + res.data.data.areaName,
                        mask: true,
                        duration: 2000
                    })
                }
            }
        })
    },

    ///窗口ready回调函数
    onReady(e) {

    },

    ///窗口加载回调函数
    onLoad(options) {
        console.log(options)
        wx.showLoading({
            title: '加载中',
            mask: true
        })
        this.setData({
            floor: options.floor,
            area: options.area,
            build: options.id
        })
        this.getDate(options.id)

    },

    ///获取日期
    getDate(id) {
        wx.getStorage({
            key: 'user',
            success: (res) => {
                var username = res.data.Id
                var t = Date.parse(new Date())
                wx.request({
                    // url: 'https://netty.fak588.cn/GetDate',
                    url: 'https://netty.fak588.cn/GetDate',
                    method: 'POST',
                    data: {
                        username: username,
                        userTime: t,
                        build: id
                    },
                    success: (res) => {
                        if (res.data.code == 200) {
                            this.getInfor(t)
                        } else {
                            wx.hideLoading()
                        }
                    }
                })
            }
        })
    },

    ///获取日期轮询函数
    getInfor(time) {
        let that = this
        wx.request({
            url: 'https://netty.fak588.cn/GetDate_?userTime=' + time,
            method: 'GET',
            success: (res) => {
                if (res.data.code == 404) {
                    wx.hideLoading()
                    wx.showLoading({
                        title: '加载失败',
                        mask: true,
                        duration: 2000
                    })
                    return
                }
                if (res.data.code == 300) {
                    return
                }
                if (res.data.code == 500) {
                    that.getInfor(time)
                }
                if (res.data.code == 1) {
                    var data = res.data.data
                    var t = []
                    var m = []
                    console.log("data输出")
                    console.log(data)
                    data.forEach((item, index) => {
                        t.push({
                            date: item.day,
                            times: item.times
                        })

                    })
                    that.setData({
                        day: t
                    })
                    wx.hideLoading()
                    that.getSeat()
                }
            }
        })
    },

    //获取座位信息
    getSeat() {
        let that = this
        wx.showLoading({
            title: '座位列表加载中',
            mask: true
        })
        wx.getStorage({
            key: 'user',
            success: (res) => {
                console.log("aaa")
                var username = res.data.Id
                var t = Date.parse(new Date())
                console.log(that.data.day)
                if (this.data.day[this.data.selectedDayIndex].times[this.data.selectedTimeIndex].start == this.data.day[this.data.selectedDayIndex].times[this.data.selectedTimeIndex].end) {
                    wx.hideLoading()
                    wx.showLoading({
                        title: '该时间段禁止预约',
                        mask: true,
                        duration: 2000
                    })
                    return
                }
                wx.request({
                    url: 'https://netty.fak588.cn/GetSeat',
                    // url: 'http://127.0.0.1:8080/GetSeat',
                    method: 'POST',
                    data: {
                        username: username,
                        userTime: t,
                        seg: this.data.day[this.data.selectedDayIndex].times[this.data.selectedTimeIndex].id,
                        endTime: this.data.day[this.data.selectedDayIndex].times[this.data.selectedTimeIndex].end,
                        startTime: this.data.day[this.data.selectedDayIndex].times[this.data.selectedTimeIndex].start,
                        area: this.data.build,
                        day: this.data.day[this.data.selectedDayIndex].date
                    },
                    success: (res) => {
                        if (res.data.code == 200) {
                            that.getSeat_(t)
                        } else {
                            wx.hideLoading()
                        }
                    }
                })
            }
        })
    },
    //获取座位轮询函数
    getSeat_(time) {
        let that = this
        wx.request({
            url: 'https://netty.fak588.cn/GetSeat_?userTime=' + time,
            // url: 'http://127.0.0.1:8080/GetSeat_?userTime=' + time,
            method: 'GET',
            success: (res) => {
                if (res.data.code == 404) {
                    wx.hideLoading()
                    wx.showLoading({
                        title: '加载失败',
                        mask: true,
                        duration: 2000

                    })
                    return
                }
                if (res.data.code == 300) {
                    return
                }
                if (res.data.code == 500) {
                    this.getSeat_(time)
                }
                if (res.data.code == 1) {
                    console.log(res.data.data)
                    //设置背景
                    that.setData({
                        floorImg: "https://image.fak588.cn/" + that.data.build + "/free.jpg"
                    })
                    var data = res.data.data
                    var t = []
                    //有逻辑问题

                    data.forEach((item, index) => {
                        t.push({
                            id: item.id,
                            name: item.name,
                            point_x: item.point_x,
                            point_y: item.point_y,
                            width: item.width,
                            height: item.height,
                            status_name: item.status_name,
                            status: item.status,
                        })
                    })
                    that.setData({
                        seatList:t
                    })
                    that.setUse()
                    wx.hideLoading()
                }
            }
        })
    },

    setUse(){
        let that = this
        var list = this.data.seatList
        console.log("输出list")
        console.log(list)
        var seat = []
        const query = wx.createSelectorQuery();
        query.select('.background').boundingClientRect(function (res) {
            console.log(res)
            list.forEach((item, index) => {
                var style =
                    "background-image:url(https://image.fak588.cn/" + that.data.build + "/" + that.getStatus(item.status) + ".jpg);" +
                    "height:" + parseFloat(item.height) * res.height / 100 + "px;" +
                    "width:" + parseFloat(item.width) * res.width / 100 + "px;" +
                    "left:" + parseFloat(item.point_x) * res.width / 100 + "px;" +
                    "top:" + item.point_y * res.height / 100 + "px;" +
                    "background-position:-" + parseFloat(item.point_x) * res.width / 100 + "px -" + (parseFloat(item.point_y)) * res.height / 100 + "px;"+
                    "background-size:" + res.width + "px"
                // console.log(style)
                seat.push({
                    name: item.name,
                    id: item.id,
                    style: style
                })
            })
            that.setData({
                style: seat
            })

        }).exec(function(rect){
            console.log(rect[0])
            // rect返回一个数组，需要使用下标0才能找到
            // console.log(s[0].height)
        });
    },

    load(e){
      this.setData({
          current: e.currentTarget.dataset.name,
          seatId: e.currentTarget.dataset.id
      })
    },
    pattern(e){
        console.log(e.target.dataset.value)
        if (e.target.dataset.value == "1"){
            this.setData({
                patternList: true,
                patternMap: false
            })
        }
        else if(e.target.dataset.value == "2"){
            this.setData({
                patternList: false,
                patternMap: true
            })
        }
    },
    getStatus(id){
        console.log(id)
        switch (id) {
            case "1":
                return "free"
            case "7":
                return "leave"
            case "2":
                return "book"
            case "10":
                return "book"
            case "11":
                return "book"
            case "6":
                return "use"
            case "8":
                return "use"
            case "9":
                return "use"
            case "3":
                return "close"
            case "4":
                return "close"
            case "5":
                return "close"
        }
    }
})
