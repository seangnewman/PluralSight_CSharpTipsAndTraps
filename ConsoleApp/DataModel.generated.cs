﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    // Simulates the file generated by a third party, tool, visual designer etc.
    public partial class DataModel
    {
        public string Status { get; private set; }

        public DataModel()
        {
            Status = "New";
        }

        public void ClearStatus()
        {
            Status = "";
            AfterStatusCleared();
        }

        partial void AfterStatusCleared();      // Not Implementation or {}
    }
}
