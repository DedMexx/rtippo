using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Checkers.Classes.Game.Enums;

namespace Checkers.Classes.Game
{
    public class Drawer
    {
        private readonly TableLayoutPanel tableLayoutPanel;
        private readonly Form form;
        public Drawer(TableLayoutPanel tableLayoutPanel, Form form)
        {
            this.tableLayoutPanel = tableLayoutPanel;
            this.form = form;
        }

        public void DrawChecker(Checker checker, Game game)
        {
            Coordinate coordinate = checker.Coordinate;
            PictureBox checkerPictureBox = new PictureBox();
            var control = GetPanelFromPosition(coordinate.X, coordinate.Y);

            checkerPictureBox.Width = 50;
            checkerPictureBox.Height = 50;
            checkerPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            checkerPictureBox.BackColor = System.Drawing.Color.Transparent;
            checkerPictureBox.Margin = new Padding(0);
            checkerPictureBox.Tag = checker;
            checkerPictureBox.Click += (sender, e) =>
            {
                Checker checker1 = checkerPictureBox.Tag as Checker;
                var availableMoves = checker.AvailableMoves();
                if (availableMoves.Count > 0 && checker.Player.SelectedChecker == null && game.CurrentPlayer == checker.Player)
                {
                    checker.Player.SelectChecker(checker1);
                    var clicked = GetPanelFromPosition(coordinate.X, coordinate.Y);
                    if (control is Panel)
                    {
                        control.BackColor = Color.Yellow;
                    }
                    DrawAvailableMoves(checker, game);
                }
            };

            if (checker.Player.Side == SideType.White)
            {
                if(checker.Type == CheckerType.Regular)
                {
                    checkerPictureBox.Image = Properties.Resources.checker_white; 
                } else checkerPictureBox.Image = Properties.Resources.checker_white_lady;
            }
            else
            {
                if (checker.Type == CheckerType.Regular)
                {
                    checkerPictureBox.Image = Properties.Resources.checker_black; 
                }
                else checkerPictureBox.Image = Properties.Resources.checker_black_lady;
            }

            if (control is Panel)
            {
                control.Controls.Add(checkerPictureBox);
            }
        }

        public void DeleteChecker(Checker checker)
        {
            Coordinate coordinate = checker.Coordinate;
            var control = GetPanelFromPosition(coordinate.X, coordinate.Y);

            if (control is Panel)
            {
                control.Controls.Clear();
            }
        }

        private Control GetPanelFromPosition(int row, int col)
        {
            return tableLayoutPanel.GetControlFromPosition(row, col);
        }

        public void DrawAvailableMoves(Checker checker, Game game)
        {
            foreach (Coordinate finalCoordinate in checker.AvailableMoves())
            {
                var control = GetPanelFromPosition(finalCoordinate.X, finalCoordinate.Y);
                if (control is Panel)
                {
                    control.BackColor = Color.Yellow;

                    control.Click += (sender, e) =>
                    {
                        if (game.CurrentPlayer.SelectedChecker != null && !game.CurrentPlayer.SelectedChecker.Coordinate.Equals(finalCoordinate))
                        {
                            game.CurrentPlayer.MakeMove(new Move(this, game.CurrentPlayer.SelectedChecker, finalCoordinate, game.Checkers));
                        }
                    };
                }
            }
        }

        public void ClearSelect()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var panel = GetPanelFromPosition(i, j);
                    if (panel is Panel)
                    {
                        panel.BackColor = Color.Transparent;
                    }
                }
            }
        }

        public void SelectChecker(Checker checker)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var panel = GetPanelFromPosition(i, j);
                    if (panel is Panel && i == checker.Coordinate.X && j == checker.Coordinate.Y)
                    {
                        panel.BackColor = Color.Yellow;
                    }
                }
            }
        }

        public void DrawCurrentPlayerName(Player player)
        {
            Control label = form.Controls.Find("CurrentPlayer", false)[0];
            if (label is Label)
            {
                label.Text = "Сейчас ходит: " + player.Name;
            }
        }

        public void MakeLady(Checker checker)
        {
            var panel = GetPanelFromPosition(checker.Coordinate.X, checker.Coordinate.Y);
            if (panel is Panel)
            {
                var control = panel.Controls[0];
                if (control is PictureBox)
                {
                    PictureBox pb = (PictureBox)control;
                    Checker ch = pb.Tag as Checker;
                    if (ch.Player.Side == SideType.Black)
                    {
                        pb.Image = Properties.Resources.checker_black_lady;
                    }
                    if (ch.Player.Side == SideType.White)
                    {
                        pb.Image = Properties.Resources.checker_white_lady;
                    }
                }
            }
        }
    }
}
