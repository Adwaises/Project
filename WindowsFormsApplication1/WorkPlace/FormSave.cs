﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDataForBD;
using LibSaveOrder;

namespace WorkPlace
{
    public partial class FormSave : Form
    {
        SaveOrder slo = new SaveOrder();

        

        public FormSave()
        {
            InitializeComponent();
            DateTime data = DateTime.Now;
            DataForBD.Mounth = data.Month;

            foreach (var n in slo.initCBCustomer())
            {
                CBCustomer.Items.Add(n);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RBSelect.Checked)
            {
                if (CBCustomer.SelectedIndex != -1) {
                    slo.saveOrder(1, CBCustomer.SelectedIndex, TBFamil.Text, TBName.Text, TBOtch.Text, TBTel.Text, TBmail.Text);
                    slo.initIdOrder();
                    MessageBox.Show("Заказ оформлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (RBNew.Checked)
            {
                try
                {
                    slo.saveOrder(2, CBCustomer.SelectedIndex, TBFamil.Text, TBName.Text, TBOtch.Text, TBTel.Text, TBmail.Text);
                    slo.initIdOrder();
                    MessageBox.Show("Заказ оформлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }catch
                {
                    MessageBox.Show("Введите верные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
        }

        private void FormSave_FormClosed(object sender, FormClosedEventArgs e)
        {
            slo.initIdOrder();
        }

        private void FormSave_Load(object sender, EventArgs e)
        {
            TBFamil.Enabled = false;
            TBName.Enabled = false;
            TBOtch.Enabled = false;
            TBTel.Enabled = false;
            TBmail.Enabled = false;
        }

        private void RBSelect_CheckedChanged(object sender, EventArgs e)
        {
            TBFamil.Enabled = false;
            TBName.Enabled = false;
            TBOtch.Enabled = false;
            TBTel.Enabled = false;
            TBmail.Enabled = false;
            CBCustomer.Enabled = true;
        }

        private void RBNew_CheckedChanged(object sender, EventArgs e)
        {
            TBFamil.Enabled = true;
            TBName.Enabled = true;
            TBOtch.Enabled = true;
            TBTel.Enabled = true;
            TBmail.Enabled = true;
            CBCustomer.Enabled = false;
        }
    }
}
