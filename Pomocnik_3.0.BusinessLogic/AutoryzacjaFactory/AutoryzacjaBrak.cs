using System;
using System.Collections.Generic;
using System.Text;
using Pomocnik_3._0.Domain;

namespace Pomocnik_3._0.BusinessLogic
{
    class AutoryzacjaBrak : IAutoryzacja
    {
        public bool autoryzuj(Uzytkownik uzytkownik)
        {
            return true;
        }
    }
}
