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
        }*****************************************************************************************************************************
        namespace MyCalculator
{
    public partial class Calculator : Form
    {
        private string currentCalculation = "";
        private string firstNum = "0";
        private string operation = "";
        private decimal result = 0;

        public Calculator()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_click(object sender, EventArgs e)
        {
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
            Button button = (Button)sender;
            string newOperation = button.Text;

            if (!string.IsNullOrEmpty(firstNum) && string.IsNullOrEmpty(currentCalculation))
            {
                operation = newOperation;
                txtOperationBox.Text = $"{firstNum} {operation}";
            }
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
            if (string.IsNullOrEmpty(currentCalculation) || string.IsNullOrEmpty(firstNum) || string.IsNullOrEmpty(operation))
            {
                txtOutput.Text = "ERROR";
                SetButtonsEnabled(false);
                return;
            }

            decimal firstNumber = Convert.ToDecimal(firstNum);
            decimal secondNumber = Convert.ToDecimal(currentCalculation);

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
                txtOutput.Text = result.ToString("N1");

                //txtOutput.Text = result.ToString("0.##");

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
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            txtOutput.Text = currentCalculation;
        }
        private string Comma_Dot_Click(string input)
        {
            string cleanedInput = input.Replace(",", "");
            if (cleanedInput.Contains("."))
            {
                string[] parts = cleanedInput.Split('.');

                string formattedIntegerPart = $"{int.Parse(parts[0]):n0}";

                return parts.Length > 1 ? formattedIntegerPart + "." + parts[1] : formattedIntegerPart + ".";
            }
            else
            {
                return $"{double.Parse(cleanedInput):n0}";
            }
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
        private void Calculator_KeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    Zero.PerformClick();
                    break;
                case '1':
                    One.PerformClick();
                    break;
                case '2':
                    two.PerformClick();
                    break;
                case '3':
                    three.PerformClick();
                    break;
                case '4':
                    Four.PerformClick();
                    break;
                case '5':
                    Five.PerformClick();
                    break;
                case '6':
                    Six.PerformClick();
                    break;
                case '7':
                    Seven.PerformClick();
                    break;
                case '8':
                    Eight.PerformClick();
                    break;
                case '9':
                    Nine.PerformClick();
                    break;
                case '+':
                    AdditionSign.PerformClick();
                    break;
                case '-':
                    SubtractionSign.PerformClick();
                    break;
                case '*':
                    MultiplySign.PerformClick();
                    break;
                case '/':
                    DivisionSign.PerformClick();
                    break;
                case '=':
                    EqualSign.PerformClick();
                    break;
                case '.':
                    Decimal.PerformClick();
                    break;
                case (char)8: // Backspace key
                    ClearEntry.PerformClick();
                    break;
                default:
                    break;
            }
        }

    }
}
    }
}
