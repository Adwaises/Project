﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void графическийОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diagram diag = new Diagram();
            diag.ShowDialog();
        }


        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.blank();
            DialogResult result = MessageBox.Show("Открыть?", "Отчет сформирован", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes) //Если нажал Да
            {
                //отрытие документа программой по умолчанию
                Process.Start("Document.pdf");
            }
        }

        private void отправитьНаПочтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists("Document.pdf"))
            {
                ToMail tm = new ToMail();
                tm.ShowDialog();
            } else
            {
                MessageBox.Show("Бланк заказа не сформирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
