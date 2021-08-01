using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Pomocnik_3._0.Domain;



namespace Pomocnik_3._0.BusinessLogic
{
    public class AutoryzacjaWlasne : IAutoryzacja
    {
        private string _login { get; set; }
        private string _haslo { get; set; }
        public AutoryzacjaWlasne()
        {
            _login = "";
            _haslo = "";
        }
        public bool autoryzuj(Uzytkownik uzytkownik)
        {
            if (uzytkownik.Login == _login && uzytkownik.Haslo == _haslo)
            {
                return true;
            }

            MessageBox.Show("Nieprawidłowy użytkownik lub hasło", "Logowanie",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
