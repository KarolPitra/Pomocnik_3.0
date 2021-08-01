using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Pomocnik_3._0.Domain;
using Pomocnik_3._0.BusinessLogic;
using Pomocnik_3._0.Settings;



namespace Pomocnik_3._0
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                     
            // Tworzę instancję użytkownika
            var uzytkownik = new Uzytkownik();
            // Tworzę instancję ustawień użytkownika
            var ustawieniaAplikacji = new UstawieniaUzytkownika();
            
            
            
            //Sprawdzam czy jest to pierwsze logowanie do aplikacji
            if (ustawieniaAplikacji.ktoreLogowanie == 0)
            {
                // Jeżeli jest to pierwsze logowanie, pokazuje okno to personalizacji ustawień
                MessageBox.Show("To jest Twoje pierwsze logowanie");
            }
            
            // Po ustaweniu parametrów startowych pobieram je i zgodnie z nimi tworzę odpowiednie instancję odpowiednich klas
            /*
             * 
             *  Kod na pobranie parametrów
             * 
             */
            
            // 1. Sposób autoryzacji
            var autoryzacjaFactory = new AutoryzacjaFactory();
            var rodzajAutoryzacji = autoryzacjaFactory.rodzajAutoryzacji((RodzajeAutoryzacji)ustawieniaAplikacji.sposobAutoryzacji);
            
            // Dokonuje autoryzacji z pobraniem użytkownika
            using (var logowanie = new Logowanie(rodzajAutoryzacji, uzytkownik, ustawieniaAplikacji))
            {
                logowanie.ShowDialog();
                if (logowanie.DialogResult != DialogResult.OK)
                {                    
                    return;
                }
                uzytkownik = logowanie._uzytkownik;
            }
             
            
            // 2. Z jakiej bazy danych korzysta
            /* 
             *  KOD NA BAZA DANYCH FACTORY
             */

            //Jeżeli dane do logowania są poprawne zwiększam ilość logowań
                    
            // Uruchomienie aplikacji z odpowiednimi implementacjami klas, czyli ustawieniami użytkownika
            //Application.Run(new Glowny(uzytkownik, bazaDanych));
                        
        }
    }
}
