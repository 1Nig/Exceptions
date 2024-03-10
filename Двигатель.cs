using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    public class Двигатель
    {
        [XmlAttribute]
        public double Мощность { get; set; }
        [XmlAttribute]
        public double Объем { get; set; }
        [XmlAttribute]
        public string Тип { get; set; }
        [XmlAttribute]
        public string СерийныйНомер { get; set; }
        public Двигатель(double й, double ц, string у, string к) { Мощность = й; Объем = ц; Тип = у; СерийныйНомер = к; }
        public Двигатель() { }
        public void Print()
        {
            Console.WriteLine($"Двигатель имеет мощность {Мощность}, объем {Объем}, Тип двигателя - {Тип},  - {СерийныйНомер}");
        }



    }
}