using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Word_Puzzles
{
    class Program
    {
        private static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            var allWords = GetWordList();
            
            var numberOfWordsToPrint = 200;

            while (numberOfWordsToPrint > 0)
            {
                var randomWord = FindRandomWord(allWords);
                var matchingWord = WordStartsWithEndOfRandomWord(randomWord, allWords);
                Console.WriteLine(matchingWord);
                numberOfWordsToPrint--;
               
            }

        }


        static string[] GetWordList()
        {
            var lastWord = string.Empty;
            var filePath = @"D:\gitREPOS\GET\OppgaveSett\C#\Word Puzzles\Word Puzzles\ordliste.txt";
            var wordList = new List<string>();

            foreach (var line in File.ReadLines(filePath, Encoding.UTF8)) //les en og en linje i teksten
            {
                var parts = line.Split('\t'); //splitt på mellomrom, så du får ett og ett ord
                var word = parts[1]; //selve ordet det gjelder ligger på 2. plass i arrayet.

                if (word != lastWord   //om alt av ordkrav møtes... 
                    && word.Length > 6
                    && word.Length < 10
                    && !word.Contains("-"))
                {
                    wordList.Add(word); //   - legg det til i lista
                   
                }
                lastWord = word;
            }
            return wordList.ToArray();
        }


        private static string FindRandomWord(string[] words)
        {
            var randomWordIndex = Random.Next(words.Length);
            var selectedWord = words[randomWordIndex];
            return selectedWord;
     
        }

        private static string WordStartsWithEndOfRandomWord(string randomWord, string[] allWords)
        {
            var currentLength = randomWord.Length;
            var endOfRandomWord3 = randomWord.Substring(currentLength - 3);
            var endOfRandomWord4 = randomWord.Substring(currentLength - 4);
            var endOfRandomWord5 = randomWord.Substring(currentLength - 5);
           
            foreach (var word in allWords)
            {
                if (word.StartsWith(endOfRandomWord3) && KombiWordMustBeAWordOnItsOwn(endOfRandomWord3, allWords)) { return randomWord + " & " + word; }
                if (word.StartsWith(endOfRandomWord4) && KombiWordMustBeAWordOnItsOwn(endOfRandomWord4, allWords)) { return randomWord + " & " + word; }
                if (word.StartsWith(endOfRandomWord5) && KombiWordMustBeAWordOnItsOwn(endOfRandomWord5, allWords)) { return randomWord + " & " + word; }
            }


            return "No Match";
        }


        private static bool KombiWordMustBeAWordOnItsOwn(string wordEnd, string[] allWords)
        {
            //try to fix this :(
             
            foreach (var word in allWords)
            {
                if (word == wordEnd)
                {
                    Console.WriteLine(word, wordEnd);
                    return true;
                }
            }

                return true;
        }



    }
}
