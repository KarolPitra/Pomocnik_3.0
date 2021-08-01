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
    public partial class Ustawienia : Form
    {
        private UstawieniaUzytkownika _ustawieniaAplikacji;
        List<RadioButton> _radioButton = new List<RadioButton>();
        private string _haslo;
        private string _login;
        private int _sposobAutoryzacji;
        
        public Ustawienia(UstawieniaUzytkownika ustawieniaAplikacji)
        {
            InitializeComponent();

            _ustawieniaAplikacji = ustawieniaAplikacji;

            ustawDaneNaFormularzu();            
            
        }

        private void ustawDaneNaFormularzu()
        {
            checkBoxZapamietajPoswiadczenia.Checked = _ustawieniaAplikacji.czyZapamietacLogin;
            _login = _ustawieniaAplikacji.logowanieLogin;
            _sposobAutoryzacji = _ustawieniaAplikacji.sposobAutoryzacji;
            textBoxHaslo.Text = _haslo;
            textBoxLogin.Text = _login;
            _radioButton = groupBoxSposobAutoryzacji.Controls.OfType<RadioButton>().ToList();
            foreach (var item in _radioButton.Where(x => x.AccessibleName == Enum.GetName(typeof(RodzajeAutoryzacji), _sposobAutoryzacji)))
            {
                item.Checked = true;
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            _ustawieniaAplikacji.logowanieLogin = textBoxLogin.Text;
            _ustawieniaAplikacji.logowanieHaslo = textBoxHaslo.Text;
            _ustawieniaAplikacji.czyZapamietacLogin = checkBoxZapamietajPoswiadczenia.Checked;
            _ustawieniaAplikacji.sposobAutoryzacji = (int)Enum.Parse(typeof(RodzajeAutoryzacji), groupBoxSposobAutoryzacji.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).AccessibleName);
            
        }

        public void wyborPliku(object sender, EventArgs e)
        {
            /*
            var sciezka = _plik.wyborPliku();
            var przycisk = (Button)sender;
            switch (przycisk.Name)
            {
                case "buttonSciezkaDoPlikuZKluczem":
                    textBoxSciezkaDoPlikuZKluczem.Text = sciezka;
                    break;
                case "buttonSciezkaDoPlikuExcel":
                    textBoxSciezkaDoPlikuExcel.Text = sciezka;
                    break;
                default:
                    break;
            }
            */
        }

        public void wyborFolderu(object sender, EventArgs e)
        {
            /*
            var sciezka = _plik.wyborFolderu();
            var przycisk = (Button)sender;
            switch (przycisk.Name)
            {
                case "buttonSciezkaDoPlikuZKluczem":
                    textBoxSciezkaDoPlikuZKluczem.Text = sciezka;
                    break;
                case "buttonSciezkaDoFolderuSimple":
                    textBoxSciezkaDoFolderuSimple.Text = sciezka;
                    break;
                case "buttonSciezkaDoGlownegoKataloguFirm":
                    textBoxSciezkaDoGlownegoKataloguFirm.Text = sciezka;
                    break;
                default:
                    break;
            }
            */
        }
    }
}
