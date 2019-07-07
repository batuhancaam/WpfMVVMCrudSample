using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
   public class MusteriModel
    {
        private int _kisiId;
        private string _kisiAdi;
        private string _kisiSoyadi;
        private int _telefon;
        private int _numara;
        


        #region Constructor MusteriModel
        public int KisiId
        {
            get { return _kisiId; }
            set { _kisiId = value; }
        }

     

        public string KisiAdi
        {
            get { return _kisiAdi; }
            set { _kisiAdi = value; }
        }

      

        public string KisiSoyadi
        {
            get { return _kisiSoyadi; }
            set { _kisiSoyadi = value; }
        }

        

        public int Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

     

        public int Numara
        {
            get { return _numara; }
            set { _numara = value; }
        }

        private int _pozId;

        public int PozisyonId
        {
            get { return _pozId; }
            set { _pozId = value; }
        }




        #endregion






    }
}
