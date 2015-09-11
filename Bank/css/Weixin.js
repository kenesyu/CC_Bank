var WeiXin = {
    RegisterWeiXin: function (a, t, n, s) {
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: a, // 必填，企业号的唯一标识，此处填写企业号corpid
            timestamp: t, // 必填，生成签名的时间戳
            nonceStr: n, // 必填，生成签名的随机串
            signature: s, // 必填，签名，见附录1
            jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage', 'onMenuShareQQ', 'onMenuShareWeibo', 'onMenuShareQZone', 'hideMenuItems', 'showMenuItems', 'hideAllNonBaseMenuItem',
                            'showAllNonBaseMenuItem', 'translateVoice', 'startRecord', 'stopRecord', 'onVoiceRecordEnd', 'playVoice', 'onVoicePlayEnd', 'pauseVoice', 'stopVoice', 'uploadVoice', 'downloadVoice',
                            'chooseImage', 'previewImage', 'uploadImage', 'downloadImage', 'getNetworkType', 'openLocation', 'getLocation', 'hideOptionMenu', 'showOptionMenu', 'closeWindow', 'scanQRCode', 'chooseWXPay',
                            'openProductSpecificView', 'addCard', 'chooseCard', 'openCard'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });

    },


    ChoseImg: function () {
        wx.chooseImage({
            count: 9, // 默认9
            sizeType: ['original', 'compressed'],   // 可以指定是原图还是压缩图，默认二者都有
            sourceType: ['album', 'camera'],        // 可以指定来源是相册还是相机，默认二者都有
            success: function (res) {
                var localIds = res.localIds;        // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片
                var idslist = localIds.split(',');
                for (i = 0; i < idslist.length; i++) {
                    WeiXin.UpLoadImg(idslist[i]);
                }


                //alert(localIds);
                //WeiXin.UpLoadImg(localIds);
            }
        });
    },


    UpLoadImg: function (ids) {
        alert(ids);
        wx.uploadImage({
            localId: ids, // 需要上传的图片的本地ID，由chooseImage接口获得
            isShowProgressTips: 1, // 默认为1，显示进度提示
            success: function (res) {
                var serverId = res.serverId; // 返回图片的服务器端ID
                alert(serverId)
            }
        });
    }
}