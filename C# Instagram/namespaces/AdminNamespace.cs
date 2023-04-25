using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Instagram.namespaces.PostNamespace;


namespace Instagram.namespaces.AdminNamespace {
    public class Admin {
        // Private Fields

        private readonly Guid _id;
        private string _username;
        private string _email;
        private string _password;
        public List<Post> Posts = new();
        public List<Notification> Notifications = new();
      
        // Properties

        public Guid Id { get { return _id; } }
        public string Username { get { return _username; } 
            set {
                try {
                    if (value.Length < 3) throw new Exception("Username can't be lower than 3 char !");    
                    _username = value;
                } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }
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

        // Constructors

        public Admin() {
            _id = Guid.NewGuid();
        }
        public Admin(string username, string email, string password) : this() {
            Username = username;
            Email = email;
            Password = password;
        }
        public Admin(string username, string email, string password, List<Post> posts) 
            : this(username, email, password) {
            Posts = posts;
        }

        // Functions

        public void newNotification(Notification notification) {
            Notifications.Add(notification);
        }

        public void newPost(Post post) {
            Posts.Add(post);
        }

        public void showPostInformations() {
            foreach (Post post in Posts) {
                Console.WriteLine(post);
            }
        }

        public void showNotifications() {
            foreach (Notification notification in Notifications) {
                Console.WriteLine($"{notification}\n");
            }
        }

        public override string ToString() {
            string admin = $"Account Info\n\nId : {Id}\nUsername : {Username}\nEmail : {Email}\nPassword : {Password}\n";
            return admin;
        }
    }
}
