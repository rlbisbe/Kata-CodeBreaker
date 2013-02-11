using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Enero_CodeBreaker
{
    public class CodeMachine
    {
        public CodeMachine(string password)
        {
            this.mPassword = password;
        }

        public string Decode(string p)
        {
            List<char> exactPositions = new List<char>();
            List<char> unexactPositions = new List<char>();

            char[] array = p.ToCharArray();
            char[] passwordToDecode = mPassword.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (IsExactMatch(array, passwordToDecode, i))
                {
                    exactPositions.Add('X');
                    continue;
                }

                if (IsUnexactMatch(array, passwordToDecode, i))
                    unexactPositions.Add('*');
            }

            exactPositions.AddRange(unexactPositions);

            return String.Concat(exactPositions);
        }

        private bool IsUnexactMatch(char[] array, 
            char[] passwordToDecode, int i)
        {
            return passwordToDecode.Contains(array[i]);
        }

        private bool IsExactMatch(char[] array, 
            char[] passwordToDecode, int i)
        {
            return array[i] == passwordToDecode[i];
        }

        private string mPassword;
    }
}
