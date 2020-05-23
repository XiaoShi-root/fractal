﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            
        private void Clickaction(object sender, EventArgs e)
        {
            Graphics g;
            g = this.CreateGraphics();
            Sierpinski_triangle sierpinski_Triangle = new Sierpinski_triangle(g);
            sierpinski_Triangle.Draw(1000L);
        }

        private void fload(object sender, EventArgs e)
        {

        }
    }
    public class Sierpinski_triangle
    {
        Graphics g;
        readonly Pen Pen = new Pen(Color.Black, 4f);
        public int[] a, b, c;//三个初始点
        public double[] temppoint;
        public double a_Between_temppoint, b_Between_temppoint,c_Between_temppoint;//三个初始点与temppoint的距离
        public Sierpinski_triangle(Graphics graphics)//初始化四个点
        {
            a = new int[] { 400,2 };
            b = new int[] { 2,500 };
            c = new int[] { 798, 500 };
            temppoint = new double[] { 12.33f, 123.2f };
            g = graphics;
            g.DrawLine(Pen, a[0], a[1], a[0] + 0.1f, a[1] + 1f);
            g.DrawLine(Pen, b[0], b[1], b[0] + 0.1f, b[1] + 1f);
            g.DrawLine(Pen, c[0], c[1], c[0] + 0.1f, c[1] + 1f);
        }
        public void Draw(long times)//在form上画谢尔并斯基三角，使用递归完成
        {
            a_Between_temppoint = Get_Distance(a, temppoint);
            b_Between_temppoint = Get_Distance(b, temppoint);
            c_Between_temppoint = Get_Distance(c, temppoint);
            if (a_Between_temppoint >= b_Between_temppoint)
            {
                if (a_Between_temppoint >= c_Between_temppoint)
                {
                    temppoint = Getmidpoint(a, temppoint);
                }
            }
            else if(b_Between_temppoint >= c_Between_temppoint)
            {
                temppoint = Getmidpoint(b, temppoint);
            }
            else
            {
                temppoint = Getmidpoint(c, temppoint);
            }
            g.DrawLine(Pen, (float)temppoint[0], (float)temppoint[1], (float)(temppoint[0] + 6), (float)(temppoint[1] + 6));//画出新点
            if (times >= 0)//使用递归完成
            {
                Draw(times - 1);
            }
            
        }
        protected double Get_Distance(int[]a , double[] temp)//获取两点间的距离
        {
            return Math.Sqrt(Math.Pow(a[0]-b[0],2)+Math.Pow(a[1]-b[1],2));
        }
        protected double[] Getmidpoint(int[] a, double[] temp)//获取两点的中点的坐标
        {
            return new double[] {(a[0]+temp[0])/2, (a[1] + temp[1]) / 2 };
        }
    }
} 
