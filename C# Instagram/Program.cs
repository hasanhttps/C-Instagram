using Instagram.namespaces;
using Instagram.namespaces.AdminNamespace;
using Instagram.namespaces.NetworkNamespace;
using Instagram.namespaces.PostNamespace;
using Instagram.namespaces.UserNamespace;
using System.Threading;
using System.ComponentModel.Design;
using System.Numerics;

// Using Static Class

using static Instagram.namespaces.NetworkNamespace.Network;

namespace Instagram {
    public class Program {
        public static int Menu(List<string> choose) {
            Console.Clear();
            bool entered = false;
            int index = 0;
            while (true) {
                int y = 14 - choose.Count;
                for (int i = 0; i < choose.Count; i++) {
                    Console.SetCursorPosition(55, y + i);
                    if (index == i) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(choose[i]);
                }
                dynamic ascii = Console.ReadKey();
                if (ascii.Key == ConsoleKey.Escape) break;
                else if (ascii.Key == ConsoleKey.UpArrow) {
                    if (index > 0) index--;
                    else index = choose.Count - 1;
                }
                else if (ascii.Key == ConsoleKey.DownArrow) {
                    if (index < choose.Count - 1) index++;
                    else index = 0;
                }
                else if (ascii.Key == ConsoleKey.Enter) { 
                    entered = true;
                    break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            if (entered) return index;
            return -1;
        }

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
                    List<string> adminChoose = new();
                    adminChoose.Add("Log in");
                    adminChoose.Add("Exit");
                    var adminIndex = 1;

                    while(adminIndex != -1) { 
                        adminIndex = Menu(adminChoose);

                        if (adminIndex == 0) {
                            Console.Write("Please enter the username or email : ");
                            string username = Console.ReadLine();
                            Console.Write("Please enter the password : ");
                            string password = Console.ReadLine();
                            if (dataBase.checkAdmin(username, password)) {
                                List<string> adminMenu = new();
                                adminMenu.Add("Create Post");
                                adminMenu.Add("Post Information");
                                adminMenu.Add("Notifications");
                                adminMenu.Add("Account");
                                adminMenu.Add("Exit");
                                var adminMenuIndex = 1;

                                while (adminMenuIndex != -1) {
                                    adminMenuIndex = Menu(adminMenu);

                                    if (adminMenuIndex == 0) {
                                        Console.Write("Please enter the post content : ");
                                        string content = Console.ReadLine();

                                        Post newPost = new(content, 0, 0);
                                        DataBase.currentAdmin.newPost(newPost);

                                    }
                                    else if (adminMenuIndex == 1) {
                                        DataBase.currentAdmin.showPostInformations();
                                        Console.Write("Press any key to continue . . . ");
                                        Console.ReadKey();
                                    }
                                    else if (adminMenuIndex == 2) {
                                        DataBase.currentAdmin.showNotifications();
                                        Console.Write("Press any key to continue . . . ");
                                        Console.ReadKey();
                                    }else if (adminMenuIndex == 3) {
                                        Console.WriteLine(DataBase.currentAdmin);
                                        Console.Write("Press any key to continue . . . ");
                                        Console.ReadKey();
                                    }
                                    else if (adminMenuIndex == 4) break;
                                }
                            }else {
                                try {
                                    throw new Exception("Not valid accaount !");
                                }catch (Exception e) { 
                                    Console.WriteLine(e.Message); 
                                }
                            }
                        }else if (adminIndex == 1) break;
                    }
                }else if (index == 1) {
                    List<string> userChoose = new List<string>();
                    userChoose.Add("Sign Up");
                    userChoose.Add("Log In");
                    userChoose.Add("Exit");
                    var userIndex = 1;

                    while (userIndex != -1) {
                        userIndex = Menu(userChoose);

                        if (userIndex == 0) {
                            Console.Write("Please enter your name : ");
                            string name = Console.ReadLine();
                            Console.Write("Please enter your surname : ");
                            string surname = Console.ReadLine();
                            Console.Write("Please enter your age : ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter your email : ");
                            string email = Console.ReadLine();
                            Console.Write("Please enter your password : ");
                            string password = Console.ReadLine();
                            Random random = new Random();
                            int randint = random.Next(100000, 1000000);

                            string message = $"<div class=\"\"><div class=\"aHl\"></div><div id=\":ot\" tabindex=\"-1\"></div><div id=\":mk\" class=\"ii gt\" jslog=\"20277; u014N:xr6bB; 1:WyIjdGhyZWFkLWY6MTc2Mzg5OTExNjA0OTQ4MDAzOCIsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsW11d; 4:WyIjbXNnLWY6MTc2Mzg5OTExNjA0OTQ4MDAzOCIsbnVsbCxbXV0.\"><div id=\":ml\" class=\"a3s aiL msg1943207792933616446\"><u></u><div style=\"margin:0;padding:0\" bgcolor=\"#FFFFFF\"><table width=\"100%\" height=\"100%\" style=\"min-width:348px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" lang=\"az\"><tbody><tr height=\"32\" style=\"height:32px\"><td></td></tr><tr align=\"center\"><td><div><div></div></div><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding-bottom:20px;max-width:516px;min-width:220px\"><tbody><tr><td width=\"8\" style=\"width:8px\"></td><td><div style=\"border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px\" align=\"center\" class=\"m_1943207792933616446mdv2rw\"><img src=\"https://logos-download.com/wp-content/uploads/2016/03/Instagram_Logo_2016.png\" width=\"74\" height=\"24\" aria-hidden=\"true\" style=\"margin-bottom:16px\" alt=\"Google\" class=\"CToWUd\" data-bit=\"iit\"><div style=\"font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word\"><div style=\"font-size:24px\">E-poçtunuzu doğrulayın </div></div><div style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left\">Hesabinizi dogrulamaq ucun asagidaki koddan istifade edin : <br><div style=\"text-align:center;font-size:36px;margin-top:20px;line-height:44px\">{randint.ToString()}</div><br>Bu kodun vaxtı 24 saat sonra bitəcək.<br><br></div></div><div style=\"text-align:left\"><div style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center\"><div>Google Hesabı və xidmətlərinə edilən mühüm dəyişikliklərdən xəbərdar olmaq üçün bu e-məktubu aldınız.</div><div style=\"direction:ltr\">© 2023 Google LLC, <a class=\"m_1943207792933616446afal\" style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center\">1600 Amphitheatre Parkway, Mountain View, CA 94043, USA</a></div></div></div></td><td width=\"8\" style=\"width:8px\"></td></tr></tbody></table></td></tr><tr height=\"32\" style=\"height:32px\"><td></td></tr></tbody></table></div></div><div class=\"yj6qo\"></div><div class=\"yj6qo\"></div></div><div id=\":op\" class=\"ii gt\" style=\"display:none\"><div id=\":oo\" class=\"a3s aiL \"></div></div><div class=\"hi\"></div></div>";                         
                            Notification notification = new Notification("Registration Code", message, "Instagram");

                            isHtml = true;
                            Thread thread = new Thread(() => sendNotification(email, notification));
                            thread.IsBackground = true;
                            thread.Start();

                            Console.Write("Please enter the registration code : ");
                            string code = Console.ReadLine();
                            if (randint == Convert.ToInt32(code)) {
                                User newUser = new(name, surname, email, password, age);
                                dataBase.addUser(newUser);
                            }
                            else {
                                try {
                                    throw new Exception("Not valid Registration Code !");
                                }catch(Exception ex) { Console.WriteLine(ex.Message); }
                            }
                        }else if (userIndex == 1) {
                            Console.Write("Please enter the name or email : ");
                            string username = Console.ReadLine();
                            Console.Write("Please enter the password : ");
                            string password = Console.ReadLine();
                            if (dataBase.checkUser(username, password)) {
                                Console.Clear();
                                List<string> userMenu = new();
                                userMenu.Add("Posts");
                                userMenu.Add("Account");
                                userMenu.Add("Exit");
                                var userMenuIndex = 1;

                                while (userMenuIndex != -1) {
                                    userMenuIndex = Menu(userMenu);

                                    if (userMenuIndex == 0) {

                                        for (int i = 0; i < dataBase.Admins.Length; i++) {
                                            foreach (Post post in dataBase.Admins[i].Posts) {
                                                Console.WriteLine($"Post Id : {post.Id}\nPost Date : {post.CreationDate}\nLike Count : {post.LikeCount}, View Count : {post.ViewCount}\n\n");
                                            }
                                        }

                                        Console.Write("Please enter the post id for view (or enter exit for exit) : ");
                                        string id = Console.ReadLine();
                                        Thread thread;

                                        if (id == "exit") break;
                                        else {

                                            bool isfound = false;

                                            for (int i = 0; i < dataBase.Admins.Length; i++) {
                                                foreach (Post post in dataBase.Admins[i].Posts) {
                                                    if (post.Id.ToString() == id) {
                                                        Console.Clear();
                                                        isfound = true;
                                                        Notification notification = new Notification("View Notification", $"{DataBase.currentUser.Name} viewed your post at {DateTime.Now}.", DataBase.currentUser.Name);
                                                        dataBase.Admins[i].newNotification(notification);
                                                        thread = new Thread(() => sendNotification(DataBase.currentAdmin.Email, notification));
                                                        thread.IsBackground = true;
                                                        thread.Start();
                                                        post.ViewCount += 1;
                                                        Console.WriteLine(post);
                                                    }
                                                }
                                            }
                                            if (isfound) {
                                                Console.Write("Please enter the post id for like (or enter exit for exit) : ");
                                                id = Console.ReadLine();
                                                if (id == "exit") break;
                                                else {
                                                    for (int i = 0; i < dataBase.Admins.Length; i++) {
                                                        foreach (Post post in dataBase.Admins[i].Posts) {
                                                            if (post.Id.ToString() == id) {
                                                                Console.Clear();
                                                                Notification notification = new Notification("Like Notification", $"{DataBase.currentUser.Name} liked your post at {DateTime.Now}.", DataBase.currentUser.Name);
                                                                dataBase.Admins[i].newNotification(notification);
                                                                thread = new Thread(() => sendNotification(DataBase.currentAdmin.Email, notification));
                                                                thread.Start();
                                                                post.LikeCount += 1;
                                                                Console.WriteLine(post);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else {
                                                try {
                                                    throw new Exception("This post id is not available !");
                                                }catch(Exception e) {
                                                    Console.WriteLine(e.Message);
                                                }
                                            }
                                        }
                                    }else if (userMenuIndex == 1) {
                                        Console.WriteLine(DataBase.currentUser);
                                        Console.Write("Press any key to continue . . . ");
                                        Console.ReadKey();
                                    }
                                    else if(userMenuIndex == 2) break;
                                }
                            }
                            else {
                                try {
                                    throw new Exception("Not valid accaount !");
                                }catch (Exception e) { 
                                    Console.WriteLine(e.Message); 
                                }
                            }
                        }else if (userIndex == 2) break;
                    }
                }else if (index == 2) break;

            }
        }
    }
}