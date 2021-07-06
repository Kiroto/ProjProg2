using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;

namespace GameForm
{
    public partial class TicTacToeForm : Form
    {
        TicTacToeGame ticTacToeGame = new TicTacToeGame();

        public TicTacToeForm()
        {
            InitializeComponent();
        }

        private void refreshPlayfield()
        {
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = ticTacToeGame.getGamespace(i%3, i/3).ToString();
            }
            label2.Text = ticTacToeGame.getCurrentPlayerSymbol().ToString().ToUpper();
            int plrWin = ticTacToeGame.didPlayerWin();
            switch (plrWin)
            {
                case 1:
                    {
                        label1.Text = "Ganó el jugador X";
                        break;
                    }
                case 2:
                    {
                        label1.Text = "Ganó el jugador O";
                        break;
                    }
                case 3:
                    {
                        label1.Text = "Empate";
                        break;
                    }
                default:
                    {
                        label1.Text = "A jugar";
                        break;
                    }
            }
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            ticTacToeGame.initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(0, 0);
            refreshPlayfield();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(1, 0);
            refreshPlayfield();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(2, 0);
            refreshPlayfield();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(0, 1);
            refreshPlayfield();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(1, 1);
            refreshPlayfield();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(2, 1);
            refreshPlayfield();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(0, 2);
            refreshPlayfield();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(1, 2);
            refreshPlayfield();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ticTacToeGame.playOnTable(2, 2);
            refreshPlayfield();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ticTacToeGame.initialize();
            refreshPlayfield();
        }
    }
}
