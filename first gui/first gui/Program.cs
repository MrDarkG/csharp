using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using first_gui.Models;
using System.Windows.Forms;
using System.Threading;

namespace first_gui
{
    static class Program
    {
        public static bool is_logged = false;
        public static int user_id=0;
        public static int priv;
        public static int chat_id; //aq vinaxav mere ids romeli chati aqvs archeuli 
        public static int last_message_id=0;
        public static string chat_name = "";
        public static bool clear_chat = false;
        public static Thread thread = null;
        static string GetMd5Hash(MD5 md5Hash, string input)
        {


            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));


            StringBuilder sBuilder = new StringBuilder();


            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }


            return sBuilder.ToString();
        }
        public static bool UniquieUsername(string nickname)
        {
            bool to_ret = true;
            using (chatEntities context = new chatEntities())
            {
                user users = context.users.FirstOrDefault(r => r.username.Equals(nickname));
                if (users == null)
                {
                    to_ret = true;
                }
                else
                {

                    to_ret = false;
                }


            }
            return to_ret;
        }
        public static void SendMessage(string message_content)
        {
            chatEntities context = new chatEntities();
                message send_message = new message
            {
                group_id = Program.chat_id,
                sender_id= Program.user_id,
                message1 = message_content

            };
            
                context.messages.Add(send_message);
            context.SaveChanges();
        }
        public static bool UniquieGroup(string title)
        {
            bool to_ret = true;
            using (chatEntities context = new chatEntities())
            {
                group groups_title = context.groups.FirstOrDefault(r => r.title.Equals(title));
                if (groups_title == null)
                {
                    to_ret = true;
                }
                else
                {
                    to_ret = false;
                }
            }
            return to_ret;
        }
        public static string register(string username,string pwd)
        {
            
            string userName = username;

            if(!Regex.IsMatch(userName, @"^[a-zA-Z]+$") || userName.Length < 4 || !UniquieUsername(userName))
            {
                return "Invalid format or Nickname already exsists\n username:";
                
            }
            
            string newpwd = pwd;
            if (newpwd.Length < 8)
            {
                return "Password mast be min 8 char:";
                
            }
            MD5 md5Hash = MD5.Create();
            string hashedpwd = GetMd5Hash(md5Hash, newpwd);
            using (chatEntities context = new chatEntities())
            {
                user users = new user
                {
                    username = userName,
                    pwd = hashedpwd

                };
                context.users.Add(users);
                context.SaveChanges();
                return "U registered successfully";

            }


        }
        public static int Login(String Username, String Pwd)
        {


            string userName = Username;

            string newpwd = Pwd;
            MD5 md5Hash = MD5.Create();
            string hashedpwd = GetMd5Hash(md5Hash, newpwd);
            using (chatEntities context = new chatEntities())
            {
                user users = context.users.FirstOrDefault(r => r.username.Equals(userName) && r.pwd.Equals(hashedpwd));
                if (users == null)
                {
                    return 0;
                }
                else
                {
                    Program.is_logged = true;
                    Program.user_id = users.user1;
                    Program.priv = users.privilegie;
                    return 1;

                }
            }


        }
        public static void MakeUserAdmin(String Name)
        {
            chatEntities context = new chatEntities();
            user privilegie = context.users.FirstOrDefault(r => r.username.Equals(Name));
            privilegie.privilegie = 1;
            context.SaveChanges();
        }
        public static void RemoveUserAdmin(String Name)
        {
            chatEntities context = new chatEntities();
            user privilegie = context.users.FirstOrDefault(r => r.username.Equals(Name));
            privilegie.privilegie = 0;
            context.SaveChanges();
        }
        public static void UpdateGroup()
        {
            Console.Clear();
            chatEntities context = new chatEntities();
            var groups = context.groups.ToList();
            foreach (var element in groups)
            {
                Console.WriteLine($"[{element.group_id}] {element.title}");
            }

            Console.WriteLine("tell number which u want to update");
            string groups_id = Console.ReadLine();
            int gr_id = Int32.Parse(groups_id);


            group group_to_delete = context.groups.FirstOrDefault(r => r.group_id.Equals(gr_id));

            if (group_to_delete != null)
            {
                Console.WriteLine("Group Title");

                string group_title = Console.ReadLine();
                while (!Regex.IsMatch(group_title, @"^[a-zA-Z]+$") || group_title.Length < 4 || !UniquieGroup(group_title))
                {
                    Console.WriteLine("Invalid format or title already exsists\n title:");
                    group_title = Console.ReadLine();
                }
                group_to_delete.title = group_title;
                context.SaveChanges();


            }


            Admin();
        }
        public static string CreateGroup(String GroupName)
        {
            

            string group_title = GroupName;

            if(!Regex.IsMatch(group_title, @"^[a-zA-Z]+$") || group_title.Length < 4 || !UniquieGroup(group_title))
            {

                return "no match format";
            }
            using (chatEntities context = new chatEntities())
            {
                group groups = new group
                {
                    title = group_title,


                };
                context.groups.Add(groups);
                context.SaveChanges();


            }
            return "added succesfully";
        }

        public static List<UserDTO> listusers()
        {
            chatEntities context = new chatEntities();

            var items = context.users.Where(r=>r.privilegie==0).Select(x => new UserDTO
            {
                      username = x.username,
                  }).ToList();
            return items;
        }
        public static List<UserDTO> listAdmin()
        {
            chatEntities context = new chatEntities();

            var items = context.users.Where(r=>r.privilegie==1 && r.user1!=Program.user_id).Select(x => new UserDTO
            {
                username = x.username,
            }).ToList();
            return items;
        }
        public static List<Chats> listchats()
        {
            chatEntities context = new chatEntities();
            var chatgroupstoreturn = context.groups.Select(x => new Chats
            {
                title = x.title
            }).ToList();   
            //mara ar moaqvs axla :/ ra ar moaqvs
            return chatgroupstoreturn;
        }
        public static List<group> listgroup()
        {
            chatEntities context = new chatEntities();
            var chatgroupstoreturn = context.groups.ToList();
            return chatgroupstoreturn;
        }
        public static int DeleteGroup(int groups_id)
        {
            chatEntities context = new chatEntities();
            
            int gr_id = groups_id;
            group group_to_delete = context.groups.FirstOrDefault(r => r.group_id.Equals(gr_id));

            if (group_to_delete != null)
            {
                context.groups.Remove(group_to_delete);
                context.SaveChanges();


            }

            return 1;
        }
        public static List<MessageModel> Messages(String chatname)
        {

            chatEntities context = new chatEntities();
            int group_id = Int32.Parse(context.groups.FirstOrDefault(r => r.title.Equals(chatname)).group_id.ToString());
            Program.chat_id = group_id;
            

            var result = context.users.Join(
                context.messages.Where(x => x.group_id == chat_id && x.m_id>Program.last_message_id),
                x => x.user1,
                y => y.sender_id,
                (x, y) => new MessageModel { 
                    message = y.message1,
                    username = x.username,
                    messageId = y.m_id
                }
                ).ToList();
            
            return result;
            
        }
        public static void Admin()
        {
        }
        public static void SimpleUser()
        {

        }
        public static void LoggedIn()
        {
            if (Program.priv > 0)
            {
               
            }
            else
            {
                
            }
        }
        static void Main(string[] args)
        {
            if (!Program.is_logged)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                
            }
            
            LoggedIn();

        }
       
        
    }
}
