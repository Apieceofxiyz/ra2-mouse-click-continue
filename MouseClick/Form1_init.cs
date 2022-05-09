using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{
    public partial class Form1
    {
        private readonly string logFileDir = "log";

        private void initialize()
        {
            // 创建日志文件夹
            Directory.CreateDirectory(Path.Combine(Config.AppRoot, logFileDir));

            // 初始化 gameProcessList
            gameProcessList = new HashSet<string>();

            string gameProcessFileFullPath = Path.Combine(Config.AppRoot, Config.GameProcessFileName);
            if (File.Exists(gameProcessFileFullPath))
            {
                string[] gameProcesses =
                    File.ReadAllLines(gameProcessFileFullPath);
                foreach (var gp in gameProcesses)
                {
                    if (!string.IsNullOrEmpty(gp))
                    {
                        gameProcessList.Add(gp);
                    }
                }
            }
            {
                var gameProcesses = Config.GameProcessList.Split(new string[] { Config.GameProcessSeparator },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var gp in gameProcesses)
                {
                    var finalGp = gp.Trim();
                    if (!string.IsNullOrEmpty(finalGp))
                    {
                        gameProcessList.Add(finalGp);
                    }
                }
            }

            if (Config.AutoDetectMode)
            {
                materialSwitch2.Checked = true;
            }
            materialSlider1.Value = Config.ClickCounts;
            leftClickSwitch.Checked = Config.LeftClick;
            rightClickSwitch.Checked = Config.RightClick;
            materialSwitch1.Checked = Config.ClickOn;
            switch (Config.HotKeyCode)
            {
                case 160:
                    materialRadioButton1.Checked = true;
                    break;
                case 162:
                    materialRadioButton3.Checked = true;
                    break;
                case 164:
                    materialRadioButton2.Checked = true;
                    break;
                default:
                    break;
            }
        }
    }
}
