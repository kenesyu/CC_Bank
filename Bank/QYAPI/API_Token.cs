﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml.Linq;

namespace Bank.QYAPI
{
    public class API_Token
    {
        //privaet static string AppID = 
        private static DateTime GetAccessToken_Time;

        private static DateTime GetJSAPITicket_Time;
        /// <summary>
        /// 过期时间为7200秒
        /// </summary>
        private static int Expires_Period = 7200;
        /// <summary>
        /// 
        /// </summary>
        private static string mAccessToken;
        /// <summary>
        /// 
        /// </summary>
        public static string AccessToken
        {
            get
            {
                //如果为空，或者过期，需要重新获取
                if (string.IsNullOrEmpty(mAccessToken) || HasExpired())
                {
                    //获取
                    mAccessToken = GetAccessToken(ConfigurationManager.AppSettings["corpid"].ToString(), ConfigurationManager.AppSettings["corpsecret"].ToString());
                }

                return mAccessToken;
            }
        }


        private static string mJSAPITicket;
        public static string JSAPITicket
        {
            get
            {
                //如果为空，或者过期，需要重新获取
                if (string.IsNullOrEmpty(mJSAPITicket) || HasExpiredTiecket())
                {
                    //获取
                    mJSAPITicket = GetJsAPITicket(AccessToken);
                }

                return mJSAPITicket;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private static string GetAccessToken(string corpid, string corpsecret)
        {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpid, corpsecret);
            string result = HttpUtility.GetData(url);

            XDocument doc = XmlUtility.ParseJson(result, "root");
            XElement root = doc.Root;
            if (root != null)
            {
                XElement access_token = root.Element("access_token");
                if (access_token != null)
                {
                    GetAccessToken_Time = DateTime.Now;
                    if (root.Element("expires_in") != null)
                    {
                        Expires_Period = int.Parse(root.Element("expires_in").Value);
                    }
                    return access_token.Value;
                }
                else
                {
                    GetAccessToken_Time = DateTime.MinValue;
                }
            }

            return null;
        }

        private static string GetJsAPITicket(string AccessToken) {

            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", AccessToken);
            string result = HttpUtility.GetData(url);

            XDocument doc = XmlUtility.ParseJson(result, "root");
            XElement root = doc.Root;
            if (root != null)
            {
                XElement jsapi_ticket = root.Element("ticket");
                if (jsapi_ticket != null)
                {
                    GetJSAPITicket_Time = DateTime.Now;
                    if (root.Element("expires_in") != null)
                    {
                        Expires_Period = int.Parse(root.Element("expires_in").Value);
                    }
                    return jsapi_ticket.Value;
                }
                else
                {
                    GetJSAPITicket_Time = DateTime.MinValue;
                }
            }

            return null;
        }



        /// <summary>
        /// 判断Access_token是否过期
        /// </summary>
        /// <returns>bool</returns>
        private static bool HasExpired()
        {
            if (GetAccessToken_Time != null)
            {
                //过期时间，允许有一定的误差，一分钟。获取时间消耗
                if (DateTime.Now > GetAccessToken_Time.AddSeconds(Expires_Period).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }


        private static bool HasExpiredTiecket()
        {
            if (GetJSAPITicket_Time != null)
            {
                //过期时间，允许有一定的误差，一分钟。获取时间消耗
                if (DateTime.Now > GetJSAPITicket_Time.AddSeconds(Expires_Period).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }


    }
}