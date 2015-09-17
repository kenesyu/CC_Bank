var images = { localId: [], serverId: [] };

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
        idlist = "";
        wx.chooseImage({
            count: 9, // 默认9
            sizeType: ['original', 'compressed'],   // 可以指定是原图还是压缩图，默认二者都有
            sourceType: ['album'],    //, 'camera'    // 可以指定来源是相册还是相机，默认二者都有
            success: function (res) {
                //var localIds = res.localIds;        // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片
                images.localId = res.localIds;
                WeiXin.ClearImg();
                WeiXin.UpLoadImg();
            }
        });
    },

    ClearImg: function () {
        $("#divImgPreview").html("");
    },


    UpLoadImg: function () {
        if (images.localId.length == 0) {
            alert('请选择图片');
            return;
        }
        var i = 0, length = images.localId.length;
        images.serverId = [];
        function upload() {
            wx.uploadImage({
                localId: images.localId[i],
                success: function (res) {
                    $("#divImgPreview").append("<img onclick=\"WeiXin.RemoveImg(this)\" medid=" + res.serverId + " src='" + images.localId[i] + "' width='70px' height='70px'>&nbsp;");
                    i++;
                    //alert('宸蹭笂浼狅細' + i + '/' + length);
                    images.serverId.push(res.serverId);
                    $("#btnCam").text(i);
                    if (i < length) {
                        upload();
                    }
                },
                fail: function (res) {
                    alert(JSON.stringify(res));
                }
            });
        }
        upload();
    },

    RemoveImg: function (obj) {
        $(obj).remove()
        $("#btnCam").text($("#divImgPreview").find("img").length);
        if ($("#divImgPreview").find("img").length == 0) {
            $("#btnCam").text("");
        }
    },

    GetMarkByType: function (ID) {
        IsTechForm.Post("/BussinessService/MarkSysService.asmx/GetMarkByType", { ID: ID }
        , function (response) {
            if ($("string", response).text() != "") {
                var result = $("string", response).text();
                var list = result.split("|");
                for (i = 0; i < list.length; i++) { 
                
                }
                alert($("string", response).text());
            }
        }, true);

    }
}