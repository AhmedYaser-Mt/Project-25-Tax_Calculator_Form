using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project_25___Tax_Calculator_Form__
{
    public partial class frmTaxCalculator : Form
    {
        public frmTaxCalculator()
        {
            InitializeComponent();
        }

        private double Amount, TaxRate, TotalAmount, TaxAmount;

        private void ClearTextBoxes()
        {
            txtAmount.Clear();
            txtTaxRate.Clear();
            txtTaxAmount.Clear();
            txtTotalAmount.Clear();
        }

        private void ClearValues()
        {
            Amount = 0;
            TaxRate = 0;
            TotalAmount = 0;
            TaxAmount = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();

            ClearValues();
        }

        private double GetAmount()
        {
            return Convert.ToDouble(txtAmount.Text.Trim());
        }

        private double GetTaxRate()
        {
            return (Convert.ToDouble(txtTaxRate.Text.Trim()) / 100 + 1);
        }

        private double GetTotalAmount()
        {
            return (Amount * TaxRate);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            txtSavedHistory.Clear();
        }

        private bool IsTaxAmountOrTotalEmpty()
        {
            return (string.IsNullOrWhiteSpace(txtTaxAmount.Text) || string.IsNullOrWhiteSpace(txtTotalAmount.Text));
        }

        private bool IsAmountOrRatioEmpty()
        {
            return (string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtTaxRate.Text));
        }

        private double GetTaxAmount()
        {
            return TotalAmount - Amount;
        }

        private void CalculateValues()
        {
            Amount = GetAmount();
            TaxRate = GetTaxRate();
            TotalAmount = GetTotalAmount();
            TaxAmount = GetTaxAmount();
        }

        private bool IsTextBoxesEmpty()
        {
            return (IsTaxAmountOrTotalEmpty() || IsAmountOrRatioEmpty());
        }

        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxesEmpty())
            {
                txtSavedHistory.Text += "Amount " + txtAmount.Text.Trim();
                txtSavedHistory.Text += ", Ratio " + txtTaxRate.Text.Trim();
                txtSavedHistory.Text += ", Tax " + txtTaxAmount.Text.Trim();
                txtSavedHistory.Text += ", Total " + txtTotalAmount.Text.Trim();
                txtSavedHistory.Text += Environment.NewLine;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!IsAmountOrRatioEmpty())
            {
                CalculateValues();

                txtTotalAmount.Text = TotalAmount.ToString();

                txtTaxAmount.Text = TaxAmount.ToString();
            }
        }
    }
}
