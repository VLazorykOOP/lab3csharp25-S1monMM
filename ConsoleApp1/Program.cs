namespace Lab3Charp
{
    using System;
    internal class Program
    {
        /* 
        
        Старт першого завдання

        */
        class Point
        {
            private int x;
            private int y;
            private int c;
            public Point()
            {
                this.x = 0;
                this.y = 0;
                this.c = 0;
            }
            public Point(int dX, int dY, int color)
            {
                this.x = dX;
                this.y = dY;
                this.c = color;
            }

            public void getCords()
            {
                Console.WriteLine("X,Y = " + this.x + "," + this.y);
            }

            public double getDistance()
            {
                double distance = Math.Sqrt((x * x) + (y * y));
                Console.WriteLine("Distance = " + distance);
                return distance;
            }

            public void moveByVector(int x1, int y1)
            {
                Console.WriteLine("Old dot:" + this.x + "," + this.y);
                this.x += x1;
                this.y += y1;
                Console.WriteLine("New dot:" + this.x + "," + this.y);
            }

            public int X
            {
                get { return this.x; }
                set { this.x = value; }
            }

            public int Y
            {
                get { return this.y; }
                set { this.y = value; }
            }

            public int Color
            {
                get { return this.c; }
            }
        }

        /* 
        
        Кінець першого завдання
        
        */
        /* 
        
        Початок другого завдання
        
        */

        class Person
        {
            protected string Name;
            protected int age;
            protected int Salary;

            public Person(string name, int age, int salary)
            {
                this.Name = name;
                this.age = age;
                this.Salary = salary;
            }

            public virtual void Show()
            {
                Console.WriteLine("Name: " + this.Name + ", Age: " + this.Age + ", Salary: " + this.Salary);
            }

            public int Age
            {
                get { return age; }
            }
        }

        class Student : Person
        {
            private string Faculty;

            public Student(string name, int age, string faculty) : base(name, age, 0)
            {
                this.Faculty = faculty;
            }

            public override void Show()
            {
                Console.WriteLine("Student: " + this.Name + ", Age: " + this.Age + ", Faculty: " + this.Faculty);
            }
        }

        class Teacher : Person
        {
            protected string Subject;
            protected int Experience;

            public Teacher(string name, int age, int salary, string subject, int experience) : base(name, age, salary)
            {
                this.Subject = subject;
                this.Experience = experience;
            }

            public override void Show()
            {
                Console.WriteLine("Teacher: " + this.Name + ", Age: " + this.Age + ", Subject: " + this.Subject + ", Experience: " + this.Experience + " years, Salary: " + this.Salary);
            }
        }

        class HeadOfDepartment : Teacher
        {
            private string Department;

            public HeadOfDepartment(string name, int age, int salary, string subject, int experience, string department) : base(name, age, salary, subject, experience)
            {
                this.Department = department;
            }

            public override void Show()
            {
                Console.WriteLine("Head of Department: " + this.Name + ", Age: " + this.Age + ", Subject: " + this.Subject + ", Experience: " + this.Experience + " years, Department: " + this.Department + ", Salary: " + this.Salary);
            }
        }

        /* 
        
        Кінець другого завдання
        
        */

        static void Main(string[] args)
        {

            void task1()
            {

                Console.WriteLine("Create Point in (2,1) with colour 255");
                Point dot = new Point(2, 1, 255);
                dot.getCords();
                dot.getDistance();

                Console.WriteLine("Moving by vector (5,7)");
                dot.moveByVector(5, 7);
                Console.WriteLine("New cords");
                dot.getCords();

                Console.WriteLine("Sequence of Points");
                Point[] points = new Point[]
                {
                    new Point(3, 4, 100),
                    new Point(-5, 12, 200),
                    new Point(8, -15, 150),
                    new Point(7, 24, 50),
                    new Point(-10, -10, 75)
                };

                foreach (var point in points)
                {
                    point.getCords();
                    point.getDistance();
                }

                double avgDistance = 0;
                foreach (var point in points)
                {
                    avgDistance += point.getDistance();
                }
                avgDistance /= points.Length;

                Console.WriteLine("Average distance: " + avgDistance);
                Console.WriteLine("Moving Point (that farther than average) by vector (-2,-3):");

                foreach (var point in points)
                {
                    if (point.getDistance() > avgDistance)
                    {
                        point.moveByVector(-2, -3);
                    }
                    point.getCords();
                }
            }

            void task2()
            {
                Person[] people = new Person[]{
                    new Student("Andrey", 20, "FMI"),
                    new Student("Maria", 22, "FBR"),
                    new Teacher("Petro", 45, 25000, "Mathematics", 20),
                    new Teacher("Olena", 38, 27000, "Programming", 15),
                    new HeadOfDepartment("Serhiy", 50, 35000, "Computer Science", 25, "IT Department")
                };

                Console.WriteLine("Data before sorting:");

                foreach (var person in people)
                {
                    person.Show();
                }

                for (int i = 0; i < people.Length - 1; i++)
                {
                    for (int j = 0; j < people.Length - i - 1; j++)
                    {
                        if (people[j].Age > people[j + 1].Age)
                        {
                            Person temp = people[j];
                            people[j] = people[j + 1];
                            people[j + 1] = temp;
                        }
                    }
                }

                Console.WriteLine("\nData after sorting by age:");
                foreach (var person in people)
                {
                    person.Show();
                }
            }

            void choose_task()
            {
                Console.Write("1. Point\n2. Hierarchy\n");
                int answer = Convert.ToInt16(System.Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        {
                            task1();
                            Console.Write("\n\n\n");
                            choose_task();
                            break;
                        }
                    case 2:
                        {
                            task2();
                            Console.Write("\n\n\n");
                            choose_task();
                            break;
                        }
                    default:
                        {
                            choose_task();
                            break;
                        }
                }
            }
            choose_task();
        }
    }
}
