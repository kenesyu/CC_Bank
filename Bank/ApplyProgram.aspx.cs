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
using System.Data;

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
            BindData();
        }



        private void BindData() { 
            signature = QYAPI.HttpUtility.EncryptToSHA1("jsapi_ticket=" + jsticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + Request.Url.ToString());

            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token=" + QYAPI.API_Token.AccessToken + "&department_id=3&fetch_child=0&status=1";
            string result = QYAPI.HttpUtility.GetData(url);

            StringReader sr = new StringReader(result); 
            JsonSerializer serializer = new JsonSerializer();
            UserList ulist = (UserList)serializer.Deserialize(new JsonTextReader(sr), typeof(UserList));

            this.sel_S.Items.Clear();
            if (ulist.errcode == "0")
            {
                foreach (User u in ulist.userlist)
                {
                    this.sel_S.Items.Add(new ListItem(u.name, u.userid));
                }
            }

            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dtMarkType = dbHelper.ExecuteDataTable("select * from T_MarkType");
            this.sel_Program.Items.Clear();
            foreach (DataRow dr in dtMarkType.Rows) {
                this.sel_Program.Items.Add(new ListItem(dr["TypeName"].ToString(), dr["TypeID"].ToString()));
            }
            dbHelper.Dispose();
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {





        }
    }
}