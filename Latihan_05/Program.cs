using System;
using System.Collections.Generic;
using System.IO;

namespace Latihan_05
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
        static public int JumlahDosen { get; private set; }

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
        public DateTime TanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        public Prodi ProgramStudi { get; set; }
        public Dosen PembimbingAkademik { get; set; }
        static public int JumlahMahasiswa { get; private set; } = 0;

        public Mahasiswa(string namaMahasiswa)
        {
            NamaMahasiswa = namaMahasiswa;
            JumlahMahasiswa++;
            Console.WriteLine("Mahasiswa ditambahkan, nama " + namaMahasiswa);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi) : this(namaMahasiswa)
        {
            ProgramStudi = programStudi;
            ProgramStudi.tambahMahasiswa();
            Console.WriteLine("\tProgram Studi : " + programStudi.NamaProdi);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi, string nomorInduk, string tempatTanggalLahir) : this(namaMahasiswa, programStudi)
        {
            NomorIndukMahasiswa = nomorInduk;
            string[] arr = tempatTanggalLahir.Split(',');

            TempatLahir = arr[0];
            TanggalLahir = DateTime.ParseExact(arr[1].Trim(), "d/M/yyyy", null); //convert to excel date format

            Console.WriteLine("\tNIK : " + NomorIndukMahasiswa);
            Console.WriteLine("\tTempat, Tanggal Lahir  : " + TempatLahir + ", " + TanggalLahir);
        }
    }


    class Program
    {
        static void bacaFileMahasiswa(string fileMahasiswa, Prodi prodi, Dictionary<int, Mahasiswa> mahasiswa)
        {

            const string folderOutput = "../../output/";

            if (!Directory.Exists(folderOutput))
                Directory.CreateDirectory(folderOutput);
            string hasil= "";
            string fileOutput = folderOutput + "Mahasiswa.CSV";

            if (!File.Exists(fileOutput))
                hasil = "No., NIM, Nama Mahasiswa, Program Studi, Tempat Lahir, Tanggal Lahir\n";

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


                for (int i = 0; i < baris.Length; i++)
                {
                    string[] kolom = baris[i].Split('|');
                    Mahasiswa m = new Mahasiswa(kolom[1], prodi, kolom[0], kolom[2]);
                    mahasiswa.Add(i + sizeOfDic, m);
                    hasil += (i + sizeOfDic + 1) + ", " + kolom[0] + ", " + kolom[1] + ", " + prodi.NamaProdi +", "+ m.TempatLahir + ", " + m.TanggalLahir.ToShortDateString() + "\n"; //adding program studi and showing excel date format
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error : " + e.Message);
            }

            if (!File.Exists(fileOutput))
                File.WriteAllText(fileOutput, hasil);
            else
                File.AppendAllText(fileOutput, hasil);

            fileOutput = Path.GetFullPath(fileOutput);
            Console.WriteLine("\nOutput telah ditulis ke file : " + fileOutput);

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
