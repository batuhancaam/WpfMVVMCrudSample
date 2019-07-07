using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ResimModel
    {

        private int _resId;

        public int ResimId
        {
            get { return _resId; }
            set { _resId = value; }
        }

        private string _resAd;

        public string ResimAd
        {
            get { return _resAd; }
            set { _resAd = value; }
        }

        private int kisiId;

        public int KisiId
        {
            get { return kisiId; }
            set { kisiId = value; }
        }

    }
}
