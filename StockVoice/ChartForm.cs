using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockVoice
{
    public partial class ChartForm : Form
    {
        public ChartForm(decimal[] yAxisData, DateTime[] xAxisData)
        {
            InitializeComponent();
            List<Double> myList = new List<Double>();
            foreach(var date in xAxisData)
            {
                myList.Add(date.Year);
            }
            Double[] xAxisDataArray = myList.ToArray();
            chart1.Series["Price"].Points.DataBindY(yAxisData);
        }
    }
}
