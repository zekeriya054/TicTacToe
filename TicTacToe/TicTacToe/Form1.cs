using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] btns = new Button[3, 3];
        int[,] tictac = new int[3, 3];
        int number = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            int top = 0, left = 0;
            for (int i = 0; i <= btns.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= btns.GetUpperBound(1); j++)
                {
                    btns[i, j] = new Button();
                    btns[i,j].Click+= new System.EventHandler(this.btns_click);
                    btns[i, j].Height = 100;
                    btns[i, j].Width = 100;
                    btns[i,j].Font=new Font("Arial", 24, FontStyle.Bold);
                    btns[i, j].Left = left;
                    btns[i, j].Top = top;
                    left += 100;

                    this.Controls.Add(btns[i, j]);
                    tictac[i, j] = -1;
                }
                top += 100;
                left = 0;
            }
        }

        private void btns_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (number++ % 2 == 0)
            {
                btn.Text = "X";
                btn.BackColor = Color.Red;
                tictac[btn.Top / 100, btn.Left / 100] = 1;
                if(CheckWin(1)) MessageBox.Show("X Won");
                             
            }
            else
            {
                btn.Text = "O";
                btn.BackColor = Color.Yellow;
                tictac[btn.Top /100, btn.Left / 100] = 0;
                if (CheckWin(0)) MessageBox.Show("O Won");
            }

            btn.Enabled = false;
            


        }

        private Boolean CheckWin(int n) 
        {
            Boolean state=true;
            for (int i = 0; i < 3; i++)
            {
                state=true;
                for (int j = 0; j < 3; j++)
                {
                    if (tictac[i, j] == n) continue;
                    else state = false;
                }
                if (state == true) break;
            }
            if (state != true)
            {
                for (int i = 0; i < 3; i++)
                {
                    state = true;
                    for (int j = 0; j < 3; j++)
                    {
                        if (tictac[j, i] == n) continue;
                        else state = false;
                    }
                    if (state == true) break;
                }
            }
            if (state != true)
            {
                state = true;
                for (int i = 0; i < 3; i++)
                {
                    if (tictac[i, i] == n) continue;
                    else state = false;
                }

            }
            if (state != true)
            {
                state = true;
                for (int i = 0; i < 3; i++)
                {
                    if (tictac[i, 2-i] == n) continue;
                    else state = false;
                }
            }
            return state;

        }

 
    }
}
