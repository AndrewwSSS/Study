using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_16._11._2021
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
            BackColor = Color.FromArgb(trackBarRGB_R.Value, trackBarRGB_G.Value, trackBarRGB_B.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            OnColorUpdate();
        }
        private void trackBarRGB_G_Scroll(object sender, EventArgs e) {
            OnColorUpdate();
        }
        private void trackBarRGB_B_Scroll(object sender, EventArgs e) {
            OnColorUpdate();
        }

        private void OnColorUpdate() {
            BackColor = Color.FromArgb(trackBarRGB_R.Value, trackBarRGB_G.Value, trackBarRGB_B.Value);
        }
    }
}
