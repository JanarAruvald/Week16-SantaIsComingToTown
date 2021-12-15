using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int snowflakespeed = 6;
        int treespeed = 6;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void tree_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Santa.Top += gravity;
            SnowFlake.Left -= snowflakespeed;
            tree.Left -= treespeed;
            Score.Text = $"Score: {score}";

            if(SnowFlake.Left < -100)
            {
                SnowFlake.Left = 500;
                score++;
            }

            if(tree.Left < -100)
            {
                tree.Left = 600;
                score++;
            }
            if(Santa.Top < -25)
            {
                gameOver();
            }

            if(Santa.Bounds.IntersectsWith(SnowFlake.Bounds) || Santa.Bounds.IntersectsWith(tree.Bounds) || Santa.Bounds.IntersectsWith(ground.Bounds))
            {
                gameOver();
            }
            
        }
        private void gameOver()
        {
            timer1.Stop();
            Score.Text = $"Game Over!";
            
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
    }
}
