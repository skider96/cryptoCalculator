using System;
using System.Windows.Forms;
using CryptoCurrencyCalculator;

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
            initialValueTextBox = new TextBox();
            annualInterestRateTextBox = new TextBox();
            numberOfDaysTextBox = new TextBox();
            calculateButton = new Button();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // initialValueTextBox
            // 
            initialValueTextBox.Location = new Point(58, 58);
            initialValueTextBox.Margin = new Padding(4, 3, 4, 3);
            initialValueTextBox.Name = "initialValueTextBox";
            initialValueTextBox.Size = new Size(116, 23);
            initialValueTextBox.TabIndex = 0;
            initialValueTextBox.TextChanged += initialValueTextBox_TextChanged;
            // 
            // annualInterestRateTextBox
            // 
            annualInterestRateTextBox.Location = new Point(58, 92);
            annualInterestRateTextBox.Margin = new Padding(4, 3, 4, 3);
            annualInterestRateTextBox.Name = "annualInterestRateTextBox";
            annualInterestRateTextBox.Size = new Size(116, 23);
            annualInterestRateTextBox.TabIndex = 1;
          
            //text to be added as a description*
            //  annualInterestRateTextBox. = "Write annual interest rate:";
            // 
            // numberOfDaysTextBox
            // 
            numberOfDaysTextBox.Location = new Point(58, 127);
            numberOfDaysTextBox.Margin = new Padding(4, 3, 4, 3);
            numberOfDaysTextBox.Name = "numberOfDaysTextBox";
            numberOfDaysTextBox.Size = new Size(116, 23);
            numberOfDaysTextBox.TabIndex = 2;
            numberOfDaysTextBox.Text = "Write number of days:";
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(58, 162);
            calculateButton.Margin = new Padding(4, 3, 4, 3);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(88, 27);
            calculateButton.TabIndex = 3;
            calculateButton.Text = "Calculate";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += CalculateButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(58, 208);
            resultLabel.Margin = new Padding(4, 0, 4, 0);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(0, 15);
            resultLabel.TabIndex = 4;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 288);
            Controls.Add(resultLabel);
            Controls.Add(calculateButton);
            Controls.Add(numberOfDaysTextBox);
            Controls.Add(annualInterestRateTextBox);
            Controls.Add(initialValueTextBox);
            Margin = new Padding(4, 3, 4, 3);
            Name = "GUI";
            Text = "Crypto Currency Calculator";
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

        private void initialValueTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
