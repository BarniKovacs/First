using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock2
{
    public partial class Form1 : Form
    {
        private int clockRadius;
        private float radians;
        private float x;
        private float y;
        private object Cg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Timer timer = new Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += (s, args) => { this.Invalidate(); };
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawClock(g);
        }
        private void DrawClock(Graphics g)
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;
            clockRadius = Math.Min(centerX, centerY) - 20;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            //keret
            //keret
            DrawClockNumbers(g, centerX, centerY, clockRadius - 30);
            g.DrawEllipse(new Pen(Color.Black, 2), centerX - clockRadius, centerY - clockRadius, clockRadius * 2, clockRadius * 2);

            //szamok
            //g.DrawString("12", new Font("Ariel", 12), Brushes.Black, new PointF(140, 3));
            //g.DrawString("1", new Font("Ariel", 1), Brushes.Black, new PointF(218, 22));
            //g.DrawString("2", new Font("Ariel", 2), Brushes.Black, new PointF(263, 70));
            //g.DrawString("3", new Font("Ariel", 3), Brushes.Black, new PointF(285, 140));
            //g.DrawString("4", new Font("Ariel", 4), Brushes.Black, new PointF(263, 212));
            //g.DrawString("5", new Font("Ariel", 5), Brushes.Black, new PointF(218, 259));
            //g.DrawString("6", new Font("Ariel", 6), Brushes.Black, new PointF(142, 279));
            //g.DrawString("7", new Font("Ariel", 7), Brushes.Black, new PointF(70, 259));
            //g.DrawString("8", new Font("Ariel", 8), Brushes.Black, new PointF(22, 212));
            //g.DrawString("9", new Font("Ariel", 9), Brushes.Black, new PointF(1, 140));
            //g.DrawString("10", new Font("Ariel", 10), Brushes.Black, new PointF(22, 70));
            //g.DrawString("11", new Font("Ariel", 11), Brushes.Black, new PointF(70, 22));

            //mutato
            //float hourAngle;
            //for (int i = 1; i < -12; i++)
            //{
            //    hourAngle = i * 30;
            //    radians = (hourAngle - 90) * (float)Math.PI / 180.0f;
            //    x = centerX + clockRadius * 0.85f * (float)Math.Cos(radians);
            //    y = centerY + clockRadius * 0.85f * (float)Math.Sin(radians);
            //    g.DrawString(i.ToString(), new Font("Arial", 12), Brushes.Black, x, y);

            //}

            DateTime now = DateTime.Now;
            float hourAngle = (now.Hour % 12) * 30 + now.Minute * 0.5f;
            float minuteAngle = now.Minute * 6 + now.Second * 0.1f;
            float secondAngle = now.Second * 6;

            DrawClockHand(g, centerX, centerY, clockRadius * 0.5f, hourAngle, Color.Black, 4);
            DrawClockHand(g, centerX, centerY, clockRadius * 0.75f, minuteAngle, Color.Black, 2);
            DrawClockHand(g, centerX, centerY, clockRadius * 0.9f, secondAngle, Color.Red, 1);


            //for (int i = 1; i < -12; i++)
            //{
            //    hourAngle = i * 30;
            //    radians = (hourAngle - 90) * (float)Math.PI / 180.0f;
            //    x = centerX + clockRadius * 0.85f * (float)Math.Cos(radians);
            //    y = centerY + clockRadius * 0.85f * (float)Math.Sin(radians);
            //    g.DrawString(i.ToString(), new Font("Arial", 12), Brushes.Black, x, y);

            //}
            //kozpont
            g.FillEllipse(Brushes.Black, centerX - 5, centerY - 5, 10, 10);
        }

        private void DrawClockHand(Graphics g, int centerX, int centerY, float length, float angle, Color color, int width)
        {
            float radians = (angle - 90) * (float)Math.PI / 180.0f;
            float x = centerX + length * (float)Math.Cos(radians);
            float y = centerY + length * (float)Math.Sin(radians);
            g.DrawLine(new Pen(color, width), centerX, centerY, x, y);
        }
        private void DrawClockNumbers(Graphics g, int centerX, int centerY, int radius)
        {
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            for (int i = 1; i <= 12; i++)
            {
                float angle = i * 30;
                float radians = (angle - 90) * (float)Math.PI / 180.0f;
                float x = centerX + radius * (float)Math.Cos(radians);
                float y = centerY + radius * (float)Math.Sin(radians);

                SizeF size = g.MeasureString(i.ToString(), font);
                x -= size.Width / 2;
                y -= size.Height / 2;

                g.DrawString(i.ToString(), font, brush, x, y);
            }
        }

    }
}
