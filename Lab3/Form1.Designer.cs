namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFirst = new TextBox();
            txtSecond = new TextBox();
            txtResult = new TextBox();
            cmbOperation = new ComboBox();
            cmbFirstType = new ComboBox();
            cmbSecondType = new ComboBox();
            cmbResultType = new ComboBox();
            SuspendLayout();
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(144, 32);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(125, 27);
            txtFirst.TabIndex = 0;
            txtFirst.TextChanged += onValueTextChanged;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(144, 65);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(125, 27);
            txtSecond.TabIndex = 1;
            txtSecond.TextChanged += onValueTextChanged;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(35, 107);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(234, 27);
            txtResult.TabIndex = 2;
            // 
            // cmbOperation
            // 
            cmbOperation.FormattingEnabled = true;
            cmbOperation.Items.AddRange(new object[] { "+", "-", "*", "==", ">", "<", "!=" });
            cmbOperation.Location = new Point(35, 32);
            cmbOperation.Name = "cmbOperation";
            cmbOperation.Size = new Size(99, 28);
            cmbOperation.TabIndex = 3;
            cmbOperation.Text = "+";
            cmbOperation.SelectedIndexChanged += onValueChanged;
            // 
            // cmbFirstType
            // 
            cmbFirstType.FormattingEnabled = true;
            cmbFirstType.Location = new Point(290, 32);
            cmbFirstType.Name = "cmbFirstType";
            cmbFirstType.Size = new Size(59, 28);
            cmbFirstType.TabIndex = 4;
            cmbFirstType.SelectedIndexChanged += onValueChanged;
            // 
            // cmbSecondType
            // 
            cmbSecondType.FormattingEnabled = true;
            cmbSecondType.Location = new Point(290, 66);
            cmbSecondType.Name = "cmbSecondType";
            cmbSecondType.Size = new Size(59, 28);
            cmbSecondType.TabIndex = 5;
            cmbSecondType.SelectedIndexChanged += onValueChanged;
            // 
            // cmbResultType
            // 
            cmbResultType.FormattingEnabled = true;
            cmbResultType.Location = new Point(290, 107);
            cmbResultType.Name = "cmbResultType";
            cmbResultType.Size = new Size(59, 28);
            cmbResultType.TabIndex = 6;
            cmbResultType.SelectedIndexChanged += onValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 167);
            Controls.Add(cmbResultType);
            Controls.Add(cmbSecondType);
            Controls.Add(cmbFirstType);
            Controls.Add(cmbOperation);
            Controls.Add(txtResult);
            Controls.Add(txtSecond);
            Controls.Add(txtFirst);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirst;
        private TextBox txtSecond;
        private TextBox txtResult;
        private ComboBox cmbOperation;
        private ComboBox cmbFirstType;
        private ComboBox cmbSecondType;
        private ComboBox cmbResultType;
    }
}
