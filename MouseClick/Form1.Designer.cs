namespace MouseClick
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialSlider1 = new MaterialSkin.Controls.MaterialSlider();
            this.materialSwitch2 = new MaterialSkin.Controls.MaterialSwitch();
            this.leftClickSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.rightClickSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton3 = new MaterialSkin.Controls.MaterialRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(606, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "点击修改配置(保存即生效，无需重启)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(606, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(606, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "开源地址";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(629, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 25);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Debug模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.Location = new System.Drawing.Point(613, 222);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(197, 25);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "自动检测游戏进程";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(631, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "？";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(668, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "？";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(609, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "连点次数";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(722, 269);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 9;
            // 
            // materialSwitch1
            // 
            this.materialSwitch1.AutoSize = true;
            this.materialSwitch1.Depth = 0;
            this.materialSwitch1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialSwitch1.Location = new System.Drawing.Point(9, 76);
            this.materialSwitch1.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch1.Name = "materialSwitch1";
            this.materialSwitch1.Ripple = true;
            this.materialSwitch1.Size = new System.Drawing.Size(122, 37);
            this.materialSwitch1.TabIndex = 11;
            this.materialSwitch1.Text = "连点开关";
            this.materialSwitch1.UseVisualStyleBackColor = true;
            this.materialSwitch1.CheckedChanged += new System.EventHandler(this.materialSwitch1_CheckedChanged);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(11, 301);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(280, 36);
            this.materialButton1.TabIndex = 12;
            this.materialButton1.Text = "更 多 设 置 ( 需 要 重 启 )";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // materialSlider1
            // 
            this.materialSlider1.Depth = 0;
            this.materialSlider1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialSlider1.Location = new System.Drawing.Point(18, 159);
            this.materialSlider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSlider1.Name = "materialSlider1";
            this.materialSlider1.RangeMax = 30;
            this.materialSlider1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialSlider1.Size = new System.Drawing.Size(250, 40);
            this.materialSlider1.TabIndex = 28;
            this.materialSlider1.Text = "连点次数";
            this.materialSlider1.Value = 10;
            this.materialSlider1.ValueMax = 30;
            this.materialSlider1.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.materialSlider1_onValueChanged);
            // 
            // materialSwitch2
            // 
            this.materialSwitch2.AutoSize = true;
            this.materialSwitch2.Depth = 0;
            this.materialSwitch2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialSwitch2.Location = new System.Drawing.Point(9, 118);
            this.materialSwitch2.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch2.Name = "materialSwitch2";
            this.materialSwitch2.Ripple = true;
            this.materialSwitch2.Size = new System.Drawing.Size(186, 37);
            this.materialSwitch2.TabIndex = 32;
            this.materialSwitch2.Text = "自动检测游戏进程";
            this.materialSwitch2.UseVisualStyleBackColor = true;
            this.materialSwitch2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // leftClickSwitch
            // 
            this.leftClickSwitch.AutoSize = true;
            this.leftClickSwitch.Depth = 0;
            this.leftClickSwitch.Location = new System.Drawing.Point(9, 206);
            this.leftClickSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.leftClickSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.leftClickSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.leftClickSwitch.Name = "leftClickSwitch";
            this.leftClickSwitch.Ripple = true;
            this.leftClickSwitch.Size = new System.Drawing.Size(122, 37);
            this.leftClickSwitch.TabIndex = 33;
            this.leftClickSwitch.Text = "左键连点";
            this.leftClickSwitch.UseVisualStyleBackColor = true;
            this.leftClickSwitch.CheckedChanged += new System.EventHandler(this.leftClickSwitch_CheckedChanged);
            // 
            // rightClickSwitch
            // 
            this.rightClickSwitch.AutoSize = true;
            this.rightClickSwitch.Depth = 0;
            this.rightClickSwitch.Location = new System.Drawing.Point(146, 206);
            this.rightClickSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.rightClickSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rightClickSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.rightClickSwitch.Name = "rightClickSwitch";
            this.rightClickSwitch.Ripple = true;
            this.rightClickSwitch.Size = new System.Drawing.Size(122, 37);
            this.rightClickSwitch.TabIndex = 34;
            this.rightClickSwitch.Text = "右键连点";
            this.rightClickSwitch.UseVisualStyleBackColor = true;
            this.rightClickSwitch.CheckedChanged += new System.EventHandler(this.rightClickSwitch_CheckedChanged);
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Location = new System.Drawing.Point(8, 251);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(101, 37);
            this.materialRadioButton1.TabIndex = 35;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Shift连点";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            this.materialRadioButton1.Click += new System.EventHandler(this.materialRadioButton1_Clicked);
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Location = new System.Drawing.Point(108, 251);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(86, 37);
            this.materialRadioButton2.TabIndex = 36;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Alt连点";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            this.materialRadioButton2.Click += new System.EventHandler(this.materialRadioButton1_Clicked);
            // 
            // materialRadioButton3
            // 
            this.materialRadioButton3.AutoSize = true;
            this.materialRadioButton3.Depth = 0;
            this.materialRadioButton3.Location = new System.Drawing.Point(195, 251);
            this.materialRadioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton3.Name = "materialRadioButton3";
            this.materialRadioButton3.Ripple = true;
            this.materialRadioButton3.Size = new System.Drawing.Size(91, 37);
            this.materialRadioButton3.TabIndex = 37;
            this.materialRadioButton3.TabStop = true;
            this.materialRadioButton3.Text = "Ctrl连点";
            this.materialRadioButton3.UseVisualStyleBackColor = true;
            this.materialRadioButton3.Click += new System.EventHandler(this.materialRadioButton1_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 353);
            this.Controls.Add(this.materialRadioButton3);
            this.Controls.Add(this.materialRadioButton2);
            this.Controls.Add(this.materialRadioButton1);
            this.Controls.Add(this.rightClickSwitch);
            this.Controls.Add(this.leftClickSwitch);
            this.Controls.Add(this.materialSwitch2);
            this.Controls.Add(this.materialSlider1);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialSwitch1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 353);
            this.MinimumSize = new System.Drawing.Size(300, 353);
            this.Name = "Form1";
            this.Sizable = false;
            this.Text = "鼠标连点器(Ra2定制版)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialSlider materialSlider1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch2;
        private MaterialSkin.Controls.MaterialSwitch leftClickSwitch;
        private MaterialSkin.Controls.MaterialSwitch rightClickSwitch;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton3;
    }
}

