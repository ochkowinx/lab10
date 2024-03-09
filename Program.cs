using Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лабораторка_10
{
    internal class Program
    {
        public static void Query1(Plant[] plants)
        {
            Console.WriteLine("1. Название, цвет и запах всех роз без шипов:");

            foreach (var plant in plants)
            {
                if (plant is Rose rose && !rose.HasThorns)
                {
                    Console.WriteLine($"Название: {rose.Name}, Цвет: {rose.Color}, Запах: {rose.Smell}");
                }
            }

            Console.WriteLine();
        }

        public static void Query2(Plant[] plants)
        {
            Console.WriteLine("2. Самое маленькое (низкое) дерево:");

            Tree smallestTree = null;
            double minHeight = double.MaxValue;

            foreach (var plant in plants)
            {
                if (plant is Tree tree && tree.Height < minHeight)
                {
                    smallestTree = tree;
                    minHeight = tree.Height;
                }
            }

            if (smallestTree != null)
            {
                Console.WriteLine($"Название: {smallestTree.Name}, Цвет: {smallestTree.Color}, Высота: {smallestTree.Height} м");
            }

            Console.WriteLine();
        }

        public static void Query3(Plant[] plants, string targetSmell)
        {
            Console.WriteLine($"3. Названия всех цветов с запахом '{targetSmell}':");

            foreach (var plant in plants)
            {
                if (plant is Flower flower && flower.Smell == targetSmell)
                {
                    Console.WriteLine($"Название: {flower.Name}, Цвет: {flower.Color}");
                }
            }

            Console.WriteLine();
        }

        static void Main()
        {
            // Создаем массив из 20 объектов разных классов
            Plant[] plants = new Plant[20];

            for (int i = 0; i < 5; i++)
            {
                plants[i] = new Plant();
                plants[i].RandomInit();
            }

            for (int i = 5; i < 10; i++)
            {
                plants[i] = new Tree();
                plants[i].RandomInit();
            }

            for (int i = 10; i < 15; i++)
            {
                plants[i] = new Flower();
                plants[i].RandomInit();
            }

            for (int i = 15; i < 20; i++)
            {
                plants[i] = new Rose();
                plants[i].RandomInit();
            }

            // Просмотр элементов массива с помощью обычных и виртуальных функций
            foreach (Plant plant in plants)
            {
                plant.Show();
                Console.WriteLine();
            }

            Query1(plants);
            Query2(plants);
            Query3(plants, "Smell2");

            // Создаем массив объектов из иерархии классов
            IInit[] objects = new IInit[]
            {
            new Post(),
            new Plant(),
            new Tree(),
            new Flower(),
            new Rose(),
            new Post(),
            new Flower(),
            new Tree(),
            new Tree()
            };

            // Выводим объекты на печать и подсчитываем количество объектов каждого типа
            int postCount = 0, plantCount = 0, treeCount = 0, flowerCount = 0, roseCount = 0;

            foreach (var obj in objects)
            {
                Console.WriteLine(obj.GetType().Name);

                if (obj is Post)
                {
                    postCount++;
                }
                else if (obj is Tree)
                {
                    treeCount++;
                }
                else if (obj is Rose)
                {
                    roseCount++;
                }
                else if (obj is Flower)
                {
                    flowerCount++;
                }
                else if (obj is Plant)
                {
                    plantCount++;
                }
            }

            Console.WriteLine($"Post count: {postCount}");
            Console.WriteLine($"Plant count: {plantCount}");
            Console.WriteLine($"Tree count: {treeCount}");
            Console.WriteLine($"Flower count: {flowerCount}");
            Console.WriteLine($"Rose count: {roseCount}");


            // Создаем массив объектов из иерархии классов
            Plant[] objects2 = new Plant[]
            {
            new Plant("Plant B", "Green", 12),
            new Plant("Plant A", "Blue", 2),
            new Tree("Tree A", "Yellow", 10.1, 6),
            new Flower("Flower C", "Green", "smell12", 8),
            new Rose("Rose B", "Red", "smell10", true, 9)
            };

            // Выводим объекты на печать до сортировки
            Console.WriteLine("объекты до сортировки");
            foreach (var obj in objects2)
            {
                Console.WriteLine(obj);
            }

            // Сортируем массив объектов с использованием интерфейса IComparable
            Array.Sort(objects2);

            // Выводим объекты на печать после сортировки
            Console.WriteLine("\nобъекты после сортировки");
            foreach (var obj in objects2)
            {
                Console.WriteLine(obj);
            }


            // Создаем объект для поиска
            Plant searchKey = new Plant("Plant A", "Blue", 12);

            // Ищем объект в отсортированном массиве
            int index = Array.BinarySearch(objects2, searchKey);

            // Выводим результат
            if (index >= 0)
            {
                Console.WriteLine($"объект найден под индексом: {index}: {objects2[index]}");
            }
            else
            {
                Console.WriteLine("объект не найден");
            }


            Plant originalPlant = new Plant("Original Plant", "Green", 123);
            Plant clonedPlant = (Plant)originalPlant.Clone();

            Console.WriteLine("Original Plant: " + originalPlant);
            Console.WriteLine("Cloned Plant: " + clonedPlant);
            Console.WriteLine("Are they equal? " + (originalPlant.Equals(clonedPlant) ? "Yes" : "No"));
            Console.ReadKey();
        }
    }
}
