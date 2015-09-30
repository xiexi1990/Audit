using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audit
{
    public partial class Rule : Form
    {
        public Rule()
        {
            InitializeComponent();
            radioButton_TimeDetermin.Checked = true;
            radioButton_TypeDetermin.Checked = true;
        }
    }
}
