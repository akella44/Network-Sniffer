using Shell.NTM.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shell.NTM.CommonUi
{
    public partial class Filters : Form
    {
        private ViewFiltersBuilder _filters;
        public Filters(ViewFiltersBuilder filters)
        {
            InitializeComponent();
            _filters = filters;
        }

        private void Filters_Load(object sender, EventArgs e)
        {
            foreach (var obj in ViewFiltersBuilder.Filters.Keys)
            {   
                filtersLabel.Text = filtersLabel.Text + obj + Environment.NewLine;
            }
        }

        private void Filters_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
