namespace Calculator
{
    public partial class Form1 : Form
    {
        string[] validInputs = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        double n2 = 0, n1 = double.MinValue; //n1 is the final result
        int op = 0;
        string[] op_string = { "+", "-", "x", "÷" };

        public Form1()
        {
            InitializeComponent();
        }

        public void insertInput(string input)
        {
            if (resultLbl.Text.Length > 10)
                return;

            if (n2 == double.MinValue)
                n2 = 0;

            for (int i = 0; i < validInputs.Length; i++)
            {
                if (input == validInputs[i])
                {
                   if (resultLbl.Text == "0")
                        resultLbl.Text = "";

                    resultLbl.Text += input;
                    n2 = n2 * 10 + i;
                    break;
                }
            }
        }

        private double total()
        {
            if (n1 == double.MinValue && n2 == double.MinValue)
                   return n1 = 0;
            else if (n1 == double.MinValue && n2 != double.MinValue)
                return n1 = n2;
            else if (n1 != double.MinValue && n2 == double.MinValue)
                return n1;


            switch (op)
            {
                case 0:
                    n1 += n2;
                    break;
                case 1:
                    n1 -= n2;
                    break;
                case 2:
                    n1 *= n2;
                    break;
                case 3:
                    n1 /= n2;
                    break;
            }
            return n1;
        }

        private void changeOperation(int n)
        {
            if (n != op)
                n2 = double.Max(double.MinValue,n2);

            op = n; //0 is the index for addition in op_string

            subResultLbl.Text = numToString(total()) + op_string[op];
            resultLbl.Text = "0";

            n2 = double.MinValue;
        }

        //convert number to string up to 10 digits
        private string numToString(double val)
        {
            if (val.ToString().Contains('E'))
            {
                // Convert to a string and split the scientific notation
                string[] parts = val.ToString("0.##############E0").Split('E');
                double partBeforeE = double.Parse(parts[0]);

                // Round the part before 'E'
                double roundedNumber = Math.Round(partBeforeE,7);

                // Output the result with the original exponent
                if (parts[1][0] != '-')
                    return $"{roundedNumber}E+{parts[1]}";

                return $"{roundedNumber}E{parts[1]}";
            }

            return val.ToString().Substring(0, int.Min(val.ToString().Length, 16));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            subResultLbl.Focus();
        }

        private void percentageBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            subResultLbl.Focus();
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (resultLbl.Text.Length == 1 || resultLbl.Text == "0")
                    {
                        resultLbl.Text = "0";
                        n2 = 0;
                    }
                    else
                    {
                        resultLbl.Text = resultLbl.Text.Substring(0, resultLbl.Text.Length - 1);
                        n2 /= 10;
                    }
                    break;
                case Keys.Escape: case Keys.Delete:
                    resultLbl.Text = "0";
                    subResultLbl.Text = "";
                    n2 = double.MinValue;
                    n1 = double.MinValue;
                    break;
                case Keys.Enter:
                    subResultLbl.Text = numToString(n1) + op_string[op] + numToString(n2) +  "=";
                    resultLbl.Text = numToString(total());
                    break;
                case Keys.Add:
                    changeOperation(0); 
                    break;
                case Keys.Subtract:
                    changeOperation(1); 
                    break;
                case Keys.Multiply:
                    changeOperation(2);
                    break;
                case Keys.Divide:
                    changeOperation(3);
                    break;
            }
           
        }

        private void n1Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{1}");
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
        }

        private void n3Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{3}");
        }

        private void n4Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{4}");
        }

        private void n5Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{5}");
        }

        private void n6Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{6}");
        }

        private void n7Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{7}");
        }

        private void n8Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{8}");
        }

        private void n9Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{8}");
        }

        private void divBtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{divide}");
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{multiply}");
        }

        private void subtractBtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{subtract}");
        }

        private void additionBtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{add}");
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            resultLbl.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void n2Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{2}");
        }

        private void n0Btn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{0}");
        }

        private void cBtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DEL}");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            insertInput(e.KeyChar.ToString());
        }
    }
}