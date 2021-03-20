using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Model
{

    [Table("LtfSicaklik",Schema ="Uretim")]
    public class LtfSicaklikModel : MyBindingBase
    {
        private int? bolge1;
        private int? bolge2;
        private int? bolge3;
        private int? bolge4;
        private int? bolge5;

        [Key]
        public int Id { get; set; }

        public int SiraNo { get; set; }

        public string TavNo { get; set; }

        public DateTime TarihSaat { get; set; }
        public string Malzeme { get; set; }
        public int? Bolge1
        {
            get => bolge1;
            set
            {
                SetProperty(ref bolge1,value);
            }
        }

        public int? Bolge2 {
            get => bolge2;
            set
            {
                SetProperty(ref bolge2, value);
            }
        }
        public int? Bolge3 {
            get => bolge3;
            set
            {
                SetProperty(ref bolge3, value);
            }
        }
        public int? Bolge4 {
            get => bolge4;
            set
            {
                SetProperty(ref bolge4, value);
            }
        }
        public int? Bolge5 {
            get => bolge5; 
            set
            {
                SetProperty(ref bolge5, value);
            }
        }

      

        
    }
}
