using System;
using System.Drawing;
using System.Windows.Forms;
using CryptoCurrencyCalculator.Core;

namespace CryptoCurrencyCalculator
{
    public class GUI : Form
    {
        private TextBox initialValueTextBox;
        private TextBox annualInterestRateTextBox;
        private TextBox numberOfDaysTextBox;
        private Button calculateButton;
        private Label resultLabel;
        private CheckBox saveToFileCheckBox;
        private TextBox filePathTextBox;
        private Button browseButton;
        private TextBox cryptoNameTextBox; // Ново текстово поле за въвеждане на името на криптовалутата


        public GUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            cryptoNameTextBox = new TextBox(); // Инициализация на новото текстово поле
            cryptoNameTextBox.Location = new Point(50, 140);
            cryptoNameTextBox.Size = new Size(200, 20);
            cryptoNameTextBox.TabIndex = 8;
            cryptoNameTextBox.Text = "Enter Crypto Name"; // Съобщение за потребителя
            Controls.Add(cryptoNameTextBox); // Добавяне на текстовото поле към контролите на формата

            // Останалата част от кода за създаване на контролите
            initialValueTextBox = new TextBox();
            initialValueTextBox.Location = new Point(50, 50);
            initialValueTextBox.Size = new Size(200, 20);
            initialValueTextBox.TabIndex = 0;
            initialValueTextBox.Text = "Enter Initial Deposit";

            annualInterestRateTextBox = new TextBox();
            annualInterestRateTextBox.Location = new Point(50, 80);
            annualInterestRateTextBox.Size = new Size(200, 20);
            annualInterestRateTextBox.TabIndex = 1;
            annualInterestRateTextBox.Text = "Enter Annual Interest Rate (%)";

            numberOfDaysTextBox = new TextBox();
            numberOfDaysTextBox.Location = new Point(50, 110);
            numberOfDaysTextBox.Size = new Size(200, 20);
            numberOfDaysTextBox.TabIndex = 2;
            numberOfDaysTextBox.Text = "Enter Number of Days";

            calculateButton = new Button();
            calculateButton.Location = new Point(161, 160);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(75, 23);
            calculateButton.TabIndex = 3;
            calculateButton.Text = "Calculate";
            calculateButton.Click += CalculateButton_Click;

            resultLabel = new Label();
            resultLabel.Location = new Point(50, 200);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(200, 23);
            resultLabel.TabIndex = 4;

            saveToFileCheckBox = new CheckBox();
            saveToFileCheckBox.Location = new Point(50, 230);
            saveToFileCheckBox.Name = "saveToFileCheckBox";
            saveToFileCheckBox.Size = new Size(200, 23);
            saveToFileCheckBox.TabIndex = 5;
            saveToFileCheckBox.Text = "Save to File";

            filePathTextBox = new TextBox();
            filePathTextBox.Location = new Point(50, 260);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(200, 23);
            filePathTextBox.TabIndex = 6;
            filePathTextBox.Text = "Enter File Path";

            browseButton = new Button();
            browseButton.Location = new Point(260, 260);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 23);
            browseButton.TabIndex = 7;
            browseButton.Text = "Browse";
            browseButton.Click += BrowseButton_Click;

            ClientSize = new Size(400, 300);
            Controls.Add(initialValueTextBox);
            Controls.Add(annualInterestRateTextBox);
            Controls.Add(numberOfDaysTextBox);
            Controls.Add(calculateButton);
            Controls.Add(resultLabel);
            Controls.Add(saveToFileCheckBox);
            Controls.Add(filePathTextBox);
            Controls.Add(browseButton);
            Name = "GUI";
            Load += GUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            double initialValue = double.Parse(initialValueTextBox.Text);
            double annualInterestRate = double.Parse(annualInterestRateTextBox.Text);
            int numberOfDays = int.Parse(numberOfDaysTextBox.Text);

            Core.CryptoCurrencyCalculator calculator = new Core.CryptoCurrencyCalculator(initialValue, annualInterestRate);
            calculator.CalculateInterestForDays(numberOfDays);
            double futureValue = calculator.CalculateFutureValue(numberOfDays, 0);

            resultLabel.Text = $"Future value after {numberOfDays} days: {futureValue:f2}";

            if (saveToFileCheckBox.Checked)
            {
                string filePath = filePathTextBox.Text;
                // Implement the logic to save to file here
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }
    }
}
