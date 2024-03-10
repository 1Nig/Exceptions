using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    [Serializable]
    public class Truck : TC
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public string category;
        [XmlAttribute]
        public double Patrol;
        public Truck(string n, string c, double P) { name = n; category = c; Patrol = P; Name = "Truck"; }
        public Truck() { }
        public void Print()
        {
            Console.WriteLine($"Бренд машины и модель:{name} категория:{category} вместительность топливного бака:{Patrol}.  Параметры двигателя в данном ТС сл: двигатель {движок.Мощность}, объем {движок.Объем}, тип {движок.Тип}, серийный номер {движок.СерийныйНомер}),трансмиссия (тип {трансмиссия.Тип}, количество передач {трансмиссия.КоличествоПередач}, производитель {трансмиссия.Производитель}),шасси (количество колес {шасси.КоличествоКолес}, номер {шасси.Номер}, допустимая нагрузка {шасси.ДопустимаяНагрузка}");
        }



    }
}
