using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class User
    {
        private int id;
        private string email;
        private string pass;
        private string firstName;
        private string lastName;

        public User setId(int id)
        {
            this.id = id;
            return this;
        }
        public User setEmail(string email)
        {
            this.email = email;
            return this;
        }
        public User setPass(string pass)
        {
            this.pass = pass;
            return this;
        }
        public User setFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }
        public User setLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }
        public int getId()
        {
            return this.id;
        }
        public string getEmail()
        {
            return this.email;
        }
        public string getPass()
        {
            return this.pass;
        }
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public User() { }
        public User(int id, string email, string pass, string firstName, string lastName)
        {
            this.id = id;
            this.email = email;
            this.pass = pass;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public override string ToString()
        {
            return "First name = " + firstName + " last name = " + lastName + " email = " + email;
        }

    }
}
