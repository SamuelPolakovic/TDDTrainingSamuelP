/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2021. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class Item
    {
        private double price = 12.51;
        private string barcode = "123456789";

        public string Price => $"${Math.Round(price, 2)}";
        public string Barcode => barcode;
    }
}
