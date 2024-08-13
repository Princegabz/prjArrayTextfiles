using System;
using System.IO;
using Xceed.Wpf.Toolkit;

namespace prjArraysAndTextFiles
{
     class Program
    {
        private static StreamReader fileIn;
        private static StreamWriter fileOut;
        private static string[] id = new string[3];
        private static string[] name = new string[3];
        private static string[] price = new string[3];


        static void Main(string[] args)
        {
            fillAray();
            int choice = 1;
            while(choice == 1)
            {
                printArray();
                Console.WriteLine("Would you like to update a products price? "+"Enter (1) for Yes: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    enterNewValues();
                }
            }
        }

        private static void enterNewValues()
        {
            Console.Clear();
            Console.WriteLine("Enter the product ID to edit: ");
            string strID = Console.ReadLine();
            Boolean change = false;
            Boolean productFound = false;

            for(int y = 0; y<3; y++)
            {
                if (strID.Equals(id[y]))
                {
                    Console.WriteLine("Enter the new product price: ");
                    price[y] = Console.ReadLine();
                    change = true;
                    productFound = true;

                }
                if(productFound == false)
                {
                    Console.WriteLine("The product ID you entered cannot be located!" + "\nUpdate Failed");

                }
                if(change == true)
                {
                    writeBackToFile();
                }
            }

        }

        private static void writeBackToFile()
        {
            try
            {
                File.Delete("Products.txt");
                fileOut = new StreamWriter("Products.txt", true);
                for (int y = 0; y < 3; y++)
                {
                    fileOut.WriteLine(id[y]);
                    fileOut.WriteLine(name[y]);
                    fileOut.WriteLine(price[y]);
                }
                fileOut.Close();
                Console.WriteLine("Product file updated successfully!" + "\nUpdated");
            }
            catch(Exception ex)
            {
                Console.WriteLine("The following error had occured: " + ex.ToString());
            }
            printArray();
        }

        private static void printArray()
        {
            Console.Clear();
            Console.WriteLine("PRINT OUT FROM THE PRODUCTS TEXT FILE");
            Console.WriteLine("*************************************");
            for(int y =0; y < 3; y++)
            {
                Console.WriteLine("ID: "+id[y]);
                Console.WriteLine("PRODUCTS: "+name[y]);
                Console.WriteLine("PRICE: "+price[y]);
                Console.WriteLine("*************************************");
            }
        }

        private static void fillAray()
        {
            
            try
            {
                int x = 0;
                string proj = "";
                if (File.Exists("Products.txt"))
                {
                    fileIn = new StreamReader("Products.txt");
                    while ((proj = fileIn.ReadLine()) ! = null)
                    {
                        id[x] = proj;
                        proj = fileIn.ReadLine();
                        name[x] = proj;
                        proj = fileIn.ReadLine();
                        price[x] = proj;
                        x += 1;

                    }
                    fileIn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following error has occured: " + ex.ToString());
            }
        }
    }
}
