using System;
using System.Collections.Generic;
using System.Text;

namespace cviceni2021114
{
    static class Extension
    {
        public static bool IsCountEven(this List<string> list)
        {
            return (list.Count % 2 == 0);
        }

        public static List<string> Even(this List<string> list)
        {
            List<string> result = new List<string>();
            for(int i=0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                    result.Add(list[i]);
            }
            return result;
        }

        public static List<string> ShorterThen(this List<string> list, int count)
        {
            List<string> result = new List<string>();
            foreach (var item in list)
            {
                if(item.Length < count)
                {
                    result.Add(item);
                    
                }
            }
            return result;
        }
    }
}
