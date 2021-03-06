﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDataForBD;
using LibMail;
using LibraryManagerBD;
using LibReports;

namespace WorkPlace
{
    public partial class FToMail : Form
    {
        Mail mail = new Mail();
        ManagerBD mbd = new ManagerBD();
        DataTable dt;
        Reports report = new Reports();
        int index = 0;
        public FToMail()
        {
            InitializeComponent();
        }

        void toMail()
        {
            try
            {
                mail.SendMail(textBox1.Text, Convert.ToInt32(dt.Rows[index][0]));
            } catch(Exception ex) {
                MessageBox.Show(ex+"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            try
            {
                index = comboBox1.SelectedIndex;
                report.blank(Convert.ToInt32(dt.Rows[comboBox1.SelectedIndex][0]));
                DataForBD.Iter = 0;
                Thread t = new Thread(toMail);
                t.Start();
                timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Введите правильный E-mail", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToMail_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            dt = mbd.selectionquery("select * from zakaz;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add("Заказ №" + dt.Rows[i][0] + "" + " Размеры:" + Convert.ToDouble(dt.Rows[i][1]) / 100 + "*" + Convert.ToDouble(dt.Rows[i][2]) / 100 +
                    "*" + Convert.ToDouble(dt.Rows[i][3]) / 100 + " Сумма:" + dt.Rows[i][6]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = mbd.selectionquery("select id_zakaz,mail from zakaz join customer on zakaz.id_customer = customer.id_customer;");
            textBox1.Text = Convert.ToString(dt1.Rows[comboBox1.SelectedIndex][1]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataForBD.Iter == 0)
            {
                progressBar1.Value = 10;
            }
            else if (DataForBD.Iter == 1)
            {
                progressBar1.Value = 30;
            }
            else if (DataForBD.Iter == 2)
            {
                progressBar1.Value = 90;
            }
            else if (DataForBD.Iter == 3)
            {
                progressBar1.Value = 100;
                timer1.Stop();
                MessageBox.Show("Письмо отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
