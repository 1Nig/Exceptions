using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    [Serializable]
    public class Bus : TC
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public byte amount;
        public Bus(string n, byte a) { name = n; amount = a; Name = "Bus"; }
        public Bus() { }
        public void Print()
        {
            Console.WriteLine($"{name} автобус вмещает {amount} количество человек.  Параметры двигателя в данном ТС сл: двигатель {движок.Мощность}, объем {движок.Объем}, тип {движок.Тип}, серийный номер {движок.СерийныйНомер}),трансмиссия (тип {трансмиссия.Тип}, количество передач {трансмиссия.КоличествоПередач}, производитель {трансмиссия.Производитель}),шасси (количество колес {шасси.КоличествоКолес}, номер {шасси.Номер}, допустимая нагрузка {шасси.ДопустимаяНагрузка}");
        }
    }
}
