using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    public class Трансмиссия
    {
        [XmlAttribute]
        public string Тип = "Undefined";
        [XmlAttribute]
        public int КоличествоПередач = 0;
        [XmlAttribute]
        public string Производитель = "Undefined";

    }
}
