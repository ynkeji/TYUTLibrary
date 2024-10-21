// pages/Seat/Seat.js
import promise, {request} from "../../utils/util";
Page({

    /**
     * 页面的初始数据
     */
    data: {
        day: [{time: "", title: "今天", floor: []}, {time: "", title: "明天", floor: []}],
        t: 0,
        selectedAreaIndex: 0,
        selectedFloorIndex: 0,
        selectedDayIndex: 0,
    },

    handleDayTap(e) {
        console.log(e);
        this.setData({
            selectedDayIndex: e.currentTarget.dataset.index,
        });
        if (this.data.day[this.data.selectedDayIndex].title === "明天") {
            if (this.data.day[1].floor.length === 0) {
                wx.showLoading({  // 显示加载中loading效果
                    title: "加载中",
                    mask: true  //开启蒙版遮罩
                });
                var day2 = new Date();
                day2.setTime(day2.getTime() + 24 * 60 * 60 * 1000);
                var s2 = day2.getFullYear() + "-" + (day2.getMonth() + 1) + "-" + day2.getDate();
                this.quickSelect(s2)
                console.log("s2" + s2)
            }
        }
    },
    handleFloorTap(e) {
        console.log(e);
        this.setData({
            t: e.currentTarget.dataset.index,
            selectedFloorIndex: e.currentTarget.dataset.index,
        });
    },

    handleAreaTap(e) {
        console.log(e);
        this.setData({
            selectedAreaIndex: e.currentTarget.dataset.index,
        });
    },

    choose() {
        var id = this.data.day[this.data.selectedDayIndex].floor[this.data.selectedFloorIndex].area[this.data.selectedAreaIndex].id
        console.log("区域选择：" + this.data.selectedAreaIndex)
        console.log("楼层选择:" + this.data.selectedFloorIndex)
        console.log(this.data.day)
        wx.navigateTo({
            url: '/pages/choose/choose?id=' + id+'&floor=' + this.data.day[this.data.selectedDayIndex].floor[this.data.selectedFloorIndex].floor + '&area=' + this.data.day[this.data.selectedDayIndex].floor[this.data.selectedFloorIndex].area[this.data.selectedAreaIndex].name,
        })
        console.log("aaa")
    },

    /**
     * 生命周期函数--监听页面加载
     */
    onLoad(options) {

    }
    ,

    /**
     * 生命周期函数--监听页面初次渲染完成
     */
    onReady() {
        wx.showLoading({  // 显示加载中loading效果
            title: "加载中",
            mask: true  //开启蒙版遮罩
        });
        var newDateTime =new Date(Date.parse(new Date())+ 60*60*1000*8).toISOString().substring(0,10)
        console.log(newDateTime)
        this.quickSelect(newDateTime)
    },
    quickSelect(data) {
        let that = this
        wx.getStorage({
            key: "user",
            success(res) {
                var t = Date.parse(new Date())
                console.log(res)
                request({
                    url: 'quickSelect',
                    data: {
                        username: res.data.Id,
                        userTime: t,
                        time: data
                    },
                }).then(res => {
                    console.log(res)
                    that.quickSelect_(t, data)
                })
            }
        })
    },
    quickSelect_(newDateTime, data) {
        let that = this
        request({
            url: 'quick?userTime=' + newDateTime,
            method: 'GET'
        }).then(res => {
            console.log(res)
            if (res.code === 0) {
                var days = res.data.date
                var floor = res.data.storey
                var area = res.data.area
                console.log("days=>" + days, "floor=>" + floor, "area=>" + area)
                var f = []
                var d = []
                floor.forEach((item, index) => {
                    var t = []
                    area.forEach((item1, index1) => {
                        if (item1.parentId === item.id) {
                            t.push({name: item1.name, free_num: item1.free_num, id: item1.id})
                        }
                    })
                    f.push({floor: item.name, free: item.free_num, area: t})
                })
                if (days[0] === data) {
                    d.push({time: days[0], title: "今天", floor: f})
                    d.push({time: days[1], title: "明天", floor: that.data.day[1].floor})
                } else {
                    d.push({time: days[0], title: "今天", floor: that.data.day[0].floor})
                    d.push({time: days[1], title: "明天", floor: f})
                }
                wx.hideLoading();
                that.setData({
                    day: d,
                })
                return
            }
            if (res.statusCode === 500) {
                that.getInfor(newDateTime)
            }
            if (res.statusCode === 500) {
                that.getInfor(newDateTime)
            }
        })
    },

    /**
     * 生命周期函数--监听页面显示
     */
    onShow() {

    }
    ,

    /**
     * 生命周期函数--监听页面隐藏
     */
    onHide() {

    }
    ,

    /**
     * 生命周期函数--监听页面卸载
     */
    onUnload() {

    }
    ,

    /**
     * 页面相关事件处理函数--监听用户下拉动作
     */
    onPullDownRefresh() {

    }
    ,

    /**
     * 页面上拉触底事件的处理函数
     */
    onReachBottom() {

    }
    ,

    /**
     * 用户点击右上角分享
     */
    onShareAppMessage() {

    }
})
