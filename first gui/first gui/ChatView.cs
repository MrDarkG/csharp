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
using first_gui.Models;

namespace first_gui
{
    public partial class ChatView : Form
    {
        public ChatView()
        {
            InitializeComponent();
        }

        private void ChatView_Load(object sender, EventArgs e)
        {
            var list = Program.listchats();
            dataGridView5.DataSource = list;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.clear_chat = true;
            Program.last_message_id = 0;
            if (e.ColumnIndex == 0)
            {
                Program.chat_name = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                MessageToSend.Enabled = true;
                button1.Enabled = true;

                if (Program.thread != null)
                {
                    Program.thread.Abort();
                }
                
                Program.thread = new Thread(ThreadWork);
                Program.thread.Start();
                
                
            }
            
        }

        public void ThreadWork()
        {
            while (true)
            {
                List<MessageModel> mess = Program.Messages(Program.chat_name);
                foreach (MessageModel result in mess)
                {
                    if (Program.last_message_id != result.messageId)
                    {
                        
                        Messagebox.BeginInvoke(new MethodInvoker(() =>
                        {
                            if (Program.clear_chat)
                            {
                                Messagebox.Text = "";
                                Program.clear_chat = false;
                            }
                                Messagebox.Text += result.username + ":" + result.message + "\n";
                        }));
                        Program.last_message_id = result.messageId;
                    }

                }

                Thread.Sleep(1000); 
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.SendMessage(MessageToSend.Text);
            MessageToSend.Text = "";
            
        }
    }
}
