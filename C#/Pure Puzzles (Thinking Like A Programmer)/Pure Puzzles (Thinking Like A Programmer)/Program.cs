using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ting
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise2_3();
            Exercise2_2();
            Exercise2_1();
        }

        private static void Exercise2_3()
        {
            /*
                #            #
                 ##        ## 
                  ###    ###
                   ########
                   ########
                  ###    ###
                 ##        ##
                #            # 
            */

            var iValues = new[] { 0, 1, 2, 3, 3, 2, 1, 0 };
            foreach (var i in iValues) Row(i);

            //for (var i = 0; i < 4; i++) Row(i);
            //for (var i = 4 - 1; i >= 0; i--) Row(i);
        }

        private static void Row(int i)
        {
            Space(i);
            Hash(i + 1);
            Space(12 - i * 4);
            Hash(i + 1);
            NewLine();
        }

        private static void Exercise2_2()
        {
            /*
                  ##
                 ####
                ######
               ########
               ########
                ######
                 ####
                  ##
             */
            for (var i = 3; i >= 0; i--)  //tegn opp ene halvsiden 
            {
                Space(i);
                Hash(8 - 2 * i);  //8 hashes på det breieste 
                NewLine();
            }
            for (var i = 0; i < 4; i++) //tegn opp andre halvsiden
            {
                Space(i);
                Hash(8 - 2 * i);
                NewLine();
            }

            NewLine();
        }
        private static void Exercise2_1()
        {
            /*
               ########
                ######
                 ####
                  ##
             */
            for (var i = 0; i < 4; i++)
            {
                Space(i);
                Hash(8 - 2 * i);  
                NewLine();
            }

            NewLine();
        }

        private static void Hash(int count)   //tell hasher og kall tegnefunksjonen for hver gang det er noe som telles
        {
            for (var i = 0; i < count; i++) Hash();
        }

        private static void Hash()  //tegn ett symbol
        {
            Console.Write("#");
        }

        private static void NewLine() //neste linje
        {
            Console.WriteLine();
        }

        private static void Space(int count) //lag ett space
        {
            for (var i = 0; i < count; i++) Space();   
        }

        private static void Space() //om ikke parameter til Space, kjøres denne
        {
            Console.Write(" ");
        }
    }
}