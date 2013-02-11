using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Enero_CodeBreaker
{
    public class CodeMachine
    {
        private string password;

        public CodeMachine(string password)
        {
            this.password = password;
        }

        public string Decode(string p)
        {
            List<char> exactPositions = new List<char>();
            List<char> unexactPositions = new List<char>();

            char[] array = p.ToCharArray();
            char[] passwordToDecode = password.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == passwordToDecode[i])
                {
                    exactPositions.Add('X');
                    continue;
                }
                if (passwordToDecode.Contains(array[i]))
                    unexactPositions.Add('*');
            }

            exactPositions.AddRange(unexactPositions);

            return String.Concat(exactPositions);
        }
    }
}
