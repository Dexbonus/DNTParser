using System;
using System.Windows.Forms;

namespace DNT.Test
{
    public partial class Form1 : Form
    {                
        public Form1()
        {            
            InitializeComponent();            
        }

        private void DisplayTable(Table table)
        {
            lvTable.Columns.Clear();
            lvTable.Items.Clear();


            foreach (var c in table.Columns)
            lvTable.Columns.Add(c.Name);

            lvTable.BeginUpdate();

            foreach (var r in table.Rows)
            {
                var lvi = new ListViewItem(r.ID.ToString());

                foreach (var c in r.Cells)
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, c.Value.ToString()));

                lvTable.Items.Add(lvi);                
            }

            lblRowCount.Text = table.Rows.Count + " Rows";
            lvTable.EndUpdate();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "DNT | *.dnt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblFileName.Text = ofd.SafeFileName;
                var table = new DNTParser().Parse(ofd.FileName);
                DisplayTable(table);
            }
        }        
    }
}
