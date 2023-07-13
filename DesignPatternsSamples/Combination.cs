using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples
{
    public delegate void MatchHandler(object sender, string match);

    public class Combination
    {
        public event MatchHandler? OnMatching;

        public void Permutation(string word)
        {
            if (word.Length > 0)
            {
                Permutation(word, 0, word.Length - 1);
            }
        }

        private void Permutation(string str, int init, int len)
        {
            if (init == len && OnMatching != null)
            {
                OnMatching(this, str);
            }
            else
            {
                for (int inc = init; inc <= len; inc++)
                {
                    str = swap(str, init, inc);
                    Permutation(str, init + 1, len);
                    str = swap(str, init, inc);
                }
            }
        }

        public static String swap(String a, int i, int j)
        {
            char temp;
            char[] chrray = a.ToCharArray();
            temp = chrray[i];
            chrray[i] = chrray[j];
            chrray[j] = temp;
            string s = new string(chrray);
            return s;
        }
    }
}
