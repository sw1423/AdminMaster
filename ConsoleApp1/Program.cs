using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] chars = { 'a', 'b', 'c','d' };
            //Permutation(chars, 0);


            //ZebraPrintHelper.PrinterType = DeviceType.DRV;
            //ZebraPrintHelper.PrinterName = "Intermec PB32 (203 dpi) - IPL";
            //ZebraPrintHelper.IsWriteLog = true;
            ZebraPrintHelper.PrintWithDRV("test", "Intermec PB32 (203 dpi) - IPL", false);
            //ZebraPrintHelper.PrintCommand("test");
            //ZebraPrintHelper.SendStringToPrinter("Intermec PB32 (203 dpi) - IPL", "test");
            //PrintCode.SendStringToPrinter("Intermec PB32 (203 dpi) - IPL", "test");
            var list = PrinterHelper.GetPrinterList();
            PrinterHelper.SendStringToPrinter("Intermec PB32 (203 dpi) - IPL", "");
            Console.ReadKey();
        }
        public static void Dosomething(int i)
        {
            Console.WriteLine(i);
        }
        public static void Permutation(char[] chars, int begin)
        {
            // 如果是最后一个元素了，就输出排列结果
            if (chars.Length - 1 == begin)
            {
                Console.Write(new String(chars) + " ");
            }
            else
            {
                char tmp;
                // 对当前还未处理的字符串进行处理，每个字符都可以作为当前处理位置的元素
                for (int i = begin; i < chars.Length; i++)
                {
                    tmp = chars[begin];
                    chars[begin] = chars[i];
                    chars[i] = tmp;
                    // 处理下一个位置
                    Permutation(chars, begin + 1);


                    tmp = chars[begin];
                    chars[begin] = chars[i];
                    chars[i] = tmp;
                }
            }
        }
    }
}
