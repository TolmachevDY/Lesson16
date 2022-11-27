using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Перечень_товаров
{
    /*1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/
    class Program
    {
        static void Main(string[] args)
        {
            //создаем константу для указания количества записей в массиве
            const int n = 5;
            //создаем экземпляр класса в виде массива для запии данных всех товаров
            Product[] products = new Product[n];
            //создаем цикл по сбору данных для записи
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());
                //инициализация элемента массива
                products[i] = new Product() { Code = code, Name = name, Price =price };
            }
            //конструкция для распознавания символов кириллицы
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                //построчная запись json строки
                WriteIndented = true
            };
            //записываем в джейсон строку массив
            string jsonString = JsonSerializer.Serialize(products, options);
            //записываем в файл созданную строку
            using (StreamWriter sw = new StreamWriter("../../../Products.json"))//3 раза поднялись наверх по каталогу
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
