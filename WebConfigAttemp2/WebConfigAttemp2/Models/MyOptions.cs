﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConfigAttemp2.Models
{
    #region snippet1
    public class MyOptions
    {
        public MyOptions()
        {
            // Set default value.
            Option1 = "value1_from_ctor";
        }

        public string Option1 { get; set; }
        public int Option2 { get; set; } = 5;
    }
    #endregion
}
