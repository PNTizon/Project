using System.Data;

namespace MyCalculator
{
    public partial class Calculator : Form
    {
        private string currentCalculation = "";
        private string firstNum = "0";
        private string operation = "";
        private double result = 0;

        public Calculator()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "Syntax Error")
            {
                return;
            }
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (currentCalculation.Length >= 13)
            {
                txtOutput.Text = "Input Too Long";
                SetButtonsEnabled(false);
                return;  
            }
            if (buttonText == "." && currentCalculation.Contains("."))
            {
                return;
            }
            if (buttonText == "." && string.IsNullOrEmpty(currentCalculation))
            {
                currentCalculation = "0";
            }
            currentCalculation += buttonText;
            txtOutput.Text = Comma_Dot_Click(currentCalculation);
        }
        private void operation_click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "Syntax Error")
            {
                return;
            }
            Button button = (Button)sender;
            string newOperation = button.Text;

            if (!string.IsNullOrEmpty(firstNum) && !string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(currentCalculation))
            {
                EqualSign.PerformClick(); 
                operation = newOperation;   
                txtOperationBox.Text = $"{firstNum} {operation}"; 
            }
            else if (!string.IsNullOrEmpty(txtOutput.Text) && txtOutput.Text != "0")
            {
                firstNum = txtOutput.Text;
                operation = newOperation;
                txtOperationBox.Text = $"{firstNum} {operation}";

                currentCalculation = "";
                txtOutput.Text = string.Empty;
            }
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "Syntax Error")
            {
                return;
            }

            if (string.IsNullOrEmpty(currentCalculation) || currentCalculation == "0")
            {
                txtOutput.Text = "ERROR";
                SetButtonsEnabled(false);
                return;
            }

            if (currentCalculation.Contains("."))
            {
                txtOutput.Text = "ERROR";
                SetButtonsEnabled(false);
                return;
            }

            txtOperationBox.Text = $"%({txtOutput.Text})";
            txtOutput.Text = Convert.ToString(Convert.ToDouble(txtOutput.Text) / Convert.ToDouble(100));
        }
        private void EqualSign_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "Syntax Error")
            {
                return;
            }
          else if (string.IsNullOrEmpty(currentCalculation) || string.IsNullOrEmpty(firstNum) || string.IsNullOrEmpty(operation))
            {
                txtOutput.Text = "ERROR";
                SetButtonsEnabled(false);
                return;
            }

            double firstNumber = Convert.ToDouble((firstNum));
            double secondNumber = Convert.ToDouble((currentCalculation));

            try
            {
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            txtOutput.Text = "Invalid!";
                            currentCalculation = "";
                            SetButtonsEnabled(false);
                            return;
                        }
                        result = firstNumber / secondNumber;
                        break;
                    default:
                        txtOutput.Text = "Syntax Error";
                        SetButtonsEnabled(false);
                        return;
                }
                result = firstNumber + secondNumber;
                txtOutput.Text = result.ToString("N0");  
                txtOperationBox.Text = $"{firstNumber} {operation} {secondNumber} = ";

                firstNum = result.ToString();
            }
            catch (Exception)
            {
                txtOutput.Text = "Syntax Error";
                currentCalculation = "";
                SetButtonsEnabled(false);
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
            txtOperationBox.Text = "";
            currentCalculation = "";
            firstNum = "";
            operation = "";
            result = 0;

            SetButtonsEnabled(true);
        }
        private void ClearEntry_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "Syntax Error")
            {
                return;  
            }
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            txtOutput.Text = currentCalculation;
        }
        private string Comma_Dot_Click(string input)
        {
            string cleanedInput = input.Replace(",", "");

            if (double.TryParse(cleanedInput, out double numericValue))
            {
                string[] parts = input.Split('.');

                string formattedNumber = $"{numericValue:n0}";

                return parts.Length > 1 ? formattedNumber + "." + parts[1] : formattedNumber;
            }
            return cleanedInput;
        }
        private void SetButtonsEnabled(bool isEnabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name != "ClearButton")
                {
                    button.Enabled = isEnabled;
                }
            }
        }
    }
}