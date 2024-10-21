const formatTime = date => {
    const year = date.getFullYear()
    const month = date.getMonth() + 1
    const day = date.getDate()
    const hour = date.getHours()
    const minute = date.getMinutes()
    const second = date.getSeconds()

    return `${[year, month, day].map(formatNumber).join('/')} ${[hour, minute, second].map(formatNumber).join(':')}`
}

const formatNumber = n => {
    n = n.toString()
    return n[1] ? n : `0${n}`
}

function request({url, data = {}, method = 'POST'}) {
    var baseUrl = "https://netty.fak588.cn/"
  console.log("url=>" + url)
    return new Promise((resolve, reject) => {
        wx.getStorage({
            key: 'token',
            success(res) {
              console.log("token=>" + res.data)
                wx.request({
                    url: baseUrl + url,
                    data: data,
                    method: method,
                    header: {
                        'content-type': 'application/json', // 默认值
                        'token': res.data
                    },
                    success(res) {
                        resolve(res.data);
                    },
                    fail(err) {
                        reject(err);
                    }
                });
            },
          fail(res) {
              console.log("fail=>" + res)
              if (url.includes("login")){
                wx.request({
                  url: baseUrl + url,
                  data: data,
                  method: method,
                  header: {
                    'content-type': 'application/json', // 默认值
                  },
                  success(rep) {
                      console.log( rep.data)
                    resolve(rep.data);
                  },
                  fail(err) {
                      console.log("fail=>" + err)
                    reject(err);
                  }
                });
              }else{
                wx.navigateTo({
                  url: '/pages/login/login',
                })
              }
          }
        })

    });
}

module.exports = {
    formatTime,
    request
}
