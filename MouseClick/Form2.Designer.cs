using MaterialSkin.Controls;

namespace MouseClick
{
    partial class ShortcutForm : MaterialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.HotKeyTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.DefaultButton = new MaterialSkin.Controls.MaterialButton();
            this.SaveButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(14, 34);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(106, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "请按下快捷键：";
            // 
            // HotKeyTextBox
            // 
            this.HotKeyTextBox.AnimateReadOnly = false;
            this.HotKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HotKeyTextBox.Depth = 0;
            this.HotKeyTextBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.HotKeyTextBox.LeadingIcon = null;
            this.HotKeyTextBox.Location = new System.Drawing.Point(14, 63);
            this.HotKeyTextBox.MaxLength = 50;
            this.HotKeyTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.HotKeyTextBox.Multiline = false;
            this.HotKeyTextBox.Name = "HotKeyTextBox";
            this.HotKeyTextBox.ReadOnly = true;
            this.HotKeyTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.HotKeyTextBox.Size = new System.Drawing.Size(200, 36);
            this.HotKeyTextBox.TabIndex = 1;
            this.HotKeyTextBox.Text = "";
            this.HotKeyTextBox.TrailingIcon = null;
            this.HotKeyTextBox.UseTallSize = false;
            this.HotKeyTextBox.TextChanged += new System.EventHandler(this.HotKeyTextBox_TextChanged);
            this.HotKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKeyTextBox_KeyDown);
            this.HotKeyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HotKeyTextBox_KeyPress);
            this.HotKeyTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HotKeyTextBox_KeyUp);
            this.HotKeyTextBox.LostFocus += new System.EventHandler(this.HotKeyTextBox_LostFocus);
            // 
            // DefaultButton
            // 
            this.DefaultButton.AutoSize = false;
            this.DefaultButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DefaultButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DefaultButton.Depth = 0;
            this.DefaultButton.HighEmphasis = true;
            this.DefaultButton.Icon = null;
            this.DefaultButton.Location = new System.Drawing.Point(14, 108);
            this.DefaultButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DefaultButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DefaultButton.Size = new System.Drawing.Size(90, 36);
            this.DefaultButton.TabIndex = 2;
            this.DefaultButton.Text = "默认";
            this.DefaultButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.DefaultButton.UseAccentColor = false;
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DefaultButton_MouseClick);
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = false;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.SaveButton.Depth = 0;
            this.SaveButton.HighEmphasis = true;
            this.SaveButton.Icon = null;
            this.SaveButton.Location = new System.Drawing.Point(124, 108);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.SaveButton.Size = new System.Drawing.Size(90, 36);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "保存";
            this.SaveButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.SaveButton.UseAccentColor = false;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ShortcutForm
            // 
            this.ClientSize = new System.Drawing.Size(228, 159);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.HotKeyTextBox);
            this.Controls.Add(this.materialLabel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShortcutForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialLabel materialLabel1;
        private MaterialButton DefaultButton;
        private MaterialButton SaveButton;
        internal MaterialTextBox HotKeyTextBox;
    }
}