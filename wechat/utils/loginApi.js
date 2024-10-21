import {request} from './util'

function login(username, password) {
    var newDateTime = Date.parse(new Date())
    return new Promise((resolve, reject) => {
        wx.login({
            success: function (res) {
                request({
                    url: 'login',
                    method: 'post',
                    data: {
                        username: username,
                        password: password,
                        userTime: newDateTime,
                        sign: res.code
                    }
                }).then(r => {
                    console.log(r)
                    if (r.code === 200) {
                        ///请求成功
                        ///调用成功回调
                        login_(newDateTime).then(r => {
                            console.log("login....")
                            console.log(r)
                            if (r.code === 0) reject("账号密码错误")
                            if (r.code === -1) reject("服务器异常，请稍后重试")
                            if (r.code === 1) {
                              wx.setStorage({
                                key: 'token',
                                data: r.token
                            })
                                resolve(r.data) //返回用户信息
                            }
                        })
                    }
                    if (r.code === -1) reject("服务器异常，请稍后重试")
                })
            }
        })
    })
}


function login_(userTime) {
    return request({
        url: 'login_?userTime=' + userTime,
        method: 'GET',
    }).then(r => {
        return r
    })
}


module.exports = {
    login
}
