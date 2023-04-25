using Instagram.namespaces.AdminNamespace;
using Instagram.namespaces.UserNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.namespaces {
    public class DataBase {

        // Static Fields

        private static Admin _currentAdmin;
        private static User _currentUser;

        // Private Fields

        private Admin[] _admins = new Admin[1];
        private List<User> _users = new();

        // Properties

        public Admin[] Admins { get { return _admins; } set { _admins = value; } }
        public List<User> Users { get { return _users; } }
        public static Admin currentAdmin { get { return _currentAdmin; } }
        public static User currentUser { get { return _currentUser; } }

        // Constructors

        public DataBase() { 
            Admin admin1 = new Admin("Hasanhttps", "hasanabdullazad@gmail.com", "2000Hasan");
            _admins = new Admin[1];
            _admins[0] = admin1;
            User user1 = new User("Rustem", "Hesenli", "clientrustem2000@gmail.com", "2000Rustem", 16);
            _users.Add(user1);
        }

        // Functions

        public bool checkAdmin(string username, string password) {
            foreach (Admin admin in _admins) {
                if ((admin.Username == username || admin.Email == username) && admin.Password == password) {
                    _currentAdmin = admin;
                    
                    return true;
                }
            } return false;
        }

        public bool checkUser(string username, string password) {
            foreach (User user in Users) {
                if ((user.Name == username || user.Email == username) && user.Password == password) {
                    _currentUser = user;
                    return true;
                }
            } return false;
        }

        public void addUser(User user) {
            Users.Add(user);
        }
    }
}
