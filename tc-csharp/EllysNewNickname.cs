// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class EllysNewNickname
{
    private bool isVowel(char c)
    {
        const string vowels = "aeiouy";
        return vowels.Contains(c.ToString());
    }

    public int getLength(string nickname)
    {
        bool consecutiveVowel = false;
        int res = nickname.Length;
        foreach (char c in nickname)
        {
            if (isVowel(c))
            {
                if (consecutiveVowel)
                {
                    res--;
                }
                else
                {
                    consecutiveVowel = true;
                }
            }
            else
            {
                consecutiveVowel = false;
            }
        }

        return res;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        eq(0, (new EllysNewNickname()).getLength("tourist"), 6);
        eq(1, (new EllysNewNickname()).getLength("eagaeoppooaaa"), 6);
        eq(2, (new EllysNewNickname()).getLength("esprit"), 6);
        eq(3, (new EllysNewNickname()).getLength("ayayayayayaya"), 1);
        eq(4, (new EllysNewNickname()).getLength("wuuut"), 3);
        eq(5, (new EllysNewNickname()).getLength("naaaaaaaanaaaanaananaaaaabaaaaaaaatmaaaaan"), 16);
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
    // END CUT HERE
}