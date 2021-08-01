using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Pomocnik_3._0.Domain;


namespace Pomocnik_3._0.Settings
{
    public class UstawieniaUzytkownika : IUstawienia
    {

        public string logowanieLogin 
        {
            get 
            {
                return Settings.Ustawienia.Default.logowanieLogin;
            }
            set 
            {
                Settings.Ustawienia.Default.logowanieLogin = value;
            }
        }
        public string logowanieHaslo
        {
            get
            {
                return Settings.Ustawienia.Default.logowanieLogin;
            }
            set
            {
                Settings.Ustawienia.Default.logowanieLogin = value;
            }
        }
        public int sposobAutoryzacji
        {
            get
            {
                return Settings.Ustawienia.Default.sposobAutoryzacji;
            }
            set
            {
                Settings.Ustawienia.Default.sposobAutoryzacji = value;
            }
        }
        public bool czyZapamietacLogin
        {
            get
            {
                return Settings.Ustawienia.Default.czyZapamietacLogin;
            }
            set
            {
                Settings.Ustawienia.Default.czyZapamietacLogin = value;
            }
        }
        public int ktoreLogowanie
        {
            get
            {
                return Settings.Ustawienia.Default.ktoreLogowanie;
            }
            set
            {
                Settings.Ustawienia.Default.ktoreLogowanie = value;
            }
        }

        public UstawieniaUzytkownika()
        {
            logowanieLogin = Settings.Ustawienia.Default.logowanieLogin;
            logowanieHaslo = Settings.Ustawienia.Default.logowanieHaslo;
            ktoreLogowanie = Settings.Ustawienia.Default.ktoreLogowanie;
            czyZapamietacLogin = Settings.Ustawienia.Default.czyZapamietacLogin;
            sposobAutoryzacji = Settings.Ustawienia.Default.sposobAutoryzacji;
        }

        public void zapisz()
        {
            Settings.Ustawienia.Default.Save();
            MessageBox.Show($"Weszło: {logowanieLogin}");
        }
    }
}
