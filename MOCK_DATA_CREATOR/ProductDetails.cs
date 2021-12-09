using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class ProductDetails
    {
        public ProductDetails(string data)
        {
            string[] _data = data.Split(',');

            this.ProductID = Convert.ToInt32(_data[0]);
            this.ProductName = _data[1];
            this.MeasurementUnit = _data[2];
            this.UnitPrice = Convert.ToDouble(_data[3]);
            this.Quantity = Convert.ToDouble(_data[4]);

        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string MeasurementUnit { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
    }
}
