using System.Text;

namespace ОП_ПР_5
{
    internal class Program
    {
        static void Exercise_1()
        {
            Console.WriteLine("Введіть речення:");
            string str = Console.ReadLine()!;
            int maxWhitespaces = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    int temp = 0;
                    while (i < str.Length && str[i] == ' ')
                    {
                        temp++;
                        i++;
                    }
                    maxWhitespaces = Math.Max(maxWhitespaces, temp);
                }
            }
            Console.WriteLine("Максимальна кількість пробілів підряд: " + maxWhitespaces);
        }

        static void Exercise_2()
        {
            Console.WriteLine("Введіть речення: ");
            string str = Console.ReadLine()!;
            if(str.Length > 0)
            {
                var maxCount = from chars in str
                               group chars by chars into maximum
                               select maximum;
                int maxQ = maxCount.Select(x => x.Count()).Max();
                Console.WriteLine("Найбільша кількість однакових символів -- " + maxQ + " для:");
                foreach (var c in maxCount)
                {
                    if (c.Count() == maxQ) Console.WriteLine(c.Key);
                }
            }
            else { Console.WriteLine("Тексту не було надано"); }
        }

        static void Exercise_3()
        {
            Console.WriteLine("Введіть слово: ");
            var str = Console.ReadLine()!.ToLower();
            Console.WriteLine("Кількість різних літер: " + str.Distinct().Count());
        }

        static void Exercise_4()
        {
            Console.WriteLine("Введіть слово: ");
            string str = Console.ReadLine()!.ToLower();
            Dictionary<char, int> check = new();
            int i = 0;
            bool happened = false;
            if (str.Length != 0)
            {
                for (; i < str.Length; i++)
                {
                    if (check.ContainsKey(str[i]))
                    {
                        happened = true;
                        break;
                    }
                    else
                    {
                        check.Add(str[i], i);
                    }
                }
                if (happened)
                {
                    Console.WriteLine($"Літера {str[i]} зустрічається двічі: вперше на позиції {check[str[i]]}, вдруге на позиції {i}");
                }
                else
                {
                    Console.WriteLine("Усі символи зустрічаються один раз");
                }
            }
            else { Console.WriteLine("Рядок має довжину 0"); }
        }

        static void Exercise_5()
        {
            Console.WriteLine("Введіть перше слово:");
            string str1 = Console.ReadLine()!.ToLower();
            Console.WriteLine("Введіть друге слово:");
            string str2 = Console.ReadLine()!.ToLower();

            HashSet<char> set = new HashSet<char>(str2);
            foreach (var item in str1.Distinct())
            {
                if (set.TryGetValue(item, out _)) { Console.WriteLine($"Літера {item} входить до другого слова"); continue; }
                Console.WriteLine($"Літера {item} не входить до другого слова");
            }
        }

        static void Exercise_6()
        {
            Console.WriteLine("Введіть перше слово:");
            string str1 = Console.ReadLine()!.ToLower();
            Console.WriteLine("Введіть друге слово:");
            string str2 = Console.ReadLine()!.ToLower();

            HashSet<char> set = new HashSet<char>(str2);
            Console.WriteLine("Літери, що є в першому слові, але не в другому: ");
            foreach (var item in str1.Distinct())
            {
                if (set.TryGetValue(item, out _)) continue;
                Console.Write($"{item} ");
            }
        }

        static void Exercise_7()
        {
            Console.WriteLine("Введіть перше слово: ");
            char[] str1 = Console.ReadLine()!.ToLower().ToCharArray();

            Console.WriteLine("Введіть перше слово: ");
            char[] str2 = Console.ReadLine()!.ToLower().ToCharArray();

            var noDuplicatesStr1 = str1
                                  .GroupBy(i => i)
                                  .Where(g => g.Count() == 1)
                                  .Select(g => g.Key);

            var noDuplicatesStr2 = str2
                                  .GroupBy(i => i)
                                  .Where(g => g.Count() == 1)
                                  .Select(g => g.Key);

            var ans = noDuplicatesStr1.Intersect(noDuplicatesStr2);
            Console.WriteLine("В обох словах присутні і зустрічаються один раз наступні літери:");
            foreach (var i in ans) { Console.WriteLine(i); }
        }

        static void Exercise_10()
        {
            Console.WriteLine("Введіть речення");
            string str = Console.ReadLine()!;
            char[] delimiterChars = { ' ', ',', '.', ':', ';'};
            string[] ans = str.Split(delimiterChars).Where(x => x != "").ToArray();
            Console.WriteLine($"Було створено масив {nameof(ans)} з наступними елементами: ");
            foreach (var i in ans)
            {
                Console.WriteLine(i);
            }
        }

        static void Exercise_11()
        {
            Console.WriteLine("Введіть речення: ");
            string[] strArr = Console.ReadLine()!.Split(' ');
            if (strArr.Length > 0)
            {
                Console.WriteLine("У зворотному порядку: ");
                for (int i = strArr.Length - 1; i >= 0; i--)
                {
                    Console.Write(strArr[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Речення не було введене");
            }
        }

        static void Exercise_13()
        {
            Console.WriteLine("Введіть речення");
            string str = Console.ReadLine()!.ToLower();
            char[] delimiterChars = { ' ', ',', '.', ':', ';' };
            string[] ans = str.Split(delimiterChars).Where(x => x != "").ToArray();
            Console.WriteLine("Слова що починаються з \"_\": ");
            foreach (var i in ans)
            {
                if(i.StartsWith('_')) Console.WriteLine(i);
            }
        }

        static void Exercise_14()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', ';' };
            Console.WriteLine("Введіть речення: ");
            string[] str = Console.ReadLine()!.Split(delimiterChars).Where(x => x != "").ToArray(); ;
            Array.Sort(str, (a, b) => a.Length > b.Length ? -1 : 1);
            Console.WriteLine("Слова у порядку спадання: ");
            foreach (var i in str)
            {
                Console.WriteLine(i);
            }

        }

        static void Exercise_15()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', ';' };
            Console.WriteLine("Введіть речення: ");
            string[] str = Console.ReadLine()!.ToLower().Split(delimiterChars);
            var noDuplicates = str
                                  .GroupBy(i => i)
                                  .Where(g => g.Count() == 1 && g.Key != "")
                                  .Select(g => g.Key);
            Console.WriteLine("Слова, що зустрічаються один раз: ");
            foreach (var i in noDuplicates)
            {
                Console.WriteLine(i);
            }
        }

        static void Exercise_17()
        {
            Console.WriteLine("Введіть речення: ");
            string[] strs = Console.ReadLine()!.ToLower().Split(" ");

            string toCompare = strs[0];

            var query = from s in strs
                        where s != toCompare && s.Length%2==0 && s.Distinct().Count() == s.Length
                        select s;
            Console.WriteLine("Умову задовольняють наступні слова: ");
            foreach (var str in query) { Console.WriteLine(str); }
        }

        static void Exercise_18()
        {
            Console.WriteLine("Введіть текст: ");
            string strs = Console.ReadLine()!;
            if (strs.Length == 0)
            {
                Console.WriteLine("Текст відсутній");
                return;
            }
            bool marker = false;
            foreach(var i in strs)
            {
                if(i == '(' && !marker)
                {
                    marker = true;
                }
                else if(i == ')' && marker)
                {
                    marker = false;
                }
                else if(i != '(' && i != ')')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Дужки розставлені неправильно");
                    return;
                }
            }
            Console.WriteLine("Все правильно");
        }



        static void Main()
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;
            Exercise_18();
        }
    }
}