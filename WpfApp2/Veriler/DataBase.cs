using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.Veriler
{
    public class DataBase
    {
        private static ObservableCollection<LtfSicaklikModel> sicaklikTabloData { get; set; }

        static DataBase()
        {
            sicaklikTabloData = new ObservableCollection<LtfSicaklikModel>();

            var data1 = new LtfSicaklikModel { Id = 1, SiraNo = 1, TarihSaat = DateTime.Now, TavNo = "1", Bolge1 = 233 };
            var data2 = new LtfSicaklikModel { Id = 2, SiraNo = 2, TarihSaat = DateTime.Now, TavNo = "1", Bolge1 = 344 };
            var data3 = new LtfSicaklikModel { Id = 3, SiraNo = 3, TarihSaat = DateTime.Now, TavNo = "1", Bolge1 = 34 };
            var data4 = new LtfSicaklikModel { Id = 4, SiraNo = 1, TarihSaat = DateTime.Now, TavNo = "2", Bolge1 = 4 };
            var data5 = new LtfSicaklikModel { Id = 5, SiraNo = 2, TarihSaat = DateTime.Now, TavNo = "2", Bolge1 = 456 };

            sicaklikTabloData.Add(data1);
            sicaklikTabloData.Add(data2);
            sicaklikTabloData.Add(data3);
            sicaklikTabloData.Add(data4);
            sicaklikTabloData.Add(data5);
        }

        public  static void DbSatirGuncelle(LtfSicaklikModel sicaklik)
        {
            var kayit = sicaklikTabloData.First(p => p.SiraNo == sicaklik.SiraNo && p.TavNo==sicaklik.TavNo);
            kayit.Bolge1 = sicaklik.Bolge1;
            kayit.Bolge2 = sicaklik.Bolge2;
            kayit.Bolge3 = sicaklik.Bolge3;
            kayit.Bolge4 = sicaklik.Bolge4;
            kayit.Bolge5 = sicaklik.Bolge5;
        }

        public static void DbSatirEkle(LtfSicaklikModel satir)
        {
            sicaklikTabloData.Add(satir);
        }

        public static ObservableCollection<LtfSicaklikModel> SicaklikTabloData {
            
            get {
                return sicaklikTabloData;
            }
        }
    }
}
