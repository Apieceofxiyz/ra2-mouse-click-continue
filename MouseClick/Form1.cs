using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using MouseClick.plugins;

namespace MouseClick
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents KMEvents;
        private Config Config = new Config();

        private bool clicking = false;
        private bool shiftDown = false;

        private List<ISubscribe> plugins = new List<ISubscribe>();

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;

            this.plugins.Add(new TeamControlPlugin());
        }

        private void UnSubscribe()
        {
            try
            {
                KMEvents.KeyDown -= KMEvents_KeyDown;
                KMEvents.KeyUp -= KMEvents_KeyUp;
                KMEvents.MouseDown -= KMEvents_MouseClick;

                KMEvents.Dispose();
                KMEvents = null;

                foreach (var plugin in this.plugins)
                {
                    plugin.SubscribeHandler(false, this.KMEvents);
                }
            } catch { }
        }

        private void Subscribe()
        {
            try
            {
                KMEvents = Hook.GlobalEvents();
                KMEvents.KeyDown += KMEvents_KeyDown;
                KMEvents.KeyUp += KMEvents_KeyUp;
                KMEvents.MouseDown += KMEvents_MouseClick;

                foreach (var plugin in this.plugins)
                {
                    plugin.SubscribeHandler(true, this.KMEvents);
                }
            } catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.ClickingOnLabel.Equals(button2.Text))
                UnSubscribe();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if ("lenchu".Equals(Config.Author))
            {
                this.Text = $"{this.Text} by lenchu";
            }

            Subscribe();
            button2.Text = Config.ClickingOnLabel;
        }

        private void KMEvents_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLeftClicked(e.X, e.Y);
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

        private void mouseLeftClicked(int x, int y)
        {
            if (clicking)
                return;
            if (shiftDown && shouldClick(x, y))
                multipleClickLeft(Config.ClickCounts);
        }

        private void multipleClickLeft(int counts)
        {
            clicking = true;
            Task.Run(() =>
            {
                int i = 0;
                for (i = 0; i < counts; i++)
                {
                    MouseSimulator.Click(MouseButtons.Left);
                    Thread.Sleep(Config.ClickInterval);
                }
                clicking = false;
                shiftDown = false;
            });
        }

        private void KMEvents_KeyUp(object sender, KeyEventArgs e)
        {
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
                    multipleClickLeft(Config.ClickCounts);
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
            if (Config.ClickingOnLabel.Equals(button2.Text))
            {
                UnSubscribe();
                button2.Text = Config.ClickingOffLabel;
            } else if (Config.ClickingOffLabel.Equals(button2.Text))
            {
                Subscribe();
                button2.Text = Config.ClickingOnLabel;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://gitee.com/lenchu/ra2-mouse-click");
        }
    }
}
