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
        Graphics GRAPHICS_canvas;
        Pen PEN_COLOR_white = new Pen(Brushes.White, 2);
        Pen PEN_COLOR_black = new Pen(Brushes.Black, 2);

        int COORDS_TEMP_x;
        int COORDS_TEMP_y;

        bool MOUSE_cursor = false;

        List<PointF> COORDS_POINTS_list = new List<PointF>();
        List<PointF> COORDS_POINTS_GARBAGE_list = new List<PointF>();
        PointF MOUSE_offset = new PointF();
        PointF[] COORDS_POINTS_array = new PointF[] { };
        PointF[] COORDS_POINTS_GARBAGE_array = new PointF[] { };
        float COORDS_POINTS_lower;

        bool OBJECT_falling = false;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
