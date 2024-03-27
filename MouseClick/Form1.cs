using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using log4net;
using MaterialSkin;
using MaterialSkin.Controls;

namespace MouseClick
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public static readonly ILog LogDebug = LogManager.GetLogger("MC.DEBUG");
        public static readonly ILog LogInfo = LogManager.GetLogger("MC.INFO");

        private IKeyboardMouseEvents KMEvents;
        private Config Config = new Config();

        private ILog log = LogInfo;

        private bool clicking = false;
        private bool shiftDown = false;

        private bool flag_ares = false;

        private HashSet<string> gameProcessList;
        private HashSet<string> aresProcessList;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            //InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                       Primary.LightBlue600,
                       Primary.LightBlue800,
                       Primary.LightBlue300,
                       Accent.Red100,
                       TextShade.WHITE);
        }

        private void UnSubscribe()
        {
            try
            {
                //log.Info("try to unSubscribe");
                KMEvents.KeyDown -= KMEvents_KeyDown;
                KMEvents.KeyUp -= KMEvents_KeyUp;
                KMEvents.MouseDown -= KMEvents_MouseClick;

                KMEvents.Dispose();
                KMEvents = null;
            } catch(Exception e) {
                //log.Error("UnSubscribe failed", e);
                ;
            }
            //log.Info("UnSubscribe success");
        }

        private void Subscribe()
        {
            try
            {
                //log.Info("try to subscribe");
                KMEvents = Hook.GlobalEvents();
                KMEvents.KeyDown += KMEvents_KeyDown;
                KMEvents.KeyUp += KMEvents_KeyUp;
                KMEvents.MouseDown += KMEvents_MouseClick;
            } catch (Exception e)
            {
                //log.Error("Subscribe failed", e);
                ;
            }
            //log.Info("Subscribe success");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.ClickingOnLabel.Equals(button2.Text))
                UnSubscribe();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initialize();
        }

        private void KMEvents_MouseClick(object sender, MouseEventArgs e)
        {
            if (Config.LeftClick && e.Button == MouseButtons.Left)
            {
                //log.Debug($"鼠标左键点击了: ({e.X},{e.Y})位置");
                mouseClicked(e.X, e.Y);
            }
            if (Config.RightClick && e.Button == MouseButtons.Right)
            {
                //log.Debug($"鼠标右键点击了: ({e.X},{e.Y})位置");
                mouseClicked(e.X, e.Y, MouseButtons.Right);
            }
        }

        private bool shouldClick()
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            return shouldClick(x, y);
        }

        private bool shouldClick(int x, int y)
        {
            return Config.EnableRa2Mode ? Config.ScreenWidth - x < Config.ConstructionBarWidth : true;
        }

        private void mouseClicked(int x, int y, MouseButtons mouseButton = MouseButtons.Left)
        {
            if (clicking)
            {
                //log.Debug("正在连点中，忽略本次连点");
                return;
            }
            if (shiftDown && shouldClick(x, y))
            {
                if(!materialSwitch3.Checked || !flag_ares)
                    multipleClickMouse(Config.ClickCounts-1, mouseButton);
                else
                    multipleClickMouse(Config.ClickCounts/5-1, mouseButton);
            }
                
        }

        private void multipleClickMouse(int counts, MouseButtons mouseButton = MouseButtons.Left)
        {
            clicking = true;
            Task.Run(() =>
            {
                //log.Info($"开始连点({mouseButton.ToString()}): ({Cursor.Position.X},{Cursor.Position.Y})");
                int i = 0;
                for (i = 0; i < counts; i++)
                {
                    MouseSimulator.Click(mouseButton);
                    Thread.Sleep(Config.ClickInterval);
                }
                clicking = false;
                shiftDown = false;
                //log.Info($"连点结束, 本次连点点击了{counts}次");
            });
        }

        private void KMEvents_KeyUp(object sender, KeyEventArgs e)
        {
            //log.Debug($"{e.KeyCode} 键被松开");
            if (Config.UseRa2olStyle)
            {
                if ((int)e.KeyCode == Config.HotKeyCode)
                {
                    shiftDown = false;
                }
            }
        }

        private void KMEvents_KeyDown(object sender, KeyEventArgs e)
        {
            //log.Debug($"{e.KeyCode} 键被按下");
            if (Config.UseRa2olStyle)
            {
                if ((int)e.KeyCode == Config.HotKeyCode)
                {
                    shiftDown = true;
                }
            } else
            {
                if (shouldClick())
                {
                    multipleClickMouse(Config.ClickCounts);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 查看/修改 配置文件
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;

            string textEditor = Config.TextEditor;
            if (Path.IsPathRooted(textEditor))
            {
                FileInfo fileInfo = new FileInfo(textEditor);
                p.StartInfo.WorkingDirectory = fileInfo.Directory.FullName;
                p.StartInfo.FileName = fileInfo.Name;
            }
            else
            {
                p.StartInfo.FileName = textEditor;
            }

            p.StartInfo.Arguments = Config.ConfigFile;

            p.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switchClickStatus();
        }

        /// <summary>
        /// 连点开关
        /// </summary>
        private void switchClickStatus()
        {
            materialSwitch1.Checked = !materialSwitch1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://gitee.com/lenchu/ra2-mouse-click");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Debug模式
            if (checkBox1.Checked)
            {
                log = LogDebug;
            } else
            {
                log = LogInfo;
            }
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                Subscribe();
            }
            else
            {
                UnSubscribe();
            }
            Config.ClickOn = materialSwitch1.Checked;
        }

        private System.Threading.Timer autoDetectTimer;
        private System.Threading.Timer autoDetectAresTimer;

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoDetectMode = materialSwitch2.Checked;
            // 自动探测模式
            if (materialSwitch2.Checked)
            {
                autoDetectTimer = new System.Threading.Timer((state) =>
                {
                    if (this.gameProcessExists() && !materialSwitch1.Checked)
                    {
                        // 游戏进程存在且没有开启连点，则开启连点
                        //log.Info("检测到游戏进程 且 连点没有开启，开启连点");
                            this.ActiveControl.BeginInvoke(new Action(() => {
                                //switchClickStatus();
                                materialSwitch1.Checked = true;
                            }));
                    }
                    else if (!this.gameProcessExists() && materialSwitch1.Checked)
                    {
                        // 游戏进程不存在且开启了连点，则关闭连点
                        //log.Info("检测不到游戏进程 且 连点仍然开启，关闭连点");
                        this.ActiveControl.BeginInvoke(new Action(() => {
                            //switchClickStatus();
                            materialSwitch1.Checked = false;
                        }));
                    }
                }, null, Config.AutoDetectInterval, Config.AutoDetectInterval);
            }
            else
            {
                if (autoDetectTimer != null)
                    autoDetectTimer.Dispose();
                autoDetectTimer = null;
            }
        }

        private void materialSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoDetectAres = materialSwitch3.Checked;
            // 自动探测Ares
            if (materialSwitch3.Checked)
            {
                autoDetectAresTimer = new System.Threading.Timer((state) =>
                {
                    if (this.aresProcessExists() && materialSwitch3.Checked)
                    {
                        // Ares进程存在，自动判断Ares开启
                        //log.Info("检测到Ares");
                        flag_ares = true;
                    }
                    else if (!this.aresProcessExists() && materialSwitch3.Checked)
                    {
                        // Ares进程不存在，自动判断Ares开启
                        //log.Info("检测不到Ares");
                        flag_ares = false;
                    }
                }, null, Config.AutoDetectInterval, Config.AutoDetectInterval);
            }
            else
            {
                if (autoDetectAresTimer != null)
                    autoDetectAresTimer.Dispose();
                autoDetectAresTimer = null;
            }
        }

        private bool gameProcessExists()
        {
            int count = 0;
            foreach (string gp in gameProcessList)
            {
                Process[] processes = Process.GetProcessesByName(gp);
                count += processes.Length;
            }
            return count > 0;
        }

        private bool aresProcessExists()
        {
            int count = 0;
            foreach (string gp in aresProcessList)
            {
                Process[] processes = Process.GetProcessesByName(gp);
                count += processes.Length;
            }
            return count > 0;
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private void label1_Click(object sender, EventArgs e)
        {
            // 解释 自动探测模式
            MessageBox.Show("自动探测模式下，将会自动检测游戏是否在运行，是则开启连点，否则关闭连点", "提示");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // 解释 Debug模式
            MessageBox.Show("Debug模式下，将会输出更详细的日志，以便开发者快速定位bug，软件可以正常使用时无需开启此模式", "提示");
        }

        /// <summary>
        /// 连点次数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="newValue"></param>
        private void materialSlider1_onValueChanged(object sender, int newValue)
        {
            Config.ClickCounts = newValue;
        }

        private void leftClickSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Config.LeftClick = leftClickSwitch.Checked;
        }

        private void rightClickSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Config.RightClick = rightClickSwitch.Checked;
        }

        private void materialRadioButton1_Clicked(object sender, EventArgs e)
        {
            int hotKeyCode = Config.HotKeyCode;
            if (materialRadioButton1.Checked)
            {
                hotKeyCode = (int)Keys.LShiftKey;
            }
            else if (materialRadioButton2.Checked)
            {
                hotKeyCode = (int)Keys.LMenu;
            }
            else if (materialRadioButton3.Checked)
            {
                hotKeyCode = (int)Keys.LControlKey;
            }

            if (Config.HotKeyCode != hotKeyCode)
            {
                Config.HotKeyCode = hotKeyCode;
            }
        }
    }
}
