﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bank.QYAPI;

namespace Bank
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string aa = ;


            string aa = QYAPI.HttpUtility.GetData("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token="+QYAPI.API_Token.AccessToken+"&id=1");
        }
    }
}