using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class Invoice_Product
    {
        private int _invoiceID;
        private double _totalCost;
        private ArrayList CurrentProducts;

        private ArrayList UniqueIndex = new ArrayList();
        private ArrayList Details = new ArrayList();

        private Random _random;
        public Invoice_Product (int InvoiceID, ArrayList AllProducts, ArrayList selectedProducts)
        {
            _random = new Random();
            this._invoiceID = InvoiceID;
            this.CurrentProducts = AllProducts; //this.ReadFile(new TextFieldParser(@"D:\Capstone Project\MOCK DATA\PRODUCT_INVOICE\PRODUCT.csv"));
            
            for(int i =0; i<selectedProducts.Count; i++)
            {
                if (uniqueIndexCheck(Convert.ToInt32( selectedProducts[i])))
                {
                    ProductDetails PD = new ProductDetails(CurrentProducts[Convert.ToInt32( selectedProducts[i])].ToString());
                    int PurchasedQunity = _random.Next(1, 6);

                    double ProductPrice = PD.UnitPrice * PurchasedQunity;
                    _totalCost += ProductPrice;
                    double ProductQuantity = PD.Quantity * PurchasedQunity;

                    string output = InvoiceProductDetails(PD.ProductID, _invoiceID, ProductQuantity, ProductPrice);
                    Details.Add(output);
                }
            }
        }

        public void CreateData()
        {
            //int NumbersOfPrdouctInInvoice = _random.Next(1, 5);

            //for (int i = 0; i < NumbersOfPrdouctInInvoice; i++)
            //{
            //    int ProductIndex = _random.Next(CurrentProducts.Count);

            //    if (uniqueIndexCheck(ProductIndex))
            //    {
            //        ProductDetails PD = new ProductDetails(CurrentProducts[ProductIndex].ToString());
            //        int PurchasedQunity = _random.Next(1, 6);

            //        double ProductPrice = PD.UnitPrice * PurchasedQunity;
            //        _totalCost += ProductPrice;
            //        double ProductQuantity = PD.Quantity * PurchasedQunity;

            //        string output = InvoiceProductDetails(PD.ProductID, _invoiceID, ProductQuantity, ProductPrice);
            //        Details.Add(output);
            //    }

            //}
        }
        public double TotalCost()
        {
            return _totalCost;
        }

        public ArrayList getDaitls()
        {
            return Details;
        }
       private string InvoiceProductDetails(int ProductID, int InvoiceID, double Quantity, double Cost)
        {
            string result = "";
            result = " new PRODUCT_INVOICE {COST = (decimal) " + Cost;
            result += ',' + "PRODUCTID = " + ProductID;
            result += ',' + "INVOICEID = " + InvoiceID;
            result += ',' + "QUANTITY = " + Quantity;
            result += "}" + ',' + "\n";

            return result;
        }

        private bool uniqueIndexCheck (int numb)
        {
            bool result = true;
            for(int i =0; i<UniqueIndex.Count; i++)
            {
                if (Convert.ToInt32 ( UniqueIndex[i]) == numb)
                {
                    return false;
                }
            }
            UniqueIndex.Add(numb);
            return result;
        }
        private ArrayList ReadFile(TextFieldParser filePath)
        {
            ArrayList Result = new ArrayList();
            using (TextFieldParser parser = filePath)
            {
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string data = parser.ReadLine();
                    Result.Add(data);
                    //  Console.WriteLine(data);
                }
            }
            return Result;
        }
    }
}
