using Backend_PrevisaoTEmpo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;


namespace BackendPrevisaoTempo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials =false)]
    public class CityController : ApiController
    {

        // GET api/previsao_tempo/cidade/{nomeCidade}
        [Route("api/previsao_tempo/cidade/{nomeCidade}")]
        [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = false)]
        public string Get(string nomeCidade)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load("http://servicos.cptec.inpe.br/XML/listaCidades?city="+ nomeCidade);
            }
            catch 
            {
                return "Não foi possível consultar as cidades";
            }


            XmlSerializer ser = new XmlSerializer(typeof(List<cidade>), new XmlRootAttribute("cidades"));

            //document.GetElementsByTagName("cidades")[0].InnerXml;
            string xml = document.InnerXml;

            List<cidade> cidades = new List<cidade>();
            //Object obj = new object();
            using (StringReader sr = new StringReader(xml))
            {
                //obj = ser.Deserialize(sr);
                cidades = (List<cidade>)ser.Deserialize(sr); 
            }


            return new JavaScriptSerializer().Serialize(cidades);
        }

    }
}
