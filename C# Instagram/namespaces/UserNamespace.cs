using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.namespaces.UserNamespace {
    public class User {

        // Private Fields

        private readonly Guid _id;
        private string _name;
        private string _surname;
        private string _email;
        private string _password;
        private int _age;

        // Properties

        public Guid Id { get { return _id; } }
        public string Name { get { return _name; } 
            set {
                try
                {
                    if (value.Length >= 3) _name = value;
                    else throw new Exception("Name must be at least 3 characters !");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }

            } 
        }
        public string Surname { get { return _surname; } set { _surname = value;} }
        public string Email { get { return _email; } 
            set {
                try{
                    if (!value.Contains('@')) throw new Exception("Email must be contains @ symbol !");
                    _email = value;
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            } 
        }
        public string Password { get { return _password; } 
            set {
                try {
                    if (value.Length < 8) throw new Exception("Password must be at least 8 character !");
                    _password = value;
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            } 
        }
        public int Age { get { return _age; }
            set
            {
                try
                {
                    if (value < 0 || value > 100) throw new Exception("Your age is not valid !");
                    _age = value;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            } 
        }

        // Constructors

        public User() {
            _id = Guid.NewGuid();
        }
        public User(string name, string surname, string email, string password, int age) : this() {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Age = age;
        }

        // Functions


        public override string ToString() {
            string user = $"Account Info\n\nId : {Id}\nName : {Name}\nSurname : {Surname}\nAge : {Age}\nEmail : {Email}\nPassword : {Password}\n";
            return user;
        }
    }
}
