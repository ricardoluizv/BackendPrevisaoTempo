using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Backend_PrevisaoTEmpo.Models
{
    [XmlRoot("cidades")]
    public class cidade
    {
        [XmlElement("nome")]
        public string nome { get; set; }

        [XmlElement("uf")]
        public string uf { get; set; }

        [XmlElement("id")]
        public int id { get; set; }

        [XmlElement("atualizacao")]
        public string atualizacao { get; set; }

        [XmlArray("previsao")]
        [XmlArrayItem("previsao")]
        public List<Previsao> listPrevisao { get; set; }
    }
}