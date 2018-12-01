namespace AP_QuestionSet_CSharp.Core.QuestionOne
{    
    using System.Collections.Generic;        

    public static class StringExtensions
    {

        // O (N/2)
        public static string Reverse(this string input)
        {
            char[] array = input.ToCharArray();            
            for(int i = 0; i < array.Length/2; i++)
            {
                char temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }

            return new string(array);
        }

        // O (N)
        public static string ReverseAndInterweave(this string input)
        {
            string reverse = input.Reverse(); //With Linq: new string(input.Reverse().ToArray());  
            
            IEnumerator<char> inputEnumerator = input.GetEnumerator();
            IEnumerator<char> inputReverseEnumerator = reverse.GetEnumerator();

            string result = string.Empty;
            while (inputEnumerator.MoveNext() && inputReverseEnumerator.MoveNext())
            {
                result += inputEnumerator.Current.ToString() + inputReverseEnumerator.Current.ToString();
            }            
            return result;
        }        
    }

    
}

