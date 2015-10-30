using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bank.QYAPI;
using System.Configuration;
using System.Net;
using System.IO;
namespace Bank
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = "{ \"zid\": \"2506\", \"formhash\": \"30cbbfb2\"}";
            string aa = QYAPI.HttpUtility.SendHttpRequest("http://nantong.iydwl.com/plugin.php?id=hejin_toupiao&model=clicks&vid=5&zid=2506&formhash=30cbbfb2",data);

            Response.Write(aa);


            //string url = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token=" + QYAPI.API_Token.AccessToken + "&media_id=Xeqf1K3zkLAMuGGfO3_iDsfm0D6HjPsYn7lqRAESY92KLnBfXHGISA6gv_DNOC7J";
            //string aa = QYAPI.HttpUtility.GetData(url);

            //HttpDownloadFile(url,Server.MapPath("download/"));
            //string aa = QYAPI.HttpUtility.SendPostHttpRequest("https://qyapi.weixin.qq.com/cgi-bin/material/batchget?access_token=" + QYAPI.API_Token.AccessToken,"post","{\"type\": \"image\",    \"agentid\": 3,    \"offset\": 0,    \"count\": 50}");
        }


        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            string newpath = path + Guid.NewGuid() + "." + response.Headers.Get(1).Replace("\"", "").Split('.')[1];

            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(newpath, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }
    }
}