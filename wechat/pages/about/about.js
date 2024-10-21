// pages/about/about.js
Page({

    /**
     * 页面的初始数据
     */
    data: {
        value: 'label_4',
        list: [
            {value: 'label_1', icon: 'home', ariaLabel: '首页'},
            {value: 'label_4', icon: 'user', ariaLabel: '我的'},
        ],
        name:"",
        id:"",
    },
    changebar(e) {
        console.log(e)
        if (e.detail.value == 'label_1') {
            wx.navigateTo({
                url: '/pages/index/index?value=label_1',
            })
        }
    },
    /**
     * 生命周期函数--监听页面加载
     */
    onLoad(options) {
      let that = this
      wx.getStorage({
        key: 'user',
        success (res) {
          that.setData({
            name:res.data.Name,
            id:res.data.Id
          })
        }
      })
    },

    exit(){
      wx.clearStorage()
        wx.reLaunch({
            url: '/pages/login/login',
        })
    },

    /**
     * 生命周期函数--监听页面初次渲染完成
     */
    onReady() {
        wx.hideHomeButton()
    },

    /**
     * 生命周期函数--监听页面显示
     */
    onShow() {
        if (typeof this.getTabBar === 'function' &&
            this.getTabBar()) {
            this.getTabBar().setData({
                selected: 0
            })
        }
    },

    /**
     * 生命周期函数--监听页面隐藏
     */
    onHide() {

    },

    /**
     * 生命周期函数--监听页面卸载
     */
    onUnload() {

    },

    /**
     * 页面相关事件处理函数--监听用户下拉动作
     */
    onPullDownRefresh() {

    },

    /**
     * 页面上拉触底事件的处理函数
     */
    onReachBottom() {

    },

    /**
     * 用户点击右上角分享
     */
    onShareAppMessage() {

    }
})
