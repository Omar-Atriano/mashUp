namespace mashUp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.PANEL_LEFT = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PLAY = new System.Windows.Forms.Button();
            this.RECORD = new System.Windows.Forms.Button();
            this.ADD = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.framesLabel = new System.Windows.Forms.Label();
            this.panelDown = new System.Windows.Forms.Panel();
            this.sliderX = new System.Windows.Forms.PictureBox();
            this.panelR = new System.Windows.Forms.Panel();
            this.sliderY = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BTN_SPEED = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.PANEL_LEFT.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderX)).BeginInit();
            this.panelR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderY)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Location = new System.Drawing.Point(211, 124);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1533, 652);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            this.PCT_CANVAS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseClick);
            this.PCT_CANVAS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseDoubleClick);
            this.PCT_CANVAS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseDown);
            this.PCT_CANVAS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseMove);
            this.PCT_CANVAS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseUp);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1531, 56);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // PANEL_LEFT
            // 
            this.PANEL_LEFT.Controls.Add(this.BTN_SPEED);
            this.PANEL_LEFT.Controls.Add(this.checkBox1);
            this.PANEL_LEFT.Controls.Add(this.PLAY);
            this.PANEL_LEFT.Controls.Add(this.RECORD);
            this.PANEL_LEFT.Controls.Add(this.ADD);
            this.PANEL_LEFT.Controls.Add(this.treeView1);
            this.PANEL_LEFT.Location = new System.Drawing.Point(0, 64);
            this.PANEL_LEFT.Name = "PANEL_LEFT";
            this.PANEL_LEFT.Size = new System.Drawing.Size(200, 771);
            this.PANEL_LEFT.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 499);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Animate all figures";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PLAY
            // 
            this.PLAY.Location = new System.Drawing.Point(12, 659);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(164, 32);
            this.PLAY.TabIndex = 3;
            this.PLAY.Text = "Play Animation";
            this.PLAY.UseVisualStyleBackColor = true;
            this.PLAY.Click += new System.EventHandler(this.PLAY_Click);
            // 
            // RECORD
            // 
            this.RECORD.Location = new System.Drawing.Point(12, 604);
            this.RECORD.Name = "RECORD";
            this.RECORD.Size = new System.Drawing.Size(164, 35);
            this.RECORD.TabIndex = 2;
            this.RECORD.Text = "Record Point";
            this.RECORD.UseVisualStyleBackColor = true;
            this.RECORD.Click += new System.EventHandler(this.RECORD_Click);
            // 
            // ADD
            // 
            this.ADD.Location = new System.Drawing.Point(12, 554);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(164, 33);
            this.ADD.TabIndex = 1;
            this.ADD.Text = "Create Figure";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Gray;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(192, 474);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeView1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.framesLabel);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Location = new System.Drawing.Point(211, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1533, 54);
            this.panel1.TabIndex = 10;
            // 
            // framesLabel
            // 
            this.framesLabel.AutoSize = true;
            this.framesLabel.Location = new System.Drawing.Point(630, 41);
            this.framesLabel.Name = "framesLabel";
            this.framesLabel.Size = new System.Drawing.Size(56, 16);
            this.framesLabel.TabIndex = 9;
            this.framesLabel.Text = "Frames:";
            // 
            // panelDown
            // 
            this.panelDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown.Controls.Add(this.sliderX);
            this.panelDown.Location = new System.Drawing.Point(211, 783);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(1505, 52);
            this.panelDown.TabIndex = 11;
            // 
            // sliderX
            // 
            this.sliderX.Location = new System.Drawing.Point(19, 14);
            this.sliderX.Name = "sliderX";
            this.sliderX.Size = new System.Drawing.Size(1492, 18);
            this.sliderX.TabIndex = 0;
            this.sliderX.TabStop = false;
            this.sliderX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sliderX_MouseDown);
            this.sliderX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sliderX_MouseMove);
            this.sliderX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sliderX_MouseUp);
            // 
            // panelR
            // 
            this.panelR.Controls.Add(this.sliderY);
            this.panelR.Location = new System.Drawing.Point(1752, 64);
            this.panelR.Margin = new System.Windows.Forms.Padding(4);
            this.panelR.Name = "panelR";
            this.panelR.Size = new System.Drawing.Size(200, 771);
            this.panelR.TabIndex = 4;
            // 
            // sliderY
            // 
            this.sliderY.Location = new System.Drawing.Point(25, 59);
            this.sliderY.Name = "sliderY";
            this.sliderY.Size = new System.Drawing.Size(20, 704);
            this.sliderY.TabIndex = 0;
            this.sliderY.TabStop = false;
            this.sliderY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sliderY_MouseDown);
            this.sliderY.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sliderY_MouseMove);
            this.sliderY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sliderY_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BTN_SPEED
            // 
            this.BTN_SPEED.Location = new System.Drawing.Point(12, 719);
            this.BTN_SPEED.Name = "BTN_SPEED";
            this.BTN_SPEED.Size = new System.Drawing.Size(164, 44);
            this.BTN_SPEED.TabIndex = 5;
            this.BTN_SPEED.Text = "Change Animation Speed";
            this.BTN_SPEED.UseVisualStyleBackColor = true;
            this.BTN_SPEED.Click += new System.EventHandler(this.BTN_SPEED_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 871);
            this.Controls.Add(this.panelR);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PANEL_LEFT);
            this.Controls.Add(this.PCT_CANVAS);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "MashUp";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.PANEL_LEFT.ResumeLayout(false);
            this.PANEL_LEFT.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sliderX)).EndInit();
            this.panelR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sliderY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel PANEL_LEFT;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.PictureBox sliderX;
        private System.Windows.Forms.Panel panelR;
        private System.Windows.Forms.PictureBox sliderY;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button PLAY;
        private System.Windows.Forms.Button RECORD;
        private System.Windows.Forms.Label framesLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button BTN_SPEED;
    }
}

