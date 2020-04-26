using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Laba2
{
    public class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Виберiть необхiдне для виконання завдання: \n1) Визначення закiнчення\n2) Таблиця функцii\n3) Масив Сума i добуток \n4) Масив  найменшi");
            int b = Convert.ToInt16(Console.ReadLine());
            switch (b)
            {
                case 1:
                    {
                        Task1();
                        break;
                    }
                case 2:
                    {
                        Task2();
                        break;
                    }
                case 3:
                    {
                        Task3();
                        break;
                    }
                case 4:
                    {
                        Task4();
                        break;
                    }
            }
            Console.ReadKey();
            Main();
        }
        public static string Task1()
        {
            Console.Clear();
            Console.WriteLine("Введiть вiк");
            string line;
            line = Console.ReadLine();
            string s = "";
            int Age = 0;
            try
            {
                Age = Convert.ToInt32(line);
                int Age2 = Age%10;
                
                if(Age2 == 1)
                {
                    Console.WriteLine(Age + " рiк");
                    s = "рік";
                }
                else if (Age2 > 1 && Age2 < 5 )
                {
                    Console.WriteLine(Age + " роки");
                    s = "роки";
                }
                else
                {
                    Console.WriteLine(Age + " рокiв");
                    s = "рокiв";
                }
            }
            catch
            {
                Console.WriteLine("Помилка, перевірте введені дані");
            }
            return s;
        }
        public static int Task2()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Формула y=ctg(x)-2sin(x)");
                double a = -(Math.PI / 2);
                double b = Math.PI / 2;
                while(a != b)
                {
                    double Res = ctg(a)-2*Math.Sin(a);
                    Console.WriteLine("x = " + a + "; F(x) = " + Res);
                    a += Math.PI / 20;
                }
            }
            catch
            {
                Console.WriteLine("Помилка, перевірте введені дані");
                Console.ReadKey();
                return 1;
            }
            return 0;
        }
        public static float Task3()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введiть кiлькiсть елементiв");
                int Count = 0;
                Count = Convert.ToInt16(Console.ReadLine());
                int[] array = new int[Count];
                Console.WriteLine("1) - Ввести значення самому\n2) Згенерувати випадково [-100,100]");
                int Res = 0;
                Res = Convert.ToInt16(Console.ReadLine());
                if (Res == 1)
                {
                    for(int i = 0;i < Count; i++)
                    {
                        Console.Write($"Array[{i}] = ");
                        array[i] = Convert.ToInt16(Console.Read());
                    }
                } 
                else if(Res != 0)
                {
                    var Rand = new Random();
                    for (int i = 0; i < Count; i++)
                    {
                        array[i] = Rand.Next(-100,100);
                    }
                }
                
                Console.Clear();
                float  sum = 0;
                float beforemin = 1;
                beforemin =  Taks3_Function(array,out sum);
                Console.WriteLine($"Кількість всiх додатнiх = {sum}\n Добуток усiх чисел перед мiнiмальним за модулем = {beforemin}");
                return sum + beforemin;

            }
            catch
            {
                Console.WriteLine("Помилка, перевiрте введенi данi");
                return -1000;
            }
        }
        public static float Task4()
        {

            try
            {
                Console.Clear();
                Console.WriteLine("Введiть кiлькiсть елементiв \nX=");
                int Count = 0;
                int CountY = 0;
                Count = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Y=");
                CountY = Convert.ToInt16(Console.ReadLine());
                int[,] array = new int[Count, CountY];
                Console.WriteLine("1) - Ввести значення самому\n2) Згенерувати випадково [-100,100]");
                int Res = 0;
                Res = Convert.ToInt16(Console.ReadLine());
                if (Res == 1)
                {
                    for (int x = 0; x < array.GetLength(0); x++)
                    {
                        for (int y = 0; y < array.GetLength(1); y++)
                        {
                            Console.Write($"Array[{x},{y}] = ");
                            array[x, y] = Convert.ToInt16(Console.Read());
                        }
                    }
                }
                else if(Res != 0)
                {
                    var Rand = new Random();
                    for (int x = 0; x < array.GetLength(0); x++)
                    {
                        for (int y = 0; y < array.GetLength(1); y++)
                        {
                            array[x, y] = Rand.Next(-100, 100);
                        }
                    }
                }
                Console.Clear();
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    for (int y = 0; y < array.GetLength(1); y++)
                    {
                        Console.Write(array[x, y] + ";");
                    }
                    Console.WriteLine("");
                }
                int Min1Pos = 0, Min2Pos = 1, Min1 = array[0, 0], Min2 = array[0, 1];
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    for (int y = 0; y < array.GetLength(1); y++)
                    {
                        if (array[x, y] < Min1)
                        {
                            Min2 = Min1;
                            Min1 = array[x, y];
                            Min2Pos = Min1Pos;
                            Min1Pos = x * 10 + y;
                        }
                        else if (array[x, y] < Min2 && Min1 > array[x, y])
                        {
                            Min2 = array[x, y];
                            Min2Pos = x * 10 + y;
                        }
                    }
                }
                Console.WriteLine(Min1Pos % 10 + ";" + Min2Pos % 10);
                int Psx = (Min1Pos - Min1Pos % 10) / 10;
                int Psy = Min1Pos % 10;
                array[Psx, Psy] = (array[Psx, Psy] == 0) ? (1) : (0);
                int Psx2 = (Min2Pos - Min2Pos % 10) / 10;
                int Psy2 = Min2Pos % 10;
                array[Psx2, Psy2] = (array[Psx2, Psy2] == 0) ? (1) : (0);
                Console.WriteLine($"Намйменші числа {Min1} і {Min2}, Опрацьований масив:");

                for (int x = 0; x < array.GetLength(0); x++)
                {
                    for (int y = 0; y < array.GetLength(1); y++)
                    {
                        if ((x == Psx && y == Psy) || (x == Psx2 && y == Psy2))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(array[x, y] + ";", Console.ForegroundColor);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.Write(array[x, y] + ";");
                        }
                    }
                    Console.WriteLine("");
                }
                Console.ReadKey();
                return Min1 + Min2;
            }
            catch
            {
                Console.WriteLine("Помилка, перевiрте введенi данi");
                Console.ReadKey();
                return -1;
            }
            
            
        }
        public static double ctg(double a)
        {
            return (1f / Math.Tan(a));
        }
        public static float Taks3_Function(int[] array, out float sum)
        {
            sum = 0;
            float beforemin = 1;
            int min = Math.Abs(array[0]);
            int MinPos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < min)
                {
                    min = Math.Abs(array[i]);
                    MinPos = i;
                }


            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    sum += 1;
                }
                if (i < MinPos)
                {
                    beforemin *= array[i];
                }
                if ((i + 1) % Math.Sqrt(array.Length) == 0)
                {
                    Console.WriteLine(array[i]);
                }
                else
                {
                    Console.Write(array[i] + ";");
                }
            }
            return beforemin;
        }
    }
}
