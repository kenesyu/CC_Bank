using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Bank.ClsLib;

namespace Bank
{
    public partial class ApplyProgram : System.Web.UI.Page
    {
        public string appid = ConfigurationManager.AppSettings["corpid"].ToString();
        public string timestamp = QYAPI.HttpUtility.ConvertDateTimeInt(DateTime.Now).ToString();
        public string jsticket = QYAPI.API_Token.JSAPITicket;
        public string noncestr = QYAPI.HttpUtility.getNoncestr();
        public string signature = string.Empty;
        //public string 


        protected void Page_Load(object sender, EventArgs e)
        {
            
            signature = QYAPI.HttpUtility.EncryptToSHA1("jsapi_ticket=" + jsticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + Request.Url.ToString());

            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token=" + QYAPI.API_Token.AccessToken + "&department_id=3&fetch_child=0&status=1";
            string result = QYAPI.HttpUtility.GetData(url);

            StringReader sr = new StringReader(result); 
            JsonSerializer serializer = new JsonSerializer();
            UserList ulist = (UserList)serializer.Deserialize(new JsonTextReader(sr), typeof(UserList));

            this.c_selectt.Items.Clear();
            this.c_selectt.Items.Add(new ListItem("---审批人---", ""));

            if (ulist.errcode == "0")
            {
                foreach (User u in ulist.userlist)
                {
                    this.c_selectt.Items.Add(new ListItem(u.name, u.userid));
                }
            }
            //JObject jo = (JObject)JsonConvert.DeserializeObject(result);

            //string zone = jo["beijing"]["zone"].ToString();
            //string zone_en = jo["beijing"]["zone_en"].ToString();  
            
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