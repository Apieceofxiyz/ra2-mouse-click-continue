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
            // 创建日志文件夹
            Directory.CreateDirectory(Path.Combine(Config.AppRoot, logFileDir));

            // 初始化 gameProcessList
            string[] gameProcesses =
                File.ReadAllLines(Path.Combine(Config.AppRoot, Config.GameProcessFileName));
            gameProcessList = new List<string>();
            foreach (var gp in gameProcesses)
            {
                if (!string.IsNullOrEmpty(gp))
                {
                    gameProcessList.Add(gp);
                }
            }

            if (Config.AutoDetectMode)
            {
                checkBox2.Checked = true;
            }
        }
    }
}
