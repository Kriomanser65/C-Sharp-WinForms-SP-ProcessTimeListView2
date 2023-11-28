using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace List_View
{
    public partial class Form1 : Form
    {
        private Timer updateTimer;
        private int refreshInterval = 1000;
        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            refreshInterval = (int)numericUpDown1.Value;
            updateTimer.Interval = refreshInterval;
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = refreshInterval;
            updateTimer.Tick += UpdateProcessList;
            updateTimer.Start();
        }
        private void UpdateProcessList(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            listView1.Items.Clear();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(process.Responding ? "Yes" : "No");
                listView1.Items.Add(item);
            }
        }
    }
}
