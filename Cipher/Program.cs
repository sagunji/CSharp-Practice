using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar_Cipher
{
    class Program
    {
        //const string MESSAGE = "That man is playing Galaga! thought we wouldn't notice, but we did.";
        //const string CIPHERED_MESSAGE = "ymfyr fsnxu qfdns llfqf lf!ym tzlmy bjbtz qis'y stynh j,gzy bjini .xxxx";

        public static void DisplayMenu (CeasorCipher cipher)
        {
            Console.WriteLine("\n\n\t\t\tWelcome to S.H.E.I.L.D encryption services, please make a selection\n");
            Console.WriteLine("\t1. Set Shift Value ({0})", cipher.ShiftValue);
            Console.WriteLine("\t2. Set Group Size ({0})", cipher.GroupSize);
            Console.WriteLine("\t3. Set Dummy Character ({0})", cipher.DummyChar);
            Console.WriteLine("\t4. Encrypt message");
            Console.WriteLine("\t5. Decrypt message");
            Console.WriteLine("\n");
        }

        public static char ExitMessage ()
        {
            Console.Write("Return to menu? (Y/N): ");
            return Console.ReadKey(true).KeyChar;
        }

        public static int SetShiftValue ()
        {
            Console.Write("Please enter your shift value: ");
            string inputShiftValue = Console.ReadLine();
            int shiftValue = -1;
            Int32.TryParse(inputShiftValue, out shiftValue);
            return shiftValue;
        }

        public static int SetGroupSize()
        {
            Console.Write("Please enter your group size: ");
            string inputGroupSize = Console.ReadLine();
            int groupSize= -1;
            Int32.TryParse(inputGroupSize, out groupSize);
            return groupSize;
        }

        public static char SetDummyChar ()
        {
            Console.Write("Please enter your dummy character: ");
            char dummyChar = Console.ReadKey().KeyChar;
            if (!Char.IsLetterOrDigit(dummyChar))
            {
                dummyChar = '-';
            }
            return dummyChar;
        }

        public static string AskForMessage(bool tobeCipher)
        {
            Console.Write("Please enter your {0}text: ", tobeCipher? "" : "encrypted ");
            return Console.ReadLine();
        }

        public static void DisplayOutput(bool cipheredOutput, string output)
        {
            Console.WriteLine("{0} : {1}", cipheredOutput ? "CeasorCipher text" : "Decipher text", output );
        }

        static void Main(string[] args)
        {
            char info = 'y';
            CeasorCipher cipher = new CeasorCipher();
            do {
                DisplayMenu(cipher);
                Console.Write("Enter any one of 1-5 option: ");
                char userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (userInput)
                {
                    case '1':
                        int shiftValue = SetShiftValue();
                        if (shiftValue > 0)
                        {
                            cipher.ShiftValue = shiftValue;
                        }
                        continue;
                    case '2':
                        int groupSize = SetGroupSize();
                        if (groupSize > 0)
                        {
                            cipher.GroupSize = groupSize;
                        }
                        continue;
                    case '3':
                        char dummyCharacter = SetDummyChar();
                        if (dummyCharacter != '-')
                        {
                            cipher.DummyChar = dummyCharacter;
                        }
                        continue;
                    case '4':
                        string plainMessage = AskForMessage(true);
                        string cipheredMessage = cipher.Encipher(plainMessage, cipher.ShiftValue);
                        cipheredMessage = cipher.groupOutput(cipheredMessage);
                        DisplayOutput(true, cipheredMessage);
                        break;
                    case '5':
                        string encryptedMessage = AskForMessage(false);
                        DisplayOutput(false, cipher.Decipher(encryptedMessage));
                        break;
                    default:
                        Console.WriteLine("There is no option except for 1-5.");
                        continue;
                }
                info = ExitMessage();
                Console.WriteLine(info);
                Console.ReadKey();
            } while (Char.ToLower(info) != 'n');

            Console.WriteLine("You have exited the program. GoodBye!! ");
            Console.ReadKey();
        }
    }
}
