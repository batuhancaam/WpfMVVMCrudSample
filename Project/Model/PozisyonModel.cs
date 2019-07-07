using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
   public class PozisyonModel
    {
        private int _pozId;

        public int PozId
        {
            get { return _pozId; }
            set { _pozId = value; }
        }

        private string _pozAdi;

        public string PozAdi
        {
            get { return _pozAdi; }
            set { _pozAdi = value; }
        }



    }
}
