using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{
    public partial class Form1 : Form
    {
        private readonly string logFileDir = "log";

        private void initialize()
        {
            Directory.CreateDirectory(Path.Combine(Config.AppRoot, logFileDir));
        }
    }
}
