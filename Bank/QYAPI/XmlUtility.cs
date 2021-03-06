﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Bank.QYAPI
{
    public class XmlUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public static XDocument ParseJson(string json, string rootName)
        {
            return JsonConvert.DeserializeXNode(json, rootName);
        }
    }
}