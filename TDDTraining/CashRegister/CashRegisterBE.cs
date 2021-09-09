using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CashRegister
{
    public static class CashRegisterBE
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FillItems();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CashRegister());
        }

        public static void FillItems()
        {
            Items.Add(new Item());
        }

        private static readonly IList<Item> Items = new List<Item>();

        public static Item Scan(string barcode)
        {
            return Items.FirstOrDefault(i => i.Barcode == barcode);
        }
    }
}
