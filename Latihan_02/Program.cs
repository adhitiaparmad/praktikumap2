using System;

namespace Latihan_02
{

    abstract class BentukBenda
    {
        protected double luas;
        public abstract double Luas();
    }

    class Segitiga : BentukBenda
    {
        double alas, tinggi;
        public Segitiga(double LebarAlas, double Tinggi)
        {
            alas = LebarAlas;
            tinggi = Tinggi;
            luas = Luas();
        }

        public override double Luas()
        {
            luas = alas * tinggi / 2.0;
            return luas;
        }

        public override string ToString()
        {
            string hasil = "\nSegi Tiga"
                + "\n\tAlas\t: " + alas
                + "\n\tTinggi\t: " + tinggi
                + "\n\tLuas\t: " + luas;
            return hasil;
        }
    }

    class SegiEmpat : BentukBenda
    {
        double panjang, lebar;
        public SegiEmpat(double Panjang, double Lebar)
        {
            panjang = Panjang;
            lebar = Lebar;
            luas = Luas();
        }

        public override double Luas()
        {
            return panjang * lebar;
        }

        public override string ToString()
        {
            string hasil = "Segi Empat"
                + "\n\tPanjang\t: " + panjang
                + "\n\tLebar\t: " + lebar
                + "\n\tLuas\t: " + luas;
            return hasil;
        }
    }

    class Lingkaran : BentukBenda
    {
        static double phi = 3.14;
        double diameter, jari;

        public Lingkaran(double Diameter)
        {
            diameter = Diameter;
            jari = diameter/2;
            luas = Luas();
        }

        public override double Luas()
        {
            return (jari*jari) * phi;
        }

        public override string ToString()
        {
            string hasil = "Lingkaran"
                + "\n\tdiameter\t: " + diameter
                + "\n\tjari-jari\t: " + jari
                + "\n\tPHI Constanta\t: " + phi
                + "\n\tLuas\t: " + luas;
            return hasil;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            bool isLoop = true;

            while (isLoop)
            {

                Console.WriteLine("Selamat Datang di Console Menghitung Luas Praktikum AP2 \n");
                Console.WriteLine("Menu Hitung Luas Benda : \n");
                Console.WriteLine("1. Segitiga \n");
                Console.WriteLine("2. Segiempat \n");
                Console.WriteLine("3. Lingkaran \n");
                Console.WriteLine("Masukkan Pilihan Anda (nomor) : ");
                ConsoleKeyInfo menu = Console.ReadKey();
                Console.WriteLine("\n Pilihan Anda adalah : " + menu.KeyChar);

                int pilihanMenu = Int32.Parse(menu.KeyChar.ToString());

                switch (pilihanMenu)
                {
                    case 1:

                        Console.WriteLine("\nMenghitung Luas Segitiga \n");
                        Console.WriteLine("\nMasukkan Lebar Alas : "); //get input parameter lebar alas
                        string inputLebarAlas = Console.ReadLine();
                        Console.WriteLine("\nMasukkan Tinggi : "); //get input parameter tinggi
                        string inputTinggi = Console.ReadLine();

                        Segitiga segi3 = new Segitiga(Double.Parse(inputLebarAlas), Double.Parse(inputTinggi));
                        Console.WriteLine(segi3);
                        break;

                    case 2:

                        Console.WriteLine("\nMenghitung Luas Segiempat \n");
                        Console.WriteLine("\nMasukkan Panjang : "); //get input parameter lebar alas
                        string inputPanjang = Console.ReadLine();
                        Console.WriteLine("\nMasukkan Lebar : "); //get input parameter tinggi
                        string inputLebar = Console.ReadLine();

                        SegiEmpat segiEmpat = new SegiEmpat(Double.Parse(inputPanjang), Double.Parse(inputLebar)); //panjang and luas as input parameter
                        Console.WriteLine(segiEmpat);
                        break;

                    case 3:

                        Console.WriteLine("\nMenghitung Luas Lingkaran \n");
                        Console.WriteLine("\nMasukkan Diameter : "); //get input parameter Diameter
                        string inputDiameter = Console.ReadLine();
                        Lingkaran lingkaran = new Lingkaran(Double.Parse(inputDiameter)); //diameter as input parameter
                        Console.WriteLine(lingkaran);
                        break;
                }

                Console.WriteLine("\nKembali Ke Menu Awal Atau Keluar (Y/N) \n");
                if (Console.ReadLine().Equals("N"))
                {
                    isLoop = false;
                }
                /*
                Segitiga segi3 = new Segitiga(2.4, 5.0);
                Console.WriteLine(segi3);

                SegiEmpat segiEmpat = new SegiEmpat(4.0, 5.0); //panjang and luas as input parameter
                Console.WriteLine(segiEmpat);

                Lingkaran lingkaran = new Lingkaran(28.0); //diameter as input parameter
                Console.WriteLine(lingkaran);

                Console.ReadLine();*/

                
            }
        }
    }
}
