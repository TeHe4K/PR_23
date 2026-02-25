using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace PR23_Konevskii.Classes
{
    public class Connection
    {
        public List<Gift> gifts = new List<Gift>();

        public enum tabels
        {
            gifts
        }
        public string localPath = "";

        public OleDbDataReader QueryAccess(string query)
        {
            try
            {
                localPath = Directory.GetCurrentDirectory();
                OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + localPath + "/accesbase.accdb");
                connect.Open();
                OleDbCommand cmd = new OleDbCommand(query, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }
        public void LoadData (tabels zap)
        {
            try
            {
                OleDbDataReader itemQuery = QueryAccess("SELECT * FROM [" + zap.ToString() + "] ORDER BY [Код]");
                gifts.Clear();
                while (itemQuery.Read())
                {
                    Gift newE1 = new Gift();
                    newE1.id = Convert.ToInt32(itemQuery.GetValue(0));
                    newE1.name = Convert.ToString(itemQuery.GetValue(1));
                    newE1.description = Convert.ToString(itemQuery.GetValue(2));
                    newE1.date = Convert.ToString(itemQuery.GetValue(3));
                    newE1.adress = Convert.ToString(itemQuery.GetValue(4));
                    newE1.mail = Convert.ToString(itemQuery.GetValue(5));

                    gifts.Add(newE1);
                }
            }
            catch
            {
                Console.WriteLine("NULL");
            }
        }
        public int SetLastId(tabels tabel)
        {
            try
            {
                LoadData(tabel);
                switch (tabel.ToString())
                {
                    case "gifts":
                        if (gifts.Count >= 1)
                        {
                            int max_status = gifts[0].id;
                            max_status = gifts.Max(x => x.id);
                            return max_status + 1;
                        }
                        else return -1;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
