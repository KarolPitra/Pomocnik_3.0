using System;
using System.Collections.Generic;
using System.Text;

namespace Pomocnik.Domain
{
    public class KontrahentModel
    {
        public string kontrahent_id { get; set; }
        public string kontrahent_idn { get; set; }
        public string kontrahent_nazwa { get; set; }
        public string erp_login { get; set; }
        public string erp_haslo { get; set; }
        public string erp_serwer { get; set; }
        public string erp_baza { get; set; }
        public string rdp_ip { get; set; }
        public string rdp_login { get; set; }
        public string rdp_haslo { get; set; }
        public string vpn_nazwa { get; set; }
        public string vpn_haslo { get; set; }
        public string vpn_login { get; set; }
        public string vpn_ip { get; set; }
        public string adnotacje { get; set; }
        public string sciezka_folderu { get; set; }
    }
}
