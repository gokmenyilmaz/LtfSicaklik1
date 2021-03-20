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
    public class TavSicaklikListeVM : INotifyPropertyChanged
    {
        LtfSicaklikRepository repo = new LtfSicaklikRepository();


        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand VeriGetirCommand => new DelegateCommand(OnVeriGetir, CanVeriGetir);
        public DelegateCommand VeriEkleCommand => new DelegateCommand(OnVeriEkle);

        public DelegateCommand<string> SicaklikGirisCommand => new DelegateCommand<string>(OnSicaklikGiris);

        private ObservableCollection<LtfSicaklikModel> ltfSicakliklari;
        public ObservableCollection<LtfSicaklikModel> LtfSicakliklari
        {
            get => ltfSicakliklari; 
            set
            {
                ltfSicakliklari = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LtfSicakliklari)));
            }
        }



        private void OnVeriEkle()
        {
            LtfSicaklikModel satır = new LtfSicaklikModel
            {
                SiraNo = 1,
                TavNo = "2"
            };
            DataBase.DbSatirEkle(satır);

            
        }



        private bool CanVeriGetir()
        {
            return true;
        }

        private void OnVeriGetir()
        {
            //LtfSicakliklari = DataBase.SicaklikTabloData;

          
        }


        public TavSicaklikListeVM()
        {
            //LtfSicakliklari = DataBase.SicaklikTabloData;

            try
            {
                var data = repo.SicakliklariGetir();

                LtfSicakliklari = new ObservableCollection<LtfSicaklikModel>(data);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void OnSicaklikGiris(string veri)
        {
            LtfSicaklikGirisView frm = new LtfSicaklikGirisView();
            LtfSicaklikGirisVM vm = new LtfSicaklikGirisVM(veri);

            frm.DataContext = vm;
            frm.Show();
        }    

    }
}
