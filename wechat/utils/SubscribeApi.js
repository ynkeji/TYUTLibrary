import {request} from "./util";

export function SubscribeApi(userId){
    var newDateTime = Date.parse(new Date())
    return new Promise((resolve, reject) => {
        request({
            url: '/subscribe?userTime=' + newDateTime + "&username=" + userId,
            method: 'GET',
        }).then(res => {
            console.log(res)
            if (res.code === 200) {
                ///请求成功
                ///调用成功回调
                SubscribeApi_(newDateTime).then(r => {
                    console.log("subscribe....")
                    console.log(r)
                    if (r.code === -1) reject("服务器异常，请稍后重试")
                    if (r.code === 1) {
                        resolve(r)
                    }
                })
            }
            if (res.code === -1) reject("服务器异常，请稍后重试")
        }).catch(err => {
            reject(err)
        })
    })
}
function SubscribeApi_(userTime) {
    return request({
        url: 'subscribe_?userTime=' + userTime,
        method: 'GET',
    }).then(r => {
        return r
    })
}
export default {
    SubscribeApi
}
