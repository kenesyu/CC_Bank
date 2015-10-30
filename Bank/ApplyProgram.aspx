<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyProgram.aspx.cs" Inherits="Bank.ApplyProgram" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name ="viewport" content ="width=device-width,initial-scale=1, maximum-scale=1, minimum-scale=1,user-scalable=no">
    <meta name="description" content="">
    <title>印章申请</title>
    <link rel="stylesheet" href="css/style.css"/>
    <link rel="stylesheet" href="css/font.css"/>
    <script src="css/zepto.js" type="text/javascript"></script>
    <script src="css/z_touch.js" type="text/javascript"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="css/Weixin.js?v=20150916_01" type="text/javascript"></script>
    <script src="css/jquery.js" type="text/javascript"></script>
    <script src="css/IsTech_core.js" type="text/javascript"></script>
    <script src="css/IsTech_form.js" type="text/javascript"></script>
    <script>
        WeiXin.RegisterWeiXin('<%=appid %>',<%=timestamp %>,'<%=noncestr %>','<%=signature %>');
    </script>
</head>
<body>
<!--标题-->
<form runat="server" id="form1">
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
            <span id="span">请选择</span>
            <select class="select" name="" id="sel_Program" runat="server">
            </select>
        </div>
    </div>
</div>
<div class="applyBox">
    <div class="applyL">印章</div>
    <div class="applyR">
        <div class="sel_wrap" id="sel_wrapc">
            <span id="span1">请选择</span>
            <select class="select" name="" id="sel_Mark" runat="server">
            </select>
        </div>
    </div>
</div>
<!--审批人-->
<div class="applyBox">
    <div class="applyL">审批人</div>
    <div class="applyR">
        <div class="sel_wrap" id="sel_wrapp">
            <span id="span2">请选择</span>
            <select class="select" name="" id="sel_S" runat="server">

            </select>
        </div>
    </div>
</div>
<!--文档拍照-->
<div class="applyBox">
    <div class="applyL">文件拍照</div>
    <div class="applyR">
        <div class="paizhao ccc" data-icon="xiangji" id="btnCam" onclick="WeiXin.ChoseImg()"></div>
    </div>
</div>
<div class="applyBox">
    <div class="applyL">图片预览</div>
    <div class="applyR" id="divImgPreview">
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
<div class="applyBox padding" align="center">
    <asp:TextBox ID="txtMedid" runat="server"></asp:TextBox>
    <asp:Button ID="btnApply" runat="server" Text="申请" class="applybtn" 
        onclick="btnApply_Click" OnClientClick="return Submit()" />
<%--    <a href="#"><div class="applybtn ">申请</div></a>--%>
</div>

</form>
</body>
</html>
<script>
    function Submit() {
        var medid = "";
        $("#divImgPreview").find("img").each(function () {
            medid += $(this).attr("medid") + ",";
        })
        $("#txtMedid").val(medid);
        return false;
    }
</script>
<script>
    $(function () {
        function a(x) {
            return document.getElementById(x);
        }
        var sel = a("sel_Program");
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
            WeiXin.GetMarkByType($("#sel_Program").val());
        }
        var sell = a("sel_S");
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


        var sell = a("sel_Mark");
        var wrapp = a("sel_wrapc");
        var resulttt = wrapp.getElementsByTagName("span");
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
            resulttt[0].innerHTML = x;
        }
    })
</script>
