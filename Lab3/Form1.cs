namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var measureItems = new string[]
            {
            "μ/ρ",
            "κμ/χ",
            "ση",
            "μΰυ",
            };

            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }

        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "μ/ρ":
                    measureType = MeasureType.mps;
                    break;
                case "κμ/χ":
                    measureType = MeasureType.kph;
                    break;
                case "ση":
                    measureType = MeasureType.kn;
                    break;
                case "μΰυ":
                    measureType = MeasureType.max;
                    break;
                default:
                    measureType = MeasureType.mps;
                    break;
            }
            return measureType;
        }

        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstSpeed = new Speed(firstValue, firstType);
                var secondSpeed = new Speed(secondValue, secondType);

                Speed sumSpeed;

                if (cmbOperation.Text == "+" || cmbOperation.Text == "-" || cmbOperation.Text == "*")
                {
                    switch (cmbOperation.Text)
                    {
                        case "+":
                            sumSpeed = firstSpeed + secondSpeed;
                            break;
                        case "-":
                            sumSpeed = firstSpeed - secondSpeed;
                            break;
                        case "*":
                            sumSpeed = firstSpeed * secondSpeed; 
                            break;
                        default:
                            sumSpeed = new Speed(0, MeasureType.mps);
                            break;
                    }
                    txtResult.Text = sumSpeed.To(resultType).Verbose();
                }
                else
                {
                    bool compareResult;
                    switch (cmbOperation.Text)
                    {
                        case ">":
                            compareResult = firstSpeed > secondSpeed;
                            break;
                        case "<":
                            compareResult = firstSpeed < secondSpeed;
                            break;
                        case "==":
                            compareResult = firstSpeed == secondSpeed;
                            break;
                        case "!=":
                            compareResult = firstSpeed != secondSpeed;
                            break;
                        default:
                            compareResult = false;
                            break;
                    }
                    txtResult.Text = compareResult.ToString();
                }
            }
            catch (FormatException)
            {
                
            }
        }

        private void onValueTextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
