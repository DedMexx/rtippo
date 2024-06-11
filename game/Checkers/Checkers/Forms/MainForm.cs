using Checkers.Classes.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class MainForm : Form
    {
        Game game;
        public MainForm(string Name1, string Name2)
        {
            InitializeComponent();
            Drawer drawer = new Drawer(tableLayoutPanel1, this);
            this.game = new Game(drawer, this);

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Panel panel = new Panel();
                    panel.Margin = new Padding(1);
                    panel.Width = 55;
                    panel.Height = 55;
                    panel.BackColor = Color.Transparent;
                    this.tableLayoutPanel1.Controls.Add(panel, col, row);
                }
            }

            game.CreatePlayer(Name1);
            game.CreatePlayer(Name2);

            label1.Text = "Игрок: " + game.Players.First().Name;
            label2.Text = "Игрок: " + game.Players[1].Name;
            drawer.DrawCurrentPlayerName(game.Players.First());
            game.CurrentPlayer = game.Players.First();
        }

        private void GiveUpTop_Click(object sender, EventArgs e)
        {
            game.Players[0].GiveUp();

        }

        private void GiveUpBottom_Click(object sender, EventArgs e)
        {
            game.Players[1].GiveUp();
        }
    }
}
