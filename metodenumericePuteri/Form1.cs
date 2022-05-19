using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metodenumericePuteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double pdx(double x, double y) {
            return Math.Pow(x, y);
        }
        public string textboxtext2string(ref TextBox t)
        {
            return  t.Text;
            
        }
        public double text2double(string s)
        {
            return Convert.ToDouble(s);
        }
        public string double2string(double x)
        {
            return x.ToString();
        }
        public void string2textboxtext(ref TextBox t, string s, string mode)
        {
            if (mode == "+=")
            {
                t.Text += s;
            }
            else
            {
                t.Text = s;
            }
        }

        public Graphics g;
        public Pen p = new Pen(Color.Black, 1);
        public Brush b = new SolidBrush(Color.Black);
        public Font f;

        private void button1_Click(object sender, EventArgs e)
        {
            double v = pdx(text2double(textboxtext2string(ref this.textBox1)),text2double(textboxtext2string(ref this.textBox3)));
            string2textboxtext(ref this.textBox2, double2string(v),"");
        }
        public float double2float(double d)
        { 
            return float.Parse(d.ToString());
        }

        public void drawcerc(ref Graphics rg, float x, float y, float r)
        {
            rg.DrawEllipse(p, x, y, r, r);
        }
        public void findalldatas(int a, int b , float p, ref TextBox t )
        {
            for (int i = a; i < b; i++)
            {
                double v = pdx(i,(double)p);

                string2textboxtext(ref t, double2string(v),"+=");
                t.Text += "\r\n";
                adddouble2list(v, ref listofvalues);
            }
        }

        public void adddouble2list(double d, ref List<double> ld)
        { 
            ld.Add(d);
        }

        public List<double> listofvalues = new List<double>();
        public void plotDoubles2graphics(ref List<double> ld, ref Graphics rg)
        {
            for (int i = 0; i < ld.Count; i++)
            {
                drawcerc(ref rg, i * 5 + 5, double2float(ld[i])/2, 2);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            f = new Font(this.Font, FontStyle.Bold);
            g = this.panel1.CreateGraphics();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            findalldatas(-20, 20, 2, ref this.textBox4);
            findalldatas(-20, 20, 3, ref this.textBox4);
            findalldatas(-20, 20, 4, ref this.textBox4);
            findalldatas(-20, 20, 5, ref this.textBox4);
            findalldatas(-20, 20, 6, ref this.textBox4);

            plotDoubles2graphics(ref listofvalues, ref g);
        }
    }
}
