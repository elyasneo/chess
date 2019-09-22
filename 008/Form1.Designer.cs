namespace _008
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button_start = new System.Windows.Forms.Button();
            this.stausTextView = new System.Windows.Forms.TextBox();
            this.labelCheck = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labaleWMC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labaleBMC = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelWD = new System.Windows.Forms.Label();
            this.labelBD = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(229, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start Game";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.buttonStart);
            // 
            // stausTextView
            // 
            this.stausTextView.Location = new System.Drawing.Point(658, 48);
            this.stausTextView.Multiline = true;
            this.stausTextView.Name = "stausTextView";
            this.stausTextView.Size = new System.Drawing.Size(183, 138);
            this.stausTextView.TabIndex = 1;
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelCheck.ForeColor = System.Drawing.Color.Red;
            this.labelCheck.Location = new System.Drawing.Point(658, 209);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(89, 24);
            this.labelCheck.TabIndex = 2;
            this.labelCheck.Text = "Check!!!!!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "White Move: ";
            // 
            // labaleWMC
            // 
            this.labaleWMC.AutoSize = true;
            this.labaleWMC.Location = new System.Drawing.Point(739, 258);
            this.labaleWMC.Name = "labaleWMC";
            this.labaleWMC.Size = new System.Drawing.Size(13, 13);
            this.labaleWMC.TabIndex = 4;
            this.labaleWMC.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Black Move: ";
            // 
            // labaleBMC
            // 
            this.labaleBMC.AutoSize = true;
            this.labaleBMC.Location = new System.Drawing.Point(739, 281);
            this.labaleBMC.Name = "labaleBMC";
            this.labaleBMC.Size = new System.Drawing.Size(13, 13);
            this.labaleBMC.TabIndex = 6;
            this.labaleBMC.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(892, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "White Dead: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1056, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Black Dead :";
            // 
            // labelWD
            // 
            this.labelWD.AutoSize = true;
            this.labelWD.Location = new System.Drawing.Point(892, 84);
            this.labelWD.Name = "labelWD";
            this.labelWD.Size = new System.Drawing.Size(0, 13);
            this.labelWD.TabIndex = 9;
            // 
            // labelBD
            // 
            this.labelBD.AutoSize = true;
            this.labelBD.Location = new System.Drawing.Point(1056, 84);
            this.labelBD.Name = "labelBD";
            this.labelBD.Size = new System.Drawing.Size(0, 13);
            this.labelBD.TabIndex = 10;
            // 
       
       
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 520);
            this.Controls.Add(this.labelBD);
            this.Controls.Add(this.labelWD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labaleBMC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labaleWMC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCheck);
            this.Controls.Add(this.stausTextView);
            this.Controls.Add(this.button_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox stausTextView;
        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labaleWMC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labaleBMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelWD;
        private System.Windows.Forms.Label labelBD;
        private System.Windows.Forms.Timer timer;
    }
}

