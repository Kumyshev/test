using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    class Test
    {
        public void TZ(string str)
        {
            StreamReader file = new StreamReader(@"c:\test.txt");

            List<float> list = new List<float>();

            while ((str = file.ReadLine()) != null)
            {
                string[] arr = str.Remove(0, 2).Split(' ').ToArray();

                int num = 0;
                int itogo = 0;

                switch (str[0])
                {
                    case '1':
                        foreach (var ch in arr)
                        {
                            num += Convert.ToInt32(ch); itogo = num % 255;
                        }
                        break;
                    case '2':
                        itogo = 1;
                        foreach (var ch in arr)
                        {
                            num *= Convert.ToInt32(ch.ToString()); itogo = num % 255;
                        }
                        break;
                    case '3':
                        itogo = arr.Select(x => Convert.ToInt32(x.ToString())).Max();
                        break;
                    case '4':
                        itogo = arr.Select(x => Convert.ToInt32(x.ToString())).Min();
                        break;
                }

                List<int> nums = Enumerable.Range(3, 1000001).Where(x => x % 3 == 0).ToList();


                foreach (var n in nums)
                {
                    list.Add(itogo / n);
                }

                float k = Math.Abs(list.Sum()) / list.Count();

                Console.WriteLine(k);
            }
            Console.ReadKey();
        }
    }
}
