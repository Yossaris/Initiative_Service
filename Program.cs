using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initiative_Service
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
       

        
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainWindow());
            var Name = new List<string> {"Bharmir", "Jennifer", "Caedwyth", "Leygolass", "Malon" };
            var IniBonus = new List<int> { -1, 3, 0, 3, 0 };
            var Roll = new List<int> { };
            
        }
        

    }
}
