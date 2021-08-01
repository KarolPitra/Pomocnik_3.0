using System;
using System.Collections.Generic;
using System.Text;

namespace Pomocnik_3._0.Domain
{
    public interface IBazaDanych
    {
        List<Uzytkownik> LadujUzytkownikow();
        void DodajUzytkownika(Uzytkownik uzytkownik);
        bool CzyIstniejeKontrahent(Kontrahent kontrahent);
        void EdytujKontrahenta(Kontrahent kontrahent);
        void DodajKontrahenta(Kontrahent kontrahent);
        string LadujConnectionString(string id);
        List<Kontrahent> pobierzKontrahentow();
        void usunKontrahenta(Kontrahent kontrahent);
    }
}
