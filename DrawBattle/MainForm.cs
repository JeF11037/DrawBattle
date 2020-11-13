using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawBattle
{
    public partial class MainForm : Form
    {
        Graphics g;
        Pen p = new Pen(Brushes.Black, 2);

        int x;
        int y;
        bool f = true;

        bool c = false;

        List<List<PointF>> POINT_all = new List<List<PointF>>();
        List<PointF> POINT_temp = new List<PointF>();

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
