using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkWinner(string currentPlayer, int clicks)
        {
            if ((button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "") ||
                (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "") ||
                (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "") ||
                (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "") ||
                (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "") ||
                (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "") ||
                (button1.Text == button5.Text && button5.Text == button3.Text && button3.Text != "") ||
                (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != ""))
            {
                label.Text = currentPlayer + " WINS!";

                // disable all remaining buttons
                foreach (Control btn in this.Controls)
                {
                    // skip restart button
                    if (btn.Name == "restart_btn")
                    {
                        continue;
                    }
                    // skip already disabled buttons
                    else if (btn.Enabled == false)
                    {
                        continue;
                    }
                    // skip label
                    else if (btn is Label)
                    {
                        continue;
                    }
                    else
                    {
                        btn.Enabled = false;
                    }
                }
            }
            else if (clicks == 9)
            {
                label.Text = "It's a tie!";
            }
        }

        public string currentPlayer = "O";
        public int clicks = 0;

        private void button_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = currentPlayer;
            (sender as Button).Enabled = false;
            clicks++;
            checkWinner(currentPlayer, clicks);
            
            if (currentPlayer == "O")
            {
                currentPlayer = "X";
                label.Text = "Next turn: " + currentPlayer;
            }
            else
            {
                currentPlayer = "O";
                label.Text = "Next turn: " + currentPlayer;
            }
        }

        // TO DO: FIX WRONG LABEL TEXT AFTER WIN

        private void restart_btn_Click(object sender, EventArgs e)
        {
            // enable all buttons and clear the 'O' and 'X' symbols, skip restart button
            foreach (Control btn in this.Controls)
            {
                if (btn.Name == "restart_btn")
                {
                    continue;
                }
                else
                {
                    btn.Text = "";
                    btn.Enabled = true;
                }
            }

            // set current player to 'O' and change the label
            currentPlayer = "O";
            label.Text = "Next turn: " + currentPlayer;
            clicks = 0;
        }
    }
}

// TO DO: CHANGE LAYOUT OF DISABLED BUTTONS