using System;
using System.Collections.Generic;

namespace Latihan_07
{
    enum Pendanaan
    {
        OrangTua,
        Pribadi,
        BeasiswaParamadina,
        CSR_Paramadina,
        Kedinasan
    }

    class Mahasiswa
    {
        public static int NimTerakhir = 191001000;
        public static Dictionary<int, Mahasiswa> DaftarMahasiswa = new Dictionary<int, Mahasiswa>();
        public int SPP, UangGedung;
        public int[] UangSKS, Pembayaran;
        static bool KonfirmasiPembayaranMahasiswa = false;
        public bool DataInvalid = false;
        private string nama;
        private Pendanaan pendanaan;
        private int nim;
        private static int hargaSKS = 300000;
        public List<int> ArrUangSKS = new List<int>();

        public static Dictionary<Pendanaan, float> IpMin = new Dictionary<Pendanaan, float>()
        {
            {Pendanaan.BeasiswaParamadina, 3.25f },
            {Pendanaan.CSR_Paramadina, 3.00f },
            {Pendanaan.Kedinasan, 2.75f },
            {Pendanaan.OrangTua, 2.00f },
            {Pendanaan.Pribadi, 2.00f }
        };

        public int NIM
        {
            get { return nim; }
        }

        public Pendanaan SumberDana
        {
            get { return pendanaan; }
            set
            {
                pendanaan = value;
                switch (pendanaan)
                {
                    case Pendanaan.OrangTua:
                    case Pendanaan.Pribadi:
                        SPP = 5000000;
                        UangGedung = 12000000;
                        break;
                    case Pendanaan.BeasiswaParamadina:
                        SPP = 0;
                        UangGedung = 0;
                        break;
                    case Pendanaan.CSR_Paramadina:
                        SPP = 5000000;
                        UangGedung = 0;
                        break;
                    case Pendanaan.Kedinasan:
                        SPP = 2500000;
                        UangGedung = 6000000;
                        break;
                    default:
                        break;
                }
            }
        }

        public string NamaLengkap
        {
            get { return nama; }
            set
            {
                if(value.IndexOf(",") > 0 || value.IndexOf(".") > 0)
                {
                    Console.WriteLine("<< Salah : Nama tidak boleh disingkat atau mengandung jabatan/kepangkatan. >>");
                    DataInvalid = true;
                    return;
                }
                nama = value;
            }
        }

        public Mahasiswa(int NIM, string Nama, Pendanaan pendanaan)
        {
            nim = NIM;
            NamaLengkap = Nama;
            SumberDana = pendanaan;
            if (DataInvalid)
            {
                ToString();
                Console.WriteLine("Penambahan Mahasiswa Gagal");
                return;
            }
            if (KonfirmasiPembayaranMahasiswa)
            {
                Console.WriteLine("\nPenambahan Mahasiswa Baru");
                ToString();
            }
            DaftarMahasiswa.Add(nim, this);
        }

        public Mahasiswa(string Nama, Pendanaan pendanaan) : this(++NimTerakhir, Nama, pendanaan)
        {

        }

        public Mahasiswa(string Nama) : this(++NimTerakhir, Nama, Pendanaan.OrangTua)
        {
                
        }

        public void Tambah_IRS(float IP_semester_lalu, int jumlah_sks_diambil)
        {
            if (this.SumberDana == Pendanaan.OrangTua || this.SumberDana == Pendanaan.Pribadi)
            {
                this.ArrUangSKS.Add(jumlah_sks_diambil * hargaSKS);
            }
               
        }

        public override string ToString()
        {
            Console.WriteLine("NIM\t\t: {0}", NIM);
            Console.WriteLine("Nama Mahasiswa\t: {0}\nSumber Dana SPP\t: {1}", NamaLengkap, SumberDana);
            Console.WriteLine("IP Minimal\t\t: {0,4:F2}", Mahasiswa.IpMin[SumberDana]);
            Console.WriteLine("SPP\t\t: {0,-18:C0}\nUang Gedung\t: {1, -18:c0}", SPP, UangGedung);
            return null;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Mahasiswa m1 = new Mahasiswa("Harry T Yani Achsan");
            m1.Tambah_IRS(3, 10);
            m1.Tambah_IRS(3, 5);
            //m1.Tambah_IRS(1, 5);
            

            Mahasiswa m2 = new Mahasiswa("Harry Potter", Pendanaan.Kedinasan);
            m2.SumberDana = Pendanaan.CSR_Paramadina;
            Console.WriteLine(m2);
            m1 = new Mahasiswa("Tukijo");
            Mahasiswa m3 = new Mahasiswa("Surtini", Pendanaan.BeasiswaParamadina);
           
            Console.WriteLine("\n\nJumlah Mahasiswa : {0} Orang", Mahasiswa.DaftarMahasiswa.Count);
            Console.WriteLine("Daftar Mahasiswa");

            for (int i = 191001001; i <= Mahasiswa.NimTerakhir; i++)
            {
                try
                {
                    Mahasiswa m = Mahasiswa.DaftarMahasiswa[i];
                    Console.WriteLine("NIM : {0}, Nama: {1}", m.NIM, m.NamaLengkap);
                    //adding looping to print Array SKS
                    if (m.SumberDana == Pendanaan.OrangTua || m.SumberDana == Pendanaan.Pribadi)
                    {
                        for (int k = 0; k < m.ArrUangSKS.Count; k++)
                        {
                            Console.WriteLine("Uang SKS {0} : {1}", k, m.ArrUangSKS[k]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("NIM {0} Tidak Ditemukan.", i);
                }

            }

            Console.WriteLine("\n\nDaftar Detil Seluruh Mahasiswa, iterasi dengan menggunakan WHILE:");
            int nim = 191001001;
            Mahasiswa mhs;
            while (Mahasiswa.DaftarMahasiswa.TryGetValue(nim, out mhs))
            {
                Console.WriteLine("\n{0}", mhs);
                //adding looping to print Array SKS
                if (mhs.SumberDana == Pendanaan.OrangTua || mhs.SumberDana == Pendanaan.Pribadi)
                {
                    for (int k = 0; k < mhs.ArrUangSKS.Count; k++)
                    {
                        Console.WriteLine("Uang SKS {0} : {1}", k, mhs.ArrUangSKS[k]);
                    }
                }
                nim++;
            }

            Console.WriteLine("\n\nDaftar Detil Seluruh Mahasiswa, iterasi dengan menggunakan DO WHILE:");
            nim = 191001002;
            do
            {
                Mahasiswa mhs2 = Mahasiswa.DaftarMahasiswa[nim];
                Console.WriteLine("\n{0}", mhs2);
                //adding looping to print Array SKS
                if (mhs2.SumberDana == Pendanaan.OrangTua || mhs2.SumberDana == Pendanaan.Pribadi)
                {
                    for (int k = 0; k < mhs2.ArrUangSKS.Count; k++)
                    {
                        Console.WriteLine("Uang SKS {0} : {1}", k, mhs2.ArrUangSKS[k]);
                    }
                }

                nim++;
            } while (Mahasiswa.DaftarMahasiswa.TryGetValue(nim, out mhs));

            Console.ReadLine();
        }
    }
}
