using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Bank.ClsLib;
using System.Configuration;
using System.Data;

namespace Bank.BussinessService
{
    /// <summary>
    /// MarkSysService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class MarkSysService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetMarkByType(string ID)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("select * from T_Marks where TypeID = " + ID);
            string strValue = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                strValue += dr["ID"].ToString() + "," + dr["Name"].ToString() + "|";
            }
            return strValue.TrimEnd('|');
        }
    }
}
