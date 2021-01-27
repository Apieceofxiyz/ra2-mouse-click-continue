﻿using System;
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

        private readonly int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;

        private bool clicking = false;
        private bool shiftDown = false;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KMEvents.KeyDown -= KMEvents_KeyDown;
            KMEvents.KeyUp -= KMEvents_KeyUp;
            KMEvents.MouseClick -= KMEvents_MouseClick;

            KMEvents.Dispose();
            KMEvents = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KMEvents = Hook.GlobalEvents();
            KMEvents.KeyDown += KMEvents_KeyDown;
            KMEvents.KeyUp += KMEvents_KeyUp;
            KMEvents.MouseUp += KMEvents_MouseClick;
            Console.WriteLine(ScreenWidth);
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

        private bool shouldClick(int x, int y)
        {
            return shiftDown && ScreenWidth - x < 240;
        }

        private void mouseLeftClicked(int x, int y)
        {
            if (clicking)
                return;
            if (shouldClick(x, y))
                multipleClickLeft(9);
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
                    Thread.Sleep(10);
                }
                clicking = false;
                shiftDown = false;
            });
        }

        private void KMEvents_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LShiftKey)
            {
                shiftDown = false;
            }
        }

        private void KMEvents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LShiftKey)
            {
                shiftDown = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = int.Parse(button1.Text);
            button1.Text = $"{++count}";
        }
    }
}