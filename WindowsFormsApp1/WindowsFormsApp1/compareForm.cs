using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hosteditor
{
    public partial class compareForm : Form
    {
        public compareForm()
        {
            InitializeComponent();
        }

        private void compareForm_Load(object sender, EventArgs e)
        {

        }

        public void setA(String x)
        {
            this.textBox1.Text = x;
        }

        public void setB(String x)
        {
            this.textBox2.Text = x;
        }

    }
}
