using System.IO; // Contains the class file
using TurboReader;
using Fclp;
using System.Globalization;

namespace HangMan
{
        /// <summary>
        /// All of the code below is in this class called Program.
        /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main function of the program.
        /// </summary>
        /// <param name="args">This is an array of strings that contains the command-line
        /// arguments.</param>
        static void Main(string[] args)
        {
            string filename = ParseFileName(args);
            string secretWord = RandomizeWordFromFile(filename);
            int pointsLeft = PlayHangman(secretWord);
            ShowEndScreen(pointsLeft, secretWord);
        }

        /// <summary>
        /// It takes in an array of strings and returns a string.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static string ParseFileName(string[] args)
        {
            // Fallback file is what is returned in the case that
            // arguments cannot be parsed
            string fallbackFile = "sanat.txt";
            FluentCommandLineParser<ApplicationArguments> parser = new FluentCommandLineParser<ApplicationArguments>();

            //Usage: --file <filename>
            parser.Setup(arg => arg.FileName)
              .As("file") 
              .Required();

            var result = parser.Parse(args);
            if (result.HasErrors == false)
            {
                //ApplicationArguments arguments = parser.Object;
                return parser.Object.FileName;
            }
            else
            {
                return fallbackFile;
            }
        }

        /// <summary>
        /// Randomizes a valid word from given file.
        /// </summary>
        /// <param sanat.txt="filename">Name of the file</param>
        /// <returns>A valid word or empty word if something fails</returns>
        public static string RandomizeWordFromFile(string filename)
        {
            if (File.Exists(filename) == false)
            {
                Console.WriteLine("ERROR: No such file");
                return "";
            }
            // Read all the lines in the file
            string[] lines = File.ReadAllLines(filename);

            List<string> validWords = new List<string>(); // Creates empty list

            // Go through all the lines and add the valid ones to the list
            for (int i = 0; i < lines.Length; i++)
            {
                string word = lines[i];
                if (IsWordValid(word))
                {
                    // Ok, let's add to list
                    validWords.Add(word);
                }
                else
                {
                    // Discard - invalid word
                    // NOP (no operation)
                }
            }
            // Check if any of the words were valid
            if (validWords.Count > 0)
            {
                // make a new instance of random from one of the suitable rows
                Random random = new Random();
                // take random index to list
                int index = random.Next(0, validWords.Count);
                return validWords[index];
            }
            else
            {
                Console.WriteLine("ERROR: No valid words!");
                return "";
            }
        }

        /// <summary>
        /// It checks if the word is valid.
        /// </summary>
        /// <param name="word">The word to check.</param>
        public static bool IsWordValid(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            bool lettersOnly = true; // hypothesis
            //string = string of characters
            char[] contents= word.ToCharArray();
            for (int ctr = 0; ctr < contents.Length; ctr++)
            {
                char ch = contents[ctr];
                if (Char.IsLetter(ch))
                {
                    //is letter
                }
                else
                {
                    // is not letter
                    lettersOnly = false;
                    break;
                }
            }

            if(lettersOnly == true) {
                return true;
            }
            
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A function that takes a string as an argument and returns an integer.
        /// </summary>
        /// <param name="word">The word to be guessed.</param>
        public static int PlayHangman(string word)
        {
            // INIT PHASE:
            int points = 5; // Starting points
            List<char> guessed_letters = new List<char>(); // No guesses yet
                                                           // Array full of underscores for discovered letters: _ _ _ _ _ 
            char[] discovered_letters = new char[word.Length];

            for (int i = 0; i < discovered_letters.Length; i++)
            {
                discovered_letters[i] = '_';
            }
            int found_amount = 0;

            

            // GAME LOOP:
            while (true)
            {

                Console.WriteLine($"Points left: {points}");
                // Write discovered letters to screen
                Console.Write("Secret word: ");
                for (int i = 0; i < discovered_letters.Length; i++)
                {
                    Console.Write(discovered_letters[i]);
                }


                // Write guessed letters
                Console.WriteLine("");
                Console.WriteLine("Guessed letters:");
                for (int i = 0; i < guessed_letters.Count; i++)
                {
                    Console.Write(guessed_letters[i]);
                }

                Console.WriteLine("");
                char guess = KeyboardInput.ReadLetter("Guess the letter: ");

                if (guessed_letters.Contains(guess))
                {
                    Console.WriteLine("You have already guessed the letter: " + guess);
                    continue;
                }

                else
                {
                    guessed_letters.Add(guess);
                }

                if (word.Contains(guess))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess && discovered_letters[i] == '_')
                        {
                            discovered_letters[i] = guess;
                            found_amount++;
                        }
                    }
                    if(found_amount == word.Length)
                    {
                        //WIN
                        return points;
                    }
                }

                else
                {
                    Console.WriteLine($"Letter {guess} is not in the word.");
                    points--;

                    if(points == 0)
                    {
                        // GAME OVER
                        return points;
                    }
                }
            }
            return points;
        }

        /// <summary>
        /// *|MARKER_CURSOR|*
        /// </summary>
        /// <param name="pointsLeft">The number of points the player has left.</param>
        /// <param name="secretWord">The secret word that the user was trying to guess.</param>
        public static void ShowEndScreen(int pointsLeft, string secretWord)
        {
            if (pointsLeft > 0)
            {
                // You win screen. Tells you what the secret word was.
                Console.WriteLine($"You win! The secret word was {secretWord}.");
            }
            else
            {
                // You lose screen. Tells you what the secret word was.
                Console.WriteLine($"You lose! The secret word was {secretWord}.");
            }
        }
    }
}