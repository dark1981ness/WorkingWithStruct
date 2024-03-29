﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WorkingWithStruct
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        static void Main(string[] args)
        {
            string result = "2998589353917872714814599237991174513476623756395992135212546127959342974628712329595771672911914471";
            char digit = '3';
            int i = 0;
            double max = double.MinValue;
            int idx;
            string tmpString = string.Empty;
            double tmpRes;

            while (i < result.Length)
            {
                //idx = result.IndexOf(digit, i);

                //if (idx == 0)
                //{
                //    tmpString = result.Substring(idx + 1);
                //    i += idx + 1;
                //}
                //if (idx == result.Length - 1)
                //{
                //    tmpString = result.Substring(0, idx);
                //    i++;
                //}
                //if (idx > 0 && idx < result.Length - 1)
                //{
                //    tmpString = result.Substring(0, idx) + result.Substring(idx + 1);
                //    i++;
                //}


                i = result.IndexOf(digit, i);

                if (i == -1) break;

                if (i == 0)
                {
                    tmpString = result.Substring(i + 1);
                    i++;
                }
                else if (i == result.Length - 1)
                {
                    tmpString = result.Substring(0, i);
                    i++;
                }
                else if (i > 0 && i < result.Length - 1)
                {
                    tmpString = result.Substring(0, i) + result.Substring(i + 1);
                    i++;
                }
                

                max = Math.Max(max, Convert.ToDouble(tmpString));
            }

            Console.WriteLine(String.Format("{0:f0}",max));

        }

        #region 2259. Remove Digit From Number to Maximize Result

        public static string RemoveDigit(string number, char digit)
        {
            int i = 0;
            double max = double.MinValue;
            string tmpString = string.Empty;

            while (i < number.Length)
            {

                i = number.IndexOf(digit, i);

                if (i == -1) break;

                if (i == 0)
                {
                    tmpString = number.Substring(i + 1);
                    i++;
                }
                else if (i == number.Length - 1)
                {
                    tmpString = number.Substring(0, i);
                    i++;
                }
                else if (i > 0 && i < number.Length - 1)
                {
                    tmpString = number.Substring(0, i) + number.Substring(i + 1);
                    i++;
                }

                max = Math.Max(max, Convert.ToDouble(tmpString));
            }

            return String.Format("{0:f0}", max);
        }

        #endregion

        #region 2423. Remove Letter To Equalize Frequency

        public static bool EqualFrequency(string word)
        {
            return word.Length - new HashSet<char>(word).Count <= 1;

        }

        #endregion

        #region 2273. Find Resultant Array After Removing Anagrams

        public static IList<string> RemoveAnagrams(string[] words)
        {
            IList<string> tempWords = words.ToList();

            for (int i = 1; i < tempWords.Count; i++)
            {
                bool isEqual = tempWords[i].OrderBy(x => x)
                    .SequenceEqual(tempWords[i - 1].OrderBy(x => x));

                if (isEqual)
                {
                    tempWords.Remove(tempWords[i]);
                    i--;
                }
            }

            return tempWords;
        }

        #endregion


        #region 2287. Rearrange Characters to Make Target String

        public static int RearrangeCharacters(string s, string target)
        {
            int[] freqArrS = new int[26];
            int[] freqArrT = new int[26];
            int result = int.MaxValue;

            foreach (char item in s)
            {
                freqArrS[item - 97]++;
            }

            foreach (char item in target)
            {
                freqArrT[item - 97]++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (freqArrT[i] > 0)
                {
                    result = Math.Min(result, freqArrS[i] / freqArrT[i]);
                }
            }

            return result;
        }

        #endregion

        #region 2451. Odd String Difference

        public static string OddString(string[] words)
        {
            string result = string.Empty;
            Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();

            for (int i = 0; i < words.Length; i++)
            {
                List<int> ints = new List<int>();
                for (int j = 0; j < words[i].Length - 1; j++)
                {
                    int tmp = words[i][j + 1] - words[i][j];
                    ints.Add(tmp);
                }

                keyValuePairs.Add(i, ints);
            }

            return result;
        }

        #endregion

        #region 2269. Find the K-Beauty of a Number

        public static int DivisorSubstrings(int num, int k)
        {
            int result = 0;
            int del = (int)Math.Pow(10, k);
            int tmpNum = num;

            string tmpStr = num.ToString();

            for (int i = 0; i <= tmpStr.Length - k; i++)
            {
                if ((num % del != 0) && (tmpNum % (num % del) == 0))
                {
                    result++;
                }

                num /= 10;
            }

            return result;
        }

        #endregion

        #region 2129. Capitalize the Title

        public static string CapitalizeTitle(string title)
        {
            string[] strings = title.Split(' ');
            string result = string.Empty;

            int i = 0;

            if (title.Length == 1)
            {
                return result += title.ToLower();
            }

            while (i < strings.Length)
            {
                if (strings[i].Length == 1 || strings[i].Length == 2)
                {
                    result += (strings[i].ToLower() + " ");
                }
                else
                {
                    result += (char.ToUpper(strings[i][0]) + strings[i][1..].ToLower() + " ");
                }

                i++;
            }


            return result.Trim();
        }

        #endregion

        #region 2138. Divide a String Into Groups of Size k

        public static string[] DivideString(string s, int k, char fill)
        {
            List<string> list = new List<string>();
            int partsCount = s.Length / k;

            if (s.Length % k == 0)
            {
                for (int i = 0, j = 0; i < partsCount; i++, j += k)
                {
                    list.Add(s.Substring(j, k));
                }
            }
            else
            {
                int count = k - s.Length % k;
                string fillStr = new string(fill, count);

                for (int i = 0, j = 0; i <= partsCount - 1; i++, j += k)
                {
                    list.Add(s.Substring(j, k));
                }

                list.Add(s.Substring((s.Length - s.Length % k), s.Length % k) + fillStr);
            }

            return list.ToArray();
        }

        #endregion

        #region 2264. Largest 3-Same-Digit Number in String

        public static string LargestGoodInteger(string num)
        {
            int maxvalue = int.MinValue;
            string result = string.Empty;
            int k = 3;

            for (int i = 0; i < num.Length - (k - 1); i++)
            {
                if (num[i] == num[i + 1] && num[i] == num[i + 2])
                {
                    if (maxvalue < num[i] - 48)
                    {
                        maxvalue = num[i] - 48;
                        result = num.Substring(i, k);
                    }
                }
            }

            return result;
        }

        #endregion

        #region 1624. Largest Substring Between Two Equal Characters

        public static int MaxLengthBetweenEqualCharacters(string s)
        {
            int maxSubLength = int.MinValue;

            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();


            for (int i = 0; i < s.Length; i++)
            {
                int tmpCount = int.MinValue;

                if (!keyValuePairs.ContainsKey(s[i]))
                {
                    keyValuePairs.Add(s[i], i);
                }
                else
                {
                    tmpCount = i - keyValuePairs[s[i]] - 1;
                }

                if (tmpCount > maxSubLength)
                {
                    maxSubLength = tmpCount;
                }
            }


            return maxSubLength >= 0 ? maxSubLength : -1;
        }

        #endregion

        #region 1154. Day of the Year

        public static int DayOfYear(string date)
        {
            return DateTime.Parse(date).DayOfYear;
        }

        #endregion

        #region 925. Long Pressed Name

        public static bool IsLongPressedName(string name, string typed)
        {
            int i = 0;
            int j = 0;

            if (name.Length > typed.Length)
            {
                return false;
            }

            while (j < typed.Length)
            {
                if (i < name.Length && name[i] == typed[j])
                {
                    i++;
                    j++;
                }
                else if (i > 0 && name[i - 1] == typed[j])
                {
                    j++;
                }
                else
                {
                    return false;
                }

            }

            return i == name.Length;
        }

        #endregion

        #region 844. Backspace String Compare

        public static bool BackspaceCompare(string s, string t)
        {
            return StringBuild(s).Equals(StringBuild(t));

            string StringBuild(string value)
            {
                Stack<char> stack = new Stack<char>();

                foreach (char item in value)
                {
                    if (item != '#')
                    {
                        stack.Push(item);
                    }
                    else if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }

                return new string(stack.ToArray());
            }

        }

        #endregion

        #region 929. Unique Email Addresses

        public static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> strings = new HashSet<string>();

            for (int i = 0; i < emails.Length; i++)
            {
                string[] strings1 = emails[i].Split('@');

                string tmpStr = emailcleanUp(strings1[0]);

                string tmpStr2 = tmpStr + '@' + strings1[1];

                if (!strings.Contains(tmpStr2))
                {
                    strings.Add(tmpStr2);
                }
            }

            string emailcleanUp(string value)
            {
                string result = string.Empty;
                int i = 0;

                while (i < value.Length)
                {
                    if (value[i] == '.')
                    {
                        i++;
                        continue;
                    }

                    if (value[i] == '+')
                    {
                        return result;
                    }
                    result += value[i];
                    i++;
                }

                return result;
            }

            return strings.Count;
        }

        #endregion

        #region 917. Reverse Only Letters

        public static string ReverseOnlyLetters(string s)
        {
            char[] chars = new char[s.Length];
            int i = 0, j = s.Length - 1;

            if (s.Length == 1)
            {
                return s;
            }

            while (i <= j)
            {
                if (!char.IsLetter(s[i]))
                {
                    chars[i] = s[i];
                    i++;
                }
                if (!char.IsLetter(s[j]))
                {
                    chars[j] = s[j];
                    j--;
                }
                if (char.IsLetter(s[i]) && char.IsLetter(s[j]))
                {
                    chars[i] = s[j];
                    chars[j] = s[i];
                    i++;
                    j--;
                }

            }

            return new String(chars);
        }

        #endregion

        #region 824. Goat Latin

        public static string ToGoatLatin(string sentence)
        {
            string vowels = "aeiouAEIOU";
            string result = string.Empty;

            int i = 0, j = 0;

            foreach (var item in sentence.Split(' '))
            {
                result += ' ' + (vowels.Contains(item[0]) ? item : item.Substring(1) + item[0]) + "ma";
                for (j = 0, i++; j < i; j++)
                {
                    result += "a";
                }
            }
            return result.Substring(1);
        }

        #endregion

        #region 1332. Remove Palindromic Subsequences

        public static int RemovePalindromeSub(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            if (IsPolindrome(s))
            {
                return 1;
            }
            else
            {
                return 2;
            }

            static bool IsPolindrome(string value)
            {
                int i = 0;
                int j = value.Length - 1;

                while (i <= j)
                {
                    if (value[i] != value[j])
                    {
                        return false;
                    }
                    i++;
                    j--;
                }

                return true;
            }
        }

        #endregion

        #region 1592. Rearrange Spaces Between Words

        public static string ReorderSpaces(string text)
        {
            string result = string.Empty;
            int whitespacesCount = 0;
            int extraSpaces;
            int spacesBetweenWords;
            List<string> tempArr = new List<string>();

            #region get whitespaces count
            //int i = 0;
            //int j = text.Length - 1;

            //while (i < j)
            //{
            //    if (text[i] == ' ')
            //    {
            //        whitespacesCount++;
            //    }
            //    if (text[j] == ' ')
            //    {
            //        whitespacesCount++;
            //    }
            //    i++;
            //    j--;
            //} 
            #endregion

            for (int k = 0; k < text.Length; k++)
            {
                string tempString = string.Empty;

                if (text[k] != ' ')
                {
                    while (text[k] != ' ')
                    {

                        tempString += text[k];
                        k++;
                        if (k == text.Length)
                            break;
                    }
                    k--;
                    tempArr.Add(tempString);
                }
                else
                {
                    whitespacesCount++;
                }
            }

            if (tempArr.Count == 1)
            {
                extraSpaces = whitespacesCount;
                return tempArr[0].PadRight(tempArr[0].Length + extraSpaces);
            }

            spacesBetweenWords = whitespacesCount / (tempArr.Count - 1);
            extraSpaces = whitespacesCount - (spacesBetweenWords * (tempArr.Count - 1));

            for (int i = 0; i < tempArr.Count; i++)
            {
                if (i == tempArr.Count - 1)
                {
                    result += tempArr[i].PadRight(tempArr[i].Length + extraSpaces);
                }
                else
                {
                    result += tempArr[i].PadRight(tempArr[i].Length + spacesBetweenWords);
                }

            }

            return result;
        }

        #endregion

        #region 1422. Maximum Score After Splitting a String

        public static int MaxScore(string s)
        {
            int score = int.MinValue;
            int sumLeft = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                int tempScore;
                int sumRight = 0;

                if (s[i] == 48)
                {
                    sumLeft++;
                }

                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j] == 49)
                    {
                        sumRight++;
                    }
                }

                tempScore = sumLeft + sumRight;

                if (tempScore > score)
                {
                    score = tempScore;
                }
            }

            return score;
        }

        #endregion

        #region 500. Keyboard Row
        public static string[] FindWords(string[] words)
        {
            List<string> result = new List<string>();
            List<string> keyboardRows = new List<string> { "qwertyuiop", "asdfghjkl", "zxcvbnm" };

            foreach (string word in words)
            {
                for (int i = 0; i < keyboardRows.Count; i++)
                {
                    if (isSubset(keyboardRows[i], word))
                    {
                        result.Add(word);
                    }
                }
            }

            return result.ToArray();

            bool isSubset(string fWord, string sWord)
            {
                string tempString = string.Empty;

                Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

                HashSet<char> charsSet = new HashSet<char>(sWord.ToLower().ToCharArray());

                tempString = string.Join("", charsSet);

                for (int i = 0; i < fWord.Length; i++)
                {
                    if (keyValuePairs.ContainsKey(fWord[i]))
                    {
                        keyValuePairs[fWord[i]] += 1;
                    }
                    else
                    {
                        keyValuePairs.Add(fWord[i], 1);
                    }
                }

                for (int i = 0; i < tempString.Length; i++)
                {



                    if (!keyValuePairs.ContainsKey(tempString[i]))
                    {
                        return false;
                    }
                    else if (keyValuePairs[tempString[i]] > 0)
                    {
                        keyValuePairs[tempString[i]] -= 1;
                    }
                }

                return true;
            }
        }

        #endregion

        #region 748. Shortest Completing Word

        public static string ShortestCompletingWord(string licensePlate, string[] words)
        {
            string result = string.Empty;
            int tempLength = int.MaxValue;

            licensePlate = licensePlate.ToLower();

            foreach (string word in words)
            {
                if (word.Length >= tempLength)
                {
                    continue;
                }
                bool isComplete = IsComplete(ConvertToDic(word), ConvertToDic(licensePlate));
                if (isComplete)
                {
                    tempLength = word.Length;
                    result = word;
                }
            }

            return result;
        }

        private static Dictionary<char, int> ConvertToDic(string word)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int n = word.Length - 1;

            word = word.ToLower();

            while (n >= 0)
            {
                if (dict.ContainsKey(word[n]))
                {
                    dict[word[n]]++;
                }
                if (!dict.ContainsKey(word[n]) && Char.IsLetter(word[n]))
                {
                    dict.Add(word[n], 1);
                }
                n--;
            }

            return dict;
        }

        private static bool IsComplete(Dictionary<char, int> compDictF, Dictionary<char, int> compDictS)
        {

            foreach (char key in compDictS.Keys)
            {
                if (!compDictF.ContainsKey(key))
                {
                    return false;
                }

                if (compDictF[key] < compDictS[key])
                {
                    return false;
                }
            }

            return true;
        }


        #endregion

        #region Word Pattern
        public static void WordPattern(string pattern, string s)
        {
            List<int> values = new List<int>();
            List<string> values2 = new List<string>(s.Split(' '));
            int[] ints = new int[values2.Count];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }


            for (int i = 0; i < values2.Count; i++)
            {
                for (int j = i + 1; j < values2.Count; j++)
                {
                    if (values2[i].Equals(values2[j]))
                    {
                        ints[j] = i;
                    }
                }
            }

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }


        }

        #endregion

        #region Excel Sheet Column Number
        public static int TitleToNumber(string columnTitle)
        {
            int result = 0;

            foreach (var item in columnTitle)
            {
                result *= 26;
                result += item - 'A' + 1;
            }

            return result;
        }

        #endregion


        #region Two Sum II - Input Array Is Sorted

        public static int[] TwoSum(int[] numbers, int target)
        {


            if (numbers.Length - 1 <= target)
            {
                int arrLength = numbers.Length;
                Hashtable twoSumList = new Hashtable();
                for (int i = 0; i < arrLength; i++)
                {
                    int diff = target - numbers[i];
                    if (twoSumList.ContainsKey(diff))
                    {
                        return new int[] { (int)twoSumList[diff], i };
                    }
                    twoSumList[numbers[i]] = i;
                }
            }
            return null;
        }

        #endregion

        #region Contains Duplicate II(в процессе)

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                if (nums[left] == nums[right] && Math.Abs(left - right) <= k)
                {
                    return true;
                }

            }

            return false;
        }

        #endregion

        #region Maximum Number of Words Found in Sentences

        public static int MostWordsFound(string[] sentences)
        {
            int result = int.MinValue;

            for (int i = 0; i < sentences.Length; i++)
            {
                int idx = 0;
                int count = 0;
                do
                {
                    idx = sentences[i].IndexOf(' ', idx);

                    count++;

                    idx += 1;

                } while (idx > 0);

                result = result < count ? count : result;
            }

            return result;
        }

        #endregion

        #region Find First Palindromic String in the Array

        public static string FirstPalindrome(string[] words)
        {
            int i = 0;
            while (i < words.Length)
            {
                if (CheckPalindrome(words[i]))
                {
                    return words[i];
                }

                i++;
            }

            return String.Empty;
        }

        public static bool CheckPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (true)
            {
                if (left > right) return true;

                if (s[left] != s[right]) return false;

                left++;
                right--;
            }

        }

        #endregion

        #region Two Out of Three

        public static IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            IList<int> result = new List<int>();
            HashSet<int> hs1 = new HashSet<int>(nums1);
            HashSet<int> hs2 = new HashSet<int>(nums2);
            HashSet<int> hs3 = new HashSet<int>(nums3);


            foreach (var item in hs1)
            {

            }


            return result;
        }
        #endregion

        #region Find Minimum in Rotated Sorted Array II

        public static int FindMin(int[] nums)
        {
            int first = 0;
            int last = nums.Length - 1;
            while (first < last)
            {
                var mid = (first + last) / 2;

                if (nums[mid] < nums[last])
                {
                    last = mid;
                }
                else if (nums[mid] > nums[last])
                {
                    first = mid + 1;
                }
                else
                {
                    last--;
                }
            }
            return nums[first];

            /* WITH LINQ */
            //return nums.Min();
        }
        #endregion

        #region Reverse Words in a String

        public static string ReverseWordsInString(string s)
        {
            int idx = 0;
            StringBuilder result = new StringBuilder();

            while (idx < s.Length)
            {
                if (s[idx].Equals(' '))
                {
                    idx++;
                    continue;
                }
                else
                {
                    string tempString = string.Empty;

                    while (!s[idx].Equals(' '))
                    {
                        tempString += s[idx];
                        idx++;
                        if (idx == s.Length)
                        {
                            break;
                        }
                    }

                    result.Insert(0, tempString);
                    result.Insert(0, ' ');
                }
            }

            return result.ToString().Trim();
        }

        #endregion

        #region Squares of a Sorted Array

        public static int[] SortedSquares(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                if (left == right)
                {
                    nums[left] = nums[left] * nums[left];
                }
                else
                {
                    nums[left] = nums[left] * nums[left];
                    nums[right] = nums[right] * nums[right];
                }

                left++;
                right--;
            }

            //Array.Sort(nums);

            return nums;
        }
        #endregion

        #region Longest Substring Without Repeating Characters(доделать)

        public static void LengthOfLongestSubstring(string s)
        {
            //int k = 0;
            int i = s.Length - 1;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            while (i >= 0)
            {
                if (!keyValuePairs.ContainsKey(s[i]))
                {
                    keyValuePairs.Add(s[i], 1);
                }
                else
                {
                    keyValuePairs[s[i]]++;
                }

                i--;
            }

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} / {item.Value}");
            }
            //return k;
        }

        #endregion

        #region Rotate Array(?)

        public static void RotateSecondVer(int[] nums, int k)
        {
            int[] tempArr = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var idx = (i + nums.Length - k) % nums.Length;
                tempArr[i] = nums[idx];
            }
            nums = tempArr;
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region Final Prices With a Special Discount in a Shop

        public static int[] FinalPrices(int[] prices)
        {
            int[] result = new int[prices.Length];

            for (int i = 0; i < prices.Length; i++)
            {
                int discount = 0;
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[j] <= prices[i])
                    {
                        discount = prices[j];
                        break;
                    }
                }

                result[i] = prices[i] - discount;
            }

            return result;
        }
        #endregion

        #region Destination City

        public static string DestCity(IList<IList<string>> paths)
        {
            Dictionary<string, string> pathHash = new Dictionary<string, string>();

            foreach (IList<string> p in paths)
            {
                pathHash.Add(p[0], p[1]);
            }

            foreach (var s in pathHash)
            {
                if (!pathHash.ContainsKey(s.Value))
                {
                    return s.Value;
                }
            }

            return string.Empty;
        }

        #endregion

        #region Increasing Decreasing String

        public static string SortString(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            SortedDictionary<char, int> ht = new SortedDictionary<char, int>();
            int idx = 0;

            while (idx < s.Length)
            {
                if (!ht.ContainsKey(s[idx]))
                {
                    ht[s[idx]] = 1;
                }
                else
                {
                    ht[s[idx]]++;
                }

                idx++;
            }

            int countIdx = ht.Max(x => x.Value);

            while (countIdx > 0)
            {
                for (int i = 0; i < ht.Count; i++)
                {
                    if (ht.ElementAt(i).Value > 0)
                    {
                        stringBuilder.Append(ht.ElementAt(i).Key);
                        ht[ht.ElementAt(i).Key]--;
                    }
                }

                for (int i = ht.Count - 1; i >= 0; i--)
                {
                    if (ht.ElementAt(i).Value > 0)
                    {
                        stringBuilder.Append(ht.ElementAt(i).Key);
                        ht[ht.ElementAt(i).Key]--;
                    }
                }

                countIdx--;
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Make Two Arrays Equal by Reversing Sub-arrays

        public static bool CanBeEqual(int[] target, int[] arr)
        {

            /*
             with sorting
             */
            Array.Sort(target);
            Array.Sort(arr);

            return target.SequenceEqual(arr);

            /*
             hashtable
             */
            //Dictionary<int, int> ht = new Dictionary<int, int>();

            //int idx = 0;
            //int left = 0;
            //int right = arr.Length - 1;

            //while (idx < target.Length)
            //{
            //    if (!ht.ContainsKey(target[idx]))
            //    {
            //        ht[target[idx]] = 1;
            //    }
            //    else
            //    {
            //        ht[target[idx]]++;
            //    }
            //    idx++;
            //}

            //while (left <= right)
            //{
            //    if (ht.ContainsKey(arr[left]) && ht[arr[left]] > 1)
            //    {
            //        ht[arr[left]]--;
            //    }
            //    else
            //    {
            //        ht.Remove(arr[left]);
            //    }
            //    if (ht.ContainsKey(arr[right]) && ht[arr[right]] > 1)
            //    {

            //        ht[arr[right]]--;
            //    }
            //    else
            //    {
            //        ht.Remove(arr[right]);
            //    }
            //    left++;
            //    right--;
            //}

            //return ht.Count == 0 ? true : false;
        }
        #endregion

        #region Longest Palindrome

        public static int LongestPalindrome(string s)
        {
            Dictionary<char, int> ht = new Dictionary<char, int>();

            int result = 0;

            if (s.Length < 2) return ++result;

            foreach (var item in s)
            {
                if (!ht.ContainsKey(item))
                {
                    ht[item] = 1;
                }
                else
                {
                    ht.Remove(item);
                    result += 2;
                }
            }

            return ht.Count > 0 ? ++result : result;
        }

        #endregion

        #region Replace All ?'s to Avoid Consecutive Repeating Characters(доделать)
        public static string ModifyString(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int idx = 0;

            while (idx < s.Length)
            {

                if (s[idx].Equals('?'))
                {

                }
                idx++;
            }

            return stringBuilder.ToString();
        }


        #endregion

        #region Final Value of Variable After Performing Operations
        public static int FinalValueAfterOperations(string[] operations)
        {
            int x = 0;
            int idx = 0;

            //int left = 0;
            //int right = operations.Length - 1;

            //while (left<=right)
            //{
            //    if (left == right)
            //    {
            //        _ = operations[left].Contains("++") ? x++ : x--;
            //    }
            //    else
            //    {
            //        _ = operations[left].Contains("++") ? x++ : x--;
            //        _ = operations[right].Contains("++") ? x++ : x--;
            //    }

            //    left++;
            //    right--;
            //}


            while (idx < operations.Length)
            {
                _ = operations[idx].Contains("++") ? x++ : x--;

                idx++;
            }


            return x;
        }
        #endregion

        #region Decrypt String from Alphabet to Integer Mapping

        public static string FreqAlphabets(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int idx = s.Length - 1;

            while (idx >= 0)
            {
                char tempValue;
                if (s[idx] == '#')
                {
                    tempValue = (char)('a' - 1 + Int32.Parse(s.Substring(idx - 2, 2)));
                    stringBuilder.Insert(0, tempValue);
                    idx -= 3;
                }
                else
                {
                    tempValue = (char)('0' + s[idx]);
                    stringBuilder.Insert(0, tempValue);
                    idx--;
                }
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Crawler Log Folder

        public static int MinOperations(string[] logs)
        {
            Stack<string> stack = new Stack<string>();

            int idx = 0;

            while (idx < logs.Length)
            {
                if (logs[idx].Equals("../") && stack.Count > 0)
                {
                    stack.Pop();
                }
                if (logs[idx].Equals("./"))
                {
                    idx++;
                    continue;
                }
                if (!logs[idx].Equals("../"))
                {
                    stack.Push(logs[idx]);
                }
                idx++;
            }

            return stack.Count;
        }

        #endregion

        #region Number of Strings That Appear as Substrings in Word

        public static int NumOfStrings(string[] patterns, string word)
        {
            int idx = 0;
            int result = 0;

            while (idx < patterns.Length)
            {
                if (word.Contains(patterns[idx]))
                    result++;

                idx++;
            }

            return result;
        }

        #endregion

        #region Minimum Time to Type Word Using Special Typewriter

        public static int MinTimeToType(string word)
        {
            int minTime = word.Length;
            char last = 'a';
            int idx = 0;

            while (idx < word.Length)
            {
                int start = (word[idx] - last + 26) % 26;
                int end = (last - word[idx] + 26) % 26;
                minTime += Math.Min(start, end);
                last = word[idx];
                idx++;
            }

            return minTime;
        }

        #endregion

        #region Reverse Prefix of Word
        private static string ReversePrefix(string word, char ch)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            int idx = 0;

            while (idx < word.Length)
            {
                stack.Push(word[idx]);
                if (word[idx] == ch)
                {

                    while (stack.Count > 0)
                    {
                        stringBuilder.Append(stack.Pop());
                    }
                    idx++;
                    while (idx < word.Length)
                    {
                        stringBuilder.Append(word[idx]);
                        idx++;
                    }

                    return stringBuilder.ToString();
                }

                idx++;
            }

            return word;
        }
        #endregion


        #region Replace All Digits with Characters
        //You are given a 0-indexed string s that has lowercase English letters in its even indices and digits in its odd indices.

        //There is a function shift(c, x), where c is a character and x is a digit, that returns the xth character after c.

        //For example, shift('a', 5) = 'f' and shift('x', 0) = 'x'.
        //For every odd index i, you want to replace the digit s[i] with shift(s[i - 1], s[i]).

        //Return s after replacing all digits.It is guaranteed that shift(s[i - 1], s[i]) will never exceed 'z'.




        //Example 1:

        //Input: s = "a1c1e1"
        //Output: "abcdef"
        //Explanation: The digits are replaced as follows:
        //- s[1] -> shift('a',1) = 'b'
        //- s[3] -> shift('c',1) = 'd'
        //- s[5] -> shift('e',1) = 'f'
        //Example 2:

        //Input: s = "a1b2c3d4e"
        //Output: "abbdcfdhe"
        //Explanation: The digits are replaced as follows:
        //- s[1] -> shift('a',1) = 'b'
        //- s[3] -> shift('b',2) = 'd'
        //- s[5] -> shift('c',3) = 'f'
        //- s[7] -> shift('d',4) = 'h'


        //Constraints:

        //1 <= s.length <= 100
        //s consists only of lowercase English letters and digits.
        //shift(s[i - 1], s[i]) <= 'z' for all odd indices i.

        public static string ReplaceDigits(string s)
        {
            int i = 0;
            StringBuilder stringBuilder = new StringBuilder();

            while (i <= s.Length - 1)
            {
                if (Char.IsDigit(s[i]))
                {
                    int tempValue = (int)s[i - 1] + (int)Char.GetNumericValue(s[i]);
                    stringBuilder.Append(Convert.ToChar(tempValue));
                    i++;
                }
                else
                {
                    stringBuilder.Append(s[i]);
                    i++;
                }
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Next Greater Element I

        //You are given two integer arrays nums1 and nums2 both of unique elements, where nums1 is a subset of nums2.

        //Find all the next greater numbers for nums1's elements in the corresponding places of nums2.

        //The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2.If it does not exist, return -1 for this number.



        //Example 1:

        //Input: nums1 = [4, 1, 2], nums2 = [1, 3, 4, 2]
        //Output: [-1,3,-1]
        //Explanation:
        //For number 4 in the first array, you cannot find the next greater number for it in the second array, so output -1.
        //For number 1 in the first array, the next greater number for it in the second array is 3.
        //For number 2 in the first array, there is no next greater number for it in the second array, so output -1.
        //Example 2:

        //Input: nums1 = [2, 4], nums2 = [1, 2, 3, 4]
        //Output: [3,-1]
        //Explanation:
        //For number 2 in the first array, the next greater number for it in the second array is 3.
        //For number 4 in the first array, there is no next greater number for it in the second array, so output -1.



        //Constraints:

        //1 <= nums1.length <= nums2.length <= 1000
        //0 <= nums1[i], nums2[i] <= 104
        //All integers in nums1 and nums2 are unique.
        //All the integers of nums1 also appear in nums2.


        //Follow up: Could you find an O(nums1.length + nums2.length) solution?

        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            #region test
            //Stack<int> ts = new Stack<int>();
            //bool ctr = false;
            //for (int i = 0; i < nums1.Length; i++)
            //{
            //    int startIdx =  Array.IndexOf(nums2, nums1[i]);
            //    if (startIdx == nums2.Length - 1)
            //    {
            //        ts.Push(-1);
            //    }
            //    else
            //    {
            //        for (; startIdx < nums2.Length; startIdx++)
            //        {
            //            if (nums2[startIdx] > nums1[i])
            //            {
            //                ts.Push(nums2[startIdx]);
            //                ctr = true;
            //                break;
            //            }
            //        }
            //    }

            //    if (!ctr)
            //    {
            //        ts.Push(-1);
            //    }
            //}

            //int[] result = ts.ToArray();

            //Array.Reverse(result);

            //return result; 
            #endregion


            Stack<int> ts = new Stack<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                int startIdx = Array.IndexOf(nums2, nums1[i]);
                if (startIdx == nums2.Length - 1)
                {
                    ts.Push(-1);
                }
                else
                {
                    for (; startIdx < nums2.Length; startIdx++)
                    {
                        if (nums2[startIdx] > nums1[i])
                        {
                            ts.Push(nums2[startIdx]);
                            break;
                        }
                    }
                    if (startIdx != nums2.Length)
                    {
                        ts.Push(-1);
                    }
                }


            }

            int[] result = ts.ToArray();

            Array.Reverse(result);

            return result;
        }


        #endregion

        #region Check If All 1's Are at Least Length K Places Away
        //Given an array nums of 0s and 1s and an integer k, return True if all 1's are at least k places away from each other, otherwise return False.

        //Example 1:
        //Input: nums = [1,0,0,0,1,0,0,1], k = 2
        //Output: true
        //Explanation: Each of the 1s are at least 2 places away from each other.

        //Example 2:
        //Input: nums = [1,0,0,1,0,1], k = 2
        //Output: false
        //Explanation: The second 1 and third 1 are only one apart from each other.

        //Example 3:
        //Input: nums = [1,1,1,1,1], k = 0
        //Output: true

        //Example 4:
        //Input: nums = [0,1,0,1], k = 1
        //Output: true

        //Constraints:

        //1 <= nums.length <= 105
        //0 <= k <= nums.length
        //nums[i] is 0 or 1


        public static bool KLengthApart(int[] nums, int k)
        {
            int i = 0;
            int counter = k;

            while (i <= nums.Length - 1)
            {
                if (nums[i] == 1)
                {
                    if (counter < k)
                    {
                        return false;
                    }

                    counter = 0;
                    i++;
                }
                else
                {
                    counter += 1;
                    i++;

                }
            }

            return true;
        }

        #endregion

        #region test

        public static long Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        public static double Pow(int value, int pow)
        {
            double tempValue = value;

            if (pow == 0) return 1;

            for (int i = 1; i < pow; i++)
            {
                tempValue *= value;
            }

            return tempValue;
        }

        public static string Exp(int n)
        {
            double e = 1;
            int i = 0;
            int tempValue = n;

            while (i < n)
            {
                e += 1 / (double)Factorial(tempValue);
                tempValue--;
                i++;
            }

            return e.ToString("F" + 5);
        }

        public static string ExpPow(int addCount, int x)
        {
            double e = 1;
            int i = 0;

            int tempValue = addCount;

            while (i < addCount)
            {
                e += (double)Pow(x, tempValue) / (double)Factorial(tempValue);
                tempValue--;
                i++;
            }

            return e.ToString("F" + 6);
        }

        public static void EarthParam(int value)
        {
            int speed = 900;
            int r = 2 * value;

            int h = (2 * r) / speed;

            Console.WriteLine($"{r} {h}");
        }
        #endregion

        #region Is Subsequence
        //Given two strings s and t, check if s is a subsequence of t.

        //A subsequence of a string is a new string that is formed from the original string by deleting some(can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).



        //Example 1:

        //Input: s = "abc", t = "ahbgdc"
        //Output: true
        //Example 2:

        //Input: s = "axc", t = "ahbgdc"
        //Output: false


        //Constraints:

        //0 <= s.length <= 100
        //0 <= t.length <= 104
        //s and t consist only of lowercase English letters.


        //Follow up: If there are lots of incoming s, say s1, s2, ..., sk where k >= 109, and you want to check one by one to see if t has its subsequence.In this scenario, how would you change your code?

        /*
         Напишите программу используя библиотеки стд и алогоритмов для вычисления и 
        вывода максимальных элементов массива
        желательно написать шаблонизированную функцию для любого контейнера на входе.
        требований по памяти и времени нет
        вывод оформите в функции мейн
        пример:
        vectro<int>{1,-4,68,32,-60,-10,68}
        на выходе даст {68,68}
         * */



        public static bool IsSubsequence(string s, string t)
        {

            List<int> hs = new List<int>();
            List<char> charList = t.ToList();
            int tmpIdx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = tmpIdx; j < charList.Count; j++)
                {
                    if (s[i].Equals(charList[j]))
                    {
                        hs.Add(j);
                        tmpIdx = j + 1;
                        break;
                    }

                }
            }

            if (hs.Count.Equals(s.Length))
            {
                return true;
            }

            return false;
        }

        public static bool IsSorted(List<int> arr)
        {
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Shuffle the Array

        //Given the array nums consisting of 2n elements in the form[x1, x2, ..., xn, y1, y2, ..., yn].

        //Return the array in the form[x1, y1, x2, y2, ..., xn, yn].

        //Example 1:

        //Input: nums = [2,5,1,3,4,7], n = 3
        //Output: [2,3,5,4,1,7]
        //        Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        //Example 2:

        //Input: nums = [1,2,3,4,4,3,2,1], n = 4
        //Output: [1,4,2,3,3,2,4,1]
        //        Example 3:

        //Input: nums = [1,1,2,2], n = 2
        //Output: [1,2,1,2]

        //Constraints:

        //1 <= n <= 500
        //nums.length == 2n
        //1 <= nums[i] <= 10^3

        public static int[] Shuffle(int[] nums, int n)
        {

            int[] result = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                result[2 * i] = nums[i];
                result[2 * i + 1] = nums[n + i];
            }

            return result;
        }

        #endregion

        #region Second Largest Digit in a String

        public static int SecondHighest(string s)
        {
            int max = 0;
            int result = Int32.MinValue;
            HashSet<int> hs = new HashSet<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                    hs.Add(s[i] - '0');
            }

            if (hs.Count < 2) return -1;

            max = hs.Max();

            foreach (var item in hs)
            {
                if (item < max && item > result)
                    result = item;
            }

            return result;
        }

        #endregion

        #region Rotate String

        //We are given two strings, s and goal.

        //A shift on s consists of taking string s and moving the leftmost character to the rightmost position.For example, if s = 'abcde', then it will be 'bcdea' after one shift on s.Return true if and only if s can become goal after some number of shifts on s.

        //Example 1:
        //Input: s = 'abcde', goal = 'cdeab'
        //Output: true

        //Example 2:
        //Input: s = 'abcde', goal = 'abced'
        //Output: false
        //Note:

        //s and goal will have length at most 100.

        public static bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;
            if (s.Length == 0 && goal.Length == 0)
                return true;

            for (int i = 0; i < s.Length; i++)
            {
                var right = s.Substring(0, i);

                var left = s.Substring(i);

                if (string.Equals(goal, (left + right)))
                {
                    return true;
                }
            }

            return false;
        }


        #endregion

        #region Search in a Binary Search Tree

        //You are given the root of a binary search tree(BST) and an integer val.

        //Find the node in the BST that the node's value equals val and return the subtree
        //rooted with that node. If such a node does not exist, return null.


        //public TreeNode SearchBST(TreeNode root, int val)
        //{
        //    return FindNode(root, val);
        //}

        //private TreeNode FindNode(TreeNode node, int val)
        //{
        //    if (node == null)
        //    {
        //        return null;
        //    }

        //    if (node.val == val)
        //    {
        //        return node;
        //    }

        //    if (val < node.val)
        //    {
        //        return FindNode(node.left, val);
        //    }

        //    return FindNode(node.right, val);
        //}


        #endregion

        #region Ransom Note

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> mag = new Dictionary<char, int>();

            if (ransomNote.Length > magazine.Length)
                return false;

            for (int i = 0; i < magazine.Length; i++)
            {
                if (!mag.ContainsKey(magazine[i]))
                    mag.Add(magazine[i], 1);
                else
                    mag[magazine[i]] += 1;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                mag.TryGetValue(ransomNote[i], out int value);

                if (value < 1)
                    return false;
                else
                    mag[ransomNote[i]] -= 1;
            }

            return true;

        }
        #endregion

        #region Sorting the Sentence
        //A sentence is a list of words that are separated by a single space with no leading or trailing spaces.Each word consists of lowercase and uppercase English letters.

        //A sentence can be shuffled by appending the 1-indexed word position to each word then rearranging the words in the sentence.

        //For example, the sentence "This is a sentence" can be shuffled as "sentence4 a3 is2 This1" or "is2 sentence4 This1 a3".
        //Given a shuffled sentence s containing no more than 9 words, reconstruct and return the original sentence.



        //Example 1:


        //Input: s = "is2 sentence4 This1 a3"
        //Output: "This is a sentence"
        //Explanation: Sort the words in s to their original positions "This1 is2 a3 sentence4", then remove the numbers.
        //Example 2:


        //Input: s = "Myself2 Me1 I4 and3"
        //Output: "Me Myself and I"
        //Explanation: Sort the words in s to their original positions "Me1 Myself2 and3 I4", then remove the numbers.



        //Constraints:

        //2 <= s.length <= 200
        //s consists of lowercase and uppercase English letters, spaces, and digits from 1 to 9.
        //The number of words in s is between 1 and 9.
        //The words in s are separated by a single space.
        //s contains no leading or trailing spaces.

        public static string SortSentence(string s)
        {
            string result = string.Empty;

            SortedDictionary<int, string> temp = new SortedDictionary<int, string>();

            string[] tempArr = s.Split(' ');

            foreach (var item in tempArr)
            {
                string value = item.Substring(0, item.Length - 1);
                int key = int.Parse((item.Substring(item.Length - 1)));
                temp.Add(key, value);
            }

            result = string.Join(" ", temp.Select(x => x.Value).ToList());

            return result;
        }
        #endregion

        #region Reverse Linked List
        public static ListNode ReverseList(ListNode head)
        {
            ListNode current = head;
            ListNode previous = new ListNode();
            while (current != null)
            {
                ListNode nextNode = current.next;
                current.next = previous;
                previous.val = current.val;
                previous = current;
                current = nextNode;
            }
            return previous.next;
        }

        #endregion

        #region  Positions of Large Groups
        //In a string s of lowercase letters, these letters form consecutive groups of the same character.

        //For example, a string like s = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z", and "yy".

        //A group is identified by an interval[start, end], where start and end denote the start and end indices(inclusive) of the group.In the above example, "xxxx" has the interval[3, 6].

        //A group is considered large if it has 3 or more characters.

        //Return the intervals of every large group sorted in increasing order by start index.



        //Example 1:

        //Input: s = "abbxxxxzzy"
        //Output: [[3,6]]
        //Explanation: "xxxx" is the only large group with start index 3 and end index 6.
        //Example 2:

        //Input: s = "abc"
        //Output: []
        //        Explanation: We have groups "a", "b", and "c", none of which are large groups.
        //        Example 3:

        //Input: s = "abcdddeeeeaabbbcd"
        //        Output: [[3,5], [6,9], [12,14]]
        //Explanation: The large groups are "ddd", "eeee", and "bbb".
        //Example 4:

        //Input: s = "aba"
        //Output: []


        //        Constraints:

        //1 <= s.length <= 1000
        //s contains lower-case English letters only.
        public static IList<IList<int>> LargeGroupPositions(string s)
        {
            int i = 0;
            var result = new List<IList<int>>();

            while (i < s.Length)
            {
                var tempChar = s[i];
                var tempList = new List<int>();
                while (i < s.Length && s[i].Equals(tempChar))
                {
                    tempList.Add(i++);
                }

                if (tempList.Count >= 3)
                {
                    result.Add(new List<int>() { tempList.First(), tempList.Last() });
                }
            }
            return result;
        }

        #endregion

        #region Sign of the Product of an Array

        public static int ArraySign(int[] nums)
        {
            int counter = 0;

            foreach (var item in nums)
            {
                if (item == 0) return 0;

                if (item < 0) counter++;
            }

            return counter % 2 == 0 ? 1 : -1;
        }

        #endregion

        #region Sum of Digits in Base K

        public static int SumBase(int n, int k)
        {
            int result = 0;

            while (n > 0)
            {
                result += n % k;
                n /= k;
            }

            return result;
        }
        #endregion

        #region Count Odd Numbers in an Interval Range

        public static int CountOdds(int low, int high)
        {
            int counter = 0;

            if (low % 2 == 0 && high % 2 == 0)
            {
                counter = (high - low) / 2;
            }
            if (low % 2 != 0 && high % 2 != 0)
            {
                counter = ((high - low) / 2) + 1;
            }

            if (low % 2 == 0 && high % 2 != 0)
            {
                counter = (high - (low - 1)) / 2;
            }

            if (low % 2 != 0 && high % 2 == 0)
            {
                counter = (high + 1 - low) / 2;
            }

            return counter;

            //return (int)Math.Round((double)(1+high-low)/2, MidpointRounding.AwayFromZero);
        }

        #endregion

        #region Jewels and Stones

        public static int NumJewelsInStones(string J, string S)
        {

            int result = 0;

            Dictionary<char, int> hs = new Dictionary<char, int>();

            foreach (char item in J)
            {
                if (!hs.ContainsKey(item)) hs.Add(item, 0);
            }

            foreach (char item in S)
            {
                if (hs.ContainsKey(item)) result++;
            }

            return result;
        }

        #endregion

        #region Last Stone Weight

        public static int LastStoneWeight(int[] stones)
        {
            List<int> tempList = stones.ToList();
            tempList.Sort();

            while (tempList.Count > 2)
            {
                int x = tempList.Last();
                int y = tempList[tempList.Count - 2];

                tempList.Remove(x);
                tempList.Remove(y);


                if ((x - y) != 0)
                {
                    tempList.Add(x - y);
                }

                tempList.Sort();
            }

            if (tempList.Count == 1)
            {
                return tempList.Last();
            }
            else
            {
                return tempList.Last() - tempList.First();
            }

        }

        #endregion

        #region Sum of All Subset XOR Totals

        //The XOR total of an array is defined as the bitwise XOR of all its elements, or 0 if the array is empty.

        //For example, the XOR total of the array[2, 5, 6] is 2 XOR 5 XOR 6 = 1.
        //Given an array nums, return the sum of all XOR totals for every subset of nums.

        //Note: Subsets with the same elements should be counted multiple times.

        //An array a is a subset of an array b if a can be obtained from b by deleting some (possibly zero) elements of b.




        //Example 1:

        //Input: nums = [1, 3]
        //Output: 6
        //Explanation: The 4 subsets of [1,3] are:
        //- The empty subset has an XOR total of 0.
        //- [1] has an XOR total of 1.
        //- [3] has an XOR total of 3.
        //- [1,3] has an XOR total of 1 XOR 3 = 2.
        //0 + 1 + 3 + 2 = 6
        //Example 2:

        //Input: nums = [5, 1, 6]
        //Output: 28
        //Explanation: The 8 subsets of [5,1,6] are:
        //- The empty subset has an XOR total of 0.
        //- [5] has an XOR total of 5.
        //- [1] has an XOR total of 1.
        //- [6] has an XOR total of 6.
        //- [5,1] has an XOR total of 5 XOR 1 = 4.
        //- [5,6] has an XOR total of 5 XOR 6 = 3.
        //- [1,6] has an XOR total of 1 XOR 6 = 7.
        //- [5,1,6] has an XOR total of 5 XOR 1 XOR 6 = 2.
        //0 + 5 + 1 + 6 + 4 + 3 + 7 + 2 = 28
        //Example 3:

        //Input: nums = [3, 4, 5, 6, 7, 8]
        //Output: 480
        //Explanation: The sum of all XOR totals for every subset is 480.



        //Constraints:

        //1 <= nums.length <= 12
        //1 <= nums[i] <= 20

        public static int SubsetXORSum(int[] nums)
        {
            int result = 0;

            if (nums.Length == 0 || nums is null) return 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result += nums[i];
                result += BitSum(nums, i, nums[i]);
            }

            return result;
        }

        private static int BitSum(int[] nums, int currIdx, int xorValue)
        {
            int result = 0;

            for (int i = currIdx + 1; i < nums.Length; i++)
            {
                var tempValue = (xorValue ^ nums[i]);
                result += tempValue;
                result += BitSum(nums, i, tempValue);
            }

            return result;
        }

        #endregion

        #region  Power of Two

        //Given an integer n, return true if it is a power of two.Otherwise, return false.

        //An integer n is a power of two, if there exists an integer x such that n == 2x.



        //Example 1:

        //Input: n = 1
        //Output: true
        //Explanation: 20 = 1
        //Example 2:

        //Input: n = 16
        //Output: true
        //Explanation: 24 = 16
        //Example 3:

        //Input: n = 3
        //Output: false
        //Example 4:

        //Input: n = 4
        //Output: true
        //Example 5:

        //Input: n = 5
        //Output: false



        //Constraints:

        //-231 <= n <= 231 - 1

        public static bool IsPowerOfTwo(int n)
        {
            Console.WriteLine(n & (n - 1));
            return (n > 0) && ((n & (n - 1)) == 0);
        }

        public static bool IsPowerOfThree(int n)
        {
            //double e = 1e-6;
            //return (Math.Log(n) / Math.Log(3) + e) % 1 <= 2 * e;

            return ((n > 0) && (1162261467 % n == 0));
        }

        public bool IsPowerOfFour(int n)
        {
            return n > 0 && ((n & (n - 1)) == 0) && (n & 0xAAAAAAAA) == 0;
        }
        #endregion

        #region  Pow(x, n)

        public static double MyPow(double x, int n)
        {
            if (n < 0)
                return 1 / PowerOf(x, Math.Abs((long)n));
            else
                return PowerOf(x, (long)n);
        }

        private static double PowerOf(double x, long n)
        {
            if (n == 0) return 1;

            if ((n & 1) == 0)
            {
                var value = PowerOf(x, n >> 1);
                return value * value;
            }
            else
            {
                return x * PowerOf(x, n - 1);
            }
        }
        #endregion

        #region Path Crossing

        public static bool IsPathCrossing(string path)
        {
            int x = 0;
            int y = 0;
            HashSet<string> visited = new HashSet<string>();

            visited.Add($"{x},{y}");
            foreach (char ch in path)
            {
                switch (ch)
                {
                    case 'N':
                        y++;
                        break;
                    case 'E':
                        x++;
                        break;
                    case 'S':
                        y--;
                        break;
                    case 'W':
                        x--;
                        break;
                }
                if (visited.Contains($"{x},{y}")) return true;

                visited.Add($"{x},{y}");
            }
            return false;
        }

        #endregion

        #region Palindrome Partitioning

        public static IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            if (string.IsNullOrEmpty(s))
                return result;
            Helper(s, 0, result, new List<string>());
            return result;

        }

        private static void Helper(string str, int start, List<IList<string>> result, IList<string> temp)
        {
            if (start == str.Length)
            {
                result.Add(new List<string>(temp));
                return;
            }

            for (int i = 1; i + start <= str.Length; i++)
            {
                if (Reverse(str.Substring(start, i)))
                {
                    temp.Add(str.Substring(start, i));
                    Helper(str, start + i, result, temp);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }

        private static bool Reverse(string s)
        {
            char[] chArr = s.ToCharArray();
            Array.Reverse(chArr);
            string reverse = new string(chArr);
            if (s.Equals(reverse, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Sqrt(x)

        //Given a non-negative integer x, compute and return the square root of x.

        //Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.

        //Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.

        //Example 1:

        //Input: x = 4
        //Output: 2
        //Example 2:

        //Input: x = 8
        //Output: 2
        //Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.


        //Constraints:

        //0 <= x <= 231 - 1

        public static int MySqrt(int x)
        {
            long left = 0;
            long right = int.MaxValue / 2 + 1;
            long approx;
            long middle;

            if (x == 0) return 0;
            if (x == 1) return 1;

            while (left < right)
            {
                middle = left + (right - left) / 2;
                approx = middle * middle;

                if (approx == middle)
                    return (int)middle;
                else if (approx > x)
                    right = middle;
                else
                    left = middle + 1;
            }

            return (int)left - 1;
        }

        #endregion

        #region MyReNumber of Days Between Two Datesgion

        //Write a program to count the number of days between two dates.

        //The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.

        //Example 1:

        //Input: date1 = "2019-06-29", date2 = "2019-06-30"
        //Output: 1
        //Example 2:

        //Input: date1 = "2020-01-15", date2 = "2019-12-31"
        //Output: 15

        //Constraints:

        //The given dates are valid dates between the years 1971 and 2100.


        public static void DaysBetweenDates(string date1, string date2)
        {
            int daysCount;

            string[] fDateArr = date1.Split('-');
            string[] sDateArr = date2.Split('-');

            #region Using DateTime and Math libs
            //DateTime dateFirst = new DateTime(int.Parse(fDateArr[0]), int.Parse(fDateArr[1]), int.Parse(fDateArr[2]));
            //DateTime dateSecond = new DateTime(int.Parse(sDateArr[0]), int.Parse(sDateArr[1]), int.Parse(sDateArr[2]));
            DateTime dateFirst = DateTime.Parse(date1);
            DateTime dateSecond = DateTime.Parse(date2);
            Console.WriteLine($"*------ DateTime struct -----*");
            Console.WriteLine(Math.Abs((dateSecond - dateFirst).Days));
            Console.WriteLine();
            //return Math.Abs((dateSecond - dateFirst).Days); 
            #endregion

            #region w/o libs
            Console.WriteLine($"*----- Without DateTime struct -----*");
            Console.WriteLine();
            if (Math.Abs(int.Parse(fDateArr[0]) - int.Parse(sDateArr[0])) > 2)
            {
                daysCount = DaysCount(date1) + DaysCount(date2);
                for (int i = int.Parse(fDateArr[0]) + 1; i < int.Parse(sDateArr[0]); i++)
                {
                    if (i % 4 == 0 || i % 400 == 0)
                    {
                        daysCount += 366;
                    }
                    else
                    {
                        daysCount += 365;
                    }
                }
            }
            else
            {
                daysCount = DaysCount(date1) + DaysCount(date2);
            }

            Console.WriteLine(daysCount);
            #endregion
        }

        private static int DaysCount(string date)
        {
            int daysCount = 0;
            bool _IsLeapYear;

            string[] dateArr = date.Split('-');

            int _GetMonthNum = int.Parse(dateArr[1]);
            int _GetDaysCount = int.Parse(dateArr[2]);

            int _LastMonthDaysCount = (int)(28 + (_GetMonthNum + Math.Floor((decimal)_GetMonthNum / 8)) % 2 + 2 % _GetMonthNum + 2 * Math.Floor(1 / (decimal)_GetMonthNum)) - _GetDaysCount;

            bool temp = int.Parse(dateArr[0]) % 4 == 0 || int.Parse(dateArr[0]) % 400 == 0 ? _IsLeapYear = true : _IsLeapYear = false;

            for (int i = 1; i <= int.Parse(dateArr[1]); i++)
            {
                daysCount += (int)(28 + (i + Math.Floor((decimal)i / 8)) % 2 + 2 % i + 2 * Math.Floor(1 / (decimal)i));
            }

            if (_IsLeapYear && _GetMonthNum > 2)
                daysCount += 1;

            daysCount -= _LastMonthDaysCount;

            return daysCount;
        }
        #endregion

        #region Determine Color of a Chessboard Square

        public static bool SquareIsWhite(string coordinates)
        {
            int charCoord = coordinates[0] - '0';
            int digitCoord = coordinates[1];

            if (charCoord % 2 != 0 && digitCoord % 2 == 0 || charCoord % 2 == 0 && digitCoord % 2 != 0)
                return true;

            return false;
        }

        #endregion

        #region Check If Two String Arrays are Equivalent

        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            StringBuilder fString = new StringBuilder();
            StringBuilder sString = new StringBuilder();

            for (int i = 0; i < word1.Length; i++)
            {
                fString.Append(word1[i]);
            }

            for (int i = 0; i < word2.Length; i++)
            {
                sString.Append(word2[i]);
            }

            string firstRes = fString.ToString();
            string secRes = sString.ToString();

            if (string.Equals(firstRes, secRes)) return true;

            return false;
        }


        #endregion

        #region Minimum Operations to Make the Array Increasing

        public static int MinOperations(int[] nums)
        {
            int result = 0;

            if (nums.Length <= 1) return result;

            int previous = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int tempValue = 0;
                if (nums[i] <= previous)
                    tempValue = previous - nums[i] + 1;

                previous = nums[i] + tempValue;
                result += tempValue;
            }

            return result;
        }

        #endregion

        #region N-Repeated Element in Size 2N Array

        //In a array nums of size 2 * n, there are n + 1 unique elements, and exactly one of these elements is repeated n times.

        //Return the element repeated n times.

        //Example 1:

        //Input: nums[1, 2, 3, 3]
        //Output: 3
        //Example 2:

        //Input: nums[2, 1, 2, 5, 3, 2]
        //Output: 2
        //Example 3:

        //Input: nums[5, 1, 5, 2, 5, 3, 5, 4]
        //Output: 5

        //Note:

        //4 <= nums.length <= 10000
        //0 <= nums[i] < 10000
        //nums.length is even

        public static int RepeatedNTimes(int[] nums)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!ht.ContainsKey(nums[i]))
                    ht.Add(nums[i], 1);
                else
                    ht[nums[i]] += 1;
            }

            int maxValue = ht.Values.Max();

            return ht.FirstOrDefault(x => x.Value == maxValue).Key;
        }

        #endregion

        #region Unique Number of Occurrences

        //Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.

        //Example 1:

        //Input: arr = [1,2,2,1,1,3]
        //        Output: true
        //Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
        //Example 2:

        //Input: arr = [1,2]
        //        Output: false
        //Example 3:

        //Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
        //        Output: true


        //Constraints:

        //1 <= arr.length <= 1000
        //-1000 <= arr[i] <= 1000

        public static bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!ht.ContainsKey(arr[i]))
                    ht.Add(arr[i], 1);
                else
                    ht[arr[i]] += 1;
            }

            HashSet<int> hs = new HashSet<int>(ht.Values);

            return ht.Count == hs.Count;
        }

        #endregion

        #region Teemo Attacking

        //Our hero Teemo is attacking an enemy Ashe with poison attacks! When Teemo attacks Ashe, Ashe gets poisoned for a exactly duration seconds.
        //More formally, an attack at second t will mean Ashe is poisoned during the inclusive time interval [t, t + duration - 1].
        //If Teemo attacks again before the poison effect ends, the timer for it is reset, and the poison effect will end duration seconds after the new attack.

        //You are given a non-decreasing integer array timeSeries, where timeSeries[i] denotes that Teemo attacks Ashe at second timeSeries[i], and an integer duration.

        //Return the total number of seconds that Ashe is poisoned.

        //Example 1:


        //Input: timeSeries = [1, 4], duration = 2
        //Output: 4
        //Explanation: Teemo's attacks on Ashe go as follows:
        //- At second 1, Teemo attacks, and Ashe is poisoned for seconds 1 and 2.
        //- At second 4, Teemo attacks, and Ashe is poisoned for seconds 4 and 5.
        //Ashe is poisoned for seconds 1, 2, 4, and 5, which is 4 seconds in total.
        //Example 2:


        //Input: timeSeries = [1, 2], duration = 2
        //Output: 3
        //Explanation: Teemo's attacks on Ashe go as follows:
        //- At second 1, Teemo attacks, and Ashe is poisoned for seconds 1 and 2.
        //- At second 2 however, Teemo attacks again and resets the poison timer. Ashe is poisoned for seconds 2 and 3.
        //Ashe is poisoned for seconds 1, 2, and 3, which is 3 seconds in total.


        //Constraints:

        //1 <= timeSeries.length <= 104
        //0 <= timeSeries[i], duration <= 107
        //timeSeries is sorted in non-decreasing order.

        public static int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            int seconds = 0;

            for (int i = 0; i < timeSeries.Length - 1; i++)
            {
                int tempValue = timeSeries[i + 1] - timeSeries[i];
                if (tempValue >= duration)
                    seconds += duration;
                else
                    seconds += tempValue;
            }

            int result = seconds + duration;

            return result;
        }


        #endregion

        #region MyRegion

        //Given a non-empty array of integers nums, every element appears twice except for one.Find that single one.

        //You must implement a solution with a linear runtime complexity and use only constant extra space.



        //Example 1:


        //Input: nums = [2, 2, 1]
        //Output: 1
        //Example 2:


        //Input: nums = [4, 1, 2, 1, 2]
        //Output: 4
        //Example 3:


        //Input: nums = [1]
        //Output: 1



        //Constraints:

        //1 <= nums.length <= 3 * 104
        //-3 * 104 <= nums[i] <= 3 * 104
        //Each element in the array appears twice except for one element which appears only once.

        public static int SingleNumber(int[] nums)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!ht.ContainsKey(nums[i]))
                    ht.Add(nums[i], 1);
                else
                    ht[nums[i]] += 1;
            }

            return ht.FirstOrDefault(x => x.Value == 1).Key;
        }


        #endregion

        #region Find the Difference

        //You are given two strings s and t.

        //String t is generated by random shuffling string s and then add one more letter at a random position.

        //Return the letter that was added to t.




        //Example 1:

        //Input: s = "abcd", t = "abcde"
        //Output: "e"
        //Explanation: 'e' is the letter that was added.
        //Example 2:

        //Input: s = "", t = "y"
        //Output: "y"
        //Example 3:

        //Input: s = "a", t = "aa"
        //Output: "a"
        //Example 4:

        //Input: s = "ae", t = "aea"
        //Output: "a"



        //Constraints:

        //0 <= s.length <= 1000
        //t.length == s.length + 1
        //s and t consist of lower-case English letters.

        public static char FindTheDifference(string s, string t)
        {
            Dictionary<char, int> ht = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (!ht.ContainsKey(t[i]))
                    ht.Add(t[i], 1);
                else
                    ht[t[i]] += 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (ht.ContainsKey(s[i]))
                {
                    ht[s[i]] -= 1;
                }
            }

            return ht.FirstOrDefault(x => x.Value == 1).Key;
        }

        #endregion

        #region Arranging Coins

        public static int ArrangeCoins(int n)
        {
            int k = 0;

            if (n == 1) return 1;

            while (n > k)
            {
                k++;
                n -= k;
            }

            return k;
        }

        #endregion

        #region Find the Town Judge

        public static int FindJudge(int n, int[][] trust)
        {
            if (n == 1 && trust.Length == 0) return 1;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (var i = 0; i < trust.Length; i++)
            {
                dict[trust[i][1]] = dict.ContainsKey(trust[i][1]) ? dict[trust[i][1]] + 1 : 1;
            }

            if (dict.Count(d => d.Value == n - 1) != 1) return -1;

            var judge = dict.First(d => d.Value == n - 1).Key;

            for (var i = 0; i < trust.Length; i++)
            {
                if (trust[i][0] == judge) return -1;
            }

            return judge;
        }

        #endregion

        #region Number of Steps to Reduce a Number to Zero

        public static int NumberOfSteps(int num)
        {
            int steps = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num--;
                }
                steps++;
            }

            return steps;
        }

        #endregion

        #region Candy

        public static int Candy(int[] ratings)
        {
            if (ratings is null) return 0;

            if (ratings.Length == 1) return 2;

            if (ratings.Length == 2) return 3;

            return 0;
        }

        #endregion

        #region TopInterviewQuestionsEasy
        #region Rotate Array

        public static void Rotate(int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {
                Helper(nums);
            }

            foreach (var item in nums)
            {
                Console.Write($"{item} ");
            }
        }

        static void Helper(int[] arr)
        {
            int temp = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
                arr[i] = arr[i - 1];
            arr[0] = temp;
        }

        #endregion
        #endregion


        #region MyRegion

        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            int result = 0;

            if (boxTypes == null || boxTypes.Length == 0) return 0;

            Array.Sort(boxTypes, (a, b) => { return b[1] - a[1]; });

            int i = 0;

            while (truckSize > 0 && i < boxTypes.Length)
            {
                int count = Math.Min(truckSize, boxTypes[i][0]);
                result += count * boxTypes[i][1];
                truckSize -= count;
                i++;
            }

            return result;
        }

        #endregion

        #region Number of Students Doing Homework at a Given Time

        public static int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int counter = 0;

            for (int i = 0; i < startTime.Length; i++)
            {
                if (startTime[i] <= queryTime && endTime[i] >= queryTime)
                {
                    counter++;
                }

            }
            return counter;

        }

        #endregion

        #region Maximum Number of Coins You Can Get

        public static int MaxCoins(int[] piles)
        {
            Array.Sort(piles);

            int result = 0;
            for (int i = piles.Length / 3; i < piles.Length; i += 2)
            {
                result += piles[i];
            }

            return result;
        }

        #endregion

        #region Check If a Word Occurs As a Prefix of Any Word in a Sentence

        public static int IsPrefixOfWord(string sentence, string searchWord)
        {
            string[] tempArr = sentence.Split(' ');

            for (int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i].StartsWith(searchWord))
                {
                    return i + 1;
                }

            }

            return -1;
        }

        #endregion

        #region Latest Time by Replacing Hidden Digits

        public static string MaximumTime(string time)
        {
            char[] tempArr = time.ToCharArray();

            if (tempArr[0] == '?' && tempArr[1] == '?')
            {
                tempArr[0] = '2';
                tempArr[1] = '3';
            }
            else if (tempArr[0] == '?' && tempArr[1] != '?')
            {
                tempArr[0] = tempArr[1] <= '3' ? '2' : '1';
            }
            else if (tempArr[0] != '?' && tempArr[1] == '?')
            {
                tempArr[1] = tempArr[0] <= '1' ? '9' : '3';
            }

            if (tempArr[3] == '?')
                tempArr[3] = '5';
            if (tempArr[4] == '?')
                tempArr[4] = '9';

            return new string(tempArr);


        }

        #endregion


        #region Count of Matches in Tournament

        public static int NumberOfMatches(int n)
        {
            int sum = 0;

            if (n == 1) return sum;

            while (n != 1)
            {
                sum += n / 2;

                if (n % 2 == 1)
                {
                    n = (n / 2) + 1;
                }
                else
                {
                    n = (n / 2);
                }
            }

            return sum;
        }

        #endregion

        #region Truncate Sentence

        public static string TruncateSentence(string s, int k)
        {
            int idx = 0;

            while (k > 0)
            {
                int index = s.IndexOf(' ', idx);

                if (index == -1) return s;

                k--;

                idx = index + 1;
            }

            return s.Substring(0, idx - 1);
        }

        #endregion

        #region Maximum Nesting Depth of the Parentheses

        public static int MaxDepth(string s)
        {
            int result = 0;
            bool isPair = false;

            Stack<char> sign = new Stack<char>();

            foreach (var item in s.ToCharArray())
            {
                if (item == '(')
                {
                    isPair = true;
                    sign.Push('(');
                }
                else if (item == ')')
                {
                    result = Math.Max(result, sign.Count);
                    sign.Pop();
                }
            }

            return isPair ? result : 0;
        }

        #endregion


        #region Subrectangle Queries

        public class SubrectangleQueries
        {

            private int[][] _Rect;

            public SubrectangleQueries(int[][] rectangle)
            {
                _Rect = rectangle;
            }

            public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
            {
                for (int i = row1; i <= row2; i++)
                {
                    for (int j = col1; j <= col2; j++)
                    {
                        _Rect[i][j] = newValue;
                    }
                }
            }

            public int GetValue(int row, int col)
            {
                //if (_Rect.Length < row || _Rect[row].Length < col)
                //    throw new IndexOutOfRangeException();

                return _Rect[row][col];
            }

            public void PrintMatrix()
            {
                for (int i = 0; i < _Rect.Length; i++)
                {
                    for (int j = 0; j < _Rect[i].Length; j++)
                    {
                        Console.Write($"{_Rect[i][j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        #endregion

        #region Partitioning Into Minimum Number Of Deci-Binary Numbers

        public static int MinPartitions(string n)
        {
            int maxValue = 0;
            foreach (var ch in n)
            {
                maxValue = Math.Max(maxValue, ch - '0');
            }
            return maxValue;
        }

        #endregion

        #region Longer Contiguous Segments of Ones than Zeros

        public static bool CheckZeroOnes(string s)
        {
            int valueOne = 0;
            int valueZero = 0;
            int maxValueOfOnes = 0;
            int maxValueOfZeros = 0;

            int i = 0;

            while (i < s.Length)
            {
                if (s[i] == '1')
                {
                    valueOne++;
                    maxValueOfOnes = Math.Max(maxValueOfOnes, valueOne);
                    valueZero = 0;
                    i++;
                }
                else if (s[i] == '0')
                {
                    valueZero++;
                    maxValueOfZeros = Math.Max(maxValueOfZeros, valueZero);
                    valueOne = 0;
                    i++;
                }
            }
            return maxValueOfOnes > maxValueOfZeros;
        }

        #endregion

        #region To Lower Case

        public static string ToLowerCase(string s)
        {
            // C# string ToLower;
            //return s.ToLower();

            int i = 0;


            // string
            string str = string.Empty;

            while (i < s.Length)
            {
                if (s[i] >= 65 && s[i] <= 90)
                {
                    str += (char)(s[i] + 32);
                }
                else
                {
                    str += s[i];
                }

                i++;
            }

            return str;


            //with char array
            //char[] chArr = s.ToCharArray();

            //while (i < chArr.Length)
            //{
            //    if (chArr[i] >= 65 && chArr[i] <= 90)
            //    {
            //        chArr[i] = (char)(chArr[i] + 32);
            //    }
            //    i++;
            //}

            //return new string(chArr);
        }

        #endregion

        #region Encode and Decode TinyURL

        public class Codec
        {

            //// Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                int idx = GetIndex(longUrl);

                string firstPart = longUrl.Substring(0, idx);
                string secondPart = AscIIToHex(longUrl.Substring(idx));

                return new string(firstPart + secondPart);

            }

            //// Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                int idx = GetIndex(shortUrl);

                string firstPart = shortUrl.Substring(0, idx);
                string secondPart = HexToAscII(shortUrl.Substring(idx));

                return new string(firstPart + secondPart);
            }


            private static int GetIndex(string value)
            {
                int idx = 0;
                int k = 3;

                while (k > 0)
                {
                    int index = value.IndexOf('/', idx);
                    k--;
                    idx = index + 1;
                }

                return idx;
            }

            private static string HexToAscII(string hex)
            {
                StringBuilder ascii = new StringBuilder();
                for (int i = 0; i < hex.Length; i += 2)
                {
                    string tempString = hex.Substring(i, 2);
                    ascii.Append(Convert.ToChar(Convert.ToUInt32(tempString, 16)));
                }

                return ascii.ToString();
            }

            private static string AscIIToHex(string value)
            {
                StringBuilder hex = new StringBuilder();

                for (int i = 0; i < value.Length; i++)
                {
                    string temp = string.Format("{0:X}", (int)value[i]);
                    hex.Append(temp);
                }

                return hex.ToString();
            }
        }

        #endregion

        #region Island Perimeter

        public static int IslandPerimeter(int[][] grid)
        {
            int perimeter = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int sideCount = 4;
                        sideCount -= i - 1 >= 0 && grid[i - 1][j] == 1 ? 1 : 0;
                        sideCount -= i + 1 < grid.Length && grid[i + 1][j] == 1 ? 1 : 0;
                        sideCount -= j - 1 >= 0 && grid[i][j - 1] == 1 ? 1 : 0;
                        sideCount -= j + 1 < grid[i].Length && grid[i][j + 1] == 1 ? 1 : 0;
                        perimeter += sideCount;
                    }
                }
            }

            return perimeter;
        }

        #endregion

        #region Thousand Separator

        public static string ThousandSeparator(int n)
        {
            StringBuilder res = new StringBuilder(n.ToString());
            int i = res.Length - 4;

            if (res.Length < 4) return res.ToString();

            while (i >= 0)
            {
                res.Insert(i + 1, '.');
                i -= 3;
            }
            return res.ToString();
        }


        #endregion


        #region Queries on Number of Points Inside a Circle
        public static int[] CountPoints(int[][] points, int[][] queries)
        {
            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (Math.Pow((points[j][0] - queries[i][0]), 2) + Math.Pow((points[j][1] - queries[i][1]), 2) <= Math.Pow(queries[i][2], 2))
                    {
                        result[i]++;
                    }
                }
            }

            return result;
        }
        #endregion

        #region Goal Parser Interpretation

        public static string Interpret(string command)
        {
            int idx = 0;

            StringBuilder sb = new StringBuilder();

            while (idx < command.Length)
            {
                if (command[idx] == 'G')
                {
                    sb.Append(command[idx]);
                    idx++;
                    continue;
                }
                if (command[idx] == '(' && command[idx + 1] == ')')
                {
                    sb.Append('o');
                    idx += 2;
                    continue;
                }
                if (command[idx] == '(' && command[idx + 1] == 'a')
                {
                    sb.Append("al");
                    idx += 4;
                    continue;
                }
            }

            return sb.ToString();
            //return command.Replace("()", "o").Replace("(al)", "al");
        }
        #endregion

        #region Detect Capital

        public static bool DetectCapitalUse(string word)
        {
            int ucount = 0;

            bool l = false;

            for (int i = 0; i < word.Length; i++)
            {
                if (i > 0 && l)
                {
                    if (Char.IsUpper(word[i])) return false;
                }
                if (ucount > 1 && Char.IsLower(word[i])) return false;
                if (Char.IsUpper(word[i]))
                {
                    ucount++;
                }
                else
                {
                    l = true;
                }
            }
            return true;
        }

        #endregion

        #region Minimum Index Sum of Two Lists

        public static string[] FindRestaurant(string[] list1, string[] list2)
        {
            List<string> temp = new List<string>();
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            Dictionary<string, int> hm = new Dictionary<string, int>();

            for (int i = 0; i < list1.Length; i++)
            {
                hm.Add(list1[i], i);
            }

            for (int i = 0; i < list2.Length; i++)
            {
                if (hm.ContainsKey(list2[i]))
                {
                    keyValues.Add(list2[i], hm[list2[i]] + i);
                }
            }

            var minValue = keyValues.OrderBy(kvp => kvp.Value).First();

            foreach (var item in keyValues)
            {
                if (item.Value == minValue.Value)
                {
                    temp.Add(item.Key);
                }
            }

            return temp.ToArray();
        }

        #endregion

        #region Maximum Population Year

        public static int MaximumPopulation(int[][] logs)
        {
            int valuesSum = 0;
            int maxCount = 0;
            int result = 0;
            Dictionary<int, int> hm = new Dictionary<int, int>();

            foreach (var item in logs)
            {
                if (!hm.ContainsKey(item[0]))
                {
                    hm[item[0]] = 1;
                }
                else
                {
                    hm[item[0]]++;
                }

                if (!hm.ContainsKey(item[1]))
                {
                    hm[item[1]] = -1;
                }
                else
                {
                    hm[item[1]]--;
                }
            }

            foreach (var item in hm.OrderBy(x => x.Key))
            {
                valuesSum += item.Value;
                if (valuesSum > maxCount)
                {
                    maxCount = valuesSum;
                    result = item.Key;
                }
            }

            return result;
        }

        #endregion


        #region Number of Matching Subsequences

        public static int NumMatchingSubseq(string s, string[] words)
        {
            int count = 0;
            int k = 0;

            Dictionary<string, int> hm = new Dictionary<string, int>();

            while (k < words.Length)
            {
                if (!hm.ContainsKey(words[k]))
                {
                    hm[words[k]] = 0;
                }
                else
                {
                    hm[words[k]]++;
                }
                k++;
            }

            foreach (var item in hm)
            {
                if (IsSub(item.Key, s))
                {
                    count = count + item.Value + 1;
                }
            }

            return count;
        }

        public static bool IsSub(string s, string t)
        {
            int j = 0;

            for (int i = 0; i < t.Length && j < s.Length; i++)
            {
                if (s[j] == t[i])
                    j++;
            }

            return j == s.Length;
        }

        #endregion

        #region Maximum Product of Two Elements in an Array

        public static int MaxProduct(int[] nums)
        {
            Array.Sort(nums);

            return ((nums[nums.Length - 1] - 1) * (nums[nums.Length - 2] - 1));
        }
        #endregion

        #region License Key Formatting

        public static string LicenseKeyFormatting(string s, int k)
        {
            StringBuilder sb = new StringBuilder();

            string tempValue = s.Replace("-", string.Empty).ToUpper();

            if (tempValue.Length % k == 0)
            {
                int i = tempValue.Length / k;
                int idx = 0;
                while (i > 0)
                {
                    sb.Append(tempValue.Substring(idx, k));
                    idx += k;
                    i--;
                    if (i != 0) sb.Append("-");
                }
            }

            if (tempValue.Length % k != 0)
            {
                int i = tempValue.Length / k;
                if (i == 0) sb.Append(tempValue);
                int idx = tempValue.Length - k;
                while (i > 0)
                {
                    sb.Insert(0, tempValue.Substring(idx, k));
                    idx -= k;
                    i--;
                    if (i != 0) sb.Insert(0, "-");
                    if (i == 0)
                    {
                        int value = tempValue.Length - (sb.Length - tempValue.Length / k);
                        sb.Insert(0, "-");
                        sb.Insert(0, tempValue.Substring(0, value - 1));
                    }
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Number Of Rectangles That Can Form The Largest Square

        public static int CountGoodRectangles(int[][] rectangles)
        {
            int result = 0;

            HashSet<int> hs = new HashSet<int>();

            for (int i = 0; i < rectangles.Length; i++)
            {
                hs.Add(rectangles[i].Min());
            }

            for (int i = 0; i < rectangles.Length; i++)
            {
                if (hs.Max() == rectangles[i].Min())
                {
                    result++;
                }
            }

            return result;
        }

        #endregion

        #region Longest Continuous Increasing Subsequence
        public static int FindLengthOfLCIS(int[] nums)
        {
            int idx = 0;
            int result = 1;
            int tempValue = 1;

            while (idx < nums.Length - 1)
            {
                if (nums[idx] < nums[idx + 1])
                {

                    tempValue++;
                    result = Math.Max(tempValue, result);
                }
                else
                {
                    tempValue = 1;
                }
                idx++;
            }
            return result;
        }

        #endregion

        #region Remove All Adjacent Duplicates In String

        public static string RemoveDuplicates(string s)
        {
            int i = 0;
            while (i < s.Length - 1)
            {
                if (s[i].Equals(s[i + 1]))
                {
                    s = s.Remove(i, 2);
                    i = -1;
                }
                i++;
            }
            return s;
        }

        #endregion

        #region Max Consecutive Ones III

        public static int LongestOnes(int[] nums, int k)
        {

            int zeroCount = 0;
            int l = 0;
            int maxLen = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) zeroCount++;
                while (zeroCount > k)
                {
                    if (nums[l] == 0) zeroCount--;
                    l++;
                }
                maxLen = Math.Max(maxLen, i - l + 1);
            }
            return maxLen;

        }

        #endregion

        #region Third Maximum Number

        public static int ThirdMax(int[] nums)
        {
            SortedSet<int> hs = new SortedSet<int>(nums);

            return hs.Count < 3 ? hs.LastOrDefault() : hs.ElementAt(hs.Count - 3);

            //int idx = nums.Length - 1;
            //int thirdMax;


            //Array.Sort(nums);

            //if (nums.Length < 3) return nums.LastOrDefault();

            //while (idx > 0)
            //{
            //    if (nums[idx] > nums[idx - 1])
            //    {
            //        thirdMax = nums[idx - 1];
            //    }

            //    idx--;
            //}

        }

        #endregion

        #region Design Parking System

        public class ParkingSystem
        {

            public int Big { get; set; }
            public int Medium { get; set; }
            public int Small { get; set; }

            public ParkingSystem(int big, int medium, int small)
            {
                Big = big;
                Medium = medium;
                Small = small;
            }

            public bool AddCar(int carType)
            {
                switch (carType)
                {
                    case 1:
                        if (Big > 0)
                        {
                            Big--;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case 2:
                        if (Medium > 0)
                        {
                            Medium--;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case 3:
                        if (Small > 0)
                        {
                            Small--;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        #endregion

        #region Count Primes

        public static int CountPrimes(int n)
        {
            //var numbers = new List<uint>();

            //for (uint i = 2; i < n; i++)
            //{
            //    numbers.Add(i);
            //}

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    for (uint j = 2; j < n; j++)
            //    {
            //        numbers.Remove(numbers[i] * j);
            //    }
            //}

            //return numbers.Count;

            bool[] dp = new bool[n];
            Array.Fill(dp, true);
            for (int i = 2; i * i < n; i++)
            {
                if (dp[i])
                {
                    for (int j = i * i; j < n; j += i)
                        dp[j] = false;
                }
            }

            int result = 0;

            for (int i = 2; i < n; i++)
            {
                if (dp[i])
                    result++;
            }

            return result;
        }

        #endregion

        #region MyRegion

        public static int FindLHS(int[] nums)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int result = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                if (keyValuePairs.ContainsKey(nums[i]))
                {
                    keyValuePairs[nums[i]]++;
                }
                else
                {
                    keyValuePairs.Add(nums[i], 1);
                }
            }

            foreach (var item in keyValuePairs)
            {
                if (keyValuePairs.ContainsKey(item.Key - 1))
                {
                    int currCnt = keyValuePairs[item.Key] + keyValuePairs[item.Key - 1];
                    result = Math.Max(result, currCnt);
                }
            }

            return result;
        }

        #endregion

        #region Valid Palindrome II

        public static bool ValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            int tempValue = 0;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    if (tempValue == 0)
                    {
                        left += 1;
                        tempValue += 1;
                        continue;
                    }
                    else if (tempValue == 1)
                    {
                        left -= 1;
                        right -= 1;
                        tempValue += 1;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                left += 1;
                right -= 1;
            }
            return true;

        }

        #endregion

        #region Valid Palindrome

        public static bool IsPalindrome(string s)
        {
            string pattern = @"[^0-9a-zA-Z]+";
            string target = String.Empty;
            Regex regex = new Regex(pattern);
            s = regex.Replace(s, target);

            int left = 0;
            int right = s.Length - 1;

            while (true)
            {
                if (left > right) return true;

                if (char.ToLower(s[left]) != char.ToLower(s[right])) return false;

                left++;
                right--;
            }
        }


        #endregion

        #region Longest Increasing Subsequence

        //public static int LengthOfLIS(int[] nums)
        //{
        //    int idx = 0;
        //    int result = 1;
        //    int tempValue = 1;

        //    while (idx < nums.Length - 1)
        //    {
        //        if (nums[idx] < nums[idx + 1])
        //        {

        //            tempValue++;
        //            result = Math.Max(tempValue, result);
        //        }
        //        else
        //        {
        //            tempValue = 1;
        //        }
        //        idx++;
        //    }
        //    return result;
        //}

        #endregion

        #region Determine if String Halves Are Alike

        public static bool HalvesAreAlike(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            int counterLeft = 0;
            int counterRight = 0;
            HashSet<char> hs = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

            while (left < right)
            {
                if (hs.Contains(char.ToLower(s[left])))
                {
                    counterLeft++;
                }

                if (hs.Contains(char.ToLower(s[right])))
                {
                    counterRight++;
                }

                left++;
                right--;
            }

            return counterLeft == counterRight;
        }

        #endregion

        #region Add Strings

        public static string AddStrings(string num1, string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int shift = 0;
            int digit1;
            int digit2;

            StringBuilder sb = new StringBuilder();

            while (i >= 0 || j >= 0 || shift == 1)
            {

                if (i < 0)
                {
                    digit1 = 0;
                }
                else
                {
                    digit1 = num1[i] - '0';
                }

                if (j < 0)
                {
                    digit2 = 0;
                }
                else
                {
                    digit2 = num2[j] - '0';
                }

                int result = digit1 + digit2 + shift;

                sb.Insert(0, result % 10);

                shift = result / 10;

                i--;
                j--;
            }

            return sb.ToString();
        }


        #endregion


        #region First Unique Character in a String

        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> hm = new Dictionary<char, int>();
            StringBuilder stringBuilder = new StringBuilder();


            for (int i = 0; i < s.Length; i++)
            {
                if (!hm.ContainsKey(s[i]))
                {
                    hm[s[i]] = 1;
                }
                else
                {
                    hm[s[i]]++;
                }
            }

            foreach (var item in hm)
            {
                if (item.Value == 1)
                {
                    stringBuilder.Append(item.Key);
                }
            }

            string result = stringBuilder.ToString();

            return result.Length == 0 ? -1 : s.IndexOf(result[0]);

            //char min = hm.FirstOrDefault(x => x.Value == 1).Key;

            //return min == 0 ? -1: s.IndexOf(min);

        }


        #endregion

        #region Count the Number of Consistent Strings

        public static int CountConsistentStrings(string allowed, string[] words)
        {

            HashSet<char> hs = new HashSet<char>(allowed);
            int count = 0;
            int idx = 0;

            while (idx < words.Length)
            {
                for (int i = 0; i < words[idx].Length; i++)
                {
                    if (!hs.Contains(words[idx][i]))
                    {
                        count--;
                        break;
                    }
                }
                count++;
                idx++;
            }

            return count;
        }

        #endregion

        #region Build Array from Permutation

        public static int[] BuildArray(int[] nums)
        {
            int[] result = new int[nums.Length];

            int idx = 0;

            while (idx < nums.Length)
            {

                result[idx] = nums[nums[idx]];
                idx++;
            }

            return result;
        }
        #endregion

        #region Concatenation of Array

        public static int[] GetConcatenation(int[] nums)
        {
            int[] result = new int[nums.Length * 2];
            int idx = 0;

            while (idx < nums.Length)
            {
                result[idx] = nums[idx];

                result[idx + nums.Length] = nums[idx];

                idx++;
            }

            return result;
        }

        #endregion

        #region Subtract the Product and Sum of Digits of an Integer

        public static int SubtractProductAndSum(int n)
        {
            int prodValue = 1;
            int sumValue = 0;

            while (n > 0)
            {
                int tempValue = n % 10;
                prodValue *= tempValue;
                sumValue += tempValue;
                n /= 10;
            }

            return prodValue - sumValue;
        }

        #endregion

        #region Check if All Characters Have Equal Number of Occurrences

        public static bool AreOccurrencesEqual(string s)
        {
            Dictionary<char, int> hm = new Dictionary<char, int>();

            int idx = 0;

            while (idx < s.Length)
            {
                if (!hm.ContainsKey(s[idx]))
                {
                    hm.Add(s[idx], 1);
                }
                else
                {
                    hm[s[idx]]++;
                }

                idx++;
            }


            foreach (var item in hm)
            {
                if (item.Value > 0 && item.Value != hm[s[0]])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Substrings of Size Three with Distinct Characters

        public static int CountGoodSubstrings(string s)
        {
            int result = 0;
            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i - 1] != s[i] && s[i] != s[i + 1] && s[i - 1] != s[i + 1])
                    result++;
            }

            return result;

        }


        #endregion

        #region Beautiful Array

        public static void BeautifulArray(int n)
        {
            int[] result = new int[n];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i + 1;
            }

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        #endregion

        #region Mean of Array After Removing Some Elements

        public static double TrimMean(int[] arr)
        {
            Array.Sort(arr);
            double sum = 0;
            int count = 0;

            for (int i = (int)(arr.Length * 0.05); i < arr.Length - (int)(arr.Length * 0.05); i++)
            {
                sum += arr[i];
                count++;
            }

            return sum / count;
        }

        #endregion

        #region Sum of Digits of String After Convert

        public static int GetLucky(string s, int k)
        {
            int tempValue;
            int result = 0;

            foreach (var item in s)
            {
                tempValue = item - 'a' + 1;
                result += tempValue / 10 + tempValue % 10;
            }

            while (k > 1)
            {
                int transform = 0;
                while (result > 0)
                {
                    transform += result % 10;
                    result /= 10;
                }

                result = transform;
                k--;
            }

            return result;
        }

        #endregion

        #region Maximum Repeating Substring

        public static int MaxRepeating(string sequence, string word)
        {
            int result = 0;
            string tempString = word;

            while (sequence.IndexOf(tempString) != -1)
            {
                tempString += word;
                result++;
            }

            return result;
        }

        #endregion

        #region Remove One Element to Make the Array Strictly Increasing

        public static bool CanBeIncreasing(int[] nums)
        {
            int count = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= nums[i - 1])
                    count++;
                if (i >= 2 && nums[i - 2] >= nums[i])
                {
                    nums[i] = nums[i - 1];
                }
                if (count > 1)
                    return false;

            }

            return true;
        }

        #endregion

        #region Create Target Array in the Given Order

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] target = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {

                for (int j = nums.Length - 1; j > index[i]; j--)
                {
                    target[j] = target[j - 1];

                }

                target[index[i]] = nums[i];
            }

            return target;
        }

        #endregion

        #region Unique Morse Code Words

        public static int UniqueMorseRepresentations(string[] words)
        {
            #region With HashMap
            //Dictionary<string, int> hm = new Dictionary<string, int>();

            //string[] morseCode = { ".-", "-...", "-.-.", "-..",
            //    ".", "..-.", "--.", "....", "..", ".---", "-.-",
            //    ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
            //    "...", "-", "..-", "...-", ".--", "-..-", "-.--",
            //    "--.." };

            //for (int i = 0; i < words.Length; i++)
            //{
            //    StringBuilder morseConv = new StringBuilder();
            //    for (int j = 0; j < words[i].Length; j++)
            //    {
            //        morseConv.Append(morseCode[words[i][j] - 'a']);
            //    }

            //    string tempStr = morseConv.ToString();

            //    if (!hm.ContainsKey(tempStr))
            //    {
            //        hm[tempStr] = 1;
            //    }
            //    else
            //    {
            //        hm[tempStr]++;
            //    }
            //}

            //return hm.Count;
            #endregion

            #region With HashSet
            HashSet<string> hs = new HashSet<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string tempStr = ConvertToMorse(words[i]);

                hs.Add(tempStr);
            }

            return hs.Count;
            #endregion
        }

        private static string ConvertToMorse(string word)
        {
            string[] morseCode = { ".-", "-...", "-.-.", "-..",
                ".", "..-.", "--.", "....", "..", ".---", "-.-",
                ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
                "...", "-", "..-", "...-", ".--", "-..-", "-.--",
                "--.." };

            StringBuilder morseConv = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                morseConv.Append(morseCode[word[i] - 'a']);
            }

            return morseConv.ToString();
        }

        #endregion

        #region Excel Sheet Column Title

        public static string ConvertToTitle(int columnNumber)
        {
            string result = string.Empty;

            while (columnNumber > 0)
            {
                columnNumber -= 1;
                int tempValue = columnNumber % 26;
                char tempChar = (char)('A' + tempValue);
                result = result.Insert(0, tempChar.ToString());
                columnNumber /= 26;
            }

            return result;
        }

        #endregion

        #region Isomorphic Strings

        public static bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, int> hashMapS = new Dictionary<char, int>();
            Dictionary<char, int> hashMapT = new Dictionary<char, int>();

            StringBuilder sBuilder = new StringBuilder();
            StringBuilder tBuilder = new StringBuilder();

            int idx = 0;

            while (idx < s.Length)
            {
                if (!hashMapS.ContainsKey(s[idx]))
                {
                    hashMapS[s[idx]] = idx;
                }

                if (!hashMapT.ContainsKey(t[idx]))
                {
                    hashMapT[t[idx]] = idx;
                }

                sBuilder.Append(hashMapS[s[idx]]);
                sBuilder.Append(" ");

                tBuilder.Append(hashMapT[t[idx]]);
                tBuilder.Append(" ");

                idx++;
            }

            return sBuilder.ToString().Equals(tBuilder.ToString());
        }

        #endregion

        #region Valid Perfect Square
        public static bool IsPerfectSquare(int num)
        {
            long left = 1;
            long right = num;

            while (left <= right)
            {
                var middle = left + (right - left) / 2;
                if (middle * middle == num)
                    return true;
                else if (middle * middle < num)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return false;
        }
        #endregion

        #region Distribute Candies

        public static int DistributeCandies(int[] candyType)
        {
            HashSet<int> hs = new HashSet<int>(candyType);

            return Math.Min(candyType.Length / 2, hs.Count);
        }

        #endregion

        #region Reverse String

        public static void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            char tempChar;

            while (left < right)
            {
                tempChar = s[right];
                s[right] = s[left];
                s[left] = tempChar;

                left++;
                right--;
            }
        }

        #endregion

        #region Reverse Words in a String III

        public static string ReverseWords(string s)
        {
            string[] subs = s.Split(' ');
            StringBuilder stringBuilder = new StringBuilder();
            int idx = 0;

            while (idx < subs.Length)
            {
                stringBuilder.Append(ReverseStr(subs[idx].ToCharArray()));
                stringBuilder.Append(' ');
                idx++;
            }

            return stringBuilder.ToString().Trim();
        }

        private static string ReverseStr(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            char tempChar;

            while (left < right)
            {
                tempChar = s[right];
                s[right] = s[left];
                s[left] = tempChar;

                left++;
                right--;
            }

            return new string(s);
        }
        #endregion

        #region Reverse String II

        public static string ReverseStr(string s, int k)
        {
            char[] result = s.ToCharArray();
            int idx = 0;

            while (idx < result.Length)
            {
                int left = idx;
                int right = Math.Min(idx + k - 1, result.Length - 1);

                while (left <= right)
                {
                    char tempChar = result[right];
                    result[right] = result[left];
                    result[left] = tempChar;

                    left++;
                    right--;
                }

                idx += 2 * k;
            }

            return new string(result);
        }

        #endregion

        #region Maximum Number of Words You Can Type

        public static int CanBeTypedWords(string text, string brokenLetters)
        {
            #region w/o string array
            /*
             *  Runtime: 72 ms, faster than 92.27% of C# online submissions for Maximum Number of Words You Can Type.
             *  Memory Usage: 22.9 MB, less than 78.26% of C# online submissions for Maximum Number of Words You Can Type.
             */

            //HashSet<char> hs = new HashSet<char>(brokenLetters);
            //int count = 0;

            //for (int i = 0; i < text.Length; i++)
            //{

            //    if (text.IndexOf(' ', i) != -1)
            //    {
            //        count++;
            //        int idx = text.IndexOf(' ', i);
            //        while (idx >= i)
            //        {
            //            if (hs.Contains(text[idx]))
            //            {
            //                count--;
            //                break;
            //            }

            //            idx--;
            //        }
            //        i = text.IndexOf(' ', i);
            //    }
            //    else
            //    {
            //        count++;
            //        int idx = text.Length - 1;
            //        while (idx >= i)
            //        {
            //            if (hs.Contains(text[idx]))
            //            {
            //                count--;
            //                break;
            //            }

            //            idx--;
            //        }
            //        break;
            //    }


            //}

            //return count; 
            #endregion

            #region split text by whitespace to string array
            /*
             *  Runtime: 72 ms, faster than 92.27% of C# online submissions for Maximum Number of Words You Can Type.
             *  Memory Usage: 23.3 MB, less than 39.61% of C# online submissions for Maximum Number of Words You Can Type.
             */


            HashSet<char> hs = new HashSet<char>(brokenLetters);
            string[] words = text.Split(' ');
            int count = words.Length;

            if (brokenLetters is null) return count;

            for (int i = 0; i < words.Length; i++)
            {
                int left = 0;
                int right = words[i].Length - 1;

                while (left <= right)
                {
                    if (hs.Contains(words[i][left]) || hs.Contains(words[i][right]))
                    {
                        count--;
                        break;
                    }
                    left++;
                    right--;
                }
            }

            return count;
            #endregion
        }

        #endregion

        #region Maximum Product Difference Between Two Pairs

        public static int MaxProductDifference(int[] nums)
        {
            Array.Sort(nums);

            return (nums[nums.Length - 1] * nums[nums.Length - 2]) - ((nums[0] * nums[1]));
        }

        #endregion

        #region Check if All the Integers in a Range Are Covered

        public static bool IsCovered(int[][] ranges, int left, int right)
        {
            HashSet<int> hs = new HashSet<int>();

            for (int i = left; i <= right; i++)
            {
                hs.Add(i);
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                for (int j = ranges[i][0]; j <= ranges[i][1]; j++)
                {
                    hs.Remove(j);
                }
                if (hs.Count == 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Delete Characters to Make Fancy String

        public static string MakeFancyString(string s)
        {
            //for (int i = 0; i < s.Length - 1; i++)
            //{
            //    int counter = 1;
            //    int idx = i;

            //    while (s[i] == s[i + 1])
            //    {
            //        counter++;
            //        i++;
            //        if (i == s.Length - 1)
            //        {
            //            break;
            //        }
            //    }

            //    if (counter > 2)
            //    {
            //        s = s.Remove(idx, counter - 2);
            //        i = idx + 1;
            //    }
            //}

            //return s;

            StringBuilder stringBuilder = new StringBuilder();
            int counter = 0;
            char tempchar = ' ';

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != tempchar)
                {
                    stringBuilder.Append(s[i]);
                    tempchar = s[i];
                    counter = 1;
                }
                else if (s[i] == tempchar)
                {
                    if (counter < 2)
                    {
                        stringBuilder.Append(s[i]);
                        counter++;
                    }
                }
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Shortest Distance to a Character

        public static int[] ShortestToChar(string s, char c)
        {
            int[] ans = new int[s.Length];

            List<int> hs = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s.IndexOf(c, i) != -1)
                {
                    int startIdx = s.IndexOf(c, i);
                    int endIdx = s.IndexOf(c, startIdx + 1);
                    int tempValue;

                    if (endIdx == -1)
                    {
                        tempValue = (s.Length - 1) - startIdx;
                    }
                    else
                    {
                        tempValue = endIdx - startIdx;
                    }

                    hs.Add(startIdx);

                    for (int j = 0; j <= tempValue; j++)
                    {
                        ans[startIdx] = j;
                        startIdx++;
                    }
                    i = s.IndexOf(c, i);
                }
            }

            while (hs.Count > 0)
            {
                int startIdx = hs[hs.Count - 1];

                if (hs.Count < 2)
                {
                    for (int j = 0; j < startIdx; j++)
                    {
                        ans[j] = startIdx - j;
                    }
                }
                else
                {
                    for (int j = hs[hs.Count - 2]; j < startIdx; j++)
                    {
                        ans[j] = Math.Min(ans[j], startIdx - j);
                    }
                }
                hs.Remove(startIdx);
            }
            return ans;
        }

        #endregion

        #region Redistribute Characters to Make All Strings Equal

        public static bool MakeEqual(string[] words)
        {
            if (words.Length == 1) return true;

            Dictionary<char, int> ht = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (!ht.ContainsKey(words[i][j]))
                    {
                        ht[words[i][j]] = 1;
                    }
                    else
                    {
                        ht[words[i][j]]++;
                    }
                }
            }

            foreach (var item in ht)
            {
                if (item.Value % words.Length != 0)
                    return false;
            }

            return true;
        }

        #endregion

        #region Get Maximum in Generated Array

        public static int GetMaximumGenerated(int n)
        {

            if (n <= 0)
                return 0;

            int[] arr = new int[n + 1];

            arr[0] = 0;
            arr[1] = 1;

            for (int i = 1; i < arr.Length / 2; i++)
            {
                arr[i * 2] = arr[i];
                arr[i * 2 + 1] = arr[i] + arr[i + 1];
            }

            return arr.Max();
        }

        #endregion

        #region Minimum Distance to the Target Element

        public static int GetMinDistance(int[] nums, int target, int start)
        {
            int i = 0;
            int min = int.MaxValue;
            while (i < nums.Length)
            {
                if (nums[i] == target)
                {
                    min = Math.Min(min, Math.Abs(i - start));
                }
                i++;
            }
            return min;
        }

        #endregion

        #region Split a String in Balanced Strings

        public static int BalancedStringSplit(string s)
        {
            int counter = 0;
            int result = 0;
            foreach (var c in s)
            {
                if (c.Equals('R'))
                    counter++;
                else
                    counter--;

                if (counter == 0)
                    result++;
            }
            return result;
        }

        #endregion

        #region Largest Odd Number in Stringon

        public static string LargestOddNumber(string num)
        {
            int idx = num.Length - 1;

            while (idx >= 0)
            {
                if ((num[idx] - '0') % 2 != 0)
                {
                    return num.Substring(0, idx + 1);
                }
                idx--;
            }

            return string.Empty;
        }

        #endregion

        #region Check if Word Equals Summation of Two Words

        public static bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            int firstNumericValue = ConvertToInt(firstWord);
            int secondNumericValue = ConvertToInt(secondWord);
            int thirdNumericValue = ConvertToInt(targetWord);

            return (firstNumericValue + secondNumericValue) == thirdNumericValue ? true : false;
        }

        private static int ConvertToInt(string value)
        {
            int idx = 0;
            StringBuilder stringBuilder = new StringBuilder();

            while (idx < value.Length)
            {
                stringBuilder.Append((value[idx] - 'a'));
                idx++;
            }

            return Convert.ToInt32(stringBuilder.ToString());
        }

        #endregion

        #region Fizz Buzz

        public static IList<string> FizzBuzz(int n)
        {
            string firstPart = "Fizz";
            string secondPart = "Buzz";
            var result = new List<string>();
            int idx = 1;

            while (idx <= n)
            {
                switch (idx % 3)
                {
                    case 0 when idx % 5 == 0:
                        result.Add(string.Concat(firstPart, secondPart));
                        break;
                    case 0:
                        result.Add(firstPart);
                        break;
                    default:
                        if (idx % 5 == 0)
                        {
                            result.Add(secondPart);
                        }
                        else
                        {
                            result.Add(idx.ToString());
                        }

                        break;
                }

                idx++;
            }

            return result;
        }

        #endregion

        #region Check if Binary String Has at Most One Segment of Ones

        public static bool CheckOnesSegment(string s)
        {
            return s.IndexOf("01") == -1;
        }

        #endregion

        #region Find Center of Star Graph

        public static int FindCenter(int[][] edges)
        {
            return edges[0].Intersect(edges[1]).First();
        }

        #endregion

        #region Flipping an Image

        public static int[][] FlipAndInvertImage(int[][] image)
        {
            return image.Select(x => x.Reverse().Select(y => y ^ 1).ToArray()).ToArray();
        }

        #endregion

        #region Slowest Key

        public static char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            Dictionary<char, int> ht = new Dictionary<char, int>();

            ht[keysPressed[0]] = releaseTimes[0];

            for (int i = 1; i < keysPressed.Length; i++)
            {
                if (!ht.ContainsKey(keysPressed[i]))
                {
                    ht[keysPressed[i]] = releaseTimes[i] - releaseTimes[i - 1];
                }
                else
                {
                    ht[keysPressed[i]] = Math.Max(ht[keysPressed[i]], (releaseTimes[i] - releaseTimes[i - 1]));
                }
            }
            return ht.OrderBy(x => x.Value).ThenBy(key => key.Key).LastOrDefault().Key;
        }

        #endregion

        #region Find Greatest Common Divisor of Array

        public static int FindGCD(int[] nums)
        {
            Array.Sort(nums);

            return GCD(nums[nums.Length - 1], nums[0]);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        #endregion

        #region Sort Array by Increasing Frequency

        public static int[] FrequencySort(int[] nums)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();
            int[] result = new int[nums.Length];
            int idx = 0;
            int j = 0;

            while (idx < nums.Length)
            {
                if (!ht.ContainsKey(nums[idx]))
                {
                    ht[nums[idx]] = 1;
                }
                else
                {
                    ht[nums[idx]]++;
                }

                idx++;
            }

            foreach (var item in ht.OrderBy(x => x.Value).ThenByDescending(key => key.Key))
            {
                int i = 0;
                while (i < item.Value)
                {
                    result[j] = item.Key;
                    j++;
                    i++;
                }
            }

            return result;
        }

        #endregion

        #region Make The String Great

        public static string MakeGood(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Stack<char> ac = new Stack<char>();

            if (s.Length < 2) return s;

            int idx = 0;

            while (idx < s.Length)
            {
                if (ac.Count > 0 && Math.Abs(ac.Peek() - s[idx]) == 32)
                {
                    ac.Pop();
                }
                else
                {
                    ac.Push(s[idx]);
                }

                idx++;
            }

            while (ac.Count > 0)
            {
                stringBuilder.Insert(0, ac.Pop());
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region test

        public static List<int> PrimeFactors(int value)
        {
            List<int> primes = new List<int>();

            for (int i = 2; i <= value; i++)
            {
                while (value % i == 0)
                {
                    primes.Add(i);
                    value /= i;
                }
            }

            return primes;
        }

        public static bool IsPerfect(int number)
        {
            bool flag = false;

            List<int> tempList = Digits(number);

            int digitalRoot = DigitalRoot(number, 10);

            return flag;
        }

        private static List<int> Digits(int number)
        {
            List<int> list = new List<int>();
            while (number > 0)
            {
                list.Add(number % 10);
                number /= 10;
            }
            return list;
        }

        private static int DigitalRoot(int number, int numBase)
        {
            while (number > 9)
            {
                number = DigitalSum(number, numBase);
            }

            return number;
        }

        private static int DigitalSum(int number, int numBase)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % numBase;
                number /= numBase;
            }

            return sum;
        }
        #endregion
    }
}
