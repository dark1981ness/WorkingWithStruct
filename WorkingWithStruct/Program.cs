﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithStruct
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(RotateString("abcde", "cdeab"));
            Console.WriteLine();
        }
        public static bool Match(char ch)
        {
            return ch.Equals('e');
        }

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
    }
}
