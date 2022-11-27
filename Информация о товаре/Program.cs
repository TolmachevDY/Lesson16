using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Информация_о_товаре
{
    class Program
    {
        static void Main(string[] args)
        {
            /*2.    Необходимо разработать программу для получения информации о товаре из json-файла.
            Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
            //инициализируем переменную до чтения
            string jsonString = String.Empty;
            //считываем созданный файл
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            //получаем массив объектов из созданной строки
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            //объявляем что первый товар (нулевой элемент массива) имеет наибольшую цену
            Product maxProduct = products[0];
            foreach (Product e in products)
            {
                if (e.Price > maxProduct.Price)
                {
                    maxProduct = e;
                }
            }
            Console.WriteLine($"{maxProduct.Code} {maxProduct.Name} {maxProduct.Price:f2}");
            Console.ReadKey();

        }
    }
}
