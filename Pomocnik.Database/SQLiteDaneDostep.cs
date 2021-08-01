using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Windows.Forms;
using Pomocnik.Domain;
using System.Collections.Specialized;

namespace Pomocnik.Database
{
    public class SQLiteDaneDostep : IBazaManager
    {
        public List<UzytkownikModel> LadujUzytkownikow()
        {
            using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
            {
                var dane = cnn.Query<UzytkownikModel>("SELECT * FROM uzs", new DynamicParameters());
                return dane.ToList();
            }
        }

        public void DodajUzytkownika(UzytkownikModel uzytkownik)
        {
            using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
            {
                cnn.Execute("INSERT INTO uzs (uzs_idn, uzs_haslo) VALUES (@uzs_idn, @uzs_haslo)", uzytkownik);
            }
        }

        public bool CzyIstniejeKontrahent(KontrahentModel kontrahent)
        {
            using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
            {
                var exists = cnn.ExecuteScalar<bool>("SELECT COUNT(1) FROM kontrahent WHERE kontrahent_id = @kontrahent_id", kontrahent);
                return exists;
            }
        }

        public void EdytujKontrahenta(KontrahentModel kontrahent)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
                {
                    cnn.Execute("UPDATE kontrahent SET" +
                                "   kontrahent_idn = @kontrahent_idn" +
                                "   ,kontrahent_nazwa = @kontrahent_nazwa" +
                                "   ,erp_login = @erp_login" +
                                "   ,erp_haslo = @erp_haslo" +
                                "   ,erp_serwer = @erp_serwer" +
                                "   ,erp_baza = @erp_baza" +
                                "   ,rdp_ip = @rdp_ip" +
                                "   ,rdp_login = @rdp_login" +
                                "   ,rdp_haslo = @rdp_haslo" +
                                "   ,vpn_nazwa = @vpn_nazwa" +
                                "   ,vpn_haslo = @vpn_haslo" +
                                "   ,vpn_login = @vpn_login" +
                                "   ,adnotacje = @adnotacje" +
                                "   ,sciezka_folderu = @adnotacje" +
                                " WHERE kontrahent_id = @kontrahent_id"
                                , kontrahent);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"{kontrahent.kontrahent_idn}\n{ex.Message}", $"Edytowanie kontrahenta [{kontrahent.kontrahent_idn}]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DodajKontrahenta(KontrahentModel kontrahent)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
                {
                    cnn.Execute("INSERT INTO kontrahent " +
                                "(" +
                                "   kontrahent_idn" +
                                "   ,kontrahent_nazwa" +
                                "   ,erp_login" +
                                "   ,erp_haslo" +
                                "   ,erp_serwer" +
                                "   ,erp_baza" +
                                "   ,rdp_ip" +
                                "   ,rdp_login" +
                                "   ,rdp_haslo" +
                                "   ,vpn_nazwa" +
                                "   ,vpn_haslo" +
                                "   ,vpn_login" +
                                "   ,vpn_ip" +
                                "   ,adnotacje" +
                                "   ,sciezka_folderu" +
                                ") " +
                                "VALUES " +
                                "(" +
                                "   @kontrahent_idn" +
                                "   ,@kontrahent_nazwa" +
                                "   ,@erp_login" +
                                "   ,@erp_haslo" +
                                "   ,@erp_serwer" +
                                "   ,@erp_baza" +
                                "   ,@rdp_ip" +
                                "   ,@rdp_login" +
                                "   ,@rdp_haslo" +
                                "   ,@vpn_nazwa" +
                                "   ,@vpn_haslo" +
                                "   ,@vpn_login" +
                                "   ,@vpn_ip" +
                                "   ,@adnotacje" +
                                "   ,@sciezka_folderu" +
                                ")", kontrahent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {kontrahent.kontrahent_idn}", $"Dodawanie kontrahenta [{kontrahent.kontrahent_idn}]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<KontrahentModel> pobierzKontrahentow()
        {
            using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
            {
                var dane = cnn.Query<KontrahentModel>("SELECT * FROM kontrahent", new DynamicParameters());
                return dane.ToList();
            }
        }

        public void usunKontrahenta(KontrahentModel kontrahent)
        {
            using (IDbConnection cnn = new SQLiteConnection(LadujConnectionString()))
            {
                cnn.Query<KontrahentModel>("DELETE FROM kontrahent WHERE kontrahent_id = @kontrahent_id", kontrahent);                
            }
        }

        public string LadujConnectionString(string id ="PomocnikDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
