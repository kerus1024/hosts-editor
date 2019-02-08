using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hosteditor
{
    public partial class editForm : Form
    {
        public WindowsFormsApp1.mainForm parentForm;

        private bool _addMode = false;
        public  bool AddMode {
            get {
                return _addMode;
            }

            set {
                _addMode = value;
            }
        }

        public editForm(WindowsFormsApp1.mainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            
        }

        private void ButtonDo_click(object sender, EventArgs e)
        {
           
            if (this._addMode)
            {
                parentForm.addHost(this.inputIP.Text, this.inputDomains.Text.ToLower());
            } else
            {
                parentForm.editHost(this.inputIP.Text, this.inputDomains.Text.ToLower());
            }
            parentForm.checkLoadedHostsFilter();
            this.Close();
        }

        public void setIP(string ipa)
        {
            this.inputIP.Text = ipa;
        }

        public void setDomains(string domains)
        {
            this.inputDomains.Text = domains;
        }

        private void editForm_Load(object sender, EventArgs e)
        {
            this.inputIP.Enabled = this._addMode;
            if (this._addMode) this.inputIP.Focus();
            else this.inputDomains.Focus();
        }

        private void inputDomain_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDo.PerformClick();
            }
        }
    }
}
