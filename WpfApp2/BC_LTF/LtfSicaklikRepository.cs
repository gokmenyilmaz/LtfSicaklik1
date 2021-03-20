using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.BC_LTF
{
    public class LtfSicaklikRepository
    {
        LtfDbContext dc = new LtfDbContext();
   
        public List<LtfSicaklikModel> SicakliklariGetir()
        {
           var liste= dc.LtfSicakliklar.ToList();

            return liste;
        }

        public List<LtfSicaklikModel> TavSicakliklariGetir(string tavNo)
        {
            var liste = dc.LtfSicakliklar.Where(c => c.TavNo == tavNo).ToList();

            return liste;
        }

        public LtfSicaklikModel TavSicaklikGetir(string tavNo, int siraNo)
        {
            var sonuc = dc.LtfSicakliklar.FirstOrDefault(c => c.TavNo ==tavNo && c.SiraNo == siraNo);

            return sonuc;
        }

        internal void SicaklikEkle(LtfSicaklikModel sicaklik)
        {
            dc.LtfSicakliklar.Add(sicaklik);
        }

        internal void SicaklikGuncelle(LtfSicaklikModel sicaklik)
        {
            var kayit = dc.LtfSicakliklar.First(p => p.SiraNo == sicaklik.SiraNo && p.TavNo == sicaklik.TavNo);
            kayit.Bolge1 = sicaklik.Bolge1;
            kayit.Bolge2 = sicaklik.Bolge2;
            kayit.Bolge3 = sicaklik.Bolge3;
            kayit.Bolge4 = sicaklik.Bolge4;
            kayit.Bolge5 = sicaklik.Bolge5;
        }

        public void Kaydet()
        {
            dc.SaveChanges();
        }
    }
}
