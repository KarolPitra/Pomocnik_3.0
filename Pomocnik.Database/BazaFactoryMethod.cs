using Pomocnik.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pomocnik.Database
{
    public class BazaFactoryMethod
    {
        public IBazaManager bazaFactory(RodzajBaz typ)
        {
            switch (typ)
            {
                case RodzajBaz.Domyslny:
                    return new SQLiteDaneDostep();
                case RodzajBaz.SQLLite:
                    return new SQLiteDaneDostep();
                case RodzajBaz.SQLServer:
                    MessageBox.Show($"Nie zaimplementowano jesze możliwości połączenia z bazą {typ}, program zostanie uruchomiony z bazą SQLLite", "Połączenie z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new SQLiteDaneDostep();
                default:
                    MessageBox.Show($"Nie zaimplementowano jesze możliwości połączenia z bazą {typ}, program zostanie uruchomiony z bazą SQLLite", "Połączenie z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new SQLiteDaneDostep();
            }
        }
    }
}
