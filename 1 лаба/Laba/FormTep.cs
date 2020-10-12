﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTep
{
    public partial class FormTep : Form
    {
        private ITrain tep;
        public FormTep()
        {
            InitializeComponent();
        }
        public void SetTrain(ITrain tep)
        {
            this.tep = tep;
            Draw();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTep.Width, pictureBoxTep.Height);
            Graphics gr = Graphics.FromImage(bmp);

            tep.DrawTep(gr);
            pictureBoxTep.Image = bmp;
        }
        private void buttonCreateTep_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tep = new Teplovoz(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Green,
           Color.Gray, true, true);
            tep.SetPosition(rnd.Next(500, 600), rnd.Next(10, 100), pictureBoxTep.Width,
           pictureBoxTep.Height);

            Draw();
        }
        private void buttonCreateLoc_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            tep = new Locomotive(rnd.Next(70, 300), rnd.Next(1000, 2000), Color.Gray,
           Color.Red);
            tep.SetPosition(rnd.Next(40, 600), rnd.Next(10, 100), pictureBoxTep.Width,
           pictureBoxTep.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    tep.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    tep.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    tep.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    tep.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
