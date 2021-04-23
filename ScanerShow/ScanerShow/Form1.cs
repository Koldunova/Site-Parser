using ScanerShow.db;
using ScanerShow.xml;
using ScannerSite.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScanerShow
{
    public partial class Form1 : Form
    {
        private List<Game> games;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetListGames();
            SetListGamesFromXML();
        }

        private void SetListGames()
        {
            games = DBReader.SelectAllGames();
        }

        private void SetListGamesFromXML() {
            List<Game> gamesXML = MyXMLReader.readXMLConfig();

            xmlGames.Items.Clear();
            selectGames1.Items.Clear();

            foreach (Game game in gamesXML)
            {
                selectGames1.Items.Add(game.Name);
                xmlGames.Items.Add(game.Name);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!existGameInXMLOrNo(xmlGames.Text))
            {

                MessageBox.Show("Такая игра не существует", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                MyXMLWriter.DeleteGame(xmlGames.Text);

                SetListGames();
                SetListGamesFromXML();

                xmlGames.Text = "";
                MessageBox.Show("Операция выполнена", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //todo save

            if (existGameInXMLOrNo(newGame.Text))
            {
                MessageBox.Show("Такая игра уже существует","Внимание",MessageBoxButtons.OK);
            }
            else {
                MyXMLWriter.WriteNewGame(newGame.Text);

                SetListGames();
                SetListGamesFromXML();
                newGame.Clear();
                MessageBox.Show("Операция выполнена", "Внимание", MessageBoxButtons.OK);
            }

        }

        private bool existGameInXMLOrNo(string newGame) {
            List<Game> gamesXML = MyXMLReader.readXMLConfig();

            foreach (Game game in gamesXML) {
                if (game.Name.Equals(newGame)) {
                    return true;
                }
            }
            return false;

        }

        private void newGame_TextChanged(object sender, EventArgs e)
        {

        }

        private Graphics drawLinesGraph(Graphics g)
        {
            Pen pen = new Pen(Color.White, 1);

            for (int i = pbGraph.Height; i > 0; i -= 20) {                    
                g.DrawLine(pen, new Point(0, i), new Point(pbGraph.Width, i));
            }

            return g;
        }

        private void drawGraph(List<Game> costs) {
            Graphics g = pbGraph.CreateGraphics();
            g.Clear(Color.DarkGray);

            Pen pen = new Pen(Color.Black, 3);

            g=drawLinesGraph(g);

            double del = 1;
            double maxCost = 0.0;

            foreach (Game game in costs) {
                if (game.Cost > maxCost) {
                    maxCost = game.Cost;
                }
            }

            if (maxCost < pbGraph.Height/10) { del = 0.1; }

            while (maxCost > pbGraph.Height) {
                del *= 10;
                maxCost /= del;       
            }

            double interval = pbGraph.Width / (costs.Count()-1);
            double y ;
            double x = -interval;

            List<Point> points = new List<Point>();

            for (int i = 0; i < costs.Count; i++) {
                if (costs[i].Cost < 0)
                {
                    y = pbGraph.Height;
                }
                else
                {
                    y = pbGraph.Height - costs[i].Cost / del;
                }

                if (i == costs.Count - 1)
                {
                    x = pbGraph.Width;
                }
                else
                {
                    x += interval;
                }

                points.Add(new Point((int)x, (int)y));
            }



            for (int i = 0; i < costs.Count - 1; i++) {
                g.DrawLine(pen,points[i], points[i+1]);
            }

            pen.Dispose();

        }

        private void selectGames1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetListGames();
            tableCost.Rows.Clear();

            List<Game> costs = findCostsSelectedGame();
            foreach (Game game in costs) {
                string costPrep = "";
                if (game.Cost == -1) {
                    costPrep = "Бесплатно";
                } else {
                    if (game.Cost == -2)
                    {
                        costPrep = "Нет данных";
                    }
                    else {
                        costPrep = game.Cost.ToString();
                    }
                }
                
                tableCost.Rows.Add(game.Date, costPrep);
            }

            drawGraph(costs);
        }

        private List<Game> findCostsSelectedGame() {

            List<Game> findCosts = new List<Game>();

            foreach (Game game in games)
            { 
                if (game.Name.Equals(selectGames1.Text))
                {
                    findCosts.Add(game);
                }
            }

            return findCosts;
        }

        private void tableCost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void удалитьДанныеОбИгреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectGames1.Text.Length < 0) {
                MessageBox.Show("Выберите игру");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить данные игры?", "Внимание", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                foreach (Game game in games)
                {
                    if (game.Name.Equals(selectGames1.Text))
                    {
                        Form2 form2 = new Form2(2, game, games);
                        form2.Show();
                        break;
                    }
                }
            }
        }

        private void самаяДешоваяИСамаяДорогаяИграНаДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(1, null, games);
            form2.Show();
        }

        private void средняяЦенаИгрыЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectGames1.Text.Length < 0)
            {
                MessageBox.Show("Выберите игру");
                return;
            }

            foreach (Game game in games)
            {
                if (game.Name.Equals(selectGames1.Text))
                {
                    Form2 form2 = new Form2(3, game, games);
                    form2.Show();
                }
            }
            
        }

        private void игрыВДиапазонеЦенНаДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(4, null, games);
            form2.Show();
        }

        private void списокИгрПоДатеВыходаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(5, null, games);
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //фильтер
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            DBImport.importData(filename, selectGames1.Text);
            SetListGames();
            selectGames1_SelectedIndexChanged(null, null);
        }
    }
}
