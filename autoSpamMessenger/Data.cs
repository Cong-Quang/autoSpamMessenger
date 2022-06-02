using System.IO;
using System.Text;

namespace autoSpamMessenger
{
    internal class Data
    {
        private string username;
        private string password;
        public Data()
        {
            string path = "user.txt";
            if (!File.Exists(path) || File.ReadAllText(path) == "")
            {
                File.WriteAllText(path,"Tài_Khoản;Mật_Khẩu",Encoding.UTF8);
            }
            string[] subUser = File.ReadAllText(path).Split(';');
            username = subUser[0];
            password = subUser[1];
        }

        public string Username { get => username;}
        public string Password { get => password;}
    }
}
