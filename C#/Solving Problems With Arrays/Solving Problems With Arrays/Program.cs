using System;

namespace Solving_Problems_With_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 - 3 Write a bool function that is passed an array and the number of elements in
            //that array and determines whether the data in the array is sorted.This should
            //require only one pass
            Exercise3();


            //3 - 4 Here’s a variation on the array of const values.Write a program for creating a
            //substitution cipher problem.In a substitution cipher problem, all messages
            //are made of uppercase letters and punctuation.The original message is called
            //the plaintext, and you create the ciphertext by substituting each letter with
            //another letter(for example, each C could become an X).For this problem,
            //hard - code a const array of 26 char elements for the cipher, and have your
            //program read a plaintext message and output the equivalent ciphertext.
            // &&
            //3 - 5 Have the previous program convert the ciphertext back to the plaintext to
            //verify the encoding and decoding.
            Exercise4and5(true, "heisann hopp topp");  // <-- sender med hardkoda fordi....
            //Exercise4and5(args[0] == "e", args[1]);   -- args er broken av en eller annen grunn for tida


            //3 - 6 To make the ciphertext problem even more challenging, have your program randomly generate the cipher array instead of a hard - coded const array.
            //Effectively, this means placing a random character in each element of the
            //array, but remember that you can’t substitute a letter for itself.So the first
            //element can’t be A, and you can’t use the same letter for two substitutions—
            //that is, if the first element is S, no other element can be S.
            Exercise6();



            //3 - 7 Write a program that is given an array of integers and determines the mode,
            //which is the number that appears most frequently in the array.
            Exercise7();
        }

        private static void Exercise3()
        {
            int[] numbers = { 5, 2, 3, 4, 5, 7, 8 };

            foreach (var number in numbers) Console.Write(number + " "); //vis ett og ett array-tall i console
            Console.WriteLine($"sorted = {IsSorted3(numbers)}");  //send det usorterte arrayet til funksjonen og se om det er sortert - vis så i console

            numbers = new[] { 1, 2, 3, 5, 7, 8 };

            foreach (var number in numbers) Console.Write(number + " ");  //vis ett og ett array-tall i console
            Console.WriteLine($"sorted = {IsSorted3(numbers)}"); //send det sorterte arrayet til funksjonen og se om det er sortert - vis så i console
        }

        private static bool IsSorted3(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++) //begynne på 1 hvis ikke så blir det "out of bounds" med 0 minus 1. Den skal bare sjekke nåværende index VS previous index 
            {
                if (numbers[i] < numbers[i - 1]) return false;  //om nummeret NÅ er lavere enn nummeret bak - så er det ikke sortert. Send ut false.
            }
            return true;
        }



        private static void Exercise4and5(bool encrypt, string plaintext)
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var code = "QWERTYUIOPÅÆØLKJHGFDSAZXCVBNM";
            var ciphertext = Encrypt(plaintext,
                                     encrypt ? alphabet : code,   //er encrypt true? send med alafabetet som første par. False? send code som første par.
                                     encrypt ? code : alphabet);  //er encrypt true? send med code som andre par. False? send alfabetet som andre par.

            Console.WriteLine(ciphertext);
            
        }
        private static string Encrypt(string plaintext, string alphabet, string code) //tar i mot det den skal gjøre om i første par, det den skal gjøre om til i andre par
        {
            var ciphertext = "";
            for (int i = 0; i < plaintext.Length; i++)   //for hver bokstav i inntastet/medsent kode-tekst-linje
            {
                ciphertext += EncryptChar(plaintext[i], alphabet, code); //gjør om til kode/ordentlig ord
            }

            return ciphertext;
        }

        private static char EncryptChar(char c, string alphabet, string code)//får inn en og en bokstav i teksten, og det den skal gjøre om fra og hva den skal gjøre om til
        {
            for (int i = 0; i < alphabet.Length; i++) //går imellom det den skal gjøre om FRA
            {
                if (alphabet[i] == char.ToUpper(c)) //finner tilsvarende plass i det den skal gjøre om TIL (enten det er å gjøre TIL kode, eller gjøre om fra kode til VANLIG tekst
                {
                    return code[i]; // spytt ut bokstaven den currente skal byttes ut med - som da legges inn i ciphertext oppe i Encrypt()
                }
            }
            return c;
        }




        private static void Exercise6()
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var code = CreateCode(alphabet);
            Console.WriteLine(code);
        }

        private static string CreateCode(string alphabet)
        {
            var code = alphabet.ToCharArray(); //gjør om string til array av single characters
            var random = new Random();
            for (int index1 = 0; index1 < alphabet.Length; index1++) //gå igjennom en og en av chars'a
            {
                int randomIndex2;
                int avoidIndex2;
                do
                {
                    var randomChar1 = code[index1];//slå opp på en og en
                    var avoidIndex1 = alphabet.IndexOf(randomChar1); //ikke bytt ut med den samme
                    randomIndex2 = random.Next(0, alphabet.Length - 1); //plukk ut en tilfeldig index som finnes i arrayet

                    if (randomIndex2 >= avoidIndex1) randomIndex2++; //om den tilfeldige som er plukket ut ligger før den indexen vi står på nå - pluss opp i den globale
                    var randomChar2 = code[randomIndex2]; //lagre (for denne runda) det som ligger på den "opplussede" globale indexen (som øker for hver gang vi lander på en random index som er mindre enn current)
                    avoidIndex2 = alphabet.IndexOf(randomChar2); //sett den andre indexen vi skal avoide opp i den globale så vi har den (og kan avoide den) til neste runde
                } 
                while (avoidIndex2 == index1);// gjør alt dette så lenge den globale vi skal unngå er lik current index i loopen
                var tmp = code[index1];  //finn bokstaven som ligger i char arrayet som har nå værende "loop index"
                code[index1] = code[randomIndex2]; //gi char array bokstaven på current index en ny verdi - den globale random indexen!
                code[randomIndex2] = tmp; //sett tmp til å være denne nye verdien?
            }

            return new string(code);  //spytt ut det omstokkede char arrayet som VAR et alfabet - NÅ er det randomized rekkefølge på alle bokstavene og kan brukes til kodespråk!
        }

        private static void Exercise7()
        {
            int[] numArray = new int[6] { 3, 4, 5, 5, 5, 3}; //ett array med 6 tall i seg
            int count = 1; //counters <33
            int tempCount;

            int frequentNumber = numArray[0];  //..start med noe som helst
            int tempNumber = 0;  //et sted å legge ett og ett tall - og sjekke opp mot i if'en

            for (int i = 0; i < (numArray.Length); i++) 
            {
                tempNumber = numArray[i]; //sett temp til current
                tempCount = 0;   //null ut tempcount før neste loop-runder

                for (int j = 0; j < numArray.Length; j++) //gjennom alle talla igjen
                {
                    if (tempNumber == numArray[j]) //om temp fra forrige loop matcher det nåværende tallet i DENNE loopen
                    {
                        tempCount++;   //øk tempcount. Gjennom alle loopsa. Altså tell om current-tallet i innerste er makent til det det står på i ytterste loopen
                    }
                }
                if (tempCount > count)  //om antall makene tall er større enn count globalt
                {
                    frequentNumber = tempNumber;  //bytt ut "det første tallet" med current-tallet fra første loopen
                    count = tempCount;    // & sett count til å være tempcount!
                }
            }
            Console.WriteLine("The most frequent number in this array is {0} has been repeated {1} times.", frequentNumber, count);
            
        }
    }
}
