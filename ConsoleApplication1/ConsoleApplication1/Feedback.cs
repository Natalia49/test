using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Feedback
    {
        private int id;
        private User user;
        private Product product;
        private string text;

        public void setId(int id)
        {
            this.id = id;
        }
        public void setUser(User user)
        {
            this.user = user;
        }
        public void setGoods(Product product)
        {
            this.product = product;
        }
        public void setText(string text)
        {
            this.text = text;
        }

        public int getId()
        {
            return this.id;
        }
        public User getUser()
        {
            return this.user;
        }
        public Product getGoods()
        {
            return this.product;
        }
        public string getText()
        {
            return this.text;
        }
        public Feedback() { }
        public Feedback(User user, Product product, string text)
        { 
            this.user = user;
            this.product = product;
            this.text = text;
        }
        public override string ToString()
        {
            return "id = " + id + " user = " + user.getFirstName()+' '+user.getLastName() + " product = " + product.getName() + " text = " + text;
        }


    }
}
