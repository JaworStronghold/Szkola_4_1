using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szkola_4_1
{
    public partial class Form1 : Form
    {

        Graphics g1;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        int pensize = 7;

        public Form1()
        {
            InitializeComponent();
            g1 = panel1.CreateGraphics();
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, pensize);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }
       
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g1.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }



        //
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are u sure u want to quit the app?", ":(", MessageBoxButtons.YesNo))
            {
                this.Close();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by: Jakub Jaworski");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pensize = Convert.ToInt32(numericUpDown1.Value);
            pen.Width = pensize;
            // numericUpDown1.Value;
            // Int32.Parse(TextBoxD1.Text);
        }
        //

    }
}
