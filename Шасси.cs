using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    public class Шасси
    {
        [XmlAttribute]
        public int КоличествоКолес = 0;
        [XmlAttribute]
        public string Номер = "Undefined";
        [XmlAttribute]
        public int ДопустимаяНагрузка = 0;
    }
}
