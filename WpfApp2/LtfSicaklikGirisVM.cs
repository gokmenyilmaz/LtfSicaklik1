using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.BC_LTF;
using WpfApp2.Model;
using WpfApp2.Veriler;

namespace WpfApp2
{
    public class LtfSicaklikGirisVM : INotifyPropertyChanged
    {
        private ObservableCollection<LtfSicaklikModel> ltfSicakliklar;

        LtfSicaklikRepository repo = new LtfSicaklikRepository();

        public DelegateCommand BaslatCommand => new DelegateCommand(OnBaslat, CanBaslat);
        public DelegateCommand BitirCommand => new DelegateCommand(OnBitir, CanBitir);

        public DelegateCommand<CellValue> CellValueChangedCommand=> new DelegateCommand<CellValue>(OnCellValueChanged);

        private void OnCellValueChanged(CellValue value)
        {

            MessageBox.Show("değişti");
        }

        private bool CanBitir()
        {
            return true;
        }

        private void OnBitir()
        {
            foreach (var sicaklik in LtfSicakliklar)
            {
                if (sicaklik.Bolge1.HasValue)
                {
                    //var dbKayit = DataBase.SicaklikTabloData.FirstOrDefault(c => c.TavNo == this.TavNo && c.SiraNo == sicaklik.SiraNo);

                    var dbKayit = repo.TavSicaklikGetir(this.TavNo, sicaklik.SiraNo);

                    if (dbKayit == null)
                    {
                        repo.SicaklikEkle(sicaklik);
                        //DataBase.DbSatirEkle(sicaklik);
                    }
                    else
                    {
                        repo.SicaklikGuncelle(sicaklik);
                        //DataBase.DbSatirGuncelle(sicaklik);
                    }
                       
                }
            }


            repo.Kaydet();

           
        }

        public string TavNo { get; }

        public ObservableCollection<LtfSicaklikModel> LtfSicakliklar
        {
            get => ltfSicakliklar; 
            set
            {
                ltfSicakliklar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LtfSicakliklar"));
            }
        }

        public LtfSicaklikGirisVM(string tavNo)
        {
            this.TavNo = tavNo;

            var reelTarih = DateTime.Now;

            VarsayilanTabloOlustur(reelTarih, tavNo);



            //var db_degerler = Veriler.DataBase.SicaklikTabloData
            //                .Where(p => p.TavNo == TavNo)
            //                .ToList();


            var db_degerler = repo.TavSicakliklariGetir(tavNo);


            foreach (var item in LtfSicakliklar)
            {
                var satir=db_degerler.Where(c => c.SiraNo == item.SiraNo).FirstOrDefault();

                if(satir!=null)
                {
                    item.Bolge1 = satir.Bolge1;
                    item.Bolge2 = satir.Bolge2;
                    item.Bolge3 = satir.Bolge3;
                    item.Bolge4 = satir.Bolge4;
                    item.Bolge5 = satir.Bolge5;
                }
            }
              


        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool CanBaslat()
        {
            return true;
        }

        private void OnBaslat()
        {
       
            var reelTarih = DateTime.Now;

            var tarihSaat = DateTime.Parse(reelTarih.AddHours(1).ToString("dd/MM/yyyy HH:00"));


            for (int i = 0; i < 48; i++)
            {
                var yeniTarih=tarihSaat.AddHours(i);

                var ltfSicaklik1 = new LtfSicaklikModel
                {
                    SiraNo = i + 1,
                    TarihSaat = yeniTarih,
                    Malzeme = "Fan",
                    TavNo = this.TavNo
                };
                LtfSicakliklar.Add(ltfSicaklik1);

            }


         
        }



        public void VarsayilanTabloOlustur(DateTime reelTarih, string tavNo)
        {
            LtfSicakliklar = new ObservableCollection<LtfSicaklikModel>();

            var tarihSaat = DateTime.Parse(reelTarih.AddHours(1).ToString("dd/MM/yyyy HH:00"));


            for (int i = 0; i < 48; i++)
            {
                var yeniTarih = tarihSaat.AddHours(i);

                var ltfSicaklik1 = new LtfSicaklikModel
                {
                    SiraNo = i + 1,
                    TarihSaat = yeniTarih,
                    Malzeme = "Fan",
                    TavNo = tavNo
                };
                LtfSicakliklar.Add(ltfSicaklik1);

            }

        }

    }
}
