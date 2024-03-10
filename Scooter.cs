using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    [Serializable]

    public class Scooter : TC
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int maxSpeed;
        [XmlAttribute]
        public double WheelSize;
        public Scooter(string n, int m, double w) { name = n; maxSpeed = m; WheelSize = w; Name = "Scooter"; }
        public Scooter() { }
        public void Print()
        {
            Console.WriteLine($"Скутер развивает  {maxSpeed} макс скорость. Размер колес:{WheelSize}. Параметры двигателя в данном ТС сл: двигатель {движок.Мощность}, объем {движок.Объем}, тип {движок.Тип}, серийный номер {движок.СерийныйНомер}),трансмиссия (тип {трансмиссия.Тип}, количество передач {трансмиссия.КоличествоПередач}, производитель {трансмиссия.Производитель}),шасси (количество колес {шасси.КоличествоКолес}, номер {шасси.Номер}, допустимая нагрузка {шасси.ДопустимаяНагрузка}");
        }
    }
}
