using System;
using System.Collections.Generic;
using System.Text;

namespace Pomocnik_3._0.Domain
{
    public interface IAutoryzacja
    {
        bool autoryzuj(Uzytkownik uzytkownik);
    }
}
