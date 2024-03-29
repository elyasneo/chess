﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _008
{
    public partial class Form1 : Form
    {
        bool move_QB = true;
        bool move_RB = true;
        bool move_QW = true;
        bool move_RW = true;
        int wMove = 0;
        int bMove = 0;
        int[,] table;
        int[,] go;
        uC[,] bt;
        int I, J;
        //private EventHandler bt_Click;
        public Form1()
        {
            InitializeComponent();
            labelCheck.Visible = false;
        }
        private void buttonStart(object sender, EventArgs e)
        {
            //First Number : 0 -> Black , 1 -> White
            //Second Number : 
            // 1 -> sarbaz 
            // 2 -> rokh
            // 3 -> asb
            // 4 -> fil
            // 5 -> vazir
            // 6 -> shah
            table = new int[8, 8]      //Init Table with Pieces
            {
                {02, 03, 04, 05, 06, 04, 03, 02},
                {01, 01, 01, 01, 01, 01, 01, 01},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {11, 11, 11, 11, 11, 11, 11, 11},
                {12, 13, 14, 15, 16, 14, 13, 12},
            };
            bt = new uC[8, 8];
            go = new int[8, 8];


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    bt[i, j] = new uC();
                    bt[i, j].Parent = this;
                    bt[i, j].Location = new Point(j * 50 + 50, i * 50 + 50);
                    bt[i, j].pozX = j;
                    bt[i, j].pozY = i;
                    bt[i, j].Size = new Size(50, 50);
                    bt[i, j].Click += new EventHandler(uC_Click);
                    if (i % 2 == 0)
                        if (j % 2 == 1)
                            bt[i, j].BackColor = Color.Black;
                        else
                            bt[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1)
                        bt[i, j].BackColor = Color.White;
                    else
                        bt[i, j].BackColor = Color.Black;
                    bt[i, j].BackgroundImageLayout = ImageLayout.Center;

                }
            }

            validate();
            drawing();
        }
        public void validate()
        {
            int i, j;
            stausTextView.Text = null;
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (table[i, j] != 0)
                        go[i, j] = 1;
                    else
                        go[i, j] = 0;
                }
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    stausTextView.Text += go[i, j].ToString();
                    if (i % 2 == 0)
                        if (j % 2 == 1)
                            bt[i, j].BackColor = Color.Black;
                        else
                            bt[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1)
                        bt[i, j].BackColor = Color.White;
                    else
                        bt[i, j].BackColor = Color.Black;
                }
                stausTextView.Text += "\r\n";
            }
        }
        public void drawing()
        {
            int i, j;
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    switch (table[i, j])
                    {
                        case 00: bt[i, j].BackgroundImage = null; break;
                        case 01: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\pB.gif"); break;
                        case 02: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\RB.gif"); break;
                        case 03: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\NB.gif"); break;
                        case 04: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BB.gif"); break;
                        case 05: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\QB.gif"); break;
                        case 06: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\KB.gif"); break;
                        case 11: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\pW.gif"); break;
                        case 12: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\RW.gif"); break;
                        case 13: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\NW.gif"); break;
                        case 14: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BW.gif"); break;
                        case 15: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\QW.gif"); break;
                        case 16: bt[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\KW.gif"); break;
                    }
                }
            stausTextView.Text = null;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    stausTextView.Text += go[i, j].ToString();
                    if (go[i, j] == 2)
                        bt[i, j].BackColor = Color.Green; //For Possible destination
                    else
                        if (i % 2 == 0)
                            if (j % 2 == 1)
                                bt[i, j].BackColor = Color.Black;
                            else
                                bt[i, j].BackColor = Color.White;
                        else                                             //Line 60 to 68 For Make Black and White Table 
                            if (j % 2 == 1)
                                bt[i, j].BackColor = Color.White;
                            else
                                bt[i, j].BackColor = Color.Black;
                    if (go[i, j] == 3)
                        bt[i, j].BackColor = Color.Blue;               //For Show Select Piece
                }
                stausTextView.Text += "\r\n";
            }
           
        }
        void uC_Click(object sender, EventArgs e)
        {

            int i, j;
            i = (sender as uC).pozY;
            j = (sender as uC).pozX;
            switch (go[i, j])
            {
                case 1:
                    Pieces(table[i, j], i, j,false);
                    I = i;
                    J = j; break;

                case 3:
                case 0:
                    validate(); break;

                case 2:
                    change(i, j); break;
            }
        }
        public void delete()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    go[i, j] = 0;
                }
            I = 0;
            J = 0;
            
            
        }
        public String getName(int x)
        {
            String s = "";
            if (x / 10 > 0)
            {
                s += "White ";
            }
            else s += "Black ";

            switch (x%10)
            {
                case 1: s += "sarbaz";break;

                case 2: s += "rokh"; break;

                case 3: s += "asb"; break;

                case 4: s += "fil"; break;

                case 5: s += "vazir"; break;

                default: s += "shah";break;

            }

            return s;
        }
  
        public void change(int i, int j)
        {
            if (table[I, J] > 10)
            {
                wMove++;
                if (table[i, j] < 10 && table[i, j] != 0)
                {
                    string s = getName(table[i, j]);
                    labelBD.Text += "\n" + s;
                }
            }
            else if (table[I, J] < 10 && table[I, J] > 0)
            {
                bMove++;
                if (table[i, j] > 10 && table[i, j] != 0)
                {
                    string s = getName(table[i, j]);
                    labelWD.Text += "\n" + s;
                }
            }
               

            labaleBMC.Text = bMove.ToString();
            labaleWMC.Text = wMove.ToString();
            if (table[I, J] == 02)
                move_RB = false;
            if (table[I, J] == 12)
                move_RW = false;
            if (table[I, J] == 06)
                move_QB = false;
            if (table[I, J] == 16)
                move_QW = false;
            table[i, j] = table[I, J];
            if (table[I, J] == 06)
            {
                if (i == 0 && j == 2)
                { table[0, 3] = 02; table[0, 0] = 0; }
                if (i == 0 && j == 6)
                { table[0, 5] = 02; table[0, 7] = 0; }
            }
            if (table[I, J] == 16)
            {
                if (i == 7 && j == 2)
                {
                    table[7, 3] = 02;
                    table[7, 0] = 0;
                }
                if (i == 7 && j == 6)
                {
                    table[7, 5] = 02;
                    table[7, 7] = 0;
                }
            }

            if (table[I, J] == 1)
            {
                if(i==7)
                {
                    table[i, j] = 5;
                }
            }
            if (table[I, J] == 11)
            {
                if (i == 0)
                {
                    table[i, j] = 15;
                }
            }

            table[I, J] = 0;
            validate();
            check();
            drawing();
    

        }
        public void check()
        {
            labelCheck.Visible = false;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (table[r, c] != 0)
                    {
                        Pieces(table[r, c], r, c,true);

                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (go[i, j] == 2)
                                {
                                    if (table[r, c] > 10)
                                    {
                                        if (table[i, j] == 06)
                                        {
                                            labelCheck.Text = "Black Check!!!!";
                                            labelCheck.Visible = true;
                                        }

                                    }
                                    if (table[r, c] < 10)
                                    {
                                        if (table[i, j] == 16)
                                        {
                                            labelCheck.Text = "White Check!!!!";
                                            labelCheck.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                   
                }
            }
         
            validate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Pieces(int x, int i, int j,bool isForCheck)
        {
            delete();
            int c;
            switch (x)
            {
                case 1:  // 1 = 01 actually srbaz Black
                    if (j - 1 >= 0)
                        if (table[i + 1, j - 1] > 10)
                            go[i + 1, j - 1] = 2;
                    if (table[i + 1, j] == 0)
                        go[i + 1, j] = 2;
                    if (j + 1 < 8)
                        if (table[i + 1, j + 1] > 10)
                            go[i + 1, j + 1] = 2;
                    if (i == 1)
                        if (table[i + 2, j] == 0)
                            go[i + 2, j] = 2;
                    break;
                case 2:   // 2 = 02 actually rokh Black
                    for (c = i - 1; c > -1; c--)
                        if (table[c, j] == 0)
                        { go[c, j] = 2; }
                        else
                            if (table[c, j] < 10)
                                break;
                            else
                            { go[c, j] = 2; break; }
                    for (c = i + 1; c < 8; c++)
                        if (table[c, j] == 0)
                        { go[c, j] = 2; }
                        else
                            if (table[c, j] < 10)
                                break;
                            else
                            { go[c, j] = 2; break; }
                    for (c = j - 1; c > -1; c--)
                        if (table[i, c] == 0)
                        { go[i, c] = 2; }
                        else
                            if (table[i, c] < 10)
                                break;
                            else
                            { go[i, c] = 2; break; }
                    for (c = j + 1; c < 8; c++)
                        if (table[i, c] == 0)
                        { go[i, c] = 2; }
                        else
                            if (table[i, c] < 10)
                                break;
                            else
                            { go[i, c] = 2; break; }
                    break;
                case 3:
                    if (i - 2 >= 0)
                    {
                        if (j - 1 >= 0)
                            if (table[i - 2, j - 1] == 0 || table[i - 2, j - 1] > 10)
                                go[i - 2, j - 1] = 2;
                        if (j + 1 < 8)
                            if (table[i - 2, j + 1] == 0 || table[i - 2, j + 1] > 10)
                                go[i - 2, j + 1] = 2;
                    }
                    if (i + 2 < 8)
                    {

                        if (j - 1 >= 0)
                            if (table[i + 2, j - 1] == 0 || table[i + 2, j - 1] > 10)
                                go[i + 2, j - 1] = 2;
                        if (j + 1 < 8)
                            if (table[i + 2, j + 1] == 0 || table[i + 2, j + 1] > 10)
                                go[i + 2, j + 1] = 2;
                    }
                    if (j - 2 >= 0)
                    {

                        if (i - 1 >= 0)
                            if (table[i - 1, j - 2] == 0 || table[i - 1, j - 2] > 10)
                                go[i - 1, j - 2] = 2;
                        if (i + 1 < 8)
                            if (table[i + 1, j - 2] == 0 || table[i + 1, j - 2] > 10)
                                go[i + 1, j - 2] = 2;
                    }
                    if (j + 2 < 8)
                    {

                        if (i - 1 >= 0)
                            if (table[i - 1, j + 2] == 0 || table[i - 1, j + 2] > 10)
                                go[i - 1, j + 2] = 2;
                        if (i + 1 < 8)
                            if (table[i + 1, j + 2] == 0 || table[i + 1, j + 2] > 10)
                                go[i + 1, j + 2] = 2;
                    } break;
                case 4:
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j - c >= 0)
                            if (table[i - c, j - c] == 0 || table[i - c, j - c] > 10)
                            { go[i - c, j - c] = 2; if (table[i - c, j - c] > 10) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j + c < 8)
                            if (table[i - c, j + c] == 0 || table[i - c, j + c] > 10)
                            { go[i - c, j + c] = 2; if (table[i - c, j + c] > 10) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j + c < 8)
                            if (table[i + c, j + c] == 0 || table[i + c, j + c] > 10)
                            { go[i + c, j + c] = 2; if (table[i + c, j + c] > 10) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j - c >= 0)
                            if (table[i + c, j - c] == 0 || table[i + c, j - c] > 10)
                            { go[i + c, j - c] = 2; if (table[i + c, j - c] > 10) break; }
                            else
                                break;

                    break;
                case 5:
                    for (c = 1; c < 8; c++)
                        if (j - c >= 0)
                            if (table[i, j - c] == 0)
                            { go[i, j - c] = 2; }
                            else { 
                                if (table[i, j - c] < 10) break;
                                else go[i, j - c] = 2;break;
                            }
                    for (c = 1; c < 8; c++)
                        if (j + c < 8)

                            if (table[i, j + c] == 0)
                            { go[i, j + c] = 2; }
                            else
                            {
                                if (table[i, j + c] < 10) break;
                                else go[i, j + c] = 2; break;
                            }
                    for (c = 1; c < 8; c++)
                        if (i + c < 8)
                                if (table[i+c, j ] == 0)
                                    { go[i + c, j] = 2; }
                                    else
                                    {
                                        if (table[i + c, j] < 10) break;
                                        else go[i + c, j] = 2; break;
                                    }
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0)
                            if (table[i - c, j] == 0)
                            { go[i - c, j] = 2; }
                            else
                            {
                                if (table[i - c, j] < 10) break;
                                else go[i - c, j] = 2; break;
                            }
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j - c >= 0)
                                    if (table[i - c, j-c] == 0)
                                    { go[i - c, j-c] = 2; }
                                    else
                                    {
                                        if (table[i - c, j-c] < 10) break;
                                        else go[i - c, j-c] = 2; break;
                                    }
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j + c < 8)
                            if (table[i + c, j + c] == 0)
                            { go[i + c, j + c] = 2; }
                            else
                            {
                                if (table[i + c, j + c] < 10) break;
                                else go[i + c, j + c] = 2; break;
                            }
                    for (c = 1; c < 8; c++)
                        if (i - c >=0 && j + c < 8)
                            if (table[i - c, j + c] == 0)
                            { go[i - c, j + c] = 2; }
                            else
                            {
                                if (table[i - c, j + c] < 10) break;
                                else go[i - c, j + c] = 2; break;
                            }

                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j - c >= 0)
                            if (table[i + c, j - c] == 0)
                            {
                                go[i + c, j - c] = 2;
                            }
                            else{
                                if (table[i + c, j - c] < 10) break;
                                else go[i + c, j - c] = 2;  break; }
                    break;
                case 6:
                    if (i - 1 >= 0)
                        if (table[i - 1, j] == 0 || table[i - 1, j] > 10)
                            go[i - 1, j] = 2;
                    if (i - 1 >= 0 && j + 1 < 8)
                        if (table[i - 1, j + 1] == 0 || table[i - 1, j + 1] > 10)
                            go[i - 1, j + 1] = 2;
                    if (j + 1 < 8)
                        if (table[i, j + 1] == 0 || table[i, j + 1] > 10)
                            go[i, j + 1] = 2;
                    if (i + 1 < 8 && j + 1 < 8)
                        if (table[i + 1, j + 1] == 0 || table[i + 1, j + 1] > 10)
                            go[i + 1, j + 1] = 2;
                    if (i + 1 < 8)
                        if (table[i + 1, j] == 0 || table[i + 1, j] > 10)
                            go[i + 1, j] = 2;
                    if (i + 1 < 8 && j - 1 >= 0)
                        if (table[i + 1, j - 1] == 0 || table[i + 1, j - 1] > 10)
                            go[i + 1, j - 1] = 2;
                    if (j - 1 >= 0)
                        if (table[i, j - 1] == 0 || table[i, j - 1] > 10)
                            go[i, j - 1] = 2;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        if (table[i - 1, j - 1] == 0 || table[i - 1, j - 1] > 10)
                            go[i - 1, j - 1] = 2;
                    if (move_QB && move_RB)
                    {
                        if (table[0, 1] == 0 && table[0, 2] == 0 && table[0, 3] == 0)
                            go[0, 2] = 2;
                        if (table[0, 5] == 0 && table[0, 6] == 0)
                            go[0, 6] = 2;
                    }

                    break;
                case 11:
                    if (j - 1 >= 0)
                        if (table[i - 1, j - 1] < 10 && table[i - 1, j - 1] != 0)
                            go[i - 1, j - 1] = 2;
                    if (table[i - 1, j] == 0)
                        go[i - 1, j] = 2;
                    if (j + 1 < 8)
                        if (table[i - 1, j + 1] < 10 && table[i - 1, j + 1] != 0)
                            go[i - 1, j + 1] = 2;
                    if (i == 6)
                        if (table[i - 2, j] == 0)
                            go[i - 2, j] = 2;
                    break;
                case 12:
                    for (c = i - 1; c > -1; c--)
                        if (table[c, j] == 0)
                        { go[c, j] = 2; }
                        else
                            if (table[c, j] > 10)
                                break;
                            else
                            { go[c, j] = 2; break; }
                    for (c = i + 1; c < 8; c++)
                        if (table[c, j] == 0)
                        { go[c, j] = 2; }
                        else
                            if (table[c, j] > 10)
                                break;
                            else
                            { go[c, j] = 2; break; }
                    for (c = j - 1; c > -1; c--)
                        if (table[i, c] == 0)
                        { go[i, c] = 2; }
                        else
                            if (table[i, c] > 10)
                                break;
                            else
                            { go[i, c] = 2; break; }
                    for (c = j + 1; c < 8; c++)
                        if (table[i, c] == 0)
                        { go[i, c] = 2; }
                        else
                            if (table[i, c] > 10)
                                break;
                            else
                            { go[i, c] = 2; break; }
                    break;
                case 13:
                    if (i - 2 >= 0)
                    {
                        if (j - 1 >= 0)
                            if (table[i - 2, j - 1] < 10)
                                go[i - 2, j - 1] = 2;
                        if (j + 1 < 8)
                            if (table[i - 2, j + 1] < 10)
                                go[i - 2, j + 1] = 2;
                    }
                    if (i + 2 < 8)
                    {

                        if (j - 1 >= 0)
                            if (table[i + 2, j - 1] < 10)
                                go[i + 2, j - 1] = 2;
                        if (j + 1 < 8)
                            if (table[i + 2, j + 1] < 10)
                                go[i + 2, j + 1] = 2;
                    }
                    if (j - 2 >= 0)
                    {

                        if (i - 1 >= 0)
                            if (table[i - 1, j - 2] < 10)
                                go[i - 1, j - 2] = 2;
                        if (i + 1 < 8)
                            if (table[i + 1, j - 2] < 10)
                                go[i + 1, j - 2] = 2;
                    }
                    if (j + 2 < 8)
                    {

                        if (i - 1 >= 0)
                            if (table[i - 1, j + 2] < 10)
                                go[i - 1, j + 2] = 2;
                        if (i + 1 < 8)
                            if (table[i + 1, j + 2] < 10)
                                go[i + 1, j + 2] = 2;
                    } break;
                case 14:
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j - c >= 0)
                            if (table[i - c, j - c] == 0 || table[i - c, j - c] < 10)
                            { go[i - c, j - c] = 2; if (table[i - c, j - c] < 10 && table[i - c, j - c] != 0) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j + c < 8)
                            if (table[i - c, j + c] == 0 || table[i - c, j + c] < 10)
                            { go[i - c, j + c] = 2; if (table[i - c, j + c] < 10 && table[i - c, j + c] != 0) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j + c < 8)
                            if (table[i + c, j + c] == 0 || table[i + c, j + c] < 10)
                            { go[i + c, j + c] = 2; if (table[i + c, j + c] < 10 && table[i + c, j + c] != 0) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j - c >= 0)
                            if (table[i + c, j - c] == 0 || table[i + c, j - c] < 10)
                            { go[i + c, j - c] = 2; if (table[i + c, j - c] < 10 && table[i + c, j - c] != 0) break; }
                            else
                                break;

                    break;
                case 15:

                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j - c >= 0)
                            if (table[i - c, j - c] == 0 || table[i - c, j - c] < 10)
                            { go[i - c, j - c] = 2; if (table[i - c, j - c] < 10 && table[i - c, j - c] != 0) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i - c >= 0 && j + c < 8)
                            if (table[i - c, j + c] == 0 || table[i - c, j + c] < 10)
                            { go[i - c, j + c] = 2; if (table[i - c, j + c] < 10 && table[i - c, j + c] != 0) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j + c < 8)
                            if (table[i + c, j + c] == 0 || table[i + c, j + c] < 10)
                            { go[i + c, j + c] = 2; if (table[i + c, j + c] < 10 && table[i + c, j + c] != 0) break; }
                            else
                                break;
                    for (c = 1; c < 8; c++)
                        if (i + c < 8 && j - c >= 0)
                            if (table[i + c, j - c] == 0 || table[i + c, j - c] < 10)
                            { go[i + c, j - c] = 2; if (table[i + c, j - c] < 10 && table[i + c, j - c] != 0) break; }
                            else
                                break;
                    for (c = i - 1; c > -1; c--)
                        if (table[c, j] == 0)
                        { go[c, j] = 2; }
                        else
                            if (table[c, j] > 10)
                                break;
                            else
                            { go[c, j] = 2; break; }
                    for (c = i + 1; c < 8; c++)
                        if (table[c, j] == 0)
                        { go[c, j] = 2; }
                        else
                            if (table[c, j] > 10)
                                break;
                            else
                            { go[c, j] = 2; break; }
                    for (c = j - 1; c > -1; c--)
                        if (table[i, c] == 0)
                        { go[i, c] = 2; }
                        else
                            if (table[i, c] > 10)
                                break;
                            else
                            { go[i, c] = 2; break; }
                    for (c = j + 1; c < 8; c++)
                        if (table[i, c] == 0)
                        { go[i, c] = 2; }
                        else
                            if (table[i, c] > 10)
                                break;
                            else
                            { go[i, c] = 2; break; }
                    break;
                case 16:
                    if (i - 1 >= 0)
                        if (table[i - 1, j] == 0 || table[i - 1, j] < 10)
                            go[i - 1, j] = 2;
                    if (i - 1 >= 0 && j + 1 < 8)
                        if (table[i - 1, j + 1] == 0 || table[i - 1, j + 1] < 10)
                            go[i - 1, j + 1] = 2;
                    if (j + 1 < 8)
                        if (table[i, j + 1] == 0 || table[i, j + 1] < 10)
                            go[i, j + 1] = 2;
                    if (i + 1 < 8 && j + 1 < 8)
                        if (table[i + 1, j + 1] == 0 || table[i + 1, j + 1] < 10)
                            go[i + 1, j + 1] = 2;
                    if (i + 1 < 8)
                        if (table[i + 1, j] == 0 || table[i + 1, j] < 10)
                            go[i + 1, j] = 2;
                    if (i + 1 < 8 && j - 1 >= 0)
                        if (table[i + 1, j - 1] == 0 || table[i + 1, j - 1] < 10)
                            go[i + 1, j - 1] = 2;
                    if (j - 1 >= 0)
                        if (table[i, j - 1] == 0 || table[i, j - 1] < 10)
                            go[i, j - 1] = 2;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        if (table[i - 1, j - 1] == 0 || table[i - 1, j - 1] < 10)
                            go[i - 1, j - 1] = 2;
                    if (move_QW && move_RW)
                    {
                        if (table[7, 1] == 0 && table[7, 2] == 0 && table[7, 3] == 0)
                            go[7, 2] = 2;
                        if (table[7, 5] == 0 && table[7, 6] == 0)
                            go[7, 6] = 2;
                    }
                    break;
            }
            go[i, j] = 3;
       
            if(!isForCheck)
                drawing();
            
           
        }
      
      
    }
}
