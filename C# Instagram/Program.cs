using Instagram.namespaces;
using Instagram.namespaces.AdminNamespace;
using Instagram.namespaces.NetworkNamespace;
using Instagram.namespaces.PostNamespace;
using Instagram.namespaces.UserNamespace;
using System.ComponentModel.Design;
using System.Security.Principal;
using System.Threading;
using System.Numerics;

// Using Static Class

using static Instagram.namespaces.NetworkNamespace.Network;
using static Instagram.namespaces.Functions.Functions;

namespace Instagram {

    public class Program {
        

        static void Main() {
            DataBase dataBase = new DataBase();
            List<string> choose = new();
            choose.Add("Admin");
            choose.Add("User");
            choose.Add("Exit");
            var index = 1;

            while(index != -1) {
                index = Menu(choose);

                if (index == 0) {
                    AdminAcc(dataBase);
                }else if (index == 1) {
                    UserAcc(dataBase);
                }else if (index == 2) break;

            }
        }
    }
}