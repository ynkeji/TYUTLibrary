Page({
    data: {
        Mobile: "",
        Email: "",
        Id: "",
        RoleName: "",
        DeptName: "",
        FlagName: "",
        effective: ""

    },
    onLoad: function (options) {
        wx.getStorage({
            key: 'user',
            success: (res) => {
                console.log(res)
                this.setData({
                    Mobile: res.data.Mobile,
                    Email: res.data.Email,
                    Id: res.data.Id,
                    RoleName: res.data.RoleName,
                    DeptName: res.data.DeptName,
                    FlagName: res.data.FlagName,

                })
            }
        })
    }
});
