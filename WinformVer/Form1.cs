using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformVer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetCommand_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string command = txtCommand.Text.TrimEnd(';');
            DataSet ds = OracleConnector.GetCommand(command);
            grdResult.DataSource = ds.Tables[0];
            this.Cursor = Cursors.Default;
        }
    }
}
