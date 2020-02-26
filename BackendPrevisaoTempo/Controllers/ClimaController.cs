using Backend_PrevisaoTEmpo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BackendPrevisaoTempo.Controllers
{
    public class ClimaController : ApiController
    {

        // GET api/previsao_tempo/<controller>/5
        [Route("api/previsao_tempo/clima/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = false)]
        public string Get(int id)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load("http://servicos.cptec.inpe.br/XML/cidade/7dias/" + id + "/previsao.xml");
            }
            catch
            {
                return "Não foi possível consultar as cidades";
            }

            XmlSerializer ser = new XmlSerializer(typeof(cidade), new XmlRootAttribute("cidade"));

            cidade cidades = new cidade();
            //Object obj = new object();
            using (StringReader sr = new StringReader(document.InnerXml))
            {
                //obj = ser.Deserialize(sr);
                cidades = (cidade)ser.Deserialize(sr);
                //previsoes = (List<previsao>)ser.Deserialize(sr);


            }

            cidades.listPrevisao = new List<Previsao>();

            foreach (XmlNode xmlPrevisao in document.GetElementsByTagName("previsao"))
            {
                ser = new XmlSerializer(typeof(Previsao), new XmlRootAttribute("previsao"));
                using (StringReader sr = new StringReader(xmlPrevisao.OuterXml))
                {
                    Previsao pr = (Previsao)ser.Deserialize(sr);
                    cidades.listPrevisao.Add(pr);
                }
            }

            return new JavaScriptSerializer().Serialize(cidades);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "" };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}