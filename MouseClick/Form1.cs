using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace MouseClick
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents KMEvents;
        private Config Config = new Config();

        private readonly int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;

        private bool clicking = false;
        private bool shiftDown = false;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void UnSubscribe()
        {
            KMEvents.KeyDown -= KMEvents_KeyDown;
            KMEvents.KeyUp -= KMEvents_KeyUp;
            KMEvents.MouseDown -= KMEvents_MouseClick;

            KMEvents.Dispose();
            KMEvents = null;
        }

        private void Subscribe()
        {
            KMEvents = Hook.GlobalEvents();
            KMEvents.KeyDown += KMEvents_KeyDown;
            KMEvents.KeyUp += KMEvents_KeyUp;
            KMEvents.MouseDown += KMEvents_MouseClick;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnSubscribe();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Subscribe();
            Console.WriteLine(ScreenWidth);
            Console.WriteLine(Config.EnableRa2Mode);
        }

        private void KMEvents_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Button);
            Console.WriteLine($"{e.X}, {e.Y}");
            Console.WriteLine($"clicking: {clicking}, shiftDown: {shiftDown}, shouldClick: {shouldClick(e.X, e.Y)}");

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
            return Config.EnableRa2Mode ? ScreenWidth - x < Config.ConstructionBarWidth : true;
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
            int count = int.Parse(button1.Text);
            button1.Text = $"{++count}";
        }
    }
}
