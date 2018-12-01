using System;
using System.Collections.Generic;
using System.Linq;

namespace AP_QuestionSet_CSharp.Core.QuestionTwo
{
    // O (N/2)
    public static class Palindrome
    {
        public static bool Check(string input)
        {            
            int index = 0;
            string sequence = input.Replace(" ", string.Empty);
            while(index < sequence.Length/2)
            {
                if(sequence[index] != sequence[sequence.Length-1-index])
                    return false;
                index++;
            }

            return true;           
        }
    }
}
