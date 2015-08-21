using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Data;

namespace Basic_Financial_Tracker
{
    public class Model
    {
        private SQLiteConnection connection;
        private string connectionString = @"Data Source = BasicFinancialTracker.db;Version=3";
        public Model()
        {
            this.connection = new SQLiteConnection(this.connectionString);
            this.openConnection();
            this.closeConnection();
        }
        #region Connection Functions
        public bool openConnection()
        {
            try
            {
                this.connection.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }
            return false;
        }
        public bool closeConnection()
        {
            try
            {
                this.connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            return false;
        }
        #endregion
        #region Queries
        #region Select Queries
        public Dictionary<string,string> selectAll(string table)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            string selectQuery = "SELECT * FROM " + table;
            
            this.openConnection();
            try
            {
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, this.connection);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();
                Console.WriteLine(dataReader.FieldCount);
                while (dataReader.Read())
                {
                    data.Add(dataReader.GetString(0), dataReader.GetString(1));
                    MessageBox.Show(dataReader.GetString(0) + " - " + dataReader.GetString(1));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }

            this.closeConnection();
            return data;
        }
        public Dictionary<string, string> selectWhere(string table, List<string> columns, List<string> values)
        {
            if (columns.Count != values.Count) return null;

            Dictionary<string, string> data = new Dictionary<string, string>();
            string selectQuery = "SELECT * FROM " + table + "WHERE";

            for (int i = 0; i < columns.Count; i++)
            {
                selectQuery = selectQuery + " " + columns[i] + "=" + values[i];
            }

            this.openConnection();
            try
            {
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, this.connection);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    data.Add(dataReader.GetString(0), dataReader.GetString(1));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }

            this.closeConnection();
            return data;
        }
        public void populateDataGrid(string databinding, string table)
        {
            string selectQuery = "SELECT * FROM " + table;

            this.openConnection();
            try
            {
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, this.connection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand);
                DataSet tableData = new DataSet();
                adapter.Fill(tableData, databinding);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }

            this.closeConnection();
        }
        public void populateDataGrid(string databinding, string table, List<string> columns, List<string> values)
        {
            if (columns.Count != values.Count) return;

            string selectQuery = "SELECT * FROM " + table + "WHERE";

            for (int i = 0; i < columns.Count; i++)
            {
                selectQuery = selectQuery + " " + columns[i] + "=" + values[i];
            }

            this.openConnection();
            try
            {
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, this.connection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand);
                DataSet tableData = new DataSet();
                adapter.Fill(tableData, databinding);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }

            this.closeConnection();
        }
        #endregion Select Queries
        #region DB Manipulation Queries
        public void insert()
        {
            this.openConnection();
            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }
            this.closeConnection();
        }
        public void update(string table, string conditionColumn, string conditionValue, List<string> columns, List<string> values)
        {
            if (columns.Count != values.Count) return;

            string updateQuery = "UPDATE " + table + " SET";

            updateQuery = updateQuery + " " + columns[0] + " = '" + values[0] + "'";
            for (int i = 1; i < columns.Count; i++)
            {
                updateQuery = updateQuery + ", " + columns[i] + " = '" + values[i] + "'";
            }

            updateQuery = updateQuery + " WHERE " + conditionColumn + " = '" + conditionValue + "'";
            MessageBox.Show(updateQuery);
            this.openConnection();
            try
            {
                SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, this.connection);
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }
            this.closeConnection();
        }
        public void delete(string table, string column, string value)
        {
            string deleteQuery = "DELETE FROM " + table + " WHERE " + column + " = " + value;
            this.openConnection();
            try
            {
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, this.connection);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.StackTrace.ToString());
            }
            this.closeConnection();
        }
        #endregion DB Manipulation Queries
        #endregion Queries
    }
}
