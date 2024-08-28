namespace FileEncrypter
{
    partial class Form1
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
            richTextEncrypt = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            richTextDecrypt = new RichTextBox();
            SuspendLayout();
            // 
            // richTextEncrypt
            // 
            richTextEncrypt.Location = new Point(18, 55);
            richTextEncrypt.Name = "richTextEncrypt";
            richTextEncrypt.Size = new Size(310, 271);
            richTextEncrypt.TabIndex = 0;
            richTextEncrypt.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 21);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 1;
            label1.Text = "Enter text to encrypt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(394, 21);
            label2.Name = "label2";
            label2.Size = new Size(144, 20);
            label2.TabIndex = 1;
            label2.Text = "Enter text to decrypt";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(126, 355);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 29);
            btnEncrypt.TabIndex = 2;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(502, 355);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 29);
            btnDecrypt.TabIndex = 2;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // richTextDecrypt
            // 
            richTextDecrypt.Location = new Point(394, 55);
            richTextDecrypt.Name = "richTextDecrypt";
            richTextDecrypt.Size = new Size(310, 271);
            richTextDecrypt.TabIndex = 0;
            richTextDecrypt.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 450);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextDecrypt);
            Controls.Add(richTextEncrypt);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextEncrypt;
        private Label label1;
        private Label label2;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private RichTextBox richTextDecrypt;
    }
}
