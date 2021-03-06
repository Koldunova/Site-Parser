using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanerShow.db
{
    public partial class Form2 : Form
    {

        private int num_operation = 0;
        private Game game;
        private List<Game> games;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int num, Game game, List<Game> games)
        {
            InitializeComponent();
            num_operation = num;
            this.game = game;
            this.games = games;
            if (num == 4) {
                groupBox1.Visible = true;
                label2.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1-самая дорогая и дешевая игра
            //2-удалить данные об игре
            //3-средня цена игы за период
            //4-игры в диапазоне цен на дату
            //5-список игр по дате выхода

            if (num_operation == 1) {
                string mes = DBReader.findGameWithMinCost(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString()) + ". " +
                    DBReader.findGameWithMaxCost(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
                MessageBox.Show(mes);
            }

            if (num_operation == 2) {
                DBWriter.deleteCostsIfGame(game,dateTimePicker1.Value.ToString(),dateTimePicker2.Value.ToString());
                
                MessageBox.Show("Данные удалены. Игра: " + game.Name);
            }

            if (num_operation == 3) { 
                String mes = DBReader.findGameWithAvgCost(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(),game);
                MessageBox.Show(mes);
            }

            if (num_operation == 4) {

                String mes = DBReader.findGamesInDiap(dateTimePicker1.Value.ToString(), textBox1.Text, textBox2.Text);
                MessageBox.Show(mes);
            }

            if (num_operation == 5) {
                String mes = DBReader.getOrderListGames();
                MessageBox.Show(mes);
            }
        }
    }
}
