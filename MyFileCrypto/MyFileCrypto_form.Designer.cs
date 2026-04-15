namespace MyFileCrypto
{
    partial class MyFileCrypto_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(10, 158);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.ShortcutsEnabled = false;
            richTextBox1.Size = new Size(472, 291);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(10, 14);
            button1.Name = "button1";
            button1.Size = new Size(200, 30);
            button1.TabIndex = 1;
            button1.Text = "OPEN ENCRYPTED FILE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(10, 84);
            button2.Name = "button2";
            button2.Size = new Size(472, 30);
            button2.TabIndex = 2;
            button2.Text = "ENCRYPT BOXTEXT TO FILE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(10, 48);
            button3.Name = "button3";
            button3.Size = new Size(200, 30);
            button3.TabIndex = 1;
            button3.Text = "OPEN PLAIN TEXT FILE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.Control;
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(216, 17);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(266, 25);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(216, 51);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(266, 25);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 124);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 4;
            label1.Text = "Path:";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(51, 122);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(431, 25);
            textBox3.TabIndex = 3;
            // 
            // MyFileCrypto_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 461);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(500, 500);
            Name = "MyFileCrypto_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyFileCrypto";
            FormClosing += MyFileCrypto_form_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox3;
    }
}
