using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Pomocnik_3._0.Domain;

namespace Pomocnik_3._0.BusinessLogic
{
    public class AutoryzacjaFactory
    {
        public IAutoryzacja rodzajAutoryzacji(RodzajeAutoryzacji rodzaj)
        {
            switch (rodzaj)
            {
                case RodzajeAutoryzacji.Brak:
                    return new AutoryzacjaBrak();
                case RodzajeAutoryzacji.Wlasne:
                    return new AutoryzacjaWlasne();
                case RodzajeAutoryzacji.SQL:
                    MessageBox.Show($"Implementacja dla {rodzaj} nie została jeszcze dodana aplikacja zostanie uruchomiona z autoryzacją {default(RodzajeAutoryzacji)}", "Logowanie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new AutoryzacjaBrak();
                default:
                    MessageBox.Show($"Implementacja dla {rodzaj} nie została jeszcze dodana aplikacja zostanie uruchomiona z autoryzacją {default(RodzajeAutoryzacji)}", "Logowanie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new AutoryzacjaBrak();
            }
        }
    }
}
