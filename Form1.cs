using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4_Paper_Stone_Scissors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum enWinner { Player,Computer,Draw}
        struct stGameStatus {
            public int Rounds;
            public string ComputerChoice;
            public string PlayerChoice;
            public enWinner Winner;
            public int CounterPlayerWinner;
            public int CounterComputerWinner;
            public int CounterDraw;
        }
        stGameStatus GameStatus;


        Random random = new Random();
        private void ComputerChoice()
        {
            int Choice = random.Next(1, 4);
            switch(Choice)
            {
                case 1:
                    GameStatus.ComputerChoice = "Paper";
                    break;
                case 2:
                    GameStatus.ComputerChoice = "Rock";
                    break;
                case 3:
                    GameStatus.ComputerChoice = "Scissors";
                    break;
            }
        }
        private void PlayerChoice()
        {
            if (rbPaper.Checked)
            {
                GameStatus.PlayerChoice = "Paper";
                return;
            }
            if (rbRock.Checked)
            {
                GameStatus.PlayerChoice = "Rock";
                return;
            }
            GameStatus.PlayerChoice = "Scissors";
        }
        private void CheckValue()
        {
            PlayerChoice();
            ComputerChoice();

            if (GameStatus.PlayerChoice == GameStatus.ComputerChoice)
            {
                // Draw
                GameStatus.Winner = enWinner.Draw;
                GameStatus.Rounds++;
                GameStatus.CounterDraw++;
                lblDraw.Text = GameStatus.CounterDraw.ToString();
                lblRound.Text = GameStatus.Rounds.ToString();
                return;
            }

            switch (GameStatus.PlayerChoice)
            {
                case "Paper":
                    if (GameStatus.ComputerChoice == "Rock")
                    {
                        GameStatus.Winner = enWinner.Player;
                        GameStatus.CounterPlayerWinner++;
                        lblPlayerWinner.Text = GameStatus.CounterPlayerWinner.ToString();
                    }
                    else
                    {
                        GameStatus.Winner = enWinner.Computer;
                        GameStatus.CounterComputerWinner++;
                        lblComputerWinner.Text = GameStatus.CounterComputerWinner.ToString();
                    }
                    break;
                case "Rock":
                    if (GameStatus.ComputerChoice == "Scissors")
                    {
                        GameStatus.Winner = enWinner.Player;
                        GameStatus.CounterPlayerWinner++;
                        lblPlayerWinner.Text = GameStatus.CounterPlayerWinner.ToString();
                    }
                    else
                    {
                        GameStatus.Winner = enWinner.Computer;
                        GameStatus.CounterComputerWinner++;
                        lblComputerWinner.Text = GameStatus.CounterComputerWinner.ToString();
                    }
                    break;
                case "Scissors":
                    if (GameStatus.ComputerChoice == "Paper")
                    {
                        GameStatus.Winner = enWinner.Player;
                        GameStatus.CounterPlayerWinner++;
                        lblPlayerWinner.Text = GameStatus.CounterPlayerWinner.ToString();
                    }
                    else
                    {
                        GameStatus.Winner = enWinner.Computer;
                        GameStatus.CounterComputerWinner++;
                        lblComputerWinner.Text = GameStatus.CounterComputerWinner.ToString();
                    }
                    break;
            }

            GameStatus.Rounds++;
            lblRound.Text = GameStatus.Rounds.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbPaper.Checked = true;
        }
        private void ShowRound()
        {
            MessageBox.Show("Player: " + GameStatus.PlayerChoice + Environment.NewLine +
                "Computer: " + GameStatus.ComputerChoice + Environment.NewLine +
                "Winner: " + GameStatus.Winner.ToString(), "Result", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckValue();
            ShowRound();

        }
    }
}
