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
    <script src="css/zepto.js" type="text/javascript"></script>
    <script src="css/z_touch.js" type="text/javascript"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="css/Weixin.js?v=20150909_03" type="text/javascript"></script>
    <script>
        WeiXin.RegisterWeiXin('<%=appid %>',<%=timestamp %>,'<%=noncestr %>','<%=signature %>');
    </script>
</head>
<body>
<!--标题-->
<div class="applyBox">
    <div class="applyL">印章申请</div>
    <div class="applyR">
        <input type="text" id="txtTitle" runat="server" placeholder="输入标题" >
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
    <div class="applyL">文件拍照</div>
    <div class="applyR">
        <div class="paizhao ccc" data-icon="xiangji" onclick="WeiXin.ChoseImg()"></div>
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
