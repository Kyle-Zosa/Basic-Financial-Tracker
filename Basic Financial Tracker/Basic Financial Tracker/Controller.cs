using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace Basic_Financial_Tracker
{
    public class Controller
    {
        MainView view;
        Model model;
        public Controller(MainView view, Model model)
        {
            this.view = view;
            this.model = model;
        }
        public void updateView()
        {
            List<string> updateColumns = new List<string>();
            List<string> updateValues = new List<string>();

            updateColumns.Add("VALUE");
            updateValues.Add("3500.60");
            // model.update("Constants", "NAME", "ORIGINAL BALANCE", updateColumns, updateValues);

            List<string> selectColumns = new List<string>();
            List<string> selectValues = new List<string>();
            Console.WriteLine("HELLO!!!");
            foreach (KeyValuePair<string, string> entry in model.selectAll("sqlite_master"))
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
