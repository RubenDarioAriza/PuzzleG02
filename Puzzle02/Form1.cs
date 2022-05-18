using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int movesNumber =0, labelIndex=0;   
        
        private void Shufflebuttons()
        {
            List<int> labelList = new List<int>();

            Random rand = new Random();
            foreach (Button btn in this.button1.Controls)
            {
                while (labelList.Contains(labelIndex))
                {
                    labelIndex = rand.Next(16);

                    btn.Text = (labelIndex == 0) ? "" : labelIndex + "";
                    btn.BackColor = (btn.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLightLight);
                    labelList.Add(labelIndex);
                }
                    
            }
            movesNumber = 0;
            lblNoOfMoves.Text = "Numero de Movimientos: " + movesNumber;
        }
        private void swapLabel(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == " ")
                return;

            Button WhiteBtn = null;
            foreach (Button bt in this.button1.Controls)
            {
                if (btn.Text == " ")
                {
                    WhiteBtn = bt;
                    break;
                }
            }
            if (btn.TabIndex == (WhiteBtn.TabIndex - 1) ||
                btn.TabIndex == (WhiteBtn.TabIndex - 4) ||
                btn.TabIndex == (WhiteBtn.TabIndex + 1) ||
                btn.TabIndex == (WhiteBtn.TabIndex + 4))
            {
                WhiteBtn.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
                btn.BackColor = Color.White;
                WhiteBtn.Text = btn.Text;
                btn.Text = "";
                movesNumber++;
                lblNoOfMoves.Text = "Numero de Movimientos: " + movesNumber;
            }

            checkOrder();

        }

        private void checkOrder()
        {
            int index = 0;
            foreach (Button btn in this.button1.Controls)
            {
                if(btn.Text != "" && Convert.ToInt16(btn.Text)!= index)
                {
                    return;
                }
                index++;
            }
            MessageBox.Show("Felizidades ! Lo hiciste en " + movesNumber + "Movimientos");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Shufflebuttons();
        }
    }
}
