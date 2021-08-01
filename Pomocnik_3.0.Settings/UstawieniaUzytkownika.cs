using System;
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
                return Settings.UstawieniaApp.Default.logowanieLogin;
            }
            set
            {
                Settings.UstawieniaApp.Default.logowanieLogin = value;
            } 
        }
        public string logowanieHaslo
        {
            get
            {
                return Settings.UstawieniaApp.Default.logowanieHaslo;
            }
            set
            {
                Settings.UstawieniaApp.Default.logowanieHaslo = value;
            }
        }
        public int sposobAutoryzacji
        {
            get
            {
                return Settings.UstawieniaApp.Default.sposobAutoryzacji;
            }
            set
            {
                Settings.UstawieniaApp.Default.sposobAutoryzacji = value;
            }
        }
        public bool czyZapamietacLogin
        {
            get
            {
                return Settings.UstawieniaApp.Default.czyZapamietacLogin;
            }
            set
            {
                Settings.UstawieniaApp.Default.czyZapamietacLogin = value;
            }
        }
        public int ktoreLogowanie
        {
            get
            {
                return Settings.UstawieniaApp.Default.ktoreLogowanie;
            }
            set
            {
                Settings.UstawieniaApp.Default.ktoreLogowanie = value;
            }
        }

        public UstawieniaUzytkownika()
        {
            logowanieLogin = Settings.UstawieniaApp.Default.logowanieLogin;
            logowanieHaslo = Settings.UstawieniaApp.Default.logowanieHaslo;
            sposobAutoryzacji = Settings.UstawieniaApp.Default.sposobAutoryzacji;
            czyZapamietacLogin = Settings.UstawieniaApp.Default.czyZapamietacLogin;
            ktoreLogowanie = Settings.UstawieniaApp.Default.ktoreLogowanie;
        }

        public void zapisz()
        {
            Settings.UstawieniaApp.Default.Save();
        }
    }
}
