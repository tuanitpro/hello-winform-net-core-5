using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int AutoStopSecond { get; set; } = 0;
        public int TypeOfNumber { get; set; } = 1; // 2 so
        public string ExcelFile { get; set; } = @"Resources\data.xlsx";

        private int SpinReel_1;
        private int SpinReel_2;
        private int SpinReel_3;
        private int SpinReel_4;
        private int SpinReel_5;
        private int SpinReel_6;
        private string number1 = "0";
        private string number2 = "0";
        private string number3 = "0";
        private string number4 = "0";
        private string number5 = "0";
        private string number6 = "0";
        private string numberFinish = "000000";
        private SoundPlayer playerStart;
        private SoundPlayer playerStop;
        private List<Player> players;
        private IPlayerService playerService = new PlayerService();

        private void Form1_Load(object sender, EventArgs e)
        {
            players = playerService.ListPlayer(ExcelFile);
            lblWinner.Text = "Bắt đầu tìm người thắng cuộc";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string sPathSound = AppDomain.CurrentDomain.BaseDirectory + @"Resources\play.wav";
            playerStart = new SoundPlayer(sPathSound);
            playerStart.PlayLooping();
            timer1.Start();
            lblWinner.Text = "Đang tìm người thắng cuộc....";
            lblWinnerName.Text = "";
            btnStop.Enabled = true;
            btnStart.Enabled = false;

            number1 = number2 = number3 = number4 = number5 = number6 = "0";
            SetText();

            if (AutoStopSecond > 0)
            {
                timer2.Interval = AutoStopSecond * 1000;
                timer2.Enabled = true;
                timer2.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (playerStart != null) playerStart.Stop();

            string sPathSound = AppDomain.CurrentDomain.BaseDirectory + @"Resources\stop.wav";
            playerStop = new SoundPlayer(sPathSound);
            playerStop.Play();
            timer1.Enabled = false;
            timer2.Enabled = false;

            btnStop.Enabled = false;
            btnStart.Enabled = true;

            FindWinner(numberFinish);
        }

        private void FindWinner(string number)
        {
            var player = players.Find(x => x.Number.Contains(number));
            if (player != null)
            {
                if (player.Win == 1)
                {
                    lblWinner.Text = "Người chơi " + number + " đã trúng rồi :)";
                    lblWinnerName.Text = player.Name;
                }
                else
                {
                    lblWinner.Text = "Chúc mừng người thắng cuộc: " + numberFinish;
                    lblWinnerName.Text = player.Name;
                    player.Win = 1;
                    player.Name = number + ": " + player.Name;
                }
            }
            else
            {
                lblWinner.Text = "Chưa tìm thấy người thắng cuộc.";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            switch (TypeOfNumber)
            {
                case 0:
                    SpinReel_6 = r.Next(5000, 5999) % 10;
                    number6 = SpinReel_6.ToString();
                    break;

                case 1:
                    SpinReel_5 = r.Next(1000, 4999) % 10;
                    number5 = SpinReel_5.ToString();

                    SpinReel_6 = r.Next(5000, 5999) % 10;
                    number6 = SpinReel_6.ToString();
                    break;

                case 2:
                    SpinReel_4 = r.Next(500, 999) % 10;
                    number4 = SpinReel_4.ToString();
                    SpinReel_5 = r.Next(1000, 4999) % 10;
                    number5 = SpinReel_5.ToString();

                    SpinReel_6 = r.Next(5000, 5999) % 10;
                    number6 = SpinReel_6.ToString();
                    break;

                case 3:
                    SpinReel_3 = r.Next(100, 499) % 10;
                    number3 = SpinReel_3.ToString();
                    SpinReel_4 = r.Next(500, 999) % 10;
                    number4 = SpinReel_4.ToString();
                    SpinReel_5 = r.Next(1000, 4999) % 10;
                    number5 = SpinReel_5.ToString();

                    SpinReel_6 = r.Next(5000, 5999) % 10;
                    number6 = SpinReel_6.ToString();
                    break;

                case 4:
                    SpinReel_2 = r.Next(0, 99) % 10;
                    number2 = SpinReel_2.ToString();
                    SpinReel_3 = r.Next(100, 499) % 10;
                    number3 = SpinReel_3.ToString();
                    SpinReel_4 = r.Next(500, 999) % 10;
                    number4 = SpinReel_4.ToString();
                    SpinReel_5 = r.Next(1000, 4999) % 10;
                    number5 = SpinReel_5.ToString();

                    SpinReel_6 = r.Next(5000, 5999) % 10;
                    number6 = SpinReel_6.ToString();
                    break;

                default:
                    SpinReel_1 = r.Next(0, 10);
                    number1 = SpinReel_1.ToString();
                    SpinReel_2 = r.Next(0, 99) % 10;
                    number2 = SpinReel_2.ToString();
                    SpinReel_3 = r.Next(100, 499) % 10;
                    number3 = SpinReel_3.ToString();
                    SpinReel_4 = r.Next(500, 999) % 10;
                    number4 = SpinReel_4.ToString();
                    SpinReel_5 = r.Next(1000, 4999) % 10;
                    number5 = SpinReel_5.ToString();

                    SpinReel_6 = r.Next(5000, 5999) % 10;
                    number6 = SpinReel_6.ToString();

                    break;
            }
            SetText();
        }

        private void SetText()
        {
            lblSo1.Text = number1;
            lblSo2.Text = number2;
            lblSo3.Text = number3;
            lblSo4.Text = number4;
            lblSo5.Text = number5;
            lblSo6.Text = number6;

            numberFinish = $"{number1}{number2}{number3}{number4}{number5}{number6}";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btnStop.PerformClick();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Tác giả: Lê Thanh Tuấn \nMobile: 0976060432\nWebsite:https://tuanitpro.com";
            MessageBox.Show(text, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmOption(this);
            if (f.ShowDialog() == DialogResult.OK)
            {
                number1 = number2 = number3 = number4 = number5 = number6 = "0";
                SetText();

                players = playerService.ListPlayer(ExcelFile);
                MessageBox.Show("Cài đặt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void danhsachTrungthuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var playersWin = players.FindAll(x => x.Win > 0);
            if (playersWin.Count == 0)
            {
                MessageBox.Show("Chưa có người trúng giải", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in playersWin)
                {
                    s.AppendLine(item.Name);
                }
                MessageBox.Show(s.ToString(), "Danh sách Trúng thưởng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}