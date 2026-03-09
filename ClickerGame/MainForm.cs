using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClickerGame
{
    public class MainForm : Form
    {
        private int score = 0;

        private Label lblTitle;
        private Label lblAuthor;
        private Label lblScore;
        private Label lblCharacter;
        private Button btnClick;
        private Button btnReset;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Text = "Игра Кликер - Версия 1";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(500, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;

            lblTitle = new Label();
            lblTitle.Text = "Игра Кликер";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(170, 20);

            lblAuthor = new Label();
            lblAuthor.Text = "Автор: Контакова С.Ю.";
            lblAuthor.Font = new Font("Arial", 10, FontStyle.Regular);
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(170, 60);

            lblScore = new Label();
            lblScore.Text = "Очки: 0";
            lblScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblScore.AutoSize = true;
            lblScore.Location = new Point(190, 100);

            lblCharacter = new Label();
            lblCharacter.Text = "🙂";
            lblCharacter.Font = new Font("Segoe UI Emoji", 60, FontStyle.Regular);
            lblCharacter.AutoSize = true;
            lblCharacter.Location = new Point(155, 125);

            btnClick = new Button();
            btnClick.Text = "КЛИК!";
            btnClick.Font = new Font("Arial", 14, FontStyle.Bold);
            btnClick.Size = new Size(150, 50);
            btnClick.Location = new Point(165, 260);
            btnClick.BackColor = Color.LightGreen;
            btnClick.Click += BtnClick_Click;

            btnReset = new Button();
            btnReset.Text = "Сброс";
            btnReset.Font = new Font("Arial", 12, FontStyle.Regular);
            btnReset.Size = new Size(150, 40);
            btnReset.Location = new Point(165, 325);
            btnReset.BackColor = Color.LightCoral;
            btnReset.Click += BtnReset_Click;

            Controls.Add(lblTitle);
            Controls.Add(lblAuthor);
            Controls.Add(lblScore);
            Controls.Add(lblCharacter);
            Controls.Add(btnClick);
            Controls.Add(btnReset);
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            score++;
            lblScore.Text = "Очки: " + score;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            ClientSize = new Size(677, 633);
            Name = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = "Очки: 0";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
