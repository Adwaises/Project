﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagerBD;


namespace WorkPlace
{
    public partial class FormAddFurnit : Form
    {
        ManagerBD mbd = new ManagerBD();
        public FormAddFurnit()
        {
            InitializeComponent();


            //комент

        }

        private void FormBD_Load(object sender, EventArgs e)
        {
            mbd.Connection();
            //DataTable dt = mbd.selectionquery("select naimenovanie,nazvanie,price, count(*),id_furnitura from FurnituraZakaz  join furnitura on furnitura.id_furnit = FurnituraZakaz.id_furnitura group by id_furnitura order by count(*) desc ");
            //DataTable dt = mbd.selectionquery("select * from StroyMaterialZakaz   ");
            //DataTable dt = mbd.selectionquery("select * from FurnituraZakaz    ");
            //DataTable dt = mbd.selectionquery("select sum(summa)from zakaz where month_Zakaz = 4");
            //DataTable dt = mbd.selectionquery("select count(*) from zakaz where month_zakaz = 5");
            //DataTable dt = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = 21 group by zakaz.id_zakaz order by famil");
            //mbd.controlquery("ALTER TABLE FurnituraZakaz add Z double");
            //mbd.controlquery("update FurnituraZakaz set x = 1.51151, y=1.5985955, z=1.5595 where id_zakaz=1 and id_furnitura = 21");

            //mbd.controlquery("drop table FurnituraZakaz");

            //mbd.controlquery("create table FurnituraZakaz (id_zakaz INTEGER,id_Furnitura INTEGER ,coordX DOUBLE,coordY DOUBLE, FOREIGN KEY (id_Furnitura) REFERENCES Furnitura (id_furnit),FOREIGN KEY (id_zakaz) REFERENCES Zakaz (id_zakaz))");

            //mbd.controlquery("insert into FurnituraZakaz values (1, 61, -3, -3.5)");

            //mbd.controlquery("delete from Furnitura where id_furnit = 51");
            //mbd.controlquery("delete from FurnituraZakaz where id_zakaz = 4 and id_furnitura = 61");


            //DataTable dt = mbd.selectionquery("select * from zakaz join customer on zakaz.id_customer = customer.id_customer ; ");

            //DataTable dt = mbd.selectionquery("select * from FurnituraZakaz ; ");

            //DataTable dt = mbd.selectionquery("select Famil, Name, otchestvo, month_zakaz, count(*),id_zakaz from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = " + "61" + " group by zakaz.id_zakaz order by famil");

            //DataTable dt = mbd.selectionquery("select Famil,Name,otchestvo, month_zakaz,count(*) from zakaz join customer on zakaz.id_customer = customer.id_customer join FurnituraZakaz on zakaz.id_zakaz = FurnituraZakaz.id_zakaz where id_furnitura = " + "11"+ " group by zakaz.id_zakaz order by famil");
            /*
            mbd.controlquery("update Furnitura set naimenovanie = 'cupboard' where naimenovanie = 'shkaf'");
            mbd.controlquery("update Furnitura set naimenovanie = 'fridge' where naimenovanie = 'icebox'");
            mbd.controlquery("update Furnitura set naimenovanie = 'stove' where naimenovanie = 'plita'");
            mbd.controlquery("update Furnitura set naimenovanie = 'chair' where naimenovanie = 'stol'");
            */
            DataTable dt = mbd.selectionquery("select * from Furnitura; ");
            dataGridView1.DataSource = dt;

            comboBox1.Items.Add("mebel");
            comboBox1.Items.Add("technics");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int id = Convert.ToInt32(tbId.Text);
                string type = comboBox1.SelectedItem.ToString();
                string naim = tbNaim.Text;
                string naz = tbNazvanie.Text;
                int price = Convert.ToInt32(tbPrice.Text);

                mbd.controlquery("Insert into Furnitura values (" + id + ", '" + type + "', '" + naim + "', '" + naz + "', " + price + ");");
                MessageBox.Show("Добавлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = mbd.selectionquery("select * from Furnitura; ");
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbId2.Text);
                mbd.controlquery("Delete from Furnitura where id_furnit = " + id + ";");
                MessageBox.Show("Удалено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = mbd.selectionquery("select * from Furnitura; ");
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
