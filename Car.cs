using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;
using System.Xml.Serialization;

namespace Управление_автопарком
{
    [Serializable]
    public class Car : TC
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int maxSpeed;
        public Car(string n, int a) { name = n; maxSpeed = a; Name = "Car"; }

        public Car() { }

        public void Print()
        {
            Console.WriteLine($"Бренд машины:{name} максимальная скорость:{maxSpeed}. Параметры двигателя в данном ТС сл: двигатель {движок.Мощность}, объем {движок.Объем}, тип {движок.Тип}, серийный номер {движок.СерийныйНомер}),трансмиссия (тип {трансмиссия.Тип}, количество передач {трансмиссия.КоличествоПередач}, производитель {трансмиссия.Производитель}),шасси (количество колес {шасси.КоличествоКолес}, номер {шасси.Номер}, допустимая нагрузка {шасси.ДопустимаяНагрузка}");
        }


    }
}
