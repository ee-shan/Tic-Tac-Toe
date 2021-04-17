using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whiteboard_Windows_Form
{
    public partial class Form1 : Form
    {
        /*
            X => turn is false
            O => turn is true
        */

        bool turn = true;
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn) b.Text = "X";
            else b.Text = "O";

            turn = !turn;
            b.Enabled = false;

            turn_count++;

            win_checker();
        }

        private void win_checker()
        {
            bool finished = false;

            if ((b00.Text == b01.Text) && (b01.Text == b02.Text) && (!b00.Enabled))
                finished = true;
            else if ((b10.Text == b11.Text) && (b11.Text == b12.Text) && (!b10.Enabled))
                finished = true;
            else if ((b20.Text == b21.Text) && (b21.Text == b22.Text) && (!b20.Enabled))
                finished = true;
            else if ((b00.Text == b10.Text) && (b10.Text == b20.Text) && (!b00.Enabled))
                finished = true;
            else if ((b01.Text == b11.Text) && (b11.Text == b21.Text) && (!b01.Enabled))
                finished = true;
            else if ((b02.Text == b12.Text) && (b12.Text == b22.Text) && (!b02.Enabled))
                finished = true;
            else if ((b00.Text == b11.Text) && (b11.Text == b22.Text) && (!b00.Enabled))
                finished = true;
            else if ((b02.Text == b11.Text) && (b11.Text == b20.Text) && (!b20.Enabled))
                finished = true;

            if (finished)
            {
                disable_button();

                string winner = "";

                if (turn) winner = playerO.Text;
                else winner = playerX.Text;

                result.Text = winner + " Won!";
            }
            else
            {
                if (turn_count == 9)
                    result.Text = "Game Drawn...";
            }
        }

        private void disable_button()
        {
            try
            {
                foreach (Control control in Controls)
                {
                    if (control is Button)
                    {
                        Button b = (Button)control;

                        if (b != btn_exit && b != btn_restart)
                            b.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            result.Text = "Game is Running...";

            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        Button b = (Button)c;
                        b.Enabled = true;

                        if (b != btn_exit && b != btn_restart)
                            b.Text = "";
                    }
                }
            }
            catch { }
        }
    }
}
