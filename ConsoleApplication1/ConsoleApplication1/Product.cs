using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Product
    {
        private int id;
        private string name;
        private string details;
        private string photoUrl;
        private decimal price;
        private int number;

        public Product setId(int id)
        {
            this.id = id;
            return this;
        }
        public Product setName(string name)
        {
            this.name = name;
            return this;
        }
        public Product setDetails(string details)
        {
            this.details = details;
            return this;
        }
        public Product setPotoUrl(string photoUrl)
        {
            this.photoUrl = photoUrl;
            return this;
        }
        public Product setPrice(decimal price)
        {
            this.price = price;
            return this;
        }
        public Product setNumber(int number)
        {
            this.number = number;
            return this;
        }

        public int getId()
        {
            return this.id;
        }
        public string getName()
        {
            return this.name;
        }
        public string getDetails()
        {
            return this.details;
        }
        public string getPotoUrl()
        {
            return this.photoUrl;
        }
        public decimal getPrice()
        {
            return this.price;
        }
        public int getNumber()
        {
            return this.number;
        }
        public Product() { }
        public Product(int id, string name, string details, string photoUrl, decimal price, int number)
        {
            this.id = id;
            this.name = name;
            this.details = details;
            this.photoUrl = photoUrl;
            this.price = price;
            this.number = number;
        }
        public override string ToString()
        {
            return "id = " + id + "\tname = " + name + "\tdetails = " + details + "\tphoto = " + photoUrl + "\tprice = " + price + "\tnumber = " + number;
        }
    }
}
