using System;
using System.Diagnostics;
using System.IO;
using GemBox.Document;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using Xceed.Words.NET;
using GemBox.Document.Tables;

namespace CoreUAS
{
    class Alamat
    {
        public string kodepos;
        public string kelurahan;
        public string kecamatan;
        public string kabupatenKota;
        public string provinsi;
        public static string NEGARA = "INDONESIA";
        public decimal Latitude { get; set; }
        public decimal Longitue { get; set; }
    }
    class Sekolah : Alamat
    {
        /// <summary>
        /// Identitas Sekolah
        /// </summary>
        public string namaSekolah;
        public string NPSN;
        public string jenjangPendidikan;
        public string statusSekolah ;
        public string alamatSekolah;
        public string RT;
        public string RW;
        /// <summary>
        /// Data Pelengkap
        /// </summary>
        public string SKPendirianSekolah;
        public DateTime TanggalSKPendirian;
        public string statusKepemilikan;
        public string SKIjinOperasional;
        public DateTime tanggalSKIjinOperasional;
        public string kebutuhanKhususDilayani;
        public string nomorRekening;
        public string namaBank;
        public string cabang;
        public string rekeningNama;
        public string MBS;
        public int luasTanahMilik;
        public int luasTanahBukanMilik;
        public string namaWajibPajak;
        public string NPWP;
        /// <summary>
        /// kontak sekolah
        /// </summary>
        public string nomorTelepon;
        public string nomorFax;
        public string email;
        public string website;
        /// <summary>
        /// Data periodik
        /// </summary>
        public string waktuPenyelenggaraan;
        public string isAcceptBos;
        public string sertifikasiISO;
        public string sumberListrik;
        public string dayaListrik;
        public string aksesInternet;
        public string aksesInternetLainnya;
        /// <summary>
        /// Data lainnya
        /// </summary>
        public string namaKepalaSekolah;
        public string operatorPendataan;
        public string Akreditasi;
        public string kurikulum;
        
    }

    class DataRekap
    {
        public string[] uraian = new string[2];
        public string[] guru = new string[2];
        public string[] tendik = new string[2];
        public string[] ptk = new string[2];
        public string[] pd = new string[2];
        public string[] uraianSarpras = new string[3];
        public string[] jumlahSarpras = new string[3];
    }
    class Program
    {
        public void procExcel(string fileName, string schoolPicDir)
        {
            Sekolah sekolah = new Sekolah();
            DataRekap dataRekap = new DataRekap();
            Program pr = new Program();
            try
            {
                IWorkbook workbook = null;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);
                //First sheet
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    sekolah =  pr.SetSekolah(sheet);

                    //pr.gemboxWriting(sekolah);
                }

                sheet = workbook.GetSheetAt(1);
                if (sheet != null)
                {
                    dataRekap = pr.setDataTable(sheet);
                }

                pr.gemboxWriting(sekolah, dataRekap);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private Sekolah SetSekolah(ISheet sheet)
        {
            Sekolah sekolah = new Sekolah();
            sekolah.namaSekolah = sheet.GetRow(7).GetCell(3).ToString().Trim();
            sekolah.NPSN = sheet.GetRow(8).GetCell(3).ToString().Trim();
            sekolah.jenjangPendidikan = sheet.GetRow(9).GetCell(3).ToString().Trim();
            sekolah.statusSekolah = sheet.GetRow(10).GetCell(3).ToString().Trim();
            sekolah.alamatSekolah = sheet.GetRow(11).GetCell(3).ToString().Trim();
            sekolah.RT = sheet.GetRow(12).GetCell(3).ToString().Trim();
            sekolah.RW = sheet.GetRow(12).GetCell(5).ToString().Trim();
            sekolah.kodepos = sheet.GetRow(13).GetCell(3).ToString().Trim();
            sekolah.kelurahan = sheet.GetRow(14).GetCell(3).ToString().Trim();
            sekolah.kecamatan = sheet.GetRow(15).GetCell(3).ToString().Trim();
            sekolah.kabupatenKota = sheet.GetRow(16).GetCell(3).ToString().Trim();
            sekolah.provinsi = sheet.GetRow(17).GetCell(3).ToString().Trim();
            sekolah.Latitude = Decimal.Parse(sheet.GetRow(19).GetCell(3).ToString().Trim());
            sekolah.Longitue = Decimal.Parse(sheet.GetRow(20).GetCell(3).ToString().Trim());
            sekolah.SKPendirianSekolah = sheet.GetRow(22).GetCell(3).ToString().Trim();
            sekolah.TanggalSKPendirian = DateTime.Parse(sheet.GetRow(23).GetCell(3).ToString().Trim());
            sekolah.statusKepemilikan = sheet.GetRow(24).GetCell(3).ToString().Trim();
            sekolah.SKIjinOperasional = sheet.GetRow(25).GetCell(3).ToString().Trim();
            sekolah.tanggalSKIjinOperasional = DateTime.Parse(sheet.GetRow(26).GetCell(3).ToString().Trim());
            sekolah.kebutuhanKhususDilayani = sheet.GetRow(27).GetCell(3).ToString().Trim();
            sekolah.nomorRekening = sheet.GetRow(28).GetCell(3).ToString().Trim();
            sekolah.namaBank = sheet.GetRow(29).GetCell(3).ToString().Trim();
            sekolah.cabang = sheet.GetRow(30).GetCell(3).ToString().Trim();
            sekolah.rekeningNama = sheet.GetRow(31).GetCell(3).ToString().Trim();
            sekolah.MBS = sheet.GetRow(32).GetCell(3).ToString().Trim();
            sekolah.luasTanahMilik = int.Parse(sheet.GetRow(33).GetCell(3).ToString().Trim());
            sekolah.luasTanahBukanMilik = int.Parse(sheet.GetRow(34).GetCell(3).ToString().Trim());
            sekolah.namaWajibPajak = sheet.GetRow(35).GetCell(3).ToString().Trim();
            sekolah.NPWP = sheet.GetRow(36).GetCell(3).ToString().Trim();
            sekolah.nomorTelepon = sheet.GetRow(38).GetCell(3).ToString().Trim();
            sekolah.nomorFax = sheet.GetRow(39).GetCell(3).ToString().Trim();
            sekolah.email = sheet.GetRow(40).GetCell(3).ToString().Trim();
            sekolah.website = sheet.GetRow(41).GetCell(3).ToString().Trim();
            sekolah.waktuPenyelenggaraan = sheet.GetRow(43).GetCell(3).ToString().Trim();
            sekolah.isAcceptBos = sheet.GetRow(44).GetCell(3).ToString().Trim();
            sekolah.sertifikasiISO = sheet.GetRow(45).GetCell(3).ToString().Trim();
            sekolah.sumberListrik = sheet.GetRow(46).GetCell(3).ToString().Trim();
            sekolah.dayaListrik = sheet.GetRow(47).GetCell(3).ToString().Trim();
            sekolah.aksesInternet = sheet.GetRow(48).GetCell(3).ToString().Trim();
            sekolah.aksesInternetLainnya = sheet.GetRow(49).GetCell(3).ToString().Trim();
            sekolah.namaKepalaSekolah = sheet.GetRow(51).GetCell(3).ToString().Trim();
            sekolah.operatorPendataan = sheet.GetRow(52).GetCell(3).ToString().Trim();
            sekolah.Akreditasi = sheet.GetRow(53).GetCell(3).ToString().Trim();
            sekolah.kurikulum = sheet.GetRow(54).GetCell(3).ToString().Trim();
            return sekolah;
        }

        private DataRekap setDataTable(ISheet sheet)
        {
            DataRekap dataRekap = new DataRekap();
            dataRekap.uraian[0] = sheet.GetRow(6).GetCell(1).ToString().Trim();
            dataRekap.uraian[1] = sheet.GetRow(7).GetCell(1).ToString().Trim();
            dataRekap.guru[0] = sheet.GetRow(6).GetCell(2).ToString().Trim();
            dataRekap.guru[1] = sheet.GetRow(7).GetCell(2).ToString().Trim();
            dataRekap.tendik[0] = sheet.GetRow(6).GetCell(3).ToString().Trim();
            dataRekap.tendik[1] = sheet.GetRow(7).GetCell(3).ToString().Trim();
            dataRekap.ptk[0] = (int.Parse(dataRekap.guru[0]) + int.Parse(dataRekap.tendik[0])).ToString();
            dataRekap.ptk[1] = (int.Parse(dataRekap.guru[1]) + int.Parse(dataRekap.tendik[1])).ToString();
            dataRekap.pd[0] = sheet.GetRow(6).GetCell(5).ToString().Trim();
            dataRekap.pd[1] = sheet.GetRow(7).GetCell(5).ToString().Trim();
            dataRekap.uraianSarpras[0] = sheet.GetRow(17).GetCell(1).ToString().Trim();
            dataRekap.uraianSarpras[1] = sheet.GetRow(18).GetCell(1).ToString().Trim();
            dataRekap.uraianSarpras[2] = sheet.GetRow(19).GetCell(1).ToString().Trim();
            dataRekap.jumlahSarpras[0] = sheet.GetRow(17).GetCell(2).ToString().Trim();
            dataRekap.jumlahSarpras[1] = sheet.GetRow(18).GetCell(2).ToString().Trim();
            dataRekap.jumlahSarpras[2] = sheet.GetRow(19).GetCell(2).ToString().Trim();
            return dataRekap;
        }

        

       

        public void gemboxWriting(Sekolah sekolah, DataRekap dataRekap)
        {

            string FILE_NAME = "SURAT LAPORAN " + sekolah.namaSekolah.ToUpper() + ".docx";

            string HEADER_SURAT = "SURAT LAPORAN REKAPITULASI " + sekolah.namaSekolah.ToUpper();
            string NAMA_SEKOLAH_SURAT = "NAMA SEKOLAH \t\t : \t" + sekolah.namaSekolah.ToUpper();
            string NAMA_KEPALASKOLAH_SURAT = "NAMA KEPALA SEKOLAH \t : \t" + sekolah.namaKepalaSekolah.ToUpper();
            string ALAMATSEKOLAH_SURAT = "ALAMAT SEKOLAH \t : \t" + sekolah.alamatSekolah.ToUpper();
            string KELURAHAN_SURAT = "KELURAHAN \t\t : \t" + sekolah.kelurahan.ToUpper();
            string KECAMATAN_SURAT = "KECAMATAN \t\t : \t" + sekolah.kecamatan.ToUpper();
            string PROVINSI_SURAT = "PROVINSI \t\t : \t" + sekolah.provinsi.ToUpper();
            // If using Professional version, put your serial key below.
            //ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            ComponentInfo.SetLicense("DH5L-ED6Q-R7O0-DY0H");

            // Create new empty document.
            var document = new DocumentModel();

            var largeFont = new CharacterStyle("Large Font") { CharacterFormat = { Size = 24 } };
            document.Styles.Add(largeFont);

            // Add new section with two paragraphs, containing some text and symbols.
            /*document.Sections.Add(
                new Section(document,
                    new Paragraph(document,
                        new Run(document, "SURAT REKAPITULASI SD NEGERI KEMBANG.") { CharacterFormat = { FontName = "Windings", Size = 24} },
                        new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                        new Run(document, "\xFC" + "\xF0" + "\x32") { CharacterFormat = { FontName = "Wingdings", Size = 48 } }),
                    new Paragraph(document, "DENGAN INI KAMI MENYATAKAN.")));*/

            document.Sections.Add(
            new Section(document,
               new Paragraph(document,
                    new Run(document, HEADER_SURAT)
                    { 
                        CharacterFormat = { Style = largeFont, Bold = true, Size = 26}
                    })
               {
                   ParagraphFormat =
                   {
                        Alignment = GemBox.Document.HorizontalAlignment.Center
                   }
               },
               new Paragraph(document, "Dengan surat ini ingin melaporkan data rekapitulasi yang bertanda tangan di bawah ini :"),
               new Paragraph(document, NAMA_SEKOLAH_SURAT)
               {
                   ParagraphFormat =
                   {
                        LeftIndentation = 30,
                        RightIndentation = 20,
                        SpecialIndentation = 30
                   }
               },
               new Paragraph(document, NAMA_KEPALASKOLAH_SURAT)
               {
                   ParagraphFormat =
                   {
                        LeftIndentation = 30,
                        RightIndentation = 20,
                        SpecialIndentation = 30
                   }
               },
               new Paragraph(document, ALAMATSEKOLAH_SURAT)
               {
                   ParagraphFormat =
                   {
                        LeftIndentation = 30,
                        RightIndentation = 20,
                        SpecialIndentation = 30
                   }
               },
               new Paragraph(document, KELURAHAN_SURAT)
               {
                   ParagraphFormat =
                   {
                        LeftIndentation = 30,
                        RightIndentation = 20,
                        SpecialIndentation = 30
                   }
               },
               new Paragraph(document, KECAMATAN_SURAT)
               {
                   ParagraphFormat =
                   {
                        LeftIndentation = 30,
                        RightIndentation = 20,
                        SpecialIndentation = 30
                   }
               },
               new Paragraph(document, PROVINSI_SURAT)
               {
                   ParagraphFormat =
                   {
                        LeftIndentation = 30,
                        RightIndentation = 20,
                        SpecialIndentation = 30
                   }
               },
               
               new Paragraph(document,
                    new Run(document, "A. Data PTK dan PD")
                    {
                        CharacterFormat = { Style = largeFont, Bold = true, Size = 14 }
                    })
               {
                   ParagraphFormat =
                   {
                        Alignment = GemBox.Document.HorizontalAlignment.Left
                   }
               }));

            var section = new Section(document);
            document.Sections.Add(section);

            // Create a table with 100% width.
            GemBox.Document.Tables.Table table = new GemBox.Document.Tables.Table(document);
            table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            section.Blocks.Add(table);

            
            
            for (int r = 0; r < 3; r++)
            {
                // Create a row and add it to table.
                var row = new TableRow(document);
                table.Rows.Add(row);
                Console.WriteLine("Nambah Row");

                for (int c = 0; c < 6; c++)
                {
                    // Create a cell and add it to row.
                    var cell = new TableCell(document);
                    row.Cells.Add(cell);

                    // Create a paragraph and add it to cell.
                    if(r == 0)
                    {
                        if(c==0)
                        {
                            var paragraph = new Paragraph(document, "No");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 1)
                        {
                            var paragraph = new Paragraph(document, "Uraian");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 2)
                        {
                            var paragraph = new Paragraph(document, "Guru");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 3)
                        {
                            var paragraph = new Paragraph(document, "Tendik");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 4)
                        {
                            var paragraph = new Paragraph(document, "PTK");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 5)
                        {
                            var paragraph = new Paragraph(document, "PD");
                            cell.Blocks.Add(paragraph);
                        }
                    }
                    else
                    {
                        if (c == 0)
                        {
                            var paragraph = new Paragraph(document, r.ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 1)
                        {
                            var paragraph = new Paragraph(document, dataRekap.uraian[r-1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 2)
                        {
                            var paragraph = new Paragraph(document, dataRekap.guru[r - 1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 3)
                        {
                            var paragraph = new Paragraph(document, dataRekap.tendik[r - 1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 4)
                        {
                            var paragraph = new Paragraph(document, dataRekap.ptk[r - 1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 5)
                        {
                            var paragraph = new Paragraph(document, dataRekap.pd[r - 1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                    }
                   
                }
            }

            document.Sections.Add(
            new Section(document,
               new Paragraph(document,
                    new Run(document, "B. Data Sarpras")
                    {
                        CharacterFormat = { Style = largeFont, Bold = true, Size = 14 }
                    })
               {
                   ParagraphFormat =
                   {
                        Alignment = GemBox.Document.HorizontalAlignment.Left
                   }
               }));

            var sectionSapras = new Section(document);
            document.Sections.Add(sectionSapras);

            GemBox.Document.Tables.Table tableSapras = new GemBox.Document.Tables.Table(document);
            tableSapras.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            sectionSapras.Blocks.Add(tableSapras);

            for (int r = 0; r < 4; r++)
            {
                // Create a row and add it to table.
                var row = new TableRow(document);
                tableSapras.Rows.Add(row);
                
                for (int c = 0; c < 3; c++)
                {
                    // Create a cell and add it to row.
                    var cell = new TableCell(document);
                    row.Cells.Add(cell);

                    // Create a paragraph and add it to cell.
                    if (r == 0)
                    {
                        if (c == 0)
                        {
                            var paragraph = new Paragraph(document, "No");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 1)
                        {
                            var paragraph = new Paragraph(document, "Uraian");
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 2)
                        {
                            var paragraph = new Paragraph(document, "Jumlah");
                            cell.Blocks.Add(paragraph);
                        }
                        
                    }
                    else
                    {
                        if (c == 0)
                        {
                            var paragraph = new Paragraph(document, r.ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 1)
                        {
                            var paragraph = new Paragraph(document, dataRekap.uraianSarpras[r - 1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        if (c == 2)
                        {
                            var paragraph = new Paragraph(document, dataRekap.jumlahSarpras[r - 1].ToString());
                            cell.Blocks.Add(paragraph);
                        }
                        
                        
                    }

                }
            }

            document.Sections.Add(
            new Section(document,
              new Paragraph(document,
                   new Run(document, "Demikian laporan ini dibuat agar dapat ditindaklanjuti")
                   {
                       CharacterFormat = { Style = largeFont, Bold = true, Size = 14 }
                   })
              {
                  ParagraphFormat =
                  {
                        Alignment = GemBox.Document.HorizontalAlignment.Left
                  }
              }));

            // Save Word document to file's path.
            Console.WriteLine("Write file");
            document.Save(FILE_NAME);
            Console.WriteLine("Sukses");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Reading Excel!");
            Program pr = new Program();
            pr.procExcel("C:/Users/aputr/Documents/Kec. Mampang Prapatan/SDS KEMBANG.xlsx", "");
            pr.procExcel("C:/Users/aputr/Documents/Kec. Mampang Prapatan/SD BUDI WALUYO II.xlsx", "");

        }
    }
}
