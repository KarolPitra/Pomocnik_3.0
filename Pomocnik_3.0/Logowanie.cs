using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pomocnik_3._0.Domain;
using Pomocnik_3._0.Settings;

namespace Pomocnik_3._0
{
    public partial class Logowanie : Form
    {
        /// <summary>
        /// Interface zawierający odpowiedni rodzaj autoryzacji
        /// </summary>
        private IAutoryzacja _autoryzacja;
        public Uzytkownik _uzytkownik;
        private UstawieniaUzytkownika _ustawieniaAplikacji;

        /// <summary>
        /// Konstruktor którego głównym zadaniem jest wstrzyknięcie odpowiedniego sposobu autoryzacji
        /// </summary>
        public Logowanie(IAutoryzacja autoryzacja, Uzytkownik uzytkownik, UstawieniaUzytkownika ustawieniaAplikacji)
        {
            InitializeComponent();
            
            // Utworzenie kopii objektów
            _autoryzacja = autoryzacja;
            _uzytkownik = uzytkownik;
            _ustawieniaAplikacji = ustawieniaAplikacji;
            
            //Sprawdzenie czy wpisać login z ustawień aplikacji w textBox
            if (_ustawieniaAplikacji.czyZapamietacLogin)
            {
                textBoxLogowanieLogin.Text = _ustawieniaAplikacji.logowanieLogin;
            }
            
            //Ustawienie nazwy okienka 
            this.Text = $"Logowanie [{(RodzajeAutoryzacji)_ustawieniaAplikacji.sposobAutoryzacji}]";
                       
        }

        private void Logowanie_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Przycisk "Zaloguj" dokonuje autoryzacji danych użytkownika, wedlug sposobu zapisanego w ustawieniach aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonZaloguj_Click(object sender, EventArgs e)
        {

            _uzytkownik.Login = textBoxLogowanieLogin.Text;
            _uzytkownik.Haslo = textBoxLogowanieHaslo.Text;
            
            if (_autoryzacja.autoryzuj(_uzytkownik)) 
            {
                this.DialogResult = DialogResult.OK;                
                this.Close();                
                return;
            }

            MessageBox.Show($"Nieprawidłowy login lub hasło!", $"Logowanie [{(RodzajeAutoryzacji)_ustawieniaAplikacji.sposobAutoryzacji}]", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
