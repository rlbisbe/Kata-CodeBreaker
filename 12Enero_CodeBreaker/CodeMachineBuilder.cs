using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Enero_CodeBreaker
{
    public class CodeMachineBuilder
    {
        public static CodeMachine Generate(string password)
        {
            CheckPasswordLength(password);
            CheckAcceptedCharacters(password);
            return new CodeMachine(password);
        }

        private static void CheckAcceptedCharacters(string password)
        {
            char[] myPassword = password.ToCharArray();
            char[] accepted = { 'R', 'A', 'M', 'V', 'N', 'I' };

            foreach (var item in myPassword)
                if (!accepted.Contains(item))
                    throw new IncorrectCharactersException();
        }

        private static void CheckPasswordLength(string password)
        {
            if (password.Length != PASSWORD_LENGTH)
                throw new WrongSizedPasswordException();
        }

        private const int PASSWORD_LENGTH = 4;
    }
}
