using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesTaxes
{
    public partial class Form1 : Form
    {

        public void setDefaultValues()
        {
            FoodPricetextBox.Text = "0";
            BooksPricetextBox.Text = "0";
            MedicalPricetextBox.Text = "0";
            SomethingPricetextBox.Text = "0";
            FoodTextBox.Text = "0";
            BooksTextBox.Text = "0";
            MedialTextBox.Text = "0";
            NIFPtextBox.Text = "0";
            NIBPtextBox.Text = "0";
            NIMPtextBox.Text = "0";
            NISQtextBox.Text = "0";
            IMSPtextBox.Text = "0";
            NIFQtextBox.Text = "0";
            NIBQtextBox.Text = "0";
            NIMQtextBox.Text = "0";
            SomethingtextBox.Text = "0";
        }
        public Form1()
        {
            InitializeComponent();
            setDefaultValues();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Buy_Click(object sender, EventArgs e)
        {
            List<double> totals = ImportedTaxes();
            MessageBox.Show("the total tax is :" + totals[0] + "\n" +
                "the total is :" + totals[1]);
        }

        public List<double> ImportedTaxes()
        {
            // getting prices
            double foodPrice = double.Parse(FoodPricetextBox.Text);
            double booksPrice = double.Parse(BooksPricetextBox.Text);
            double medicalPrice = double.Parse(MedicalPricetextBox.Text);
            double somethingPrice = double.Parse(SomethingPricetextBox.Text);

            // non imported prices
            double nonImportedFoodPrice = double.Parse(NIFPtextBox.Text);
            double nonImportedBooksPrice = double.Parse(NIBPtextBox.Text);
            double noniImportedMedicalPrice = double.Parse(NIMPtextBox.Text);
            double nonImportedOtherPrice = double.Parse(IMSPtextBox.Text);

            // getting quantities
            double foodQ = double.Parse(FoodTextBox.Text);
            double booksQ = double.Parse(BooksTextBox.Text);
            double medicalQ = double.Parse(MedialTextBox.Text);
            double somethingQ= double.Parse(SomethingtextBox.Text);

            // non imported quantities
            double NonImportedFoodQuantity = double.Parse(NIFQtextBox.Text);
            double NonImportedBooksQuantity = double.Parse(NIBQtextBox.Text);
            double NonImportedMedicalQuantity = double.Parse(NIMQtextBox.Text);
            double NonImportedOtherQuantity = double.Parse(NISQtextBox.Text);

            // calculating non imported tax percentage
            double NonImportFoodBill = NonImportedFoodQuantity * nonImportedFoodPrice;
            double NonImportBooksBill = NonImportedBooksQuantity * nonImportedBooksPrice;
            double NonImportMedicalBill = NonImportedMedicalQuantity * noniImportedMedicalPrice;

            double NonImportOtherBill = NonImportedOtherQuantity * nonImportedOtherPrice;
            double NonImportedTaxOther = 10 * NonImportOtherBill / 100;
            double NonImportedHasTobePaid = NonImportedTaxOther + NonImportOtherBill;



            // calculating the percentages
            double foodGrossPrice = foodPrice * foodQ;
            double foodTax = 5 * foodGrossPrice / 100;
            double lastPriceFood = foodTax + foodPrice;

            double booksGrossPrice = booksPrice * booksQ;
            double bookTax = 5 * booksGrossPrice / 100;
            double bookPriceWithTax = bookTax + booksGrossPrice;

            double medicalGrossPrice = medicalPrice * medicalQ;
            double medicalTax = 5 * medicalGrossPrice / 100;
            double medicalPriceWithTax = medicalTax + medicalGrossPrice;

            double somethingGrossPrice = somethingPrice * somethingQ;
            double somethingTax = 15 * somethingGrossPrice / 100;
            double priceTobePaidSome = somethingTax + somethingGrossPrice;

            double totalTax = somethingTax + bookTax +
                medicalTax + foodTax +
                + NonImportedTaxOther;

            double total = lastPriceFood + bookPriceWithTax + 
                medicalPriceWithTax + priceTobePaidSome +
                NonImportFoodBill + NonImportBooksBill + 
                NonImportMedicalBill + NonImportedHasTobePaid
                ;
            List<double> totals = new List<double>();
            totals.Add(totalTax);
            totals.Add(total);
            return totals;

        }
    }
}
