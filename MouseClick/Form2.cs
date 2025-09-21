using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{
    public partial class ShortcutForm : MaterialForm
    {
        private Config Config = new Config();
        public ShortcutForm()
        {
            InitializeComponent();
            this.HotKeyTextBox.Text = Config.KillProcessHotkey;
            CheckHotkey(this.HotKeyTextBox);
        }
        
        private string KeyCodeToString(Keys KeyCode)
        {
            if (KeyCode >= Keys.D0 && KeyCode <= Keys.D9)
            {
                return KeyCode.ToString().Remove(0, 1);
            }
            else if (KeyCode >= Keys.NumPad0 && KeyCode <= Keys.NumPad9)
            {
                return KeyCode.ToString().Replace("Pad", "");
            }
            else
            {
                return KeyCode.ToString();
            }
        }
        ///
        /// 设置按键不响应
        ///
        private void HotKeyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        ///
        /// 释放按键后，若是无实际功能键，则置无
        ///
        private void HotKeyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckHotkey(sender);
        }
        ///
        /// 失去焦点后，若是无实际功能键，则置无
        ///
        private void HotKeyTextBox_LostFocus(object sender, EventArgs e)
        {
            CheckHotkey(sender);
        }
        ///
        /// 检查是否无实际功能键，是则置无
        ///
        private void CheckHotkey(object sender)
        {
            MaterialTextBox txtHotKey = (MaterialTextBox)sender;
            if (txtHotKey.Text.EndsWith(" + ") || String.IsNullOrEmpty(txtHotKey.Text))
            {
                txtHotKey.Text = "无";
                txtHotKey.Tag = -1;
                txtHotKey.SelectionStart = txtHotKey.Text.Length;
            }
        }

        private void HotKeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int HotKeyValue = 0;
            string HotKeyString = "";
            e.SuppressKeyPress = false;
            e.Handled = true;
            if (e.Modifiers != Keys.None)
            {
                switch (e.Modifiers)
                {
                    case Keys.Control:
                        HotKeyString += "Ctrl + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                    case Keys.Alt:
                        HotKeyString += "Alt + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                    case Keys.Shift:
                        HotKeyString += "Shift + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                    case Keys.Control | Keys.Alt:
                        HotKeyString += "Ctrl + Alt + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                    case Keys.Control | Keys.Shift:
                        HotKeyString += "Ctrl + Shift + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                    case Keys.Alt | Keys.Shift:
                        HotKeyString += "Alt + Shift + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                    case Keys.Control | Keys.Alt | Keys.Shift:
                        HotKeyString += "Ctrl + Alt + Shift + ";
                        HotKeyValue = (int)e.Modifiers;
                        break;
                }
                if (e.KeyCode != Keys.None && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey)
                {
                    HotKeyString += KeyCodeToString(e.KeyCode);
                    HotKeyValue += (int)e.KeyCode;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    HotKeyString = "无";
                    HotKeyValue = -1;
                }
                else if (e.KeyCode != Keys.None)
                {
                    HotKeyString = KeyCodeToString(e.KeyCode);
                    HotKeyValue = (int)e.KeyCode;
                }
            }
            if (HotKeyValue == 0)
                HotKeyValue = -1;
            MaterialTextBox txtHotKey = (MaterialTextBox)sender;
            txtHotKey.Text = HotKeyString;
            txtHotKey.Tag = HotKeyValue;
            txtHotKey.SelectionStart = txtHotKey.Text.Length;
        }

        private void DefaultButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.HotKeyTextBox.Text = "Ctrl + Alt + F4";
        }

        private void HotKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.HotKeyTextBox.Text == "无" || this.HotKeyTextBox.Text.EndsWith(" + ") || String.IsNullOrEmpty(this.HotKeyTextBox.Text))
                this.SaveButton.Enabled = false;
            else
                this.SaveButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Config.KillProcessHotkey = this.HotKeyTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
