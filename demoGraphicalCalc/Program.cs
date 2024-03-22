using DocumentFormat.OpenXml.Vml;
using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CryptoCurrencyCalculator
{
    public class GUI : Form
    {
        private TextBox initialValueTextBox;
        private TextBox annualInterestRateTextBox;
        private TextBox numberOfDaysTextBox;
        private Button calculateButton;
        private Label resultLabel;

        public GUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.initialValueTextBox = new TextBox();
            this.annualInterestRateTextBox = new TextBox();
            this.numberOfDaysTextBox = new TextBox();
            this.calculateButton = new Button();
            this.resultLabel = new Label();
            this.SuspendLayout();
            // 
            // initialValueTextBox
            // 
            this.initialValueTextBox.Location = new System.Drawing.Point(50, 50);
            this.initialValueTextBox.Name = "initialValueTextBox";
            this.initialValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.initialValueTextBox.TabIndex = 0;
            // 
            // annualInterestRateTextBox
            // 
            this.annualInterestRateTextBox.Location = new System.Drawing.Point(50, 80);
            this.annualInterestRateTextBox.Name = "annualInterestRateTextBox";
            this.annualInterestRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.annualInterestRateTextBox.TabIndex = 1;
            // 
            // numberOfDaysTextBox
            // 
            this.numberOfDaysTextBox.Location = new System.Drawing.Point(50, 110);
            this.numberOfDaysTextBox.Name = "numberOfDaysTextBox";
            this.numberOfDaysTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberOfDaysTextBox.TabIndex = 2;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(50, 140);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(50, 180);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 4;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.numberOfDaysTextBox);
            this.Controls.Add(this.annualInterestRateTextBox);
            this.Controls.Add(this.initialValueTextBox);
            this.Name = "GUI";
            this.Text = "Crypto Currency Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            double initialValue = double.Parse(initialValueTextBox.Text);
            double annualInterestRate = double.Parse(annualInterestRateTextBox.Text);
            int numberOfDays = int.Parse(numberOfDaysTextBox.Text);

            Core.CryptoCurrencyCalculator calculator = new Core.CryptoCurrencyCalculator(initialValue, annualInterestRate);
            calculator.CalculateInterestForDays(numberOfDays);
            double futureValue = calculator.CalculateFutureValue(numberOfDays, 0); // Assuming no regular deposit for simplicity

            resultLabel.Text = $"Future value after {numberOfDays} days: {futureValue:f2}";
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());
        }
    }
}
