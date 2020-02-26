using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Backend_PrevisaoTEmpo.Models
{
    [XmlRoot("previsao")]
    public class Previsao
    {
        [XmlElement("dia")]
        public string dia { get; set; }

        [XmlElement("tempo")]
        public string tempo { get; set; }

        [XmlElement("maxima")]
        public int maxima { get; set; }

        [XmlElement("minima")]
        public int minima { get; set; }

        [XmlElement("iuv")]
        public double iuv { get; set; }

    }
}