using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomLib
{
    public class OtherHelper
    {
        public static List<T> GetRandomList<T>(List<T> inputList)
        {
            //Copy to a array
            T[] copyArray = new T[inputList.Count];
            inputList.CopyTo(copyArray);

            //Add range
            List<T> copyList = new List<T>();
            copyList.AddRange(copyArray);

            //Set outputList and random
            List<T> outputList = new List<T>();
            Random rd = new Random(DateTime.Now.Millisecond);

            while (copyList.Count > 0)
            {
                //Select an index and item
                int rdIndex = rd.Next(0, copyList.Count - 1);
                T remove = copyList[rdIndex];

                //remove it from copyList and add it to output
                copyList.Remove(remove);
                outputList.Add(remove);
            }
            return outputList;
        }
        #region 获得字符串中开始和结束字符串中间得值
        /// <summary>
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="begin">开始匹配标记</param>
        /// <param name="end">结束匹配标记</param>
        /// <param name="html">Html字符串</param>
        /// <returns>返回中间字符串</returns>
        public static MatchCollection GetMidValue(string begin, string end, string html)
        {
            Regex reg = new Regex("(?<=(" + begin + "))[.\\s\\S]*?(?=(" + end + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return reg.Matches(html);
        }
        #endregion
        public static string NameForTime()
        {
            System.DateTime CurrentTime = new System.DateTime();
            CurrentTime = System.DateTime.Now;
            string sName = CurrentTime.Year.ToString();
            sName += CurrentTime.Month.ToString();
            sName += CurrentTime.Day.ToString();
            sName += CurrentTime.Hour.ToString();
            sName += CurrentTime.Minute.ToString();
            sName += CurrentTime.Second.ToString();
            Random rnd = new Random();
            int sRnd = rnd.Next(1, 10000);
            sName += sRnd.ToString();
            return sName;
        }

        public static string NameForTime2()
        {
            string sName = System.DateTime.Now.ToString("yyyyMMdddHHmmss");

            Random rnd = new Random();
            int sRnd = rnd.Next(1, 10000);
            sName += sRnd.ToString();
            return sName;
        }
        public static string GetStr(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string stre in list)
            {
                sb.Append(stre + ",");
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        //获取next  
        public static int[] GetKmpNext(string pattern)
        {
            int[] next = new int[pattern.Length];
            next[0] = -1;
            if (pattern.Length < 2) return next;
            next[1] = 0;
            int i = 2, j = 0;
            while (i < pattern.Length)
            {
                if (pattern[i - 1] == pattern[j])
                {
                    next[i++] = ++j;
                }
                else
                {
                    j = next[j];
                    if (j == -1)
                    {
                        next[i++] = ++j;
                    }
                }
            }
            return next;
        }
        /// <summary>  
        /// 查询关键字方法  
        /// </summary>  
        /// <param name="source">原字符串</param>  
        /// <param name="keywords">关键字列表用|分开</param>  
        /// <returns>如果存在关键字返回true，反之返回false。</returns>  
        public static bool SearchKeywords(string source, string[] keywords,out string key)
        {
            int wordCount = keywords.Length;
            key = "";
            int[][] nexts = new int[wordCount][];
            int i = 0;
            for (i = 0; i < wordCount; i++)
            {
                nexts[i] = GetKmpNext(keywords[i]);
            }
            i = 0;
            int[] j = new int[nexts.Length];
            while (i < source.Length)
            {
                for (int k = 0; k < wordCount; k++)
                {
                    if (source[i] == keywords[k][j[k]])
                    {
                        j[k]++;
                    }
                    else
                    {
                        j[k] = nexts[k][j[k]];
                        if (j[k] == -1)
                        {
                            j[k]++;
                        }
                    }
                    if (j[k] >= keywords[k].Length)
                    {
                        key =  keywords[k];
                        return true;
                    }
                }
                i++;
            }
            return false;
        }  

    }
}
