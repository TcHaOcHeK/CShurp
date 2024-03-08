using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab_1_WindowsForm
{
    public partial class Form1 : Form
    {
        const int coll = 8, row = 8;
        Random rand = new Random();
        Color[] pall = { Color.Red, Color.Green, Color.Yellow, Color.Blue };
        int col = 0, score = 0;
        
        int[,] desk = new int[coll, row];
        int[,] board = new int[coll, row];
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = coll;
            dataGridView1.RowCount = row;
            col = rand.Next(4);
            panel1.BackColor = pall[col];
        }

        public int ThinkColor(int y, int x, int color,  int count = 0)
        {
            int sum = 0;
            if (y < coll && y >= 0 && x < row && x >= 0)
            {
                if (desk[y, x] == color || count == 0)
                {
                    board[y, x] = 1;
                    if(count != 2)
                        sum += ThinkColor(y + 1, x, color, 1);
                    if (count != 1)
                        sum += ThinkColor(y - 1, x, color, 2);
                    if(count!= 4)
                        sum += ThinkColor(y, x + 1, color, 3);
                    if(count!= 3) 
                        sum += ThinkColor(y, x - 1, color, 4);
                    textBox1.Text += ' ' + Convert.ToString(sum);
                    return sum + 1;
                    
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
        private void Zakras(int y, int x)
        {
            int TC = ThinkColor(y, x, desk[y, x]);
            //textBox1.Text = Convert.ToString(TC); //For debug
            
            for (int i = 0; i < coll; i++)
                for (int j = 0; j < row; j++)
                    if (board[i, j] == 1 && TC >= 3)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.White;
                        desk[i, j] = 0;
                        board[i, j] = 0;
                        score ++;
                    }
            
                    else
                    {
                        board[i, j] = 0;
                    }
            


        }

     //git))

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex, y = e.ColumnIndex;
            if (desk[y, x] == 0)
            {
                
                dataGridView1[y, x].Style.BackColor =panel1.BackColor;
                desk[y, x] = col + 1;
                Zakras(y, x);
                col = rand.Next(4);
                panel1.BackColor = pall[col];
                textBox1.Text =  "Your score:" + Convert.ToString(score);

            }
            


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }


        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int k = 0; k < 200; k++)
            {
                int x = rand.Next(row), y = rand.Next(coll);
                if (desk[x, y] == 0)
                {
                    int i = rand.Next(4);
                    dataGridView1[x, y].Style.BackColor = pall[i];
                    desk[x, y] = i + 1;
                    return;
                }
               
            }
            timer1.Enabled = false;
            MessageBox.Show("Поздравляем, ваш итоговый счёт: " + Convert.ToString(score));
        }
        
    }
}