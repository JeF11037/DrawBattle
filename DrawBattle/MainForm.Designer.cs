﻿using System.Drawing;
using System.Windows.Forms;

namespace DrawBattle
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1286, 1013);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            GRAPHICS_canvas = this.pictureBox1.CreateGraphics();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 1037);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    ChangeCursor();
                    break;
                default:
                    break;
            }
        }



        private void ChangeCursor()
        {
            if (MOUSE_cursor)
            {
                pictureBox1.Cursor = Cursors.Cross;
                MOUSE_cursor = false;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Hand;
                MOUSE_cursor = true;
            }
        }

        private void DrawByMouse(MouseEventArgs e)
        {
            if (!MOUSE_cursor)
            {
                if (COORDS_TEMP_x != 0 && COORDS_TEMP_y != 0)
                {
                    GRAPHICS_canvas.DrawLine(PEN_COLOR_white, COORDS_TEMP_x, COORDS_TEMP_y, e.X, e.Y);
                }
                COORDS_TEMP_x = e.X;
                COORDS_TEMP_y = e.Y;
                if (COORDS_POINTS_lower != 0)
                {
                    if (COORDS_POINTS_lower < e.Y)
                    {
                        COORDS_POINTS_lower = e.Y;
                    }
                }
                else
                {
                    COORDS_POINTS_lower = e.Y;
                }
                COORDS_POINTS_list.Add(new Point(COORDS_TEMP_x, COORDS_TEMP_y));
            }
        }

        private void DrawNewPosition(double X, double Y)
        {
            COORDS_POINTS_array = COORDS_POINTS_list.ToArray();
            COORDS_POINTS_GARBAGE_array = COORDS_POINTS_list.ToArray();
            COORDS_POINTS_list.Clear();
            foreach (var el in COORDS_POINTS_array)
            {
                PointF point = el;
                point.X += (float)X;
                point.Y += (float)Y;
                if (COORDS_POINTS_lower != 0)
                {
                    if (COORDS_POINTS_lower < point.Y)
                    {
                        COORDS_POINTS_lower = point.Y;
                    }
                }
                else
                {
                    COORDS_POINTS_lower = point.Y;
                }
                COORDS_POINTS_list.Add(point);
            }
            GRAPHICS_canvas.DrawLines(PEN_COLOR_white, COORDS_POINTS_array);
            GRAPHICS_canvas.DrawLines(PEN_COLOR_black, COORDS_POINTS_GARBAGE_array);
        }

        private async void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (MOUSE_cursor)
                    {
                        if (MOUSE_cursor)
                        {
                            DrawNewPosition(e.X - MOUSE_offset.X, e.Y - MOUSE_offset.Y);
                        }
                    }
                    else
                    {
                        DrawByMouse(e);
                    }
                    break;
                default:
                    break;
            }
            MOUSE_offset = e.Location;
        }

        private async void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            OBJECT_falling = true;
            if (COORDS_POINTS_array.Length > 0)
            {
                if (MOUSE_cursor)
                {
                    GRAPHICS_canvas.Clear(Color.Black);
                }
                GRAPHICS_canvas.DrawLines(PEN_COLOR_white, COORDS_POINTS_array);

                if (OBJECT_falling && MOUSE_cursor)
                {
                    if(MOUSE_cursor)
                    {
                        MessageBox.Show("Tactical nuke incoming!");
                        while(COORDS_POINTS_lower <= 1013)
                        {
                            double lower = 1013 - COORDS_POINTS_lower;
                            double gravity = 6.67 * System.Math.Pow(10, -11) * COORDS_POINTS_list.Count / (System.Math.Pow(lower, 2) * System.Math.Pow(10, -1)) * System.Math.Pow(10, 11);
                            DrawNewPosition(0, gravity);
                        }
                        GRAPHICS_canvas.DrawLines(PEN_COLOR_white, COORDS_POINTS_array);
                        MessageBox.Show("BOOOOOOM!");
                    }
                }
            }
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OBJECT_falling = false;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (MOUSE_cursor)
                    {
                        GRAPHICS_canvas.Clear(Color.Black);
                    }
                    break;
            }
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}