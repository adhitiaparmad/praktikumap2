using System;
using System.Collections.Generic;
using System.IO;

namespace Latihan_04
{
    class Prodi
    {
        public string NamaProdi { get; set; }
        public Dosen Kaprodi { get; set; }
        static public int JumlahProdi { get; private set; } = 0;
        public int JumlahDosen { get; private set; } = 0;
        public int JumlahMahasiswa { get; private set; } = 0;

        public Prodi(string namaProdi)
        {
            JumlahProdi++;
            NamaProdi = namaProdi;
        }

        public Prodi(string NamaProdi, Dosen kaprodi) : this(NamaProdi)
        {
            Kaprodi = kaprodi;
            Console.WriteLine("Menambahkan Prodi : " + NamaProdi + ", Dengan Ka Prodinya : " + kaprodi.NamaDosen);
        }

        public void tambahMahasiswa()
        {
            JumlahMahasiswa++;
        }

        public void kurangiMahasiswa()
        {
            JumlahMahasiswa--;
        }
    }

    class Dosen
    {
        public string NamaDosen { get; set; }
        static public int JumlahDosen { get;private set; }
        
        public Dosen(string namaDosen)
        {
            NamaDosen = namaDosen;
            tambahDosen();
            Console.WriteLine("Tambah Dosen : " + NamaDosen);
        }

        public void tambahDosen()
        {
            JumlahDosen++;
        }

        public void kurangDosen()
        {
            JumlahDosen--;
        }
    }

    class Mahasiswa
    {
        public string NamaMahasiswa { get; set; }
        public string NomorIndukMahasiswa { get; set; }
        public string TempatTanggalLahir { get; set; }
        public Prodi ProgramStudi { get; set; }
        public Dosen PembimbingAkademik { get; set; }
        static public int JumlahMahasiswa { get; private set; } = 0;

        public Mahasiswa(string namaMahasiswa)
        {
            NamaMahasiswa = namaMahasiswa;
            JumlahMahasiswa++;
            Console.WriteLine("Mahasiswa ditambahkan, nama " + namaMahasiswa);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi):this(namaMahasiswa)
        {
            ProgramStudi = programStudi;
            ProgramStudi.tambahMahasiswa();
            Console.WriteLine("\tProgram Studi : " + programStudi.NamaProdi);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi, string nomorInduk, string tempatTanggalLahir) : this(namaMahasiswa, programStudi)
        {
            NomorIndukMahasiswa = nomorInduk;
            TempatTanggalLahir = tempatTanggalLahir;
            Console.WriteLine("\tNIK : " + NomorIndukMahasiswa);
            Console.WriteLine("\tTempat, Tanggal Lahir  : " + TempatTanggalLahir);
        }
    }


    class Program
    {
        static void bacaFileMahasiswa(string fileMahasiswa, Prodi prodi, Dictionary<int, Mahasiswa> mahasiswa)
        {
            try
            {
                string mhs = File.ReadAllText(fileMahasiswa);
                string[] baris = mhs.Split('\n');
                int sizeOfDic = mahasiswa.Count;
                int index;
                //Console.WriteLine("Size of Dic : " + sizeOfDic);
                if (sizeOfDic > 0)
                    index = sizeOfDic;
                else index = 0;

                for (int i=0; i<baris.Length; i++)
                {
                    string[] kolom = baris[i].Split('|');
                    Mahasiswa m = new Mahasiswa(kolom[1], prodi, kolom[0], kolom[2]);
                    mahasiswa.Add(i+sizeOfDic,m);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error : "+e.Message);
            }

        }

        static void Main(string[] args)
        {
            Dictionary<int, Mahasiswa> mahasiswa = new Dictionary<int, Mahasiswa>();
            Prodi psti = new Prodi("Teknik Informatika");
            Console.WriteLine("Menambahkan Mahasiswa Prodi : " + psti.NamaProdi + "\n");
            bacaFileMahasiswa("../../mahasiswa_psti.txt", psti, mahasiswa);

            Console.WriteLine("\n");
            Dosen dosen = new Dosen("Pak Hatta Syahputra");
            Console.WriteLine("\n");
            Prodi hi = new Prodi("HI", dosen);
            Console.WriteLine("Menambahkan Mahasiswa Prodi : " + hi.NamaProdi + "\n");
            bacaFileMahasiswa("../../mahasiswa_hi.txt", hi, mahasiswa);

            Console.ReadKey();
        }
    }
}
