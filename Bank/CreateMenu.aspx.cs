using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bank.QYAPI;
using System.Text;

namespace Bank
{
    public partial class CreateMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Create(1);
        }

        private void Create(int Appid) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/create?access_token=" + QYAPI.API_Token.AccessToken + "&agentid=" + Appid;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("     \"button\":[");
            sb.AppendLine("         {");
            sb.AppendLine("             \"type\":\"view\", ");
            sb.AppendLine("             \"name\":\"用章申请\", ");
            sb.AppendLine("             \"url\":\"http://www.baidu.com\" ");
            sb.AppendLine("         },");
            sb.AppendLine("         {");
            sb.AppendLine("             \"type\":\"view\", ");
            sb.AppendLine("             \"name\":\"我的审批\", ");
            sb.AppendLine("             \"url\":\"http://www.sina.com.cn\" ");
            sb.AppendLine("         }");
            sb.AppendLine("     ]");
            sb.AppendLine("}");
            string result = QYAPI.HttpUtility.SendPostHttpRequest(url, "post", sb.ToString());
        

        }
    }
}