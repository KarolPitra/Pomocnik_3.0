using System;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User
            {
                Imie = "Karol",
                Nazwisko = "Pitra"
            };
            
            var sms = new PowiadomienieSMS();
            var mail = new PowiadomienieMail();
            
            AutoryzacjaManager aMsms = new AutoryzacjaManager(sms);
            AutoryzacjaManager aMmail = new AutoryzacjaManager(mail);

            aMsms.autoryzuj(u);
            aMmail.autoryzuj(u);
        }
    }

    public interface IWysylkaPowiadomienia
    {
        void wyslij(User user);
    }

    public class User
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }

    public class AutoryzacjaManager
    {
        private IWysylkaPowiadomienia _powiadomienie;
        public AutoryzacjaManager(IWysylkaPowiadomienia rodzajWysylki)
        {
            _powiadomienie = rodzajWysylki;
        }

        public void autoryzuj(User user)
        {
            if (user.Imie == "Karol" && user.Nazwisko == "Pitra")
            {
                _powiadomienie.wyslij(user);
            }
        }
    }

    public class PowiadomienieSMS : IWysylkaPowiadomienia
    {
        public void wyslij(User user)
        {
            Console.WriteLine($"Wysyłam SMS do {user.Imie} {user.Nazwisko}");
        }
    }

    public class PowiadomienieMail : IWysylkaPowiadomienia
    {
        public void wyslij(User user)
        {
            Console.WriteLine($"Wysyłam @ do {user.Imie} {user.Nazwisko}");
        }
    }
}
