﻿using ObjectsControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDataForBD;

namespace WorkPlace
{
    public partial class FRoomConf : Form
    {
        private Room room;
        public FRoomConf(ref Room room)
        {
            InitializeComponent();
            this.room = room;
            butCancle.Click += (object sender, EventArgs e) => { Close(); };
            tBLength.Text = room.length.ToString();
            tBWidth.Text = room.width.ToString();
            tBHeigth.Text = room.height.ToString();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            try
            {
                room.length = Convert.ToDouble(tBLength.Text);
                room.width = Convert.ToDouble(tBWidth.Text);
                room.height = Convert.ToDouble(tBHeigth.Text);

                DataForBD.Length = Convert.ToInt32(room.length * 100);
                DataForBD.Width = Convert.ToInt32(room.width  * 100);
                DataForBD.Height = Convert.ToInt32(room.height * 100);

                Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
