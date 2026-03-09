using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClickerGame
{
    public class MainForm : Form
    {
        private int score = 0;
        private int clickPower = 1;
        private int multiplierLevel = 0;
        private int autoClickLevel = 0;
        private int boosterCostMultiplier = 20;
        private int boosterCostAuto = 30;
        private string currentCharacter = "🙂";

        private Label lblTitle;
        private Label lblAuthor;
        private Label lblScore;
        private Label lblCharacter;
        private Label lblClickPower;
        private Label lblAutoClick;
        private Label lblStatus;

        private Button btnClick;
        private Button btnReset;
        private Button btnBuyMultiplier;
        private Button btnBuyAutoClick;
        private Button btnSave;

        private ComboBox cmbCharacter;
        private System.Windows.Forms.Timer autoClickTimer;

        private readonly string saveFilePath = "save.txt";

        public MainForm()
        {
            InitializeComponents();
            LoadGame();
        }

        private void InitializeComponents()
        {
            Text = "Игра Кликер - Версия 2";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(700, 520);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;

            lblTitle = new Label();
            lblTitle.Text = "Игра Кликер";
            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(250, 20);

            lblAuthor = new Label();
            lblAuthor.Text = "Автор: ВАШЕ ФИО";
            lblAuthor.Font = new Font("Arial", 10, FontStyle.Regular);
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(275, 60);

            lblScore = new Label();
            lblScore.Text = "Очки: 0";
            lblScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblScore.AutoSize = true;
            lblScore.Location = new Point(290, 100);

            lblCharacter = new Label();
            lblCharacter.Text = "🙂";
            lblCharacter.Font = new Font("Segoe UI Emoji", 50, FontStyle.Regular);
            lblCharacter.AutoSize = true;
            lblCharacter.Location = new Point(285, 135);

            btnClick = new Button();
            btnClick.Text = "КЛИК!";
            btnClick.Font = new Font("Arial", 14, FontStyle.Bold);
            btnClick.Size = new Size(150, 50);
            btnClick.Location = new Point(275, 250);
            btnClick.BackColor = Color.LightGreen;
            btnClick.Click += BtnClick_Click;

            btnReset = new Button();
            btnReset.Text = "Сброс";
            btnReset.Font = new Font("Arial", 11, FontStyle.Regular);
            btnReset.Size = new Size(150, 35);
            btnReset.Location = new Point(275, 315);
            btnReset.BackColor = Color.LightCoral;
            btnReset.Click += BtnReset_Click;

            Label lblCharacterChoose = new Label();
            lblCharacterChoose.Text = "Выбор персонажа:";
            lblCharacterChoose.Font = new Font("Arial", 11, FontStyle.Regular);
            lblCharacterChoose.AutoSize = true;
            lblCharacterChoose.Location = new Point(30, 40);

            cmbCharacter = new ComboBox();
            cmbCharacter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCharacter.Items.Add("🙂");
            cmbCharacter.Items.Add("😺");
            cmbCharacter.Items.Add("🤖");
            cmbCharacter.Items.Add("👾");
            cmbCharacter.Items.Add("🐸");
            cmbCharacter.SelectedIndex = 0;
            cmbCharacter.Font = new Font("Arial", 12, FontStyle.Regular);
            cmbCharacter.Size = new Size(120, 30);
            cmbCharacter.Location = new Point(30, 70);
            cmbCharacter.SelectedIndexChanged += CmbCharacter_SelectedIndexChanged;

            lblClickPower = new Label();
            lblClickPower.
            Text = "Сила клика: 1";
            lblClickPower.Font = new Font("Arial", 12, FontStyle.Bold);
            lblClickPower.AutoSize = true;
            lblClickPower.Location = new Point(30, 130);

            lblAutoClick = new Label();
            lblAutoClick.Text = "Автоклик: 0";
            lblAutoClick.Font = new Font("Arial", 12, FontStyle.Bold);
            lblAutoClick.AutoSize = true;
            lblAutoClick.Location = new Point(30, 160);

            btnBuyMultiplier = new Button();
            btnBuyMultiplier.Text = "Бустер x2 (20)";
            btnBuyMultiplier.Font = new Font("Arial", 11, FontStyle.Regular);
            btnBuyMultiplier.Size = new Size(180, 45);
            btnBuyMultiplier.Location = new Point(30, 210);
            btnBuyMultiplier.BackColor = Color.LightBlue;
            btnBuyMultiplier.Click += BtnBuyMultiplier_Click;

            btnBuyAutoClick = new Button();
            btnBuyAutoClick.Text = "Автоклик (30)";
            btnBuyAutoClick.Font = new Font("Arial", 11, FontStyle.Regular);
            btnBuyAutoClick.Size = new Size(180, 45);
            btnBuyAutoClick.Location = new Point(30, 270);
            btnBuyAutoClick.BackColor = Color.Khaki;
            btnBuyAutoClick.Click += BtnBuyAutoClick_Click;

            btnSave = new Button();
            btnSave.Text = "Сохранить";
            btnSave.Font = new Font("Arial", 11, FontStyle.Regular);
            btnSave.Size = new Size(180, 40);
            btnSave.Location = new Point(30, 330);
            btnSave.BackColor = Color.Plum;
            btnSave.Click += BtnSave_Click;

            lblStatus = new Label();
            lblStatus.Text = "Статус: игра загружена";
            lblStatus.Font = new Font("Arial", 10, FontStyle.Italic);
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 390);

            autoClickTimer = new System.Windows.Forms.Timer();
            autoClickTimer.Interval = 1000;
            autoClickTimer.Tick += AutoClickTimer_Tick;
            autoClickTimer.Start();

            Controls.Add(lblTitle);
            Controls.Add(lblAuthor);
            Controls.Add(lblScore);
            Controls.Add(lblCharacter);
            Controls.Add(btnClick);
            Controls.Add(btnReset);
            Controls.Add(lblCharacterChoose);
            Controls.Add(cmbCharacter);
            Controls.Add(lblClickPower);
            Controls.Add(lblAutoClick);
            Controls.Add(btnBuyMultiplier);
            Controls.Add(btnBuyAutoClick);
            Controls.Add(btnSave);
            Controls.Add(lblStatus);
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            score += clickPower;
            UpdateInterface();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            score = 0;
            clickPower = 1;
            multiplierLevel = 0;
            autoClickLevel = 0;
            boosterCostMultiplier = 20;
            boosterCostAuto = 30;
            currentCharacter = "🙂";
            cmbCharacter.SelectedItem = currentCharacter;
            UpdateInterface();
            lblStatus.Text = "Статус: игра сброшена";
        }

        private void BtnBuyMultiplier_Click(object sender, EventArgs e)
        {
            if (score >= boosterCostMultiplier)
            {
                score -= boosterCostMultiplier;
                multiplierLevel++;
                clickPower *= 2;
                boosterCostMultiplier += 20;
                UpdateInterface();
                lblStatus.Text = "Статус: куплен бустер x2";
            }
            else
            {
                MessageBox.Show("Недостаточно очков для покупки бустера x2.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnBuyAutoClick_Click(object sender, EventArgs e)
        {
            if (score >= boosterCostAuto)
            {
                score -= boosterCostAuto;
                autoClickLevel++;
                boosterCostAuto += 30;
                UpdateInterface();
                lblStatus.Text = "Статус: куплен автоклик";
            }
            else
            {
                MessageBox.Show("Недостаточно очков для покупки автоклика.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CmbCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCharacter = cmbCharacter.SelectedItem.ToString();
            lblCharacter.Text = currentCharacter;
            lblStatus.Text = "Статус: персонаж изменен";
        }

        private void AutoClickTimer_Tick(object sender, EventArgs e)
        {
            if (autoClickLevel > 0)
            {
                score += autoClickLevel;
                UpdateInterface();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveGame();
            lblStatus.Text = "Статус: прогресс сохранен";
        }

        private void UpdateInterface()
        {
            lblScore.Text = "Очки: " + score;
            lblClickPower.Text = "Сила клика: " + clickPower;
            lblAutoClick.Text = "Автоклик: " + autoClickLevel;
            lblCharacter.Text = currentCharacter;
            btnBuyMultiplier.Text = "Бустер x2 (" + boosterCostMultiplier + ")";
            btnBuyAutoClick.Text = "Автоклик (" + boosterCostAuto + ")";
        }

        private void SaveGame()
        {
            string[] lines =
            {
                score.ToString(),
                clickPower.ToString(),
                multiplierLevel.ToString(),
                autoClickLevel.ToString(),
                boosterCostMultiplier.ToString(),
                boosterCostAuto.ToString(),
                currentCharacter
            };

            File.WriteAllLines(saveFilePath, lines);
        }

        private void LoadGame()
        {
            if (File.Exists(saveFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(saveFilePath);

                    if (lines.Length >= 7)
                    {
                        score = int.Parse(lines[0]);
                        clickPower = int.Parse(lines[1]);
                        multiplierLevel = int.Parse(lines[2]);
                        autoClickLevel = int.Parse(lines[3]);
                        boosterCostMultiplier = int.Parse(lines[4]);
                        boosterCostAuto = int.Parse(lines[5]);
                        currentCharacter = lines[6];

                        cmbCharacter.SelectedItem = currentCharacter;
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить сохранение. Будут использованы стандартные значения.",
                        "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            UpdateInterface();
        }
    }
}