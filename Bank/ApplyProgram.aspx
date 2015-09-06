<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyProgram.aspx.cs" Inherits="Bank.ApplyProgram" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name ="viewport" content ="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1,user-scalable=no">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <title>申请页面</title>
    <link rel="stylesheet" href="css/style.css"/>
    <link rel="stylesheet" href="css/font.css"/>
    <script src="css/zepto.js"></script>
    <script src="css/z_touch.js"></script>
        <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script>
        wx.config({
        debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: '<%=appid %>', // 必填，企业号的唯一标识，此处填写企业号corpid
            timestamp: <%=timestamp %>, // 必填，生成签名的时间戳
            nonceStr: '<%=noncestr %>', // 必填，生成签名的随机串
            signature: '<%=signature %>',// 必填，签名，见附录1
            jsApiList: ['checkJsApi',
        'onMenuShareTimeline',
        'onMenuShareAppMessage',
        'onMenuShareQQ',
        'onMenuShareWeibo',
        'onMenuShareQZone',
        'hideMenuItems',
        'showMenuItems',
        'hideAllNonBaseMenuItem',
        'showAllNonBaseMenuItem',
        'translateVoice',
        'startRecord',
        'stopRecord',
        'onVoiceRecordEnd',
        'playVoice',
        'onVoicePlayEnd',
        'pauseVoice',
        'stopVoice',
        'uploadVoice',
        'downloadVoice',
        'chooseImage',
        'previewImage',
        'uploadImage',
        'downloadImage',
        'getNetworkType',
        'openLocation',
        'getLocation',
        'hideOptionMenu',
        'showOptionMenu',
        'closeWindow',
        'scanQRCode',
        'chooseWXPay',
        'openProductSpecificView',
        'addCard',
        'chooseCard',
        'openCard'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    });
    </script>
</head>
<body>
<!--标题-->
<div class="applyBox">
    <div class="applyL">印章申请</div>
    <div class="applyR">
        <input type="text" id=placeholder placeholder="输入标题" >
    </div>
</div>

<!--审批流程-->
<div class="applyBox">
    <div class="applyL">审批流程</div>
    <div class="applyR">
        <div class="sel_wrap" id="sel_wrap">
            <span id="span">请选择审批流程</span>
            <select class="select" name="" id="c_select">
                <option value="0">张三</option>
                <option value="1">李四</option>
                <option value="2">王五</option>
                <option value="3">赵六</option>
            </select>
        </div>
    </div>
</div>
<!--审批人-->
<div class="applyBox">
    <div class="applyL">审批人</div>
    <div class="applyR">
        <div class="sel_wrap" id="sel_wrapp">
            <span>审批人</span>
            <select class="select" name="" id="c_selectt" runat="server">

            </select>
        </div>
    </div>
</div>
<!--文档拍照-->
<div class="applyBox">
    <div class="applyL">文档拍照</div>
    <div class="applyR">
        <div class="paizhao ccc" data-icon="xiangji"></div>
    </div>
</div>
<!--语音-->
<div class="applyBox">
    <div class="applyL input iii" id="iii">语音</div>
    <div class="applyR" >
        <div class="paizhao cccc ccc" data-icon="yuyin"></div>
        <div id="yuyin" data-icon="fankui" icon-pos="right"></div>
    </div>
</div>
<!--文字-->
<div class="applyBox">
    <div name=""  class="textareaa"></div>
    <div class="applyL">文字</div>
    <div class="applyR" >
        <div class="paizhao ccc" data-icon="fasong"></div>
        <input type="text" id="wenzi">
    </div>
</div>

<!--申请-->
<div class="applyBox padding">
    <a href="#"><div class="applybtn ">申请</div></a>
</div>
</body>
</html>
<script>
    $(function () {
        function a(x) {
            return document.getElementById(x);
        }
        var sel = a("c_select");
        var wrap = a("sel_wrap");
        var result = wrap.getElementsByTagName("span");
        wrap.onmouseover = function () {
            this.style.backgroundColor = "#fff";
        }
        wrap.onmouseout = function () {
            this.style.backgroundColor = "#fafafa";
        }
        sel.onchange = function () {
            var opt = this.getElementsByTagName("option");
            var len = opt.length;
            for (i = 0; i < len; i++) {
                if (opt[i].selected == true) {
                    x = opt[i].innerHTML;
                }
            }
            result[0].innerHTML = x;
        }
        var sell = a("c_selectt");
        var wrapp = a("sel_wrapp");
        var resultt = wrapp.getElementsByTagName("span");
        wrapp.onmouseover = function () {
            this.style.backgroundColor = "#fff";
        }
        wrapp.onmouseout = function () {
            this.style.backgroundColor = "#fafafa";
        }
        sell.onchange = function () {
            var opt = this.getElementsByTagName("option");
            var len = opt.length;
            for (i = 0; i < len; i++) {
                if (opt[i].selected == true) {
                    x = opt[i].innerHTML;
                }
            }
            resultt[0].innerHTML = x;
        }


    })


</script>
