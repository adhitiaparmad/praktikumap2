using System;

namespace Latihan_03
{
    abstract class BentukBenda
    {
        static int jumlahObjek = 0;
        protected double luas;
        public abstract double Luas();

        public BentukBenda()
        {
            jumlahObjek++;
        }

        public static int getJumlahObjek()
        {
            return jumlahObjek;
        }
    }

    class Segitiga : BentukBenda
    {
        static int jumlahObjek = 0;
        int nomorObjek;
        public double alas, tinggi;

        public static int JumlahObjek
        {
            get
            {
                return jumlahObjek;
            }
        }

        public Segitiga(double LebarAlas, double Tinggi)
        {
            jumlahObjek++;
            nomorObjek = jumlahObjek;
            alas = LebarAlas;
            tinggi = Tinggi;
            luas = Luas();
        }

        public Segitiga() : this(50, 50)
        {

        }

        public Segitiga(double Sisi) : base()
        {

        }

        public Segitiga(int[] input) : this(input[0], input[1])
        {
            //one input parameter constuctor
        }

        public override double Luas()
        {
            luas = alas * tinggi / 2.0;
            return luas;
        }

        public override string ToString()
        {
            string hasil = "\nSegi Tiga ke-" + nomorObjek
                + "\n\tAlas\t: " + alas
                + "\n\tTinggi\t: " + tinggi
                + "\n\tLuas\t: " + luas;
            return hasil;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] num = {10,10}; //first index alas, second index tinggi

            Segitiga benda1 = new Segitiga(2.4, 5.0);
            //Segitiga benda2 = benda1;
            //benda1.alas = 40; //commenting this to fix segitiga ke 1 luas
            Segitiga benda2 = new Segitiga(); //to fix sequence of result

            Segitiga benda3 = new Segitiga(40, 15);

            Segitiga benda4 = new Segitiga(num); //call constructor for 1 parameter input (as array)

            Console.WriteLine(benda1);
            Console.WriteLine(benda2);
            Console.WriteLine(benda3);
            Console.WriteLine(benda4);
            Console.WriteLine("\nJumlah Segitiga : " + Segitiga.JumlahObjek);
            Console.ReadKey();
        }
    }
}
