using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AA2PersonalityDisorder.Classes;

namespace AA2PersonalityDisorder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public static class Services
    {
        public static FileValidationService FileValidation { get; } = new FileValidationService();
        public static AppEventAggregator EventHub { get; } = new AppEventAggregator();
        public static EditorContext EditorContext { get; } = new EditorContext();
    }

    public static class Constants
    {
        public const string ProjectFileName = "project.json";
    }
}
