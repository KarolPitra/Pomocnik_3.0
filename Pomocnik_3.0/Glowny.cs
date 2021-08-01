using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Pomocnik_3._0.Domain;

namespace Pomocnik_3._0
{
    public partial class Glowny : Form
    {        
        IBazaDanych _bazaDanych;
        UstawieniaAplikacji _ustawieniaAplikacji;
        List<Kontrahent> _listaKontrahentow = new List<Kontrahent>();

        /// <summary>
        /// Wstrzyknięcie zależności i logik biznesowych do aplikacji
        /// </summary>
        /// <param name="bazaDanych">rodzaj bazy na jakiej współpracuje aplikacja</param>
        /// <param name="kopiuj">klasa odpowiedzialna za funkcję kopiowania danych do schowka</param>
        /// <param name="ustawienia">klasa odpowiedająca za przetrzymywanie ustawień aplikacji</param>
        /// <param name="plik">klasa odpowiedzialna za funkcję okna wyboru pliku lub folderu</param>
        public Glowny(IBazaDanych bazaDanych, IKopiujPole kopiuj, UstawieniaAplikacji ustawienia)
        {
            InitializeComponent();

            _bazaDanych = bazaDanych;
            _kopiuj = kopiuj;
            _ustawieniaAplikacji = ustawienia;
            
            //pobranie listy kontrahentów z bazy danych
            pobierzListeKontrahentow();
            
            //napełnienie drzewa danymi pobranymi z bazy
            napelnijDrzewo();
        }

        private void Glowny_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Metoda mapująca dane kontrahenta do formatek tekstowych, po kliknięciu w gałąź drzewa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapujDaneKontrahenta(object sender, TreeViewEventArgs e)
        {
            var kontrahent = _listaKontrahentow.Where(x => x.kontrahent_id == (string)e.Node.Tag);
            foreach (var item in kontrahent)
            {
                textBoxKontrahentIdentyfikator.Text = item.kontrahent_idn;
                textBoxKontrahentNazwa.Text = item.kontrahent_nazwa;
                textBoxERPBaza.Text = item.erp_baza;
                textBoxERPHaslo.Text = item.erp_haslo;
                textBoxERPLogin.Text = item.erp_login;
                textBoxERPSerwer.Text = item.erp_serwer;
                textBoxVPNHaslo.Text = item.vpn_haslo;
                textBoxVPNIp.Text = item.vpn_ip;
                textBoxVPNRodzajVpn.Text = item.vpn_nazwa;
                textBoxRDPHaslo.Text = item.rdp_haslo;
                textBoxRDPIp.Text = item.rdp_ip;
                textBoxRDPUzytkownik.Text = item.rdp_login;
                richTextBoxAdnotacje.Text = item.adnotacje;
                labelId.Text = item.kontrahent_id;
                textBoxSciezkaDoFolderuKontrahenta.Text = item.sciezka_folderu;
            }
            
        }

        /// <summary>
        /// Uruchomienie okna opcji aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opcjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ustawienia = new Ustawienia(_ustawieniaAplikacji);
            ustawienia.ShowDialog();
        }

        /// <summary>
        /// Metoda odpowiadająca za skopiowanie zawartości pola tekstowego
        /// Pole tekstowe którego zawartość jest kopiowana, szukane jest po nazwie pola "AccessibleName"
        /// Pole kopiowane musi mieć taką samą nazwę AccessibleName jak przycisk który został wciśnięty 
        /// button.AccessibleName = textBox.AccessibleName
        /// </summary>
        /// <param name="sender">przycisk który został wciśnięty</param>
        /// <param name="e"></param>
        private void kopiuj(object sender, EventArgs e)
        {
            var przycisk = (Button)sender;
            var nazwaPrzycisku = przycisk.AccessibleName;
            var ojciecPrzycisku = przycisk.Parent;            
            var nazwaTextBox = ojciecPrzycisku.Controls.OfType<TextBox>().ToList();
            var tekstDoSkopiowania = "<nie skopiowano>";
            foreach (var textBox in nazwaTextBox.Where(x => x.AccessibleName == nazwaPrzycisku))
            {
               tekstDoSkopiowania = textBox.Text;
            }
            _kopiuj.kopijDoSchowka(tekstDoSkopiowania);

        }

        /// <summary>
        /// Metoda zapisująca lub aktualizująca dane kontrahenta w bazie danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zapiszDaneKontrahenta(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var kontrahent = new Kontrahent
            {
                kontrahent_id = labelId.Text,
                kontrahent_idn = textBoxKontrahentIdentyfikator.Text.Trim(),
                kontrahent_nazwa = textBoxKontrahentNazwa.Text.Trim(),
                erp_baza = textBoxERPBaza.Text.Trim(),
                erp_login = textBoxERPLogin.Text.Trim(),
                erp_haslo = textBoxERPHaslo.Text.Trim(),
                erp_serwer = textBoxERPSerwer.Text.Trim(),
                rdp_haslo = textBoxRDPHaslo.Text.Trim(),
                rdp_login = textBoxRDPUzytkownik.Text.Trim(),
                rdp_ip = textBoxRDPIp.Text.Trim(),
                vpn_haslo = textBoxVPNHaslo.Text.Trim(),
                vpn_login = textBoxVPNUzytkownik.Text.Trim(),
                vpn_nazwa = textBoxVPNRodzajVpn.Text.Trim(),
                vpn_ip = textBoxVPNIp.Text.Trim(),
                sciezka_folderu = textBoxSciezkaDoFolderuKontrahenta.Text,
                adnotacje = richTextBoxAdnotacje.Text.Trim()                
            };
            if (_bazaDanych.CzyIstniejeKontrahent(kontrahent))
            {
                _bazaDanych.EdytujKontrahenta(kontrahent);
            }
            else
            {
                _bazaDanych.DodajKontrahenta(kontrahent);
            };
            Cursor.Current = Cursors.Default;
            pobierzListeKontrahentow();
            napelnijDrzewo();
        }

        /// <summary>
        /// Metoda pobierająca aktualną listę kontrahentów z bazy danych
        /// </summary>
        public void pobierzListeKontrahentow()
        {
            _listaKontrahentow.Clear();
            _listaKontrahentow = _bazaDanych.pobierzKontrahentow();                        
        }

        /// <summary>
        /// Metoda napełniająca drzewo kontrahentów, danymi pobranymi z bazy danych poprzez metodę "pobierzListeKontrahentow()"
        /// </summary>
        public void napelnijDrzewo()
        {            
            treeViewKontrahenci.Nodes.Clear();
            int index = 0;
            foreach (var kontrahent in _listaKontrahentow)
            {
                var galaz = new TreeNode(kontrahent.kontrahent_idn);
                galaz.Tag = kontrahent.kontrahent_id;
                galaz.Nodes.Add("Prace");
                galaz.Nodes.Add("Opcja 1");
                galaz.Nodes.Add("Opcja 2");
                treeViewKontrahenci.Nodes.Add(galaz);                
                // Add a child treenode for each Order object in the current Customer object.
                //for (int i = 0; i < 3; i++)
                //{
                //    treeViewKontrahenci.Nodes[index].Nodes.Add(
                //      new TreeNode("Przykład"));                    
                //}
                //index++;
            }
            
            treeViewKontrahenci.EndUpdate();
        }

        /// <summary>
        /// Metoda czyszcząca wszystkie pola typu textBox, znajdujące się w wewnątrz goupbox'ów[ERP, RDP, VPN, kontrachent]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void czyscTextBoxy(object sender, EventArgs e)
        {
            var ERP = groupBoxERP.Controls.OfType<TextBox>().ToList();
            var RDP = groupBoxRDP.Controls.OfType<TextBox>().ToList();
            var VPN = groupBoxVPN.Controls.OfType<TextBox>().ToList();
            var kon = groupBoxKontrahent.Controls.OfType<TextBox>().ToList();
            var union = ERP.Union(RDP.Union(VPN.Union(kon)));
            foreach (Control c in union)
            {                
                c.Text = "";
                richTextBoxAdnotacje.Clear();
                labelId.Text = "0";
            }
            textBoxKontrahentIdentyfikator.Focus();
        }

        /// <summary>
        /// Metoda usuwająca zaznaczonego kontrahenta z bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usunKontrahenta(object sender, EventArgs e)
        {
            var kontrahent = new Kontrahent
            {
                kontrahent_id = labelId.Text,
                kontrahent_idn = textBoxKontrahentIdentyfikator.Text.Trim(),
                kontrahent_nazwa = textBoxKontrahentNazwa.Text.Trim(),
                erp_baza = textBoxERPBaza.Text.Trim(),
                erp_login = textBoxERPLogin.Text.Trim(),
                erp_haslo = textBoxERPHaslo.Text.Trim(),
                erp_serwer = textBoxERPSerwer.Text.Trim(),
                rdp_haslo = textBoxRDPHaslo.Text.Trim(),
                rdp_login = textBoxRDPUzytkownik.Text.Trim(),
                rdp_ip = textBoxRDPIp.Text.Trim(),
                vpn_haslo = textBoxVPNHaslo.Text.Trim(),
                vpn_login = textBoxVPNUzytkownik.Text.Trim(),
                vpn_nazwa = textBoxVPNRodzajVpn.Text.Trim(),
                vpn_ip = textBoxVPNIp.Text.Trim(),
                sciezka_folderu = @"C:\",
                adnotacje = richTextBoxAdnotacje.Text.Trim()
            };
            DialogResult dialogResult = MessageBox.Show($"Czy aby na pewno chcesz usunąć kontrahenta: {kontrahent.kontrahent_idn}?", "Pytanie?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                _bazaDanych.usunKontrahenta(kontrahent);
                pobierzListeKontrahentow();
                napelnijDrzewo();
                czyscTextBoxy(sender,e);
                Cursor.Current = Cursors.Default;
            }            
        }

        
    }
}
