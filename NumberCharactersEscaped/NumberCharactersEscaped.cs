using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberCharactersEscaped
{
    class NumberCharactersEcs
    {
        static void Main(string[] args)
        {
            string expression = "##!r#po#";         // 0
            //string expression = "#a!b#c";         // 1 
            //string expression = "#ab!c#d#e!f#";   // 2
            //string expression = "#ae#b#!c#d#e!f"  // 1, contains 1 unclosed segment
            //string expression = "a!e#b#!c#d#e!f"; // 0, contains 1 uopened and 1 unclosed segment

            bool inHash = false, chNextEsc = false, valid = false;
            char[] lowerAlpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                                  'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'y', 'z' };
            int needsEscape = 0;

            foreach (char ch in expression)
            {
                if (ch == '#' && !inHash) { inHash = true; valid = false;  continue; }
                if (ch == '#' && inHash) { inHash = false; continue; }
                if (ch == '!' && inHash) { chNextEsc = true; continue; }
                if (chNextEsc && inHash && lowerAlpha.Contains(ch))
                {
                    needsEscape++;
                    valid = true;
                    chNextEsc = false;
                }


                //if (ch == '#' && !inHash) { inHash = true; continue; }
                //if (ch == '#' && inHash) { inHash = false; continue; }
                //if (ch == '!' && inHash) { chNextEsc = true; continue; }
                //if (chNextEsc && inHash && lowerAlpha.Contains(ch)) {
                //    //needsEscape++;
                //    valid = true;
                //    //chNext = false;
                //}
                //if (inHash && valid && chNextEsc)
                //{
                //    needsEscape++;
                //    valid = false;
                //}
            }
            if (inHash && valid)
                needsEscape--;

            Console.WriteLine(needsEscape);
        }
    }
}
