using System.Data;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;

            string[] parts = currentCalculation.Split('.');
            string integerPart = parts[0].Replace(",", "");

            if (double.TryParse(integerPart, out double numericValue))
            {
                txtOutput.Text = string.Format("{0:n0}", numericValue);

                if (parts.Length > 1)
                {
                    txtOutput.Text += "." + parts[1];
                }
            }
            else
            {
                txtOutput.Text = currentCalculation;
            }
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txtOperationBox.Text = $"%({txtOutput.Text})";
            txtOutput.Text = Convert.ToString(Convert.ToDouble(txtOutput.Text) / Convert.ToDouble(100));
        }
        private void EqualSign_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation;

            if (formattedCalculation.Contains("/0"))
            {
                txtOutput.Text = "Invalid!";
                currentCalculation = "";
                return;
            }

            try
            {
                txtOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = txtOutput.Text;
            }
            catch (Exception ex)
            {
                txtOutput.Text = "ERROR";
                currentCalculation = "";
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
            currentCalculation = "";
        }
        private void ClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            txtOutput.Text = currentCalculation;
        }
    }
}
