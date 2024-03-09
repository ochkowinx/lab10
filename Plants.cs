using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }
    public interface ICloneable
    {
        object Clone();
    }
    public class IdNumber : ICloneable
    {
        public int Number
        {
            get { return number; }
            set
            {
                if (value >= 0)
                    number = value;
                else
                    Console.WriteLine("Некорректное значение для числа IdNumber.");
            }
        }

        public object Clone()
        {
            return new IdNumber(Number);
        }

        private int number;

        public IdNumber()
        {
            // Конструктор без параметров
        }

        public IdNumber(int number)
        {
            Number = number;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            IdNumber other = (IdNumber)obj;
            return Number == other.Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return $"IdNumber: {Number}";
        }
    }
    // Базовый класс "Растение"
    public class Plant : IInit, IComparable<Plant>, ICloneable
    {
        // 1.1 Поля
        private string name;
        private string color;
        private static readonly Random random = new Random();
        public IdNumber Id { get; set; } = new IdNumber();

        // 1.2 Свойства с проверкой ограничений
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    Console.WriteLine("Некорректное значение для названия растения.");
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    color = value;
                else
                    Console.WriteLine("Некорректное значение для цвета растения.");
            }
        }

        // 1.3 Конструкторы
        public Plant(string name, string color, int idNumber)
        {
            Name = name;
            Color = color;
            Id.Number = idNumber;
        }

        public Plant()
        {
            // Конструктор без параметров
        }

        // 1.4 Метод Show()
        public virtual void Show()
        {
            Console.WriteLine($"Название: {Name}, Цвет: {Color}");
        }

        // 1.5 Метод Init()
        public virtual void Init()
        {
            Console.Write("Введите название растения: ");
            Name = Console.ReadLine();

            Console.Write("Введите цвет растения: ");
            Color = Console.ReadLine();
        }

        // 1.6 Метод RandomInit()
        public virtual void RandomInit()
        {
            Name = "Plant" + random.Next(1, 100);
            Color = "Color" + random.Next(1, 10);
        }

        // 1.7 Метод Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Plant other = (Plant)obj;
            return Name == other.Name && Color == other.Color;
        }

        // Реализация интерфейса IComparable
        public int CompareTo(Plant other)
        {
            return string.Compare(Name, other.Name);
        }

        // Переопределение метода ToString для удобного вывода
        public override string ToString()
        {
            return $"Plant: Name={Name}, Color={Color}";
        }

        public object Clone()
        {
            // Создаем новый объект с такими же значениями полей и свойств
            Plant clonedPlant = new Plant(Name, Color, Id.Number);

            // Если Id имеет свою реализацию ICloneable, клонируем его
            if (Id is ICloneable cloneableId)
            {
                clonedPlant.Id = (IdNumber)cloneableId.Clone();
            }

            return clonedPlant;
        }
    }

    // Класс "Дерево" наследуется от "Растение"
    public class Tree : Plant, IInit, ICloneable
    {
        // 1.1 Поля
        private double height;
        private static readonly Random random = new Random();

        // 1.2 Свойства с проверкой ограничений
        public double Height
        {
            get { return height; }
            set
            {
                if (value >= 0)
                    height = value;
                else
                    Console.WriteLine("Некорректное значение для высоты дерева.");
            }
        }

        // 1.3 Конструкторы
        public Tree(string name, string color, double height, int id) : base(name, color, id)
        {
            Height = height;
        }

        public Tree() : base()
        {
            // Конструктор без параметров
        }

        // 1.4 Метод Show()
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Высота: {Height} м");
        }

        // 1.5 Метод Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Введите высоту дерева (в метрах): ");
            double.TryParse(Console.ReadLine(), out double treeHeight);
            Height = treeHeight;
        }

        // 1.6 Метод RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();
            Height = random.NextDouble() * 20;
        }

        // 1.7 Метод Equals
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Tree other = (Tree)obj;
            return Height == other.Height;
        }

        public new object Clone()
        {
            // Вызываем базовый метод Clone() и преобразуем результат к типу Tree
            return (Tree)base.Clone();
        }
    }

    // Класс "Цветок" наследуется от "Растение"
    public class Flower : Plant, IInit, ICloneable
    {
        // 1.1 Поля
        private string smell;
        private static readonly Random random = new Random();

        // 1.2 Свойства с проверкой ограничений
        public string Smell
        {
            get { return smell; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    smell = value;
                else
                    Console.WriteLine("Некорректное значение для запаха цветка.");
            }
        }

        // 1.3 Конструкторы
        public Flower(string name, string color, string smell, int id) : base(name, color, id)
        {
            Smell = smell;
        }

        public Flower() : base()
        {
            // Конструктор без параметров
        }

        // 1.4 Метод Show()
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Запах: {Smell}");
        }

        // 1.5 Метод Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Введите запах цветка: ");
            Smell = Console.ReadLine();
        }

        // 1.6 Метод RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();
            Smell = "Smell" + random.Next(1, 5);
        }

        // 1.7 Метод Equals
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Flower other = (Flower)obj;
            return Smell == other.Smell;
        }

        public new object Clone()
        {
            // Вызываем базовый метод Clone() и преобразуем результат к типу Flower
            return (Flower)base.Clone();
        }
    }

    // Класс "Роза" наследуется от "Цветок"
    public class Rose : Flower, IInit, ICloneable
    {
        // 1.1 Поля
        private bool hasThorns;
        private static readonly Random random = new Random();

        // 1.2 Свойства с проверкой ограничений
        public bool HasThorns
        {
            get { return hasThorns; }
            set { hasThorns = value; }
        }

        // 1.3 Конструкторы
        public Rose(string name, string color, string smell, bool hasThorns, int id) : base(name, color, smell, id)
        {
            HasThorns = hasThorns;
        }

        public Rose() : base()
        {
            // Конструктор без параметров
        }

        // 1.4 Метод Show()
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Наличие шипов: {(HasThorns ? "Да" : "Нет")}");
        }

        // 1.5 Метод Init()
        public override void Init()
        {
            base.Init();

            Console.Write("Есть ли шипы у розы? (true/false): ");
            bool.TryParse(Console.ReadLine(), out bool thorns);
            HasThorns = thorns;
        }

        // 1.6 Метод RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();
            HasThorns = random.Next(2) == 1;
        }

        // 1.7 Метод Equals
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Rose other = (Rose)obj;
            return HasThorns == other.HasThorns;
        }
        public new object Clone()
        {
            // Вызываем базовый метод Clone() и преобразуем результат к типу Rose
            return (Rose)base.Clone();
        }
    }

    public class Post : IInit
    {
        private int numViews;
        private int numComments;
        private int numReactions;
        private static int totalObjects = 0;
        private static readonly Random random = new Random();

        public Post(int numViews, int numComments, int numReactions)
        {
            this.numViews = numViews;
            this.numComments = numComments;
            this.numReactions = numReactions;
            totalObjects++;
        }

        public Post()
        {
            numViews = 0;
            numComments = 0;
            numReactions = 0;
            totalObjects++;
        }

        public Post(Post post)
        {
            this.numViews = post.numViews;
            this.numComments = post.numComments;
            this.numReactions = post.numReactions;
            totalObjects++;
        }

        public void Show()
        {
            Console.WriteLine($"{numViews}, {numComments}, {numReactions}");
        }

        public int NumViews
        {
            get { return this.numViews; }
            set { this.numViews = value; }
        }

        public int NumComments
        {
            get { return this.numComments; }
            set { this.numComments = value; }
        }

        public int NumReactions
        {
            get { return this.numReactions; }
            set { this.numReactions = value; }
        }

        public static double CalculateEngagementRateStatic(Post post, int totalSubscribers)
        {
            return (post.NumViews + post.NumComments + post.NumReactions) / (double)totalSubscribers * 100;
        }

        public double CalculateEngagementRate(int totalSubscribers)
        {
            return (numViews + numComments + numReactions) / (double)totalSubscribers * 100;
        }

        public static int GetTotalPostCount()
        {
            return totalObjects;
        }

        public static bool operator ==(Post p1, Post p2)
        {
            return (p1.numViews == p2.numViews &&
                    p1.numComments == p2.numComments &&
                    p1.numReactions == p2.numReactions);
        }

        public static bool operator !=(Post p1, Post p2)
        {
            return !(p1 == p2);
        }

        public static explicit operator bool(Post p)
        {
            return (p.numViews != 0 && (p.numComments != 0 || p.numReactions != 0));
        }

        public static implicit operator double(Post p)
        {
            double audienceCoverage = (double)(p.numViews) / 1000.0;
            return Math.Round(audienceCoverage, 2);
        }

        public static Post operator !(Post p)
        {
            p.numReactions++;
            return p;
        }

        public static Post operator ++(Post p)
        {
            p.numViews++;
            return p;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Post other = (Post)obj;
            return (numViews == other.numViews &&
                    numComments == other.numComments &&
                    numReactions == other.numReactions);
        }

        public override string ToString()
        {
            return $"{numViews}, {numComments}, {numReactions}";
        }

        public void Init()
        {
            Console.Write("Введите количество просмотров: ");
            int.TryParse(Console.ReadLine(), out int views);
            NumViews = views;

            Console.Write("Введите количество комментариев: ");
            int.TryParse(Console.ReadLine(), out int comments);
            NumComments = comments;

            Console.Write("Введите количество реакций: ");
            int.TryParse(Console.ReadLine(), out int reactions);
            NumReactions = reactions;
        }

        public void RandomInit()
        {
            NumViews = random.Next(0, 1000);
            NumComments = random.Next(0, 1000);
            NumReactions = random.Next(0, 1000);
        }
    }

}
