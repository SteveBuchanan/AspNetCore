using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConfigAttemp2.Models
{
    #region snippet1
    public class MySubOptions
    {
        public MySubOptions()
        {
            // Set default values.
            SubOption1 = "sub option1 value1_from_ctor";
            SubOption2 = 78;
        }

        public string SubOption1 { get; set; }
        public int SubOption2 { get; set; }
    }
    #endregion
}
