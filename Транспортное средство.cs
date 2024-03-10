using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace Управление_автопарком
{
    [Serializable]
    [XmlInclude(typeof(Car)), XmlInclude(typeof(Bus)), XmlInclude(typeof(Scooter)), XmlInclude(typeof(Truck)), XmlInclude(typeof(Двигатель)), XmlInclude(typeof(Трансмиссия)), XmlInclude(typeof(Шасси))]

    public class TC
    {
        [XmlElement]
        public string Name;
        [XmlElement]
        public Двигатель движок;
        [XmlElement]
        public Трансмиссия трансмиссия;
        [XmlElement]
        public Шасси шасси;

        public TC()
        {
            Name = "TC";
            движок = new Двигатель();
            трансмиссия = new Трансмиссия();
            шасси = new Шасси();
        }
        public void Print()
        { }
    }

}
