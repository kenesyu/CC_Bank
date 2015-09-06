﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bank.QYAPI;
using System.Configuration;
namespace Bank
{
    public partial class test : System.Web.UI.Page
    {
        public string appid = ConfigurationManager.AppSettings["corpid"].ToString();
        public string timestamp = QYAPI.HttpUtility.ConvertDateTimeInt(DateTime.Now).ToString();
        public string jsticket = QYAPI.API_Token.JSAPITicket;
        public string noncestr = QYAPI.HttpUtility.getNoncestr();
        public string signature = string.Empty;
        //public string 


        protected void Page_Load(object sender, EventArgs e)
        {
            //string aa = ;
            signature = QYAPI.HttpUtility.EncryptToSHA1("jsapi_ticket=" + jsticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + Request.Url.ToString());

            //string aa = QYAPI.HttpUtility.GetData("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token="+QYAPI.API_Token.AccessToken+"&id=1");

            //string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + QYAPI.API_Token.AccessToken;
            //string data = "{ " 
            //                + " \"touser\": \"yz\","
            //                + " \"toparty\": \"\","
            //                + " \"totag\": \"\","
            //                + " \"msgtype\": \"text\","
            //                + " \"agentid\": \"1\","
            //                + " \"text\": {"
            //                + "     \"content\": \"test message <a href='http://www.sina.com.cn'>连接</a>\" "
            //                + " },"
            //                + " \"safe\":\"0\" "
            //                + " }";

            //string result = QYAPI.HttpUtility.SendPostHttpRequest(url, "post", data);

        }
    }
}