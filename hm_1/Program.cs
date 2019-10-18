using System;


namespace _1_hm
{
    class Program
    {
        static void oper()
        {
            Console.WriteLine("\nВведите через пробел 2 числа и знак операции.");
            Console.WriteLine("Чтобы выйти, введите заместо знака 0.");
            var t = Console.ReadLine().Split(' ');
            Double a = 0, b = 0;
            char op = 'ы';
            try
            {
                a = Double.Parse(t[0]);
                b = Double.Parse(t[1]);
                op = Char.Parse(t[2]);

            }
            catch (Exception)
            {
                Console.WriteLine("Проверьте корректность входных данных\n");
                oper();
                return;
            }

            switch (op)
            {
                case '+':
                    Console.WriteLine($"{a} + {b} = {a + b}");
                    break;
                case '-':
                    Console.WriteLine($"{a} - {b} = {a - b}");
                    break;
                case '*':
                    Console.WriteLine($"{a} * {b} = {a * b}");
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Проверьте корректность входных данных\n");
                        oper();
                        return;
                    }
                    else
                        Console.WriteLine($"{a} / {b} = {a / b}");
                    break;
                case '0':
                    Console.WriteLine("Выходим...\n");
                    break;
                default:
                    Console.WriteLine("Введена неверная операция.");
                    break;
            }
            if (op != '0') oper();
        }

        static void qsort_lol(ref int[] ar, int t)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < ar.Length - i - 1; j++)
                {
                    if ((t == 0 && ar[j] > ar[j + 1]) ||
                        (t == 1 && ar[j] < ar[j + 1]))
                    {
                        int t1 = ar[j];
                        ar[j] = ar[j + 1];
                        ar[j + 1] = t1;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string req = "1";
            while (req != "0")
            {
                Console.WriteLine("\nВвeдите номер выбранного пункта:");
                Console.WriteLine("1. Hello world");
                Console.WriteLine("2. Арифметические операции");
                Console.WriteLine("3. Генерация массива");
                Console.WriteLine("4. Сортировка массива");
                Console.WriteLine("5. Формулы");
                Console.WriteLine("6. Обработка текста");
                Console.WriteLine("0. выйти\n");

                req = Console.ReadLine();
                switch (req)
                {
                    case "1":
                        Console.WriteLine("Hello, world!\n");
                        break;
                    case "2":
                        oper();
                        break;
                    case "3":
                        Console.Write("Введите длину массива: ");
                        int len = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nВведите диапазон для генерации чисел.");
                        
                        Console.Write("Введите min: ");
                        var min = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Введите max: ");
                        var max = Convert.ToInt32(Console.ReadLine());

                        int[] array = new int[len];
                        Random rnd = new Random();
                        for (int i = 0; i < len; i++)
                        {
                            array[i] = rnd.Next(min, max + 1);
                            Console.WriteLine($"array[{i}] = {array[i]}");
                        }
                        break;
                    case "4":

                        int[] ar = new int[10];

                        Console.Write("{ ");
                        for (int i = 0; i < ar.Length; i++)
                        {
                            Random rnd1 = new Random();
                            ar[i] = rnd1.Next(-100, 101);
                            Console.Write($"{ar[i]} ");
                        }
                        Console.WriteLine("}");

                        Console.WriteLine("Отсортировать ");
                        Console.WriteLine("0. По возрастанию");
                        Console.WriteLine("1. По убыванию");

                        var t = Convert.ToInt32(Console.ReadLine());

                        qsort_lol(ref ar, t);
                        
                        Console.Write("{ ");
                        for (int i = 0; i < ar.Length; i++)
                        {
                            Console.Write($"{ar[i]} ");
                        }
                        Console.WriteLine("}");

                        break;

                    case "5":
                        Console.WriteLine("Выберите формулу: ");
                        Console.WriteLine("0. y = sin(x) * tg(sin(cos(x^2)))");
                        Console.WriteLine("1. y = x * (2x - 1)^2 * (x + 3)^3");
                        Console.WriteLine("2. y = tg(x) * tg(2x) / (a^2 + b^2 + 1)");
                        Console.WriteLine("3. sum(1 / ((k + 1) * (k + 2)), где k принимает значения от 1 до b");
                        Console.WriteLine("4. y = (1 / sqrt(6)) * ln(|((2x + 1) * sqrt(2) + sqrt(3 * (x^2 + x - 1))) / \n((2x + 1) * sqrt(2) - sqrt(3 * (x^2 + x - 1)))|)");
                        Console.WriteLine("5. Назад\n");

                        var t1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        int x, a, b;

                        switch (t1)
                        {
                            case 0:
                                Console.Write("Введите x: ");
                                x = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("y = {0}", Math.Sin(x) * Math.Tan(Math.Sin(Math.Cos(x * x))));
                                break;
                            case 1:
                                Console.Write("Введите x: ");
                                x = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("y = {0}", x * Math.Pow(2 * x - 1, 2) * Math.Pow(x + 3, 3));
                                break;
                            case 2:
                                Console.Write("Введите x: ");
                                x = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите a: ");
                                a = Convert.ToInt32(Console.ReadLine());
                                
                                Console.Write("Введите b: ");
                                b = Convert.ToInt32(Console.ReadLine());
                                
                                Console.WriteLine("y = {0}", Math.Tan(x) * Math.Tan(2 * x) / (a * a + b * b + 1));
                                break;
                            case 3:
                                Console.Write("Введите b: ");
                                b = Convert.ToInt32(Console.ReadLine());
                                
                                double res = 0;
                                for (int i = 1; i <= b; i++)
                                {
                                    res += (double)1 / (double)((i + 1) * (i + 2));
                                }
                                
                                Console.WriteLine("y = {0}", res);
                                break;
                            case 4:
                                Console.Write("Введите x: ");
                                x = Convert.ToInt32(Console.ReadLine());
                                
                                Console.WriteLine("y = {0}", (1 / Math.Sqrt(6)) * Math.Log(Math.Abs((2 * x + 1) * Math.Sqrt(2) + 
                                    Math.Sqrt(3 * (x * x + x - 1)) / 
                                    ((2 * x + 1) * Math.Sqrt(2) - Math.Sqrt(3 * (x * x + x - 1)))))
                                );
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Введите вашу строку и нажми <Enter>");
                        string S = Console.ReadLine();

                        string S_t = S;
                        var bad_chars = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ",", "'", "\"",
                        ".", "-", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "<", ">", "?", "|", "`", "~"};
                        foreach (var i in bad_chars)
                            S_t = S_t.Replace(i, " ");

                        int n_word = 0;
                        foreach (var i in S_t.Split(' '))
                            if (i != "")
                                n_word++;

                        int n_symb_without_space = 0;
                        for (int i = 0; i < S.Length; i++)
                            if (S[i] != ' ')
                                n_symb_without_space++;

                        Console.WriteLine("Количество слов: {0};", n_word);
                        Console.WriteLine("Количество символов без пробелов: {0};", n_symb_without_space);
                        Console.WriteLine("Соотношение количество символов без пробелов к количеству слов: {0};",
                            string.Format("{0:0.##}", n_symb_without_space / (double)n_word));

                        string S_t1 = "";
                        foreach (var i in S_t.Split(' '))
                            if (i != "")
                                S_t1 += i[i.Length - 1];
                        Console.WriteLine("Слово из последних символов слов: “{0}”.", S_t1);
                        break;
                }

            }
        }
    }
}
