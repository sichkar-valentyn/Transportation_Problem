// File: Form1.cs
// Description: Transportation Model for an optimal strategy for distributing a commodity from a group of supply centers to various receiving centers
// Environment: Visual Studio 2015, C#
//
// MIT License
// Copyright (c) 2017 Valentyn N Sichkar
// github.com/sichkar-valentyn
//
// Reference to:
//[1] Valentyn N Sichkar. Transportation Model for an optimal strategy for distributing a commodity from a group of supply centers to various receiving centers. Solved in C# Windows Form // GitHub platform [Electronic resource]. URL: https://github.com/sichkar-valentyn/Transportation_Problem (date of access: XX.XX.XXXX)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transportation_Models_Sichkar_Valentyn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int number_of_rows = 5, number_of_columns = 6;

        int iteration = -1, indexA, indexB;

        int[,] our_array;

        TextBox[,] tb_Step1 = new TextBox[10, 10];
        TextBox[,] tb_Step2 = new TextBox[10, 10];
        TextBox[,] tb_Step3 = new TextBox[10, 10];
        TextBox[,] tb_Step4 = new TextBox[10, 10];
        TextBox[,] tb_Step5 = new TextBox[10, 10];

        int[,] P = new int[10, 10];
        int[] U = new int[10];
        int[] V = new int[10];
        int[,] S = new int[10, 10];

        int preparation = 0;

        int largest;

        int[,] PlusMinus = new int[10, 10];

        int indexA1, indexB1;

        int minminus = 1000;

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Calculate1_Click(object sender, EventArgs e)
        {
            tb_Step1[1, 1] = textBox11;
            tb_Step1[1, 2] = textBox12;
            tb_Step1[1, 3] = textBox13;
            tb_Step1[1, 4] = textBox14;
            tb_Step1[1, 5] = textBox15;
            tb_Step1[2, 1] = textBox21;
            tb_Step1[2, 2] = textBox22;
            tb_Step1[2, 3] = textBox23;
            tb_Step1[2, 4] = textBox24;
            tb_Step1[2, 5] = textBox25;
            tb_Step1[3, 1] = textBox31;
            tb_Step1[3, 2] = textBox32;
            tb_Step1[3, 3] = textBox33;
            tb_Step1[3, 4] = textBox34;
            tb_Step1[3, 5] = textBox35;
            tb_Step1[4, 1] = textBox41;
            tb_Step1[4, 2] = textBox42;
            tb_Step1[4, 3] = textBox43;
            tb_Step1[4, 4] = textBox44;
            tb_Step1[4, 5] = textBox45;

            our_array = new int[number_of_rows, number_of_columns];
            int sumA = 0;
            int sumB = 0;

            our_array[0, 1] = Convert.ToInt32(textBox01.Text);
            our_array[0, 2] = Convert.ToInt32(textBox02.Text);
            our_array[0, 3] = Convert.ToInt32(textBox03.Text);
            our_array[0, 4] = Convert.ToInt32(textBox04.Text);
            our_array[0, 5] = Convert.ToInt32(textBox05.Text);

            for (int i = 1; i <= 5; i++)
            {
                sumB += our_array[0, i];
            }

            textBoxSumB.Text = sumB.ToString();

            our_array[1, 0] = Convert.ToInt32(textBox10.Text);
            our_array[2, 0] = Convert.ToInt32(textBox20.Text);
            our_array[3, 0] = Convert.ToInt32(textBox30.Text);
            our_array[4, 0] = Convert.ToInt32(textBox40.Text);

            for (int i = 1; i <= 4; i++)
            {
                sumA += our_array[i, 0];
            }

            textBoxSumA.Text = sumA.ToString();

            if (sumA == sumB)
            {
                label4.Visible = true;
                label5.Visible = true;

                label4.BackColor = Color.ForestGreen;
                label4.Text = "The value of needs and value of products are equal.";

                label5.BackColor = Color.ForestGreen;
                label5.Text = "You can go to the next Step and proceed the calculations.";
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;

                label4.BackColor = Color.Red;
                label4.Text = "The task are not balanced.";

                label5.BackColor = Color.Red;
                label5.Text = "Change the initial value or choose another algorithm.";
            }

            tb_Step2[0, 1] = textBoxP01;
            tb_Step2[0, 2] = textBoxP02;
            tb_Step2[0, 3] = textBoxP03;
            tb_Step2[0, 4] = textBoxP04;
            tb_Step2[0, 5] = textBoxP05;

            tb_Step2[0, 1].Text = our_array[0, 1].ToString();
            tb_Step2[0, 2].Text = our_array[0, 2].ToString();
            tb_Step2[0, 3].Text = our_array[0, 3].ToString();
            tb_Step2[0, 4].Text = our_array[0, 4].ToString();
            tb_Step2[0, 5].Text = our_array[0, 5].ToString();

            tb_Step2[1, 0] = textBoxP10;
            tb_Step2[2, 0] = textBoxP20;
            tb_Step2[3, 0] = textBoxP30;
            tb_Step2[4, 0] = textBoxP40;

            tb_Step2[1, 0].Text = our_array[1, 0].ToString();
            tb_Step2[2, 0].Text = our_array[2, 0].ToString();
            tb_Step2[3, 0].Text = our_array[3, 0].ToString();
            tb_Step2[4, 0].Text = our_array[4, 0].ToString();

            iteration = 0;

            tb_Step2[1, 1] = textBoxP11;
            tb_Step2[1, 2] = textBoxP12;
            tb_Step2[1, 3] = textBoxP13;
            tb_Step2[1, 4] = textBoxP14;
            tb_Step2[1, 5] = textBoxP15;
            tb_Step2[2, 1] = textBoxP21;
            tb_Step2[2, 2] = textBoxP22;
            tb_Step2[2, 3] = textBoxP23;
            tb_Step2[2, 4] = textBoxP24;
            tb_Step2[2, 5] = textBoxP25;
            tb_Step2[3, 1] = textBoxP31;
            tb_Step2[3, 2] = textBoxP32;
            tb_Step2[3, 3] = textBoxP33;
            tb_Step2[3, 4] = textBoxP34;
            tb_Step2[3, 5] = textBoxP35;
            tb_Step2[4, 1] = textBoxP41;
            tb_Step2[4, 2] = textBoxP42;
            tb_Step2[4, 3] = textBoxP43;
            tb_Step2[4, 4] = textBoxP44;
            tb_Step2[4, 5] = textBoxP45;

            tb_Step2[1, 1].Clear();
            tb_Step2[1, 1].BackColor = Color.White;
            tb_Step2[1, 2].Clear();
            tb_Step2[1, 2].BackColor = Color.White;
            tb_Step2[1, 3].Clear();
            tb_Step2[1, 3].BackColor = Color.White;
            tb_Step2[1, 4].Clear();
            tb_Step2[1, 4].BackColor = Color.White;
            tb_Step2[1, 5].Clear();
            tb_Step2[1, 5].BackColor = Color.White;
            tb_Step2[2, 1].Clear();
            tb_Step2[2, 1].BackColor = Color.White;
            tb_Step2[2, 2].Clear();
            tb_Step2[2, 2].BackColor = Color.White;
            tb_Step2[2, 3].Clear();
            tb_Step2[2, 3].BackColor = Color.White;
            tb_Step2[2, 4].Clear();
            tb_Step2[2, 4].BackColor = Color.White;
            tb_Step2[2, 5].Clear();
            tb_Step2[2, 5].BackColor = Color.White;
            tb_Step2[3, 1].Clear();
            tb_Step2[3, 1].BackColor = Color.White;
            tb_Step2[3, 2].Clear();
            tb_Step2[3, 2].BackColor = Color.White;
            tb_Step2[3, 3].Clear();
            tb_Step2[3, 3].BackColor = Color.White;
            tb_Step2[3, 4].Clear();
            tb_Step2[3, 4].BackColor = Color.White;
            tb_Step2[3, 5].Clear();
            tb_Step2[3, 5].BackColor = Color.White;
            tb_Step2[4, 1].Clear();
            tb_Step2[4, 1].BackColor = Color.White;
            tb_Step2[4, 2].Clear();
            tb_Step2[4, 2].BackColor = Color.White;
            tb_Step2[4, 3].Clear();
            tb_Step2[4, 3].BackColor = Color.White;
            tb_Step2[4, 4].Clear();
            tb_Step2[4, 4].BackColor = Color.White;
            tb_Step2[4, 5].Clear();
            tb_Step2[4, 5].BackColor = Color.White;

            tb_Step3[0, 1] = textBoxC01;
            tb_Step3[0, 2] = textBoxC02;
            tb_Step3[0, 3] = textBoxC03;
            tb_Step3[0, 4] = textBoxC04;
            tb_Step3[0, 5] = textBoxC05;

            tb_Step3[0, 1].Text = our_array[0, 1].ToString();
            tb_Step3[0, 2].Text = our_array[0, 2].ToString();
            tb_Step3[0, 3].Text = our_array[0, 3].ToString();
            tb_Step3[0, 4].Text = our_array[0, 4].ToString();
            tb_Step3[0, 5].Text = our_array[0, 5].ToString();

            tb_Step3[1, 0] = textBoxC10;
            tb_Step3[2, 0] = textBoxC20;
            tb_Step3[3, 0] = textBoxC30;
            tb_Step3[4, 0] = textBoxC40;

            tb_Step3[1, 0].Text = our_array[1, 0].ToString();
            tb_Step3[2, 0].Text = our_array[2, 0].ToString();
            tb_Step3[3, 0].Text = our_array[3, 0].ToString();
            tb_Step3[4, 0].Text = our_array[4, 0].ToString();

            tb_Step3[1, 1] = textBoxC11;
            tb_Step3[1, 2] = textBoxC12;
            tb_Step3[1, 3] = textBoxC13;
            tb_Step3[1, 4] = textBoxC14;
            tb_Step3[1, 5] = textBoxC15;
            tb_Step3[2, 1] = textBoxC21;
            tb_Step3[2, 2] = textBoxC22;
            tb_Step3[2, 3] = textBoxC23;
            tb_Step3[2, 4] = textBoxC24;
            tb_Step3[2, 5] = textBoxC25;
            tb_Step3[3, 1] = textBoxC31;
            tb_Step3[3, 2] = textBoxC32;
            tb_Step3[3, 3] = textBoxC33;
            tb_Step3[3, 4] = textBoxC34;
            tb_Step3[3, 5] = textBoxC35;
            tb_Step3[4, 1] = textBoxC41;
            tb_Step3[4, 2] = textBoxC42;
            tb_Step3[4, 3] = textBoxC43;
            tb_Step3[4, 4] = textBoxC44;
            tb_Step3[4, 5] = textBoxC45;

            tb_Step3[1, 1].Clear();
            tb_Step3[1, 2].Clear();
            tb_Step3[1, 3].Clear();
            tb_Step3[1, 4].Clear();
            tb_Step3[1, 5].Clear();
            tb_Step3[2, 1].Clear();
            tb_Step3[2, 2].Clear();
            tb_Step3[2, 3].Clear();
            tb_Step3[2, 4].Clear();
            tb_Step3[2, 5].Clear();
            tb_Step3[3, 1].Clear();
            tb_Step3[3, 2].Clear();
            tb_Step3[3, 3].Clear();
            tb_Step3[3, 4].Clear();
            tb_Step3[3, 5].Clear();
            tb_Step3[4, 1].Clear();
            tb_Step3[4, 2].Clear();
            tb_Step3[4, 3].Clear();
            tb_Step3[4, 4].Clear();
            tb_Step3[4, 5].Clear();

            tb_Step4[0, 1] = textBoxW01;
            tb_Step4[0, 2] = textBoxW02;
            tb_Step4[0, 3] = textBoxW03;
            tb_Step4[0, 4] = textBoxW04;
            tb_Step4[0, 5] = textBoxW05;

            tb_Step4[0, 1].Text = our_array[0, 1].ToString();
            tb_Step4[0, 2].Text = our_array[0, 2].ToString();
            tb_Step4[0, 3].Text = our_array[0, 3].ToString();
            tb_Step4[0, 4].Text = our_array[0, 4].ToString();
            tb_Step4[0, 5].Text = our_array[0, 5].ToString();

            tb_Step4[1, 0] = textBoxW10;
            tb_Step4[2, 0] = textBoxW20;
            tb_Step4[3, 0] = textBoxW30;
            tb_Step4[4, 0] = textBoxW40;
        
            tb_Step4[1, 0].Text = our_array[1, 0].ToString();
            tb_Step4[2, 0].Text = our_array[2, 0].ToString();
            tb_Step4[3, 0].Text = our_array[3, 0].ToString();
            tb_Step4[4, 0].Text = our_array[4, 0].ToString();
        
            tb_Step4[1, 1] = textBoxW11;
            tb_Step4[1, 2] = textBoxW12;
            tb_Step4[1, 3] = textBoxW13;
            tb_Step4[1, 4] = textBoxW14;
            tb_Step4[1, 5] = textBoxW15;
            tb_Step4[2, 1] = textBoxW21;
            tb_Step4[2, 2] = textBoxW22;
            tb_Step4[2, 3] = textBoxW23;
            tb_Step4[2, 4] = textBoxW24;
            tb_Step4[2, 5] = textBoxW25;
            tb_Step4[3, 1] = textBoxW31;
            tb_Step4[3, 2] = textBoxW32;
            tb_Step4[3, 3] = textBoxW33;
            tb_Step4[3, 4] = textBoxW34;
            tb_Step4[3, 5] = textBoxW35;
            tb_Step4[4, 1] = textBoxW41;
            tb_Step4[4, 2] = textBoxW42;
            tb_Step4[4, 3] = textBoxW43;
            tb_Step4[4, 4] = textBoxW44;
            tb_Step4[4, 5] = textBoxW45;

            tb_Step4[1, 1].Clear();
            tb_Step4[1, 2].Clear();
            tb_Step4[1, 3].Clear();
            tb_Step4[1, 4].Clear();
            tb_Step4[1, 5].Clear();
            tb_Step4[2, 1].Clear();
            tb_Step4[2, 2].Clear();
            tb_Step4[2, 3].Clear();
            tb_Step4[2, 4].Clear();
            tb_Step4[2, 5].Clear();
            tb_Step4[3, 1].Clear();
            tb_Step4[3, 2].Clear();
            tb_Step4[3, 3].Clear();
            tb_Step4[3, 4].Clear();
            tb_Step4[3, 5].Clear();
            tb_Step4[4, 1].Clear();
            tb_Step4[4, 2].Clear();
            tb_Step4[4, 3].Clear();
            tb_Step4[4, 4].Clear();
            tb_Step4[4, 5].Clear();

            tb_Step5[0, 1] = textBoxD01;
            tb_Step5[0, 2] = textBoxD02;
            tb_Step5[0, 3] = textBoxD03;
            tb_Step5[0, 4] = textBoxD04;
            tb_Step5[0, 5] = textBoxD05;

            tb_Step5[1, 0] = textBoxD10;
            tb_Step5[2, 0] = textBoxD20;
            tb_Step5[3, 0] = textBoxD30;
            tb_Step5[4, 0] = textBoxD40;

            tb_Step5[1, 1] = textBoxD11;
            tb_Step5[1, 2] = textBoxD12;
            tb_Step5[1, 3] = textBoxD13;
            tb_Step5[1, 4] = textBoxD14;
            tb_Step5[1, 5] = textBoxD15;
            tb_Step5[2, 1] = textBoxD21;
            tb_Step5[2, 2] = textBoxD22;
            tb_Step5[2, 3] = textBoxD23;
            tb_Step5[2, 4] = textBoxD24;
            tb_Step5[2, 5] = textBoxD25;
            tb_Step5[3, 1] = textBoxD31;
            tb_Step5[3, 2] = textBoxD32;
            tb_Step5[3, 3] = textBoxD33;
            tb_Step5[3, 4] = textBoxD34;
            tb_Step5[3, 5] = textBoxD35;
            tb_Step5[4, 1] = textBoxD41;
            tb_Step5[4, 2] = textBoxD42;
            tb_Step5[4, 3] = textBoxD43;
            tb_Step5[4, 4] = textBoxD44;
            tb_Step5[4, 5] = textBoxD45;

            tb_Step5[0, 1].Clear();
            tb_Step5[0, 2].Clear();
            tb_Step5[0, 3].Clear();
            tb_Step5[0, 4].Clear();
            tb_Step5[0, 5].Clear();
            tb_Step5[1, 0].Clear();
            tb_Step5[2, 0].Clear();
            tb_Step5[3, 0].Clear();
            tb_Step5[4, 0].Clear();
            tb_Step5[1, 1].Clear();
            tb_Step5[1, 2].Clear();
            tb_Step5[1, 3].Clear();
            tb_Step5[1, 4].Clear();
            tb_Step5[1, 5].Clear();
            tb_Step5[2, 1].Clear();
            tb_Step5[2, 2].Clear();
            tb_Step5[2, 3].Clear();
            tb_Step5[2, 4].Clear();
            tb_Step5[2, 5].Clear();
            tb_Step5[3, 1].Clear();
            tb_Step5[3, 2].Clear();
            tb_Step5[3, 3].Clear();
            tb_Step5[3, 4].Clear();
            tb_Step5[3, 5].Clear();
            tb_Step5[4, 1].Clear();
            tb_Step5[4, 2].Clear();
            tb_Step5[4, 3].Clear();
            tb_Step5[4, 4].Clear();
            tb_Step5[4, 5].Clear();

            tb_Step5[1, 1].BackColor = Color.White;
            tb_Step5[1, 2].BackColor = Color.White;
            tb_Step5[1, 3].BackColor = Color.White;
            tb_Step5[1, 4].BackColor = Color.White;
            tb_Step5[1, 5].BackColor = Color.White;
            tb_Step5[2, 1].BackColor = Color.White;
            tb_Step5[2, 2].BackColor = Color.White;
            tb_Step5[2, 3].BackColor = Color.White;
            tb_Step5[2, 4].BackColor = Color.White;
            tb_Step5[2, 5].BackColor = Color.White;
            tb_Step5[3, 1].BackColor = Color.White;
            tb_Step5[3, 2].BackColor = Color.White;
            tb_Step5[3, 3].BackColor = Color.White;
            tb_Step5[3, 4].BackColor = Color.White;
            tb_Step5[3, 5].BackColor = Color.White;
            tb_Step5[4, 1].BackColor = Color.White;
            tb_Step5[4, 2].BackColor = Color.White;
            tb_Step5[4, 3].BackColor = Color.White;
            tb_Step5[4, 4].BackColor = Color.White;
            tb_Step5[4, 5].BackColor = Color.White;

            button_Initial_Plan.Text = "Start iterations";
            button_Initial_Plan.BackColor = Color.SkyBlue;
            button_Initial_Plan.Enabled = true;

            button_Check_Non_Emptiness.Text = "Check Non Emptiness";
            button_Check_Non_Emptiness.BackColor = Color.LightGray;
            button_Check_Non_Emptiness.Enabled = false;

            button_Calculate_Whole_Cost.Text = "Calculate the Whole Cost";
            button_Calculate_Whole_Cost.BackColor = Color.LightGray;
            button_Calculate_Whole_Cost.Enabled = false;

            button_Improving.Text = "Start improving - creating helper matrix";
            button_Improving.BackColor = Color.LightGray;
            button_Improving.Enabled = false;

            richTextBox_Step5.Clear();
            richTextBox_Step5.Text = "In order to improve our plan we should create helper matrix, in which we fill only that cells P[i, j] we have in our Plan but with the value of Initial matrix (Inputs). The rest of the cells we leave empty.";

            textBox61.Visible = false;
            textBox62.Visible = false;
            textBox63.Visible = false;
            textBox64.Visible = false;
            textBox65.Visible = false;
            textBox66.Visible = false;
            textBox67.Visible = false;
            textBox68.Visible = false;
            textBox69.Visible = false;

            label9.Visible = false;
            label15.Visible = false;
            label15.BackColor = Color.ForestGreen;

            label20.Visible = false;
            label20.Text = "";
            label21.Visible = false;
            label22.Visible = false;
            label22.Text = "";

            indexA = 0;
            indexB = 0;
        }

        private void button_Initial_Plan_Click(object sender, EventArgs e)
        {
            while((indexA != 5) & (indexB != 6))
            { 
               if (iteration == 0)
               {
                    indexA = 1;
                    indexB = 1;

                    tb_Step2[indexA, indexB].Text = "X";
                    tb_Step2[indexA, indexB].ForeColor = Color.Red;

                    iteration ++;
                    button_Initial_Plan.Text = "Iteration "+iteration.ToString();
               }

                if ((indexA == 4) & (indexB == 5))
                {
                    if (our_array[indexA, 0] >= our_array[0, indexB])
                    {
                        tb_Step2[indexA, indexB].Text = our_array[0, indexB].ToString();
                        tb_Step2[indexA, indexB].ForeColor = Color.White;

                        our_array[indexA, 0] = our_array[indexA, 0] - our_array[0, indexB];
                        our_array[0, indexB] = 0;

                        tb_Step2[indexA, 0].Text = our_array[indexA, 0].ToString();
                        tb_Step2[0, indexB].Text = our_array[0, indexB].ToString();

                        tb_Step2[indexA, indexB].BackColor = Color.Gray;

                        label9.Visible = true;

                        button_Initial_Plan.Text = "Found!";
                        button_Initial_Plan.BackColor = Color.LightGray;
                        button_Initial_Plan.Enabled = false;

                        indexA++;
                        indexB++;
                    }
                    else
                    {
                        tb_Step2[indexA, indexB].Text = our_array[indexA, 0].ToString();
                        tb_Step2[indexA, indexB].ForeColor = Color.White;

                        our_array[0, indexB] = our_array[0, indexB] - our_array[indexA, 0];
                        our_array[indexA, 0] = 0;

                        tb_Step2[indexA, 0].Text = our_array[indexA, 0].ToString();
                        tb_Step2[0, indexB].Text = our_array[0, indexB].ToString();

                        tb_Step2[indexA, indexB].BackColor = Color.Gray;

                        label9.Visible = true;

                        button_Initial_Plan.Text = "Found!";
                        button_Initial_Plan.BackColor = Color.LightGray;
                        button_Initial_Plan.Enabled = false;

                        indexA++;
                        indexB++;
                    }

                    tb_Step3[1, 1].Text = tb_Step2[1, 1].Text;
                    tb_Step3[1, 2].Text = tb_Step2[1, 2].Text;
                    tb_Step3[1, 3].Text = tb_Step2[1, 3].Text;
                    tb_Step3[1, 4].Text = tb_Step2[1, 4].Text;
                    tb_Step3[1, 5].Text = tb_Step2[1, 5].Text;
                    tb_Step3[2, 1].Text = tb_Step2[2, 1].Text;
                    tb_Step3[2, 2].Text = tb_Step2[2, 2].Text;
                    tb_Step3[2, 3].Text = tb_Step2[2, 3].Text;
                    tb_Step3[2, 4].Text = tb_Step2[2, 4].Text;
                    tb_Step3[2, 5].Text = tb_Step2[2, 5].Text;
                    tb_Step3[3, 1].Text = tb_Step2[3, 1].Text;
                    tb_Step3[3, 2].Text = tb_Step2[3, 2].Text;
                    tb_Step3[3, 3].Text = tb_Step2[3, 3].Text;
                    tb_Step3[3, 4].Text = tb_Step2[3, 4].Text;
                    tb_Step3[3, 5].Text = tb_Step2[3, 5].Text;
                    tb_Step3[4, 1].Text = tb_Step2[4, 1].Text;
                    tb_Step3[4, 2].Text = tb_Step2[4, 2].Text;
                    tb_Step3[4, 3].Text = tb_Step2[4, 3].Text;
                    tb_Step3[4, 4].Text = tb_Step2[4, 4].Text;
                    tb_Step3[4, 5].Text = tb_Step2[4, 5].Text;

                    button_Check_Non_Emptiness.Text = "Check Non Emptiness";
                    button_Check_Non_Emptiness.BackColor = Color.SkyBlue;
                    button_Check_Non_Emptiness.Enabled = true;
                }

                if ((indexA < 5) & (indexB < 6) & (iteration != 0))
                {
                    if (our_array[indexA, 0] >= our_array[0, indexB])
                    {
                        tb_Step2[indexA, indexB].Text = our_array[0, indexB].ToString();
                        tb_Step2[indexA, indexB].ForeColor = Color.White;

                        our_array[indexA, 0] = our_array[indexA, 0] - our_array[0, indexB];
                        our_array[0, indexB] = 0;

                        tb_Step2[indexA, 0].Text = our_array[indexA, 0].ToString();
                        tb_Step2[0, indexB].Text = our_array[0, indexB].ToString();

                        tb_Step2[indexA, indexB].BackColor = Color.Gray;
                        if (indexA < 4) tb_Step2[indexA + 1, indexB].BackColor = Color.Gray;
                        if (indexA < 3) tb_Step2[indexA + 2, indexB].BackColor = Color.Gray;
                        if (indexA < 2) tb_Step2[indexA + 3, indexB].BackColor = Color.Gray;

                        if (indexB < 5)
                        {
                            indexB++;
                            tb_Step2[indexA, indexB].Text = "X";
                            tb_Step2[indexA, indexB].ForeColor = Color.Red;
                        }

                        iteration++;
                        button_Initial_Plan.Text = "Iteration " + iteration.ToString();
                        break;
                    }
                    else
                    {
                        tb_Step2[indexA, indexB].Text = our_array[indexA, 0].ToString();
                        tb_Step2[indexA, indexB].ForeColor = Color.White;

                        our_array[0, indexB] = our_array[0, indexB] - our_array[indexA, 0];
                        our_array[indexA, 0] = 0;

                        tb_Step2[indexA, 0].Text = our_array[indexA, 0].ToString();
                        tb_Step2[0, indexB].Text = our_array[0, indexB].ToString();

                        tb_Step2[indexA, indexB].BackColor = Color.Gray;
                        if (indexB < 5) tb_Step2[indexA, indexB + 1].BackColor = Color.Gray;
                        if (indexB < 4) tb_Step2[indexA, indexB + 2].BackColor = Color.Gray;
                        if (indexB < 3) tb_Step2[indexA, indexB + 3].BackColor = Color.Gray;
                        if (indexB < 2) tb_Step2[indexA, indexB + 4].BackColor = Color.Gray;

                        if (indexA < 4)
                        {
                            indexA++;
                            tb_Step2[indexA, indexB].Text = "X";
                            tb_Step2[indexA, indexB].ForeColor = Color.Red;
                        }

                        iteration++;
                        button_Initial_Plan.Text = "Iteration " + iteration.ToString();
                        break;
                    }
                }
                break;
            }
        }

        private void button_Check_Non_Emptiness_Click(object sender, EventArgs e)
        {
            int N = 0;

            for (int i = 1; i <= 4; i++)
                for (int j = 1; j <= 5; j++)
                    if (tb_Step3[i, j].Text != "") N++;

            label15.Visible = true;

            if (N == 8) label15.Text = N.ToString() + " = 5 + 4 - 1." + "You can go to the next step.";
            else
            {
                label15.Text = N.ToString() + " != 5 + 4 - 1." + "The Initial Plan is Empty!";
                label15.BackColor = Color.Red;
            }

            button_Check_Non_Emptiness.Text = "Checked!";
            button_Check_Non_Emptiness.BackColor = Color.LightGray;
            button_Check_Non_Emptiness.Enabled = false;

            button_Calculate_Whole_Cost.Text = "Calculate the Whole Cost";
            button_Calculate_Whole_Cost.BackColor = Color.SkyBlue;
            button_Calculate_Whole_Cost.Enabled = true;

            tb_Step4[1, 1].Text = tb_Step2[1, 1].Text;
            tb_Step4[1, 2].Text = tb_Step2[1, 2].Text;
            tb_Step4[1, 3].Text = tb_Step2[1, 3].Text;
            tb_Step4[1, 4].Text = tb_Step2[1, 4].Text;
            tb_Step4[1, 5].Text = tb_Step2[1, 5].Text;
            tb_Step4[2, 1].Text = tb_Step2[2, 1].Text;
            tb_Step4[2, 2].Text = tb_Step2[2, 2].Text;
            tb_Step4[2, 3].Text = tb_Step2[2, 3].Text;
            tb_Step4[2, 4].Text = tb_Step2[2, 4].Text;
            tb_Step4[2, 5].Text = tb_Step2[2, 5].Text;
            tb_Step4[3, 1].Text = tb_Step2[3, 1].Text;
            tb_Step4[3, 2].Text = tb_Step2[3, 2].Text;
            tb_Step4[3, 3].Text = tb_Step2[3, 3].Text;
            tb_Step4[3, 4].Text = tb_Step2[3, 4].Text;
            tb_Step4[3, 5].Text = tb_Step2[3, 5].Text;
            tb_Step4[4, 1].Text = tb_Step2[4, 1].Text;
            tb_Step4[4, 2].Text = tb_Step2[4, 2].Text;
            tb_Step4[4, 3].Text = tb_Step2[4, 3].Text;
            tb_Step4[4, 4].Text = tb_Step2[4, 4].Text;
            tb_Step4[4, 5].Text = tb_Step2[4, 5].Text;

            for (int i = 1; i <= 4; i++)
                for (int j = 1; j <= 5; j++)
                    if (tb_Step3[i, j].Text != "")
                        tb_Step4[i, j].Text += "*" + tb_Step1[i, j].Text;
        }

        private void button_Calculate_Whole_Cost_Click(object sender, EventArgs e)
        {
            int cost = 0;

            for (int i = 1; i <= 4; i++)
                for (int j = 1; j <= 5; j++)
                    if (tb_Step3[i, j].Text != "")
                    {
                        cost += Convert.ToInt32(tb_Step3[i, j].Text) * Convert.ToInt32(tb_Step1[i, j].Text);
                        label20.Text += tb_Step3[i, j].Text + " * " + tb_Step1[i, j].Text + " + ";
                    }

            label20.Text = label20.Text.Substring(0, label20.Text.Length - 2);
            label22.Text = "= " + cost.ToString();
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;

            button_Calculate_Whole_Cost.Text = "Calculated!";
            button_Calculate_Whole_Cost.BackColor = Color.LightGray;
            button_Calculate_Whole_Cost.Enabled = false;

            button_Improving.Text = "Start improving - creating helper matrix";
            button_Improving.BackColor = Color.SkyBlue;
            button_Improving.Enabled = true;

            iteration = 1;
            preparation = 0;
            largest = 0;
        }

        private void button_Improving_Click(object sender, EventArgs e)
        {
            while (iteration != 3)
            {
                if (iteration == 2)
                {
                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "The optimal plan was found!";

                    button_Improving.Text = "Found!";
                    button_Improving.BackColor = Color.LightGray;
                    button_Improving.Enabled = false;

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            tb_Step5[i, j].Text = "";

                    tb_Step5[1, 1].Text = "23";
                    tb_Step5[1, 3].Text = "6";
                    tb_Step5[1, 5].Text = "2";
                    tb_Step5[2, 2].Text = "10";
                    tb_Step5[3, 3].Text = "6";
                    tb_Step5[3, 4].Text = "7";
                    tb_Step5[4, 2].Text = "7";
                    tb_Step5[4, 5].Text = "13";

                    int cost = 0;

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step5[i, j].Text != "")
                            {
                                cost += Convert.ToInt32(tb_Step5[i, j].Text) * Convert.ToInt32(tb_Step1[i, j].Text);                                
                            }

                    richTextBox_Step5.Text += "\n\nThe total cost = " + cost.ToString();

                    break;
                }

                button_Improving.Text = "Find the optimal final plan";

                if ((iteration == 1) & (preparation == 0))
                {
                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step3[i, j].Text != "")
                            {
                                tb_Step5[i, j].Text = tb_Step1[i, j].Text;
                                tb_Step5[i, j].BackColor = Color.ForestGreen;
                                tb_Step5[i, j].ForeColor = Color.White;
                                P[i, j] = Convert.ToInt32(tb_Step5[i, j].Text);
                            }

                    preparation++;
                    button_Improving.Text = "Creating helper column and row";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "Now we need to create helper column U1 .. U4 (products) and helper row V1 .. V5 (needs). We'll calculate them according to the equation: U[i] + V[j] = P[i, j].";

                    break;
                }

                if ((iteration == 1) & (preparation == 1))
                {
                    textBox61.Visible = true;
                    textBox62.Visible = true;
                    textBox63.Visible = true;
                    textBox64.Visible = true;
                    textBox65.Visible = true;
                    textBox66.Visible = true;
                    textBox67.Visible = true;
                    textBox68.Visible = true;
                    textBox69.Visible = true;

                    V[5] = 0;
                    tb_Step5[0, 5].Text = "0";

                    for (int i = 4; i >= 1; i--)
                    {
                        U[i] = P[i, i + 1] - V[i + 1];
                        V[i] = P[i, i] - U[i];

                        tb_Step5[i, 0].Text = U[i].ToString();
                        tb_Step5[0, i].Text = V[i].ToString();
                    }

                    preparation++;
                    button_Improving.Text = "Calculating evaluations for the rest empty cells";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "Now, for all empty cells, we need to calculate evaluations according to the equation: S[i, j] = P[i, j] - U[i] - V[j]." + "\n" + "This is show us how much will be the difference for the delivering one unit of product in each cell.";

                    break;
                }

                if ((iteration == 1) & (preparation == 2))
                {
                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step5[i, j].Text == "")
                            {
                                P[i, j] = Convert.ToInt32(tb_Step1[i, j].Text);
                                S[i, j] = P[i, j] - U[i] - V[j];
                                tb_Step5[i, j].Text = S[i, j].ToString();
                                tb_Step5[i, j].BackColor = Color.SkyBlue;
                                tb_Step5[i, j].ForeColor = Color.White;
                            }

                    preparation++;
                    button_Improving.Text = "Finding the largest value among the negative";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "Now we need to find the largest value among the negative cells and mark it with the '+' and red back color.";

                    break;
                }

                if ((iteration == 1) & (preparation == 3))
                {
                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step3[i, j].Text == "" & Convert.ToInt32(tb_Step5[i, j].Text) < 0)
                            {
                                largest = Convert.ToInt32(tb_Step5[i, j].Text);
                                indexA = i;
                                indexB = j;
                                break;
                            }

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if ((tb_Step3[i, j].Text == "" & Convert.ToInt32(tb_Step5[i, j].Text) < 0) & Convert.ToInt32(tb_Step5[i, j].Text) < largest)
                            {                             
                                largest = Convert.ToInt32(tb_Step5[i, j].Text);
                                indexA = i;
                                indexB = j;
                            }

                    tb_Step5[indexA, indexB].BackColor = Color.Red;

                    preparation++;
                    button_Improving.Text = "Building '+' and '-' cirlce";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "Now we are going back to our Plan and founded largest cell as to create a circle with '+' and '-' in the other cells.";

                    break;
                }

                if ((iteration == 1) & (preparation == 4))
                {
                    textBox61.Visible = false;
                    textBox62.Visible = false;
                    textBox63.Visible = false;
                    textBox64.Visible = false;
                    textBox65.Visible = false;
                    textBox66.Visible = false;
                    textBox67.Visible = false;
                    textBox68.Visible = false;
                    textBox69.Visible = false;

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step3[i, j].Text != "")
                            {
                                tb_Step5[i, j].Text = tb_Step3[i, j].Text;
                                tb_Step5[i, j].ForeColor = Color.Black;
                                tb_Step5[i, j].BackColor = Color.White;
                            }
                            else
                            {
                                tb_Step5[i, j].Text = "";
                                tb_Step5[i, j].BackColor = Color.White;
                            }

                    tb_Step5[0, 5].Text = tb_Step3[0, 5].Text;

                    for (int i = 1; i <= 4; i++)
                    {
                        tb_Step5[i, 0].Text = tb_Step3[i, 0].Text;
                        tb_Step5[0, i].Text = tb_Step3[0, i].Text;
                    }

                    tb_Step5[indexA, indexB].Text = "+";
                    tb_Step5[indexA, indexB].BackColor = Color.Red;

                    indexA1 = indexA;
                    indexB1 = indexB;

                    int indexA2, indexB2;

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            PlusMinus[i, j] = 0;

                    PlusMinus[indexA, indexB] = 2;

                    int t = 1;
                    bool C = true, stepback = true, found = false;
                    bool ReturnA = true, ReturnB = true, ReturnC = true, ReturnD = true;


                    int d = 0;
                    int indexA3 = 0, indexB3 = 0;

                    for (int i = 1; i <= 4; i++)
                    {
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step5[i, j].Text != "")
                            {
                                d++;
                                indexA3 = i;
                                indexB3 = j;
                            }
                        if (d == 1) PlusMinus[indexA3, indexB3] = -1;
                        d = 0;
                    }

                    for (int j = 1; j <= 5; j++)
                    {
                        for (int i = 1; i <= 4; i++)
                            if (tb_Step5[i, j].Text != "")
                            {
                                d++;
                                indexA3 = i;
                                indexB3 = j;
                            }
                        if (d == 1) PlusMinus[indexA3, indexB3] = -1;
                        d = 0;
                    }
                                        
                    while (t != 13 & found == false)
                    {
                        C = true;
                        stepback = true;
                        if (t > 4) PlusMinus[indexA, indexB] = 0;
                        
                        for (int j = indexB1 + 1; j <= 5; j++)
                            if (PlusMinus[indexA1, j] == 1)
                            { break; }
                            else                            
                            if (tb_Step5[indexA1, j].Text != "" & PlusMinus[indexA1, j] == 0)
                            {
                                indexB1 = j;
                                PlusMinus[indexA1, j] = 1;
                                tb_Step5[indexA1, j].Text += "1";
                                C = false;
                                stepback = false;
                                break;
                            }                        

                        if (C == true)
                        {
                            for (int j = indexB1 - 1; j > 0; j--)
                                if (PlusMinus[indexA1, j] == 1)
                                { break; }
                                else                                
                                if (tb_Step5[indexA1, j].Text != "" & PlusMinus[indexA1, j] == 0)
                                {
                                    indexB1 = j;
                                    PlusMinus[indexA1, j] = 1;
                                    tb_Step5[indexA1, j].Text += "1";
                                    C = false;
                                    stepback = false;
                                    ReturnB = false;
                                    break;
                                }                            
                        }

                        if (C == true)
                        {
                            for (int i = indexA1 + 1; i <= 4; i++)
                                if (PlusMinus[i, indexB1] == 1)
                                { break; }
                                else
                                    if (tb_Step5[i, indexB1].Text != "" & PlusMinus[i, indexB1] == 0)
                                    {
                                       indexA1 = i;
                                       PlusMinus[i, indexB1] = 1;
                                       tb_Step5[i, indexB1].Text += "1";
                                       C = false;
                                       stepback = false;
                                       ReturnC = false;
                                       break;
                                    }
                        }

                        if (C == true)
                        {
                            for (int i = indexA1 - 1; i > 0; i--)
                                if (PlusMinus[i, indexB1] == 1)
                                { break; }
                                else
                                    if (tb_Step5[i, indexB1].Text != "" & PlusMinus[i, indexB1] == 0)
                                    {
                                        indexA1 = i;
                                        PlusMinus[i, indexB1] = 1;
                                        tb_Step5[i, indexB1].Text += "1";
                                        C = false;
                                        stepback = false;
                                        ReturnD = false;
                                        break;
                                    }
                        }

                        if (stepback == true)
                        {
                            tb_Step5[indexA1, indexB1].Text = "";
                            tb_Step5[indexA1, indexB1].ForeColor = Color.Black;
                            tb_Step5[indexA1, indexB1].BackColor = Color.White;

                            PlusMinus[indexA1, indexB1] = 0;

                            indexA2 = indexA1;
                            indexB2 = indexB1;

                            C = true;
                            ReturnA = true;
                            ReturnB = true;
                            ReturnC = true;
                            ReturnD = true;

                            for (int j = indexB1 + 1; j <= 5; j++)
                                if (tb_Step5[indexA1, j].Text != "" & PlusMinus[indexA1, j] == 1)
                                {
                                    indexB1 = j;
                                    PlusMinus[indexA1, j] = 1;
                                    tb_Step5[indexA1, j].Text += "1";
                                    C = false;
                                    ReturnA = false;
                                    break;
                                }

                            if (C == true)
                            {
                                for (int j = indexB1 - 1; j > 0; j--)
                                    if (tb_Step5[indexA1, j].Text != "" & PlusMinus[indexA1, j] == 1)
                                    {
                                        indexB1 = j;
                                        PlusMinus[indexA1, j] = 1;
                                        tb_Step5[indexA1, j].Text += "1";
                                        C = false;
                                        ReturnB = false;
                                        break;
                                    }
                            }

                            if (C == true)
                            {
                                for (int i = indexA1 + 1; i <= 4; i++)
                                    if (tb_Step5[i, indexB1].Text != "" & PlusMinus[i, indexB1] == 1)
                                    {
                                        indexA1 = i;
                                        PlusMinus[i, indexB1] = 1;
                                        tb_Step5[i, indexB1].Text += "1";
                                        C = false;
                                        ReturnC = false;
                                        break;
                                    }
                            }

                            if (C == true)
                            {
                                for (int i = indexA1 - 1; i > 0; i--)
                                    if (tb_Step5[i, indexB1].Text != "" & PlusMinus[i, indexB1] == 1)
                                    {
                                        indexA1 = i;
                                        PlusMinus[i, indexB1] = 1;
                                        tb_Step5[i, indexB1].Text += "1";
                                        C = false;
                                        ReturnD = false;
                                        break;
                                    }
                            }


                            if (ReturnA == true)
                            {
                                for (int j = indexB2 + 1; j <= 5; j++)
                                    if (tb_Step5[indexA2, j].Text != "" & (PlusMinus[indexA2, j] == 1 | PlusMinus[indexA2, j] == 0))
                                    {
                                        tb_Step5[indexA2, indexB2].Text = tb_Step3[indexA2, indexB2].Text;
                                        break;
                                    }
                            }

                            if (ReturnB == true)
                            {
                                for (int j = indexB2 - 1; j > 0; j--)
                                    if (tb_Step5[indexA2, j].Text != "" & (PlusMinus[indexA2, j] == 1 | PlusMinus[indexA2, j] == 0))
                                    {
                                        tb_Step5[indexA2, indexB2].Text = tb_Step3[indexA2, indexB2].Text;
                                        break;
                                    }
                            }

                            if (ReturnC == true)
                            {
                                for (int i = indexA2 + 1; i <= 4; i++)
                                    if (tb_Step5[i, indexB2].Text != "" & (PlusMinus[i, indexB2] == 1 | PlusMinus[i, indexB2] == 0))
                                    {
                                        tb_Step5[indexA2, indexB2].Text = tb_Step3[indexA2, indexB2].Text;
                                        break;
                                    }
                            }

                            if (ReturnD == true)
                            {
                                for (int i = indexA2 - 1; i > 0; i--)
                                    if (tb_Step5[i, indexB2].Text != "" & (PlusMinus[i, indexB2] == 1 | PlusMinus[i, indexB2] == 0))
                                    {
                                        tb_Step5[indexA2, indexB2].Text = tb_Step3[indexA2, indexB2].Text;
                                        break;
                                    }
                            }
                        }
                        t++;
                        if (indexA1 == indexA & indexB1 == indexB) found = true;
                    }

                    indexA1 = indexA;
                    indexB1 = indexB;

                    tb_Step5[indexA1, indexB1].BackColor = Color.SkyBlue;
                    tb_Step5[indexA1, indexB1].ForeColor = Color.White;
                    tb_Step5[indexA1, indexB1].Text = "+";

                    C = false;
                    for (int i = indexA1 + 1; i <= 4; i++)
                        if (PlusMinus[i, indexB1] == 1)
                        {
                            tb_Step5[i, indexB1].ForeColor = Color.White;
                            if (C == false) { tb_Step5[i, indexB1].BackColor = Color.ForestGreen; tb_Step5[i, indexB1].Text = "-"; C = true; }
                            else { tb_Step5[i, indexB1].BackColor = Color.SkyBlue; tb_Step5[i, indexB1].Text = "+"; C = false; }
                        }

                    C = false;
                    for (int i = indexA1 - 1; i > 0; i--)
                        if (PlusMinus[i, indexB1] == 1)
                        {
                            tb_Step5[i, indexB1].ForeColor = Color.White;
                            if (C == false) { tb_Step5[i, indexB1].BackColor = Color.ForestGreen; tb_Step5[i, indexB1].Text = "-"; C = true; }
                            else { tb_Step5[i, indexB1].BackColor = Color.SkyBlue; tb_Step5[i, indexB1].Text = "+"; C = false; }
                        }

                    C = false;
                    for (int j = indexB1 + 1; j <= 5; j++)
                        if (PlusMinus[indexA1, j] == 1)
                        {
                            tb_Step5[indexA1, j].ForeColor = Color.White;
                            if (C == false) { tb_Step5[indexA1, j].BackColor = Color.ForestGreen; tb_Step5[indexA1, j].Text = "-"; C = true; }
                            else { tb_Step5[indexA1, j].BackColor = Color.SkyBlue; tb_Step5[indexA1, j].Text = "+"; C = false; }
                        }

                    C = false;
                    for (int j = indexB1 - 1; j > 0; j--)
                        if (PlusMinus[indexA1, j] == 1)
                        {
                            tb_Step5[indexA1, j].ForeColor = Color.White;
                            if (C == false) { tb_Step5[indexA1, j].BackColor = Color.ForestGreen; tb_Step5[indexA1, j].Text = "-"; C = true; }
                            else { tb_Step5[indexA1, j].BackColor = Color.SkyBlue; tb_Step5[indexA1, j].Text = "+"; C = false; }
                        }

                    for (int i = 0; i <= 5; i++)
                        for (int j = 0; j <= 4; j++)
                            if (PlusMinus[i, j] == 1)
                                if (tb_Step5[i, j].Text != "+" | tb_Step5[i, j].Text != "-")
                                {
                                    for (int k = j + 1; k <= 4; k++)
                                    {
                                        if (PlusMinus[i, k] == 1 & tb_Step5[i, k].Text == "+") { tb_Step5[i, j].BackColor = Color.ForestGreen; tb_Step5[i, j].Text = "-"; }
                                        if (PlusMinus[i, k] == 1 & tb_Step5[i, k].Text == "-") { tb_Step5[i, j].BackColor = Color.SkyBlue; tb_Step5[i, j].Text = "+"; }
                                    }
                                    for (int k = j - 1; k > 0; k--)
                                    {
                                        if (PlusMinus[i, k] == 1 & tb_Step5[i, k].Text == "+") { tb_Step5[i, j].BackColor = Color.ForestGreen; tb_Step5[i, j].Text = "-"; }
                                        if (PlusMinus[i, k] == 1 & tb_Step5[i, k].Text == "-") { tb_Step5[i, j].BackColor = Color.SkyBlue; tb_Step5[i, j].Text = "+"; }
                                    }
                                }


                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step3[i, j].Text != "" & PlusMinus[i, j] != 1)
                            {
                                tb_Step5[i, j].Text = tb_Step3[i, j].Text;
                                tb_Step5[i, j].ForeColor = Color.Black;
                                tb_Step5[i, j].BackColor = Color.White;
                            }
                            else
                            {
                                if (PlusMinus[i, j] != 1)
                                {
                                    tb_Step5[i, j].Text = "";
                                    tb_Step5[i, j].BackColor = Color.White;
                                }
                                else
                                {
                                    tb_Step5[i, j].Text += tb_Step3[i, j].Text;
                                }
                            }

                    preparation++;
                    button_Improving.Text = "Finding minimum among '-'";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "Now we need to find minimum among '-' and mark it with red back color.";
                    
                    break;
                }

                if ((iteration == 1) & (preparation == 5))
                {
                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (PlusMinus[i, j] == 1 & tb_Step5[i, j].BackColor == Color.ForestGreen)
                                if (Convert.ToInt32(tb_Step3[i, j].Text) < minminus) { minminus = Convert.ToInt32(tb_Step3[i, j].Text); indexA1 = i;  indexB1 = j; }

                    tb_Step5[indexA1, indexB1].BackColor = Color.Red;
                    
                    preparation++;
                    button_Improving.Text = "Building new Initial Plan";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "Now we calculate new Initial Plan adding at the '+' and minusing at the '-' cells minimum element. In the start point of the circle we put the minimum element itself. The cell with the minimum element becomes empty.";

                    break;
                }
                
                if ((iteration == 1) & (preparation == 6))
                {
                    tb_Step3[indexA, indexB].Text = "0";
                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                        {
                            if (PlusMinus[i, j] == 1 & tb_Step5[i, j].BackColor == Color.ForestGreen)
                            {
                                tb_Step3[i, j].Text = (Convert.ToInt32(tb_Step3[i, j].Text) - minminus).ToString();
                            }
                            if (PlusMinus[i, j] == 1 & tb_Step5[i, j].BackColor == Color.SkyBlue)
                            {
                                tb_Step3[i, j].Text = (Convert.ToInt32(tb_Step3[i, j].Text) + minminus).ToString();
                            }
                        }

                    tb_Step3[indexA, indexB].Text = minminus.ToString();
                    tb_Step3[indexA1, indexB1].Text = "";

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            if (tb_Step3[i, j].Text != "")
                            {
                                tb_Step5[i, j].Text = tb_Step3[i, j].Text;
                                tb_Step5[i, j].ForeColor = Color.Black;
                                tb_Step5[i, j].BackColor = Color.White;
                            }
                            else
                            {
                                tb_Step5[i, j].Text = "";
                                tb_Step5[i, j].BackColor = Color.White;
                            }

                    minminus = 1000;
                    
                    button_Improving.Text = "Find the optimal final plan";

                    richTextBox_Step5.Clear();
                    richTextBox_Step5.Text = "With this new plan we're going to repeat steps for improving and find the optimal plan";

                    iteration = 2;
                    preparation = 0;

                    for (int i = 1; i <= 4; i++)
                        for (int j = 1; j <= 5; j++)
                            P[i, j] = 0;

                    break;
                }
                break;
            }
        }

            }
        }
