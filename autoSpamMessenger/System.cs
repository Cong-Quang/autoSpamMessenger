using System;
using System.Text;
namespace autoSpamMessenger
{
    internal class System
    {
        static Data data = new Data();
        private string id;
        private string N_D;
        private int SL;
        private string M_String = "https://www.facebook.com/messages/t/";
        public System()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.SetWindowSize(40,20);
            Console.Title = "Tools Tào Lao";
            checkdata();

        }
        private void checkdata()
        {
            if (data.Username == "Tài_Khoản" || data.Password == "Mật_Khẩu")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vui Lòng Nhập DATA vài file");
                Console.ResetColor();
            }
            else
            {
                Inputdata();
                SystemX();
            }
        }
        private void Inputdata()
        {
            Console.Write("Nhập ID \n\t-> ");
            id = Console.ReadLine();
            Console.Write("Nhập nội dung \n\t-> ");
            N_D = Console.ReadLine();
            inputD();
            void inputD()
            {
                try
                {
                    Console.Write("Nhập Số Lượng \n\t-> ");
                    SL = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Vui lòng nhập Số");
                    inputD();
                }
            }
        }
        private void SystemX()
        {
            chrome chrome = new chrome();
            chrome.OpenChrome();
            try
            {
                chrome.login(data.Username, data.Password);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Đăng nhập thành công");
                
                try
                {
                    chrome.openLink(M_String + id);
                    Console.WriteLine("vào ID thành công");
                    chrome.Click(N_D, SL);
                    chrome.CloseChrom();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Không thể kiếm thấy ID");
                    Console.ResetColor();
                    chrome.CloseChrom();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Đăng nhập thất bại");
                Console.ResetColor();
            }
        }
    }
}
