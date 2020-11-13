using System.Drawing;
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
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(240, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1058, 454);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            g = this.pictureBox1.CreateGraphics();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 669);
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
            if (c)
            {
                pictureBox1.Cursor = Cursors.Cross;
                c = false;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Hand;
                c = true;
            }
        }

        private void DrawByMouse(MouseEventArgs e)
        {
            if (!c)
            {
                if (f)
                {
                    x = e.X;
                    y = e.Y;
                    f = false;
                }
                else
                {
                    g.DrawLine(p, x, y, e.X, e.Y);
                    x = e.X;
                    y = e.Y;
                }
                POINT_temp.Add(new PointF(x, y));
            }
        }

        private void DragByMouse(MouseEventArgs e)
        {
            if (c)
            {
                g.Clear(Color.White);
                for (int tick = 0; tick < POINT_temp.Count; tick++)
                {
                    POINT_temp[tick] = POINT_temp[tick].X + 5.1f;
                }
                g.DrawLines(p, POINT_temp.ToArray());
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (c)
                    {
                        DragByMouse(e);
                    }
                    else
                    {
                        DrawByMouse(e);
                    }
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            f = true;
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}