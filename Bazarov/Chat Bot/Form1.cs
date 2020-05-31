using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chat_Bot
{
    public partial class Form1 : Form
    {
        public ChatBot bot = new ChatBot();
        
        public Form1()
        {
            InitializeComponent();
            ChatText.ReadOnly = true;  //ChatText доступно только для чтения
            InputText.Select();  //выбрать InputText для ввода
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void RestoreChat()  //метод восстановления чата
        {
            for (int i = 0; i < bot.History.Count; i++)
            {
                ChatText.Text += bot.History[i] + Environment.NewLine;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (InputText.Text != "")
            {
                String[] userQuestion = InputText.Text.Split(new String[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries);
                
                string message = userQuestion[0]; // для отправки боту

                userQuestion[0] = userQuestion[0].Insert(0,
                    "[" + DateTime.Now.ToString("HH:mm") + "] " + bot.UserName + ": ");

                bot.AddToHistory(userQuestion);

                ChatText.AppendText(userQuestion[0] + "\r\n");
                InputText.Text = "";
                string[] botAnswer = new string[] { bot.Answer(message) };
                botAnswer[0] = botAnswer[0].Insert(0, "Бот: ");
                ChatText.AppendText(botAnswer[0] + Environment.NewLine);

                bot.AddToHistory(botAnswer);
            }
        }

        private void ClearDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Уверены," +
                "что хотите очистить диалог?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.WriteAllText(bot.Path, string.Empty);
                bot.History.Clear();
                String[] date = new String[] {"Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                bot.AddToHistory(date);
                ChatText.Text = date[0];
            }
        }
    }
}
