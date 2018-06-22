using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Controllers
{
    public class ICDController : ApiController
    {

        [HttpGet]
        public string HienThiICD()
        {
            List<ICD> list = new List<ICD>();
            list = ICDRepository.ShowAllICD();
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpGet]
        public string HienThiICD(string id)
        {
            ICD list = new ICD();
            list = ICDRepository.ShowICD(id);
            if (list.maicd==null)
            {
                return "NULL";
            }
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }
    }
}
