using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar_Cipher
{
    class CeasorCipher
    {
        int shiftValue = 5;
        int groupSize = 5;
        char dummyChar = 'x';

        public int ShiftValue
        {
            get
            {
                return shiftValue;
            }
            set
            {
                shiftValue = value;
            }
        }
        public int GroupSize
        {
            get
            {
                return groupSize;
            }
            set
            {
                groupSize = value;
            }
        }
        public char DummyChar
        {
            get
            {
                return dummyChar;
            }
            set
            {
                dummyChar = value;
            }
        }

        private char encode(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }


        public string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += encode(ch, key);

            return output;
        }

        public string Decipher(string input)
        {
            input = input.Replace(" ", "");
            string toBeChecked = input.Substring(input.Length - GroupSize, GroupSize);
            toBeChecked = toBeChecked.Replace(DummyChar.ToString(), String.Empty);

            string newInput = input.Substring(0, input.Length - GroupSize);
            newInput += toBeChecked;

            return Encipher(newInput, 26 - ShiftValue);
        }

        public string groupOutput(string value)
        {
            string output = "";
            value = value.Replace(" ", String.Empty);
            if (value.Length % GroupSize != 0)
            {
                value += new String(DummyChar, (GroupSize - value.Length % GroupSize));
            }
            for(int i=1; i <= value.Length; i++)
            {
                output += value[i-1];
                if (i % GroupSize == 0)
                {
                    output += " ";
                }
            }
            return output.ToLower();
        }
    }
}
