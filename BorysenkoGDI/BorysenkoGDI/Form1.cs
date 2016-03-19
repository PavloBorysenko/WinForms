using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BorysenkoGDI
{
    public partial class Form1 : Form
    {
        private BufferedGraphicsContext curCont;
        private BufferedGraphics myBuf;
        private Point Begin, End;
        private int offsetX, offsetY;
        private bool move = false;
        public string figure = "";
        private Color my_color;
        private int width;

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(int crColor);
        [DllImport("gdi32.dll")]
        public static extern bool ExtFloodFill(IntPtr hdc, int nXStart, int nYStart, int crColor, uint fuFillType);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hdc, int x, int y);

        enum FLOODFILLTYPE { FLOODFILLBORDER, FLOODFILLSURFACE };
         
        public Form1()
        {
            InitializeComponent();
            my_color = Color.Black;
            Buffer();
            combo_w.Items.Add("2");
            combo_w.Items.Add("4");
            combo_w.Items.Add("6");
            combo_w.Items.Add("8");
            combo_w.SelectedIndex=0;
            //width = int.Parse(combo_w.SelectedText);

        }
        private void Buffer()
        {
            curCont = BufferedGraphicsManager.Current;
            myBuf = curCont.Allocate(CreateGraphics(), DisplayRectangle);
            myBuf.Graphics.Clear(Color.White);
        }

        private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = "rectan";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            myBuf.Render();
            if (move == true)
            {
                End = e.Location;

                Pen myPen = new Pen(my_color,width);
                offsetX = Math.Abs(End.X - Begin.X);
                offsetY = Math.Abs(End.Y - Begin.Y);
                Graphics g = CreateGraphics();
                switch (figure) { 
                    case "rectan":

                        
                g.DrawRectangle(
                    myPen,
                    Begin.X < End.X ? Begin.X : End.X,
                    Begin.Y < End.Y ? Begin.Y : End.Y,
                    offsetX, offsetY);
                        break;
                    case "circulo":

                        
                        g.DrawEllipse(
                            myPen,
                            Begin.X < End.X ? Begin.X : End.X,
                            Begin.Y < End.Y ? Begin.Y : End.Y,
                            offsetX, offsetY);
                        break;
                    case "line":

                        g.DrawLine(myPen,Begin,End);
                        break;
                    case "lastik":
                        Pen l = new Pen(Color.White, 5);
                       myBuf.Graphics.DrawRectangle(l,End.X, End.Y,5, 5);
                        break;
                    case "pencil":

                        myPen = new Pen(my_color);
                        myBuf.Graphics.DrawLine(myPen, Begin, End);
                        Begin= End;

                        break;
                           
                
                }
               
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Begin = e.Location;
            move = true;
            switch (figure) { 
                case "zaliv":
                   
                    ExtFill(myBuf.Graphics, Begin.X, Begin.Y, FLOODFILLTYPE.FLOODFILLSURFACE, my_color);
                    break;
                
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            End = e.Location;
            move = false;
            Pen myPen = new Pen(my_color,width);
            switch (figure)
            {
                case "rectan":

                    myBuf.Graphics.DrawRectangle(
                   myPen,
                   Begin.X < End.X ? Begin.X : End.X,
                   Begin.Y < End.Y ? Begin.Y : End.Y,
                   offsetX, offsetY);
                    break;
                case "circulo":
                    myBuf.Graphics.DrawEllipse(
                   myPen,
                   Begin.X < End.X ? Begin.X : End.X,
                   Begin.Y < End.Y ? Begin.Y : End.Y,
                   offsetX, offsetY);
                    break;
                case "line":

                    myBuf.Graphics.DrawLine(myPen, Begin, End);
                    break;


            }
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            myBuf.Render();
        }

        private void красныйToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            my_color = Color.Red;
            toolStripMenuItem1.BackColor = System.Drawing.Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            my_color = Color.DarkBlue;
            toolStripMenuItem1.BackColor = System.Drawing.Color.DarkBlue;

        }

        private void зеленыйToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            my_color = Color.DarkGreen;
            toolStripMenuItem1.BackColor = System.Drawing.Color.DarkGreen;

        }

        private void желтыйToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            my_color = Color.Yellow;
            toolStripMenuItem1.BackColor = System.Drawing.Color.Yellow;

        }

        private void черныйToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            my_color = Color.Black;
            toolStripMenuItem1.BackColor = System.Drawing.Color.Black;
        }

        private void белыйToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            my_color = Color.White;
            toolStripMenuItem1.BackColor = System.Drawing.Color.White;
        }

        private void элипсToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            figure = "circulo";
        }

        private void линияToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            figure = "line";
        }

        private void заливкаToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            figure = "zaliv";
        }
        private void ExtFill(Graphics vGraphics, int x, int y, FLOODFILLTYPE floodFillType, Color fillColor, Color borderColor = default(Color))
        {
            IntPtr vDC = vGraphics.GetHdc();
            IntPtr vBrush = CreateSolidBrush(ColorTranslator.ToWin32(fillColor));
            IntPtr vPreviouseBrush = SelectObject(vDC, vBrush);

            switch (floodFillType)
            {
                case FLOODFILLTYPE.FLOODFILLSURFACE:
                    ExtFloodFill(vDC, x, y, GetPixel(vDC, x, y), (uint)FLOODFILLTYPE.FLOODFILLSURFACE);
                    break;
                case FLOODFILLTYPE.FLOODFILLBORDER:
                    ExtFloodFill(vDC, x, y, ColorTranslator.ToWin32(borderColor), (uint)FLOODFILLTYPE.FLOODFILLBORDER);
                    break;
            }
            SelectObject(vDC, vPreviouseBrush);
            DeleteObject(vBrush);
            vGraphics.ReleaseHdc(vDC);
        }

        private void toolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            figure = "lastik";
        }

        private void toolStripMenuItem3_Click(object sender, System.EventArgs e)
        {
            figure = "pencil";
        }

        private void combo_w_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int temp = combo_w.SelectedIndex;
            width = (temp + 1) * 2;
            
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

    }
}
