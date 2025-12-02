using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace waAgenda.classes
{
    [XmlRoot("Pessoa")]
    public class Pessoa
    {
        [XmlElement("Nome")]
        public string Nome { get; set; }

        [XmlElement("Idade")]
        public int IdadeNova { get; set; }
    }
}