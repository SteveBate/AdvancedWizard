using System;
using System.Windows.Forms;

namespace Sample
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.Run(new CustomerWizardForm());
        }
    }
}