namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var measureItems = new string[]
        {
            "м/с",
            "км/ч",
            "уз",
            "мах",
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
                case "м/с":
                    measureType = MeasureType.mps;
                    break;
                case "км/ч":
                    measureType = MeasureType.kph;
                    break;
                case "уз":
                    measureType = MeasureType.kn;
                    break;
                case "мах":
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

                if (cmbOperation.Text == "+" || cmbOperation.Text == "-")
                {
                    switch (cmbOperation.Text)
                    {
                        case "+":
                            sumSpeed = firstSpeed + secondSpeed;
                            break;
                        case "-":
                            sumSpeed = firstSpeed - secondSpeed;
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
                txtResult.Text = "ќшибка: неверный формат";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbFirstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
