using System;

// Завдання 1: Клас Triangle (Трикутник)
public class Triangle
{
    // Захищені поля
    protected int a, b, c;
    protected int color;

    // Конструктор з перевіркою існування трикутника
    public Triangle(int sideA, int sideB, int sideC, int triangleColor = 0)
    {
        if (IsValidTriangle(sideA, sideB, sideC))
        {
            a = sideA;
            b = sideB;
            c = sideC;
            color = triangleColor;
        }
        else
        {
            throw new ArgumentException("Неможливо створити трикутник з такими сторонами!");
        }
    }

    // Перевірка існування трикутника
    private bool IsValidTriangle(int sideA, int sideB, int sideC)
    {
        return (sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideB + sideC > sideA) &&
               sideA > 0 && sideB > 0 && sideC > 0;
    }

    // Властивості для сторін (з перевіркою)
    public int SideA
    {
        get { return a; }
        set
        {
            if (IsValidTriangle(value, b, c))
                a = value;
            else
                throw new ArgumentException("Некоректна довжина сторони!");
        }
    }

    public int SideB
    {
        get { return b; }
        set
        {
            if (IsValidTriangle(a, value, c))
                b = value;
            else
                throw new ArgumentException("Некоректна довжина сторони!");
        }
    }

    public int SideC
    {
        get { return c; }
        set
        {
            if (IsValidTriangle(a, b, value))
                c = value;
            else
                throw new ArgumentException("Некоректна довжина сторони!");
        }
    }

    // Властивість для кольору (тільки для читання)
    public int Color
    {
        get { return color; }
    }

    // Метод для виведення довжин сторін
    public void PrintSides()
    {
        Console.WriteLine($"Сторони трикутника: a = {a}, b = {b}, c = {c}");
    }

    // Метод розрахунку периметра
    public int CalculatePerimeter()
    {
        return a + b + c;
    }

    // Метод розрахунку площі за формулою Герона
    public double CalculateArea()
    {
        double p = CalculatePerimeter() / 2.0; // напівпериметр
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Метод для виведення повної інформації
    public void Show()
    {
        PrintSides();
        Console.WriteLine($"Периметр: {CalculatePerimeter()}");
        Console.WriteLine($"Площа: {CalculateArea():F2}");
        Console.WriteLine($"Колір: {color}");
        Console.WriteLine();
    }
}

// Завдання 2: Ієрархія класів друкованих видань

// Базовий клас - Друковане видання
public class PrintedPublication
{
    protected string title;
    protected string author;
    protected int year;
    protected int pages;

    public PrintedPublication(string title, string author, int year, int pages)
    {
        this.title = title;
        this.author = author;
        this.year = year;
        this.pages = pages;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Назва: {title}");
        Console.WriteLine($"Автор: {author}");
        Console.WriteLine($"Рік видання: {year}");
        Console.WriteLine($"Кількість сторінок: {pages}");
    }

    // Властивість для сортування
    public int Pages { get { return pages; } }
    public string Title { get { return title; } }
}

// Похідний клас - Книга
public class Book : PrintedPublication
{
    protected string genre;
    protected string isbn;

    public Book(string title, string author, int year, int pages, string genre, string isbn)
        : base(title, author, year, pages)
    {
        this.genre = genre;
        this.isbn = isbn;
    }

    public override void Show()
    {
        Console.WriteLine("=== КНИГА ===");
        base.Show();
        Console.WriteLine($"Жанр: {genre}");
        Console.WriteLine($"ISBN: {isbn}");
        Console.WriteLine();
    }
}

// Похідний клас - Журнал
public class Magazine : PrintedPublication
{
    protected int issueNumber;
    protected string frequency;

    public Magazine(string title, string author, int year, int pages, int issueNumber, string frequency)
        : base(title, author, year, pages)
    {
        this.issueNumber = issueNumber;
        this.frequency = frequency;
    }

    public override void Show()
    {
        Console.WriteLine("=== ЖУРНАЛ ===");
        base.Show();
        Console.WriteLine($"Номер випуску: {issueNumber}");
        Console.WriteLine($"Періодичність: {frequency}");
        Console.WriteLine();
    }
}

// Похідний клас - Підручник
public class Textbook : Book
{
    protected string subject;
    protected string educationLevel;

    public Textbook(string title, string author, int year, int pages, string genre, string isbn, 
                   string subject, string educationLevel)
        : base(title, author, year, pages, genre, isbn)
    {
        this.subject = subject;
        this.educationLevel = educationLevel;
    }

    public override void Show()
    {
        Console.WriteLine("=== ПІДРУЧНИК ===");
        Console.WriteLine($"Назва: {title}");
        Console.WriteLine($"Автор: {author}");
        Console.WriteLine($"Рік видання: {year}");
        Console.WriteLine($"Кількість сторінок: {pages}");
        Console.WriteLine($"Жанр: {genre}");
        Console.WriteLine($"ISBN: {isbn}");
        Console.WriteLine($"Предмет: {subject}");
        Console.WriteLine($"Рівень освіти: {educationLevel}");
        Console.WriteLine();
    }
}

// Головний клас програми
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Демонстрація роботи з трикутниками
        Console.WriteLine("=== РОБОТА З ТРИКУТНИКАМИ ===");
        
        try
        {
            Triangle[] triangles = new Triangle[]
            {
                new Triangle(3, 4, 5, 1),
                new Triangle(6, 8, 10, 2),
                new Triangle(5, 5, 5, 3),
                new Triangle(7, 24, 25, 4)
            };

            foreach (Triangle triangle in triangles)
            {
                triangle.Show();
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\n=== РОБОТА З ДРУКОВАНИМИ ВИДАННЯМИ ===");
        
        // Створення масиву друкованих видань
        PrintedPublication[] publications = FillPublicationsArray();
        
        Console.WriteLine("Початковий масив:");
        foreach (PrintedPublication pub in publications)
        {
            pub.Show();
        }

        // Сортування за кількістю сторінок
        Array.Sort(publications, (x, y) => x.Pages.CompareTo(y.Pages));
        
        Console.WriteLine("Масив, відсортований за кількістю сторінок:");
        foreach (PrintedPublication pub in publications)
        {
            pub.Show();
        }
    }

    // Функція наповнення масиву різними об'єктами
    static PrintedPublication[] FillPublicationsArray()
    {
        return new PrintedPublication[]
        {
            new Magazine("Наука і життя", "Редколегія", 2023, 64, 12, "Щомісячно"),
            new Book("Майстер і Маргарита", "Михайло Булгаков", 1967, 480, "Фантастика", "978-5-17-082454-8"),
            new Textbook("Алгебра", "Мерзляк А.Г.", 2020, 256, "Навчальна література", 
                        "978-966-11-0234-5", "Математика", "8 клас"),
            new Magazine("Комп'ютерне обладнання", "Tech Team", 2023, 48, 3, "Щомісячно"),
            new Book("Кобзар", "Тарас Шевченко", 1840, 200, "Поезія", "978-966-03-4567-8"),
            new Textbook("Фізика", "Божинова Ф.Я.", 2021, 320, "Навчальна література", 
                        "978-966-11-1234-5", "Фізика", "10 клас")
        };
    }
}
