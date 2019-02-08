using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{


    public partial class mainForm : Form
    {

        private readonly string headerString = @"# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#       127.0.0.1       localhost
#       ::1             localhost

# Managed by Kerus Ashe's hostseditor
";

        private hosteditor.editForm editorForm;
        private hosteditor.compareForm compareForm;
        public Object buffer;
        private StreamReader hosts;
        private List<String> originhosts = new List<String>();
        
        public mainForm()
        {
            InitializeComponent();
            this.Width = 522;
            this.Height = 353;
            this.Height = 85;
            editorForm = new hosteditor.editForm(this);
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select file to open";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openPath.Text = openFileDialog1.FileName;
            }

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

            loadedHosts.Columns.Add("IP Address", 120);
            loadedHosts.Columns.Add("Domain", 354);

            //loadedHosts.Items.Add(new ListViewItem(new String[] { "127.0.0.1", "localhost" }));
            //loadedHosts.Items.Add(new ListViewItem(new String[] { "1.0.0.3", "cloud.kerus.net" }));

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            try
            {

                using(hosts = new StreamReader(this.openPath.Text))
                {
                    hosts.Close();

                    this.Height = 430;
                    this.Top = this.Location.Y - ((int)(this.Height - 85) / 2);
                    btnOpenFile.Visible = false;
                    buttonSave.Visible = true;
                    btnSelectPath.Enabled = false;
                    
                }

            } catch
            {
                MessageBox.Show(
                    "Cannot access " + this.openPath.Text,
                    "failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }

            this.readHosts();

        }

        private void readHosts()
        {

            hosts = new StreamReader(this.openPath.Text);

            List<ipdomains> domainFullList = new List<ipdomains>();

            //
            // Object ->
            // class { ip, domains[] }
            //

            String line;
            
            while ((line = hosts.ReadLine()) != null)
            {
                this.originhosts.Add(line);

                if (new StringReader(line).Read() == '#') continue;

                
                Regex extract = new Regex(@"[\s\t]?((([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))[\t\s]+(.*)[\t\s]?");
                Match match = extract.Match(line);

                if (match.Success)
                {

                    String ip;

                    ip = match.Groups[1].ToString();

                    String[] domains = match.Groups[5].ToString().Split(' ');

                    ipdomains ipdomains = new ipdomains();
                    ipdomains.ip = ip;
                    ipdomains.domains = domains;

                    domainFullList.Add(ipdomains);
                               
                }

            }

            hosts.Close();
            

            domainFullList.ForEach(delegate (ipdomains ipdomains)
            {

                String ip = ipdomains.ip;
                String domains = String.Join(" ", ipdomains.domains);

                loadedHosts.Items.Add(new ListViewItem(new String[] { ip, domains }));

            });

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {

                using (StreamWriter hosts = new StreamWriter(this.openPath.Text))
                {

                    List<String> hostsLines = new List<string>();

                    ListView.ListViewItemCollection lvItems = loadedHosts.Items;

                    foreach (ListViewItem item in lvItems)
                    {
                        String line = item.SubItems[0].Text + '\t' + item.SubItems[1].Text;
                        hostsLines.Add(line);
                    }
                    
                    String resultLine = this.headerString;

                    hostsLines.ForEach(delegate (String line)
                    {
                        resultLine += line + "\r\n";
                    });

                    hosts.Write(resultLine);
                    MessageBox.Show("Done");
                    hosts.Close();

                }

            }
            catch
            {
                MessageBox.Show(
                    "Cannot access " + this.openPath.Text,
                    "failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }

        }
        
    
        private void loadedHosts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the name of the file to open from the ListBox.

            ListView.SelectedListViewItemCollection items = loadedHosts.SelectedItems;
            ListViewItem lvItem = items[0];

            string ipa = lvItem.SubItems[0].Text;
            string doa = lvItem.SubItems[1].Text;

            FormCollection formCollection = Application.OpenForms;

            foreach (Form form in formCollection.Cast<Form>().ToList())
            {
                if (form is hosteditor.editForm)
                {
                    editorForm.Close();
                }
            }

            editorForm = new hosteditor.editForm(this);

            editorForm.Show();

            editorForm.Left = this.Location.X + ((this.Width / 2) - editorForm.Width);
            editorForm.Top = this.Location.Y + ((this.Height / 2) - editorForm.Height);
            editorForm.TopMost = true;
            editorForm.AddMode = false;
            

            editorForm.setIP(ipa);
            editorForm.setDomains(doa);

        }

        public void addHost(string iptarget, string domains)
        {
            loadedHosts.Items.Add(new ListViewItem(new String[] { iptarget, domains }));
        }

        public void editHost(string iptarget, string domains)
        {

            ListView.ListViewItemCollection lvItems = loadedHosts.Items;

            bool findFlag = false;

            ListViewItem targetItem = null;

            foreach(ListViewItem item in lvItems)
            {

                if (item.Text == iptarget)
                {
                    findFlag = true;
                    targetItem = item;

                    item.SubItems[1].Text = domains;

                }
                
            }

            if (!findFlag) {
                addHost(iptarget, domains);
            }

        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonAddHost_Click(object sender, EventArgs e)
        {
            FormCollection formCollection = Application.OpenForms;

            foreach (Form form in formCollection.Cast<Form>().ToList())
            {
                if (form is hosteditor.editForm)
                {
                    editorForm.Close();
                }
            }

            editorForm = new hosteditor.editForm(this);
            editorForm.AddMode = true;

            editorForm.Show();

            editorForm.Left = this.Location.X + ((this.Width / 2) - editorForm.Width);
            editorForm.Top = this.Location.Y + ((this.Height / 2) - editorForm.Height);
            editorForm.TopMost = true;
           

        }

        private void buttonShowCompare_Click(object sender, EventArgs e)
        {

            List<String> hostsLines = new List<string>();

            ListView.ListViewItemCollection lvItems = loadedHosts.Items;

            foreach (ListViewItem item in lvItems)
            {
                String line = item.SubItems[0].Text + '\t' + item.SubItems[1].Text;
                hostsLines.Add(line);
            }

            FormCollection formCollection = Application.OpenForms;

            foreach (Form form in formCollection.Cast<Form>().ToList())
            {
                if (form is hosteditor.compareForm)
                {
                    compareForm.Close();
                }
            }

            compareForm = new hosteditor.compareForm();

            compareForm.Show();

            String originLine = "";
            originhosts.ForEach(delegate (String line)
            {
                originLine += line + "\r\n";
            });

            compareForm.setA(originLine);

            String resultLine = this.headerString;

            hostsLines.ForEach(delegate (String line)
            {
                resultLine += line + "\r\n";
            });

            compareForm.setB(resultLine);

        }
        
        private void buttonDeleteHost_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(loadedHosts.SelectedItems.Count))
            loadedHosts.SelectedItems[0].Remove();
            this.checkLoadedHostsFilter();
        }


        public void checkLoadedHostsFilter()
        {

            List<String> domainList = new string[] { }.ToList();
            List<String> duplicatedDomainList = new List<String>();
            
            foreach (ListViewItem item in loadedHosts.Items)
            {

                String domainText = item.SubItems[1].Text;
                String[] domains = domainText.Split(' ');

                foreach (String domain in domains)
                {

                    if (!domainList.Exists(delegate (String s) { return s == domain; }))
                    {
                        domainList.Insert(domainList.Count, domain);
                    } else
                    {
                        MessageBox.Show("Some domain is alredy exist.");
                        item.BackColor = Color.DarkBlue;
                        item.ForeColor = Color.White;
                    }
                }

                
                Regex ip = new Regex(@"^\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?$");
                MatchCollection result = ip.Matches(item.SubItems[0].Text);
                
                if (!Convert.ToBoolean(result.Count)) { 
                    item.BackColor = Color.DarkRed;
                    item.ForeColor = Color.White;
                }

            }


            
        }


    }
}

public class ipdomains
{
    private String _ip;
    public String ip {
        get {
            return this._ip;
        }

        set {
            this._ip = value;
        }
    }

    private String[] _domains;
    public String[] domains {
        get {
            return this._domains;
        }

        set {
            this._domains = value;
        }
    }

}