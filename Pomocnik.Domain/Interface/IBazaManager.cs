using System;
using System.Collections.Generic;
using System.Text;

namespace Pomocnik.Domain
{
    public interface IBazaManager
    {
        List<UzytkownikModel> LadujUzytkownikow();
        void DodajUzytkownika(UzytkownikModel uzytkownik);
        bool CzyIstniejeKontrahent(KontrahentModel kontrahent);
        void EdytujKontrahenta(KontrahentModel kontrahent);
        void DodajKontrahenta(KontrahentModel kontrahent);
        string LadujConnectionString(string id);
        List<KontrahentModel> pobierzKontrahentow();
        void usunKontrahenta(KontrahentModel kontrahent);
    }
}
