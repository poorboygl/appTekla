using System;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Sap2000;

namespace appTekla
{
    internal static class Program
    {
        static Model _connectTekla;
        static Sap2000.SapObject _connectSap2000;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (_connectTekla == null)
            {
                _connectTekla = new Model();
            }
            if (_connectSap2000 == null)
            {
                _connectSap2000 = new Sap2000.SapObject();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(_connectTekla, _connectSap2000));
        }
    }
}
