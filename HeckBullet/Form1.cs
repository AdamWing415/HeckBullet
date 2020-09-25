using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeckBullet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            MainMenu mm = new MainMenu();
            Form1.Controls.Add(mm);

            mm.Location = new Point(this.Width / 2 - mm.Width / 2, this.Height / 2 - mm.Height / 2);
        }
    }
}
