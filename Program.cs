using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Runtime.Remoting.Metadata;
using static System.Net.WebRequestMethods;
using System.CodeDom;
using System.Net;
using System.Collections;
using System.Security.Cryptography;


namespace Управление_автопарком
{
    class Program
    {

        static void Main()
        {
            bool endApp = false;
            Console.WriteLine("Добро пожаловать в программу управления автопарком");
            Console.WriteLine("------------------------\n");




            Car Lada = new Car("Lada", 175)
            {
                движок = { Мощность = 113, Объем = 1.3, Тип = "бензиновый", СерийныйНомер = "144213" },
                трансмиссия = { Тип = "механическая", КоличествоПередач = 5, Производитель = "АВТОВАЗ" },
                шасси = { КоличествоКолес = 4, Номер = "1151GHT511J", ДопустимаяНагрузка = 1730 }
            };


            Car Renault = new Car("Renault", 260)
            {
                движок = { Мощность = 90, Объем = 1.6, Тип = "бензиновый", СерийныйНомер = "1596485" },
                трансмиссия = { Тип = "МКПП", КоличествоПередач = 5, Производитель = "Франция" },
                шасси = { КоличествоКолес = 4, Номер = "54834HUj", ДопустимаяНагрузка = 560 }
            };
            List<TC> jf = new List<TC>() { Lada, Renault };

            Console.WriteLine("Здесь Вы узнаете всю информацию об имеющихся легковых, грузовых автомобилях, автобусах и скутерах ");
            Console.WriteLine("Выберите операцию: 1 - операции с легковыми автомобилями, 2 - получение информации о всех транспортных средствах");
            var K = Convert.ToInt32(Console.ReadLine());
            if (K == 1)
            {
                try
                {
                    Console.WriteLine("Выберите операцию: 1 - показать информацию об определенной модели (марки) автомобиля," +
                        " 2 - получение информации об автомобиле (поиск по параметру), " +
                        "3 - добавление новой модели в автопарк, " +
                        "4 - замена модели автомобиля в автопарке," +
                        " 5 - удаление автомобиля из базы данных автопарка");
                    var Q = Convert.ToInt32(Console.ReadLine());
                    if (Q == 1)
                    {

                        try
                        {
                            Console.WriteLine("Выберите модель авто (марку): 1 - Lada; 2 - Renault");
                            var J = Convert.ToInt32(Console.ReadLine());
                            if (J == 1)
                            { Lada.Print(); }


                            else if (J == 2)
                            {
                                Renault.Print();
                                Console.WriteLine("------------------------\n");
                            }
                            else { throw new Exception("Данной марки нет в автопарке"); }
                        }
                        catch (Exception InitializationException)
                        { Console.WriteLine($"Ошибка! {InitializationException.Message}"); } // initialization exception
                    }

                    else if (Q == 2)
                    {
                        try
                        {
                            Console.WriteLine("По какому параметру Вы будете искать автомобиль? Вы можете производить поиск по марке авто (необходимо ввести name в качестве параметра)," +
                            " серийному номеру двигателя (Для этого в качестве параметра необходимо ввести Двигатель), по серийному номеру шасси " +
                            "(необходимо ввести Шасси) и по производителю трансмиссии (введите Трансмиссия и затем страну-производителя)");
                            string param = Console.ReadLine();
                            string value = Console.ReadLine();
                            if (param == "name")
                            {
                                if (value == "Lada")
                                { Lada.Print(); }
                                else if (value == "Renault")
                                { Renault.Print(); }
                                else { Console.WriteLine("Такого автомобиля в автопарке нет"); }
                            }
                            else if (param == "Двигатель")
                            {
                                if (value == "144213") { Lada.Print(); }
                                else if (value == "1596485") { Renault.Print(); }
                                else { Console.WriteLine("Такого автомобиля в автопарке нет"); }
                            }
                            else if (param == "Шасси")
                            {
                                if (value == "1151GHT511J") { Lada.Print(); }
                                else if (value == "54834HUj") { Renault.Print(); }
                                else { Console.WriteLine("Автомобиль с данным номером шасси в автопарке не зарегистрирован"); }
                            }
                            else if (param == "Трансмиссия")
                            {
                                if (value == "АВТОВАЗ") { Lada.Print(); }
                                else if (value == "Франция") { Renault.Print(); }
                                else { Console.WriteLine("Автомобиль с данным производителем шасси в автопарке не зарегистрирован"); }
                            }
                            else { throw new Exception("Откорректируйте запрос"); }
                        }
                        catch (Exception getAutoByParameter) { Console.WriteLine($"Ошибка! {getAutoByParameter.Message}"); } // getAutoByParameter exception

                    }
                    else if (Q == 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            try
                            {
                                Car newCar = new Car();

                                Console.WriteLine("Введите марку авто:");
                                newCar.Name = Console.ReadLine();

                                Console.WriteLine("Введите макс скорость:");
                                newCar.maxSpeed = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Введите мощность двигателя:");
                                newCar.движок.Мощность = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Введите объем двигателя:");
                                newCar.движок.Объем = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Введите тип двигателя:");
                                newCar.движок.Тип = Console.ReadLine();
                                Console.WriteLine("Введите серийный номер двигателя:");
                                newCar.движок.СерийныйНомер = Console.ReadLine();

                                Console.WriteLine("Введите тип трансмиссии:");
                                newCar.трансмиссия.Тип = Console.ReadLine();
                                Console.WriteLine("Введите количество передач");
                                newCar.трансмиссия.КоличествоПередач = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите производителя трансмиссии:");
                                newCar.трансмиссия.Производитель = Console.ReadLine();

                                Console.WriteLine("Введите количество колес");
                                newCar.шасси.КоличествоКолес = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите номер шасси:");
                                newCar.шасси.Номер = Console.ReadLine();
                                Console.WriteLine("Введите допустимую нагрузку");
                                newCar.шасси.ДопустимаяНагрузка = Convert.ToInt32(Console.ReadLine());
                                jf.Add(newCar);
                                newCar.Print();
                            }
                            catch (Exception AddExcepion) { Console.WriteLine($"Ошибка!Вы ввели некорректные данные"); } //AddException
                        }
                    }
                    else if (Q == 4)
                        try
                        {
                            Console.WriteLine("Введите марку авто, которое Вы хотите заменить: 1 - Lada, 2 - Renault");
                            int Z = Convert.ToInt32(Console.ReadLine());
                            if (Z != 1 && Z != 2) { throw new Exception("Данной модели нет в автопарке."); }
                            else
                            {
                                if (Z == 1)
                                {
                                    int index = jf.FindIndex(Car => Car == Lada);
                                    Car newCarr = new Car();

                                    Console.WriteLine("Введите марку авто:");
                                    newCarr.Name = Console.ReadLine();

                                    Console.WriteLine("Введите макс скорость:");
                                    newCarr.maxSpeed = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Введите мощность двигателя:");
                                    newCarr.движок.Мощность = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Введите объем двигателя:");
                                    newCarr.движок.Объем = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Введите тип двигателя:");
                                    newCarr.движок.Тип = Console.ReadLine();
                                    Console.WriteLine("Введите серийный номер двигателя:");
                                    newCarr.движок.СерийныйНомер = Console.ReadLine();

                                    Console.WriteLine("Введите тип трансмиссии:");
                                    newCarr.трансмиссия.Тип = Console.ReadLine();
                                    Console.WriteLine("Введите количество передач");
                                    newCarr.трансмиссия.КоличествоПередач = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите производителя трансмиссии:");
                                    newCarr.трансмиссия.Производитель = Console.ReadLine();

                                    Console.WriteLine("Введите количество колес");
                                    newCarr.шасси.КоличествоКолес = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите номер шасси:");
                                    newCarr.шасси.Номер = Console.ReadLine();
                                    Console.WriteLine("Введите допустимую нагрузку");
                                    newCarr.шасси.ДопустимаяНагрузка = Convert.ToInt32(Console.ReadLine());

                                    jf[index] = newCarr;
                                }
                                else if (Z == 2)
                                {
                                    int index = jf.FindIndex(Car => Car == Renault);

                                    Car newCarr = new Car();

                                    Console.WriteLine("Введите марку авто:");
                                    newCarr.Name = Console.ReadLine();

                                    Console.WriteLine("Введите макс скорость:");
                                    newCarr.maxSpeed = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Введите мощность двигателя:");
                                    newCarr.движок.Мощность = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Введите объем двигателя:");
                                    newCarr.движок.Объем = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Введите тип двигателя:");
                                    newCarr.движок.Тип = Console.ReadLine();
                                    Console.WriteLine("Введите серийный номер двигателя:");
                                    newCarr.движок.СерийныйНомер = Console.ReadLine();

                                    Console.WriteLine("Введите тип трансмиссии:");
                                    newCarr.трансмиссия.Тип = Console.ReadLine();
                                    Console.WriteLine("Введите количество передач");
                                    newCarr.трансмиссия.КоличествоПередач = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите производителя трансмиссии:");
                                    newCarr.трансмиссия.Производитель = Console.ReadLine();

                                    Console.WriteLine("Введите количество колес");
                                    newCarr.шасси.КоличествоКолес = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите номер шасси:");
                                    newCarr.шасси.Номер = Console.ReadLine();
                                    Console.WriteLine("Введите допустимую нагрузку");
                                    newCarr.шасси.ДопустимаяНагрузка = Convert.ToInt32(Console.ReadLine());

                                    jf[index] = newCarr;

                                }
                            }
                        }
                        catch (Exception UpdateAutoException) { Console.WriteLine($"Ошибка! {UpdateAutoException.Message}"); }//UpdateAutoException

                    else if (Q == 5)
                    { try
                        {
                            Console.WriteLine("Выберите, какой автомобиль Вы хотите удалить из списка:1 - Lada, 2 - Renault");
                            int Y = Convert.ToInt32(Console.ReadLine());
                            if (Y == 1)
                            { jf.Remove(Lada); }
                            else if (Y == 2)
                            { jf.Remove(Renault); }
                            else { throw new Exception("Откорректируйте запрос"); }
                        }
                        
                     catch (Exception RemoveAutoException) { Console.WriteLine($"Ошибка! {RemoveAutoException.Message}"); }//RemoveAutoException
                    }


            }
                catch { Console.WriteLine("Данной модели автомобиля нет в автопарке"); }
                }
            else if (K == 2) {
                Lada.Print();

                Console.WriteLine("------------------------\n");
                Renault.Print();
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Это вся информация по легковым автомобилям");
                

                Truck Shacman = new Truck("Тягач Shacman SX42584V324", "седельный тягач", 700)
                {
                    движок = { Мощность = 430, Объем = 11.6, Тип = "с турбонаддувом и промежуточным охлаждением воздуха", СерийныйНомер = "H130604805" },
                    трансмиссия = { Тип = "механическая, синхронизированная", КоличествоПередач = 12, Производитель = "Китай" },
                    шасси = { КоличествоКолес = 6, Номер = "463258H765IU", ДопустимаяНагрузка = 8000 }
                };
                Shacman.Print();
                jf.Add(Shacman);
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Это вся информация по грузовым автомобилям автопарка");

                Bus School = new Bus("Школьный", 30)
                {
                    движок = { Мощность = 149, Объем = 4.43, Тип = "дизельный", СерийныйНомер = "ЯМЗ-53423" },
                    трансмиссия = { Тип = "механическая", КоличествоПередач = 20, Производитель = "МКПП: Fastgear" },
                    шасси = { КоличествоКолес = 4, Номер = "5121LOJ1654", ДопустимаяНагрузка = 4000 }
                };
                School.Print();
                jf.Add(School);
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Это вся информация по автобусам автопарка");


                Scooter Clever = new Scooter("Clever", 90, 120)
                {

                    движок = { Мощность = 6, Объем = 0.060, Тип = "4-х такт", СерийныйНомер = "56121TRE56165" },
                    трансмиссия = { Тип = "механическая", КоличествоПередач = 3, Производитель = "Тайвань" },
                    шасси = { КоличествоКолес = 2, Номер = "65054HFR1651", ДопустимаяНагрузка = 150 }
                }
                ;
                Clever.Print();
                jf.Add(Clever);
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Это вся информация по скутерам автопарка");




                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TC>));

                using (FileStream fs = new FileStream("TC.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, jf);
                }
                Console.WriteLine("Objects has been serialized");

                List<TC> trans = jf.FindAll(TC => TC.движок.Объем >= 1.5);
                XmlSerializer xmlSeri = new XmlSerializer(typeof(List<TC>));

                using (FileStream fs = new FileStream("TC2.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, trans);
                }
                Console.WriteLine("Objects has been serialized");

                var tran = jf.OrderBy(TC => TC.трансмиссия.Тип).ToList();
                XmlSerializer xmlSer = new XmlSerializer(typeof(List<TC>));

                using (FileStream fs = new FileStream("TC3.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, tran);
                }
                Console.WriteLine("Objects has been serialized");


                Console.WriteLine(); // для разделения между группами




                XDocument doc = XDocument.Load("TC.xml");

                XElement root = doc.Root;



                var q = from node in doc.Descendants("движок")
                        let Мощность = node.Attribute("Мощность")
                        let Тип = node.Attribute("Тип")
                        let СерийныйНомер = node.Attribute("СерийныйНомер")
                        select new { Тип = (Тип != null) ? Тип.Value : "", Мощность = (Мощность != null) ? Мощность.Value : "", СерийныйНомер = (СерийныйНомер != null) ? СерийныйНомер.Value : "", };

                foreach (var движок in q)
                {
                    Console.WriteLine("Тип={0}, Мощность={1},СерийныйНомер = {2}", движок.Тип, движок.Мощность, движок.СерийныйНомер);

                }

                XmlTextWriter textWritter = new XmlTextWriter("TC5.xml", Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("head");
                textWritter.WriteEndElement();
                textWritter.Close();
                XmlDocument document = new XmlDocument();
                document.Load("TC5.xml");
                XmlNode TS = document.CreateElement("TC");
                document.DocumentElement.AppendChild(TS);
                XmlNode Buss = document.CreateElement("Bus");
                document.DocumentElement.AppendChild(Buss);

                XmlNode двигатель = document.CreateElement("движок");
                document.DocumentElement.AppendChild(двигатель);
                XmlNode тип = document.CreateElement("Тип");
                тип.InnerText = "дизельный";
                двигатель.AppendChild(тип);
                XmlNode Серийный_номер = document.CreateElement("СерийныйНомер");
                Серийный_номер.InnerText = "ЯМЗ-53423";
                двигатель.AppendChild(Серийный_номер);
                XmlNode мощность = document.CreateElement("Мощность");
                мощность.InnerText = "149";
                двигатель.AppendChild(мощность);

                XmlNode truck = document.CreateElement("Truck");
                document.DocumentElement.AppendChild(truck);

                XmlNode Двигатель = document.CreateElement("движок");
                document.DocumentElement.AppendChild(Двигатель);
                XmlNode ТИП = document.CreateElement("Тип");
                ТИП.InnerText = "с турбонаддувом и промежуточным охлаждением воздуха";
                Двигатель.AppendChild(ТИП);
                XmlNode Серийный_Номер = document.CreateElement("СерийныйНомер");
                Серийный_Номер.InnerText = "H130604805";
                Двигатель.AppendChild(Серийный_Номер);
                XmlNode МОЩНОСТЬ = document.CreateElement("Мощность");
                МОЩНОСТЬ.InnerText = "430";
                Двигатель.AppendChild(МОЩНОСТЬ);

                document.Save("TC5.xml");

                Console.WriteLine("\n");

                return;

            }
        }
            
            }
        }
    












