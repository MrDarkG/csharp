namespace first_gui
{
    partial class ChatView
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
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.Messagebox = new System.Windows.Forms.RichTextBox();
            this.MessageToSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(12, 12);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowTemplate.ReadOnly = true;
            this.dataGridView5.Size = new System.Drawing.Size(327, 619);
            this.dataGridView5.TabIndex = 4;
            this.dataGridView5.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView5_CellContentClick);
            // 
            // Messagebox
            // 
            this.Messagebox.Location = new System.Drawing.Point(370, 12);
            this.Messagebox.Name = "Messagebox";
            this.Messagebox.ReadOnly = true;
            this.Messagebox.Size = new System.Drawing.Size(768, 560);
            this.Messagebox.TabIndex = 5;
            this.Messagebox.Text = "";
            this.Messagebox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MessageToSend
            // 
            this.MessageToSend.Enabled = false;
            this.MessageToSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageToSend.Location = new System.Drawing.Point(370, 599);
            this.MessageToSend.Name = "MessageToSend";
            this.MessageToSend.Size = new System.Drawing.Size(652, 32);
            this.MessageToSend.TabIndex = 6;
            this.MessageToSend.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1028, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 643);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MessageToSend);
            this.Controls.Add(this.Messagebox);
            this.Controls.Add(this.dataGridView5);
            this.Name = "ChatView";
            this.Text = "ChatView";
            this.Load += new System.EventHandler(this.ChatView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.RichTextBox Messagebox;
        private System.Windows.Forms.TextBox MessageToSend;
        private System.Windows.Forms.Button button1;
    }
}