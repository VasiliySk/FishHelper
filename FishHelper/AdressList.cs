using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishHelper
{
    class AdressList
    {
        public String mAdress { get; set; }
        public String mValue { get; set; }

        public AdressList()
        {

        }

        public AdressList(String mAdress, String mValue)
        {
            this.mAdress = mAdress;
            this.mValue = mValue;
        }
    }
}
