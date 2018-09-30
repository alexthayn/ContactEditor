using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEditor.Services
{
    public class SqliteDataProvider : IDataProvider
    {
        public const string FileName = "Contacts.db";

        /// <summary>
        /// The full data path of the sqlite database file
        /// </summary>
        public string DataPath { get; private set; }

        /// <summary>
        /// The connection string
        /// </summary>
        protected string ConnectionString { get; set; }

        public SqliteDataProvider()
        {
            DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = DataPath;
            ConnectionString = builder.ToString();

            if (!File.Exists(DataPath))
            {
                SQLiteConnection.CreateFile(DataPath);

                string sqlCreateTable = @"CREATE TABLE Contact(
                    Id varchar(40) PRIMARY KEY,
                    FirstName varchar(40) NOT NULL,
                    LastName varchar(40),
                    Company varchar(40),
                    JobTitle varchar(100),
                    MobilePhone varchar(30),
                    Birthday varchar(20),
                    Email varchar(100),
                    Address varchar(255),
                    Notes varchar(255))";

                ExeNonQueryCommand(sqlCreateTable);
            }
        }

        public bool Delete(IContact contact)
        {
            string sqlDelete = $@"DELETE FROM Contact WHERE Id='{contact.Id}'";
            return ExeNonQueryCommand(sqlDelete);
        }

        public List<IContact> GetAllContacts()
        {
            var list = new List<IContact>();
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sqlInsert = $@"SELECT * FROM Contact";
                using(SQLiteCommand cmd = new SQLiteCommand(sqlInsert, conn))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd))
                    {
                        var dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        foreach(DataRow row in dataTable.Rows)
                        {
                            var contact = new Contact();
                            contact.Id = (row[0].ToString());
                            contact.FirstName = row["FirstName"].ToString();
                            contact.LastName = row["LastName"] != null ? row["LastName"].ToString() : string.Empty;
                            contact.Company = row["Company"] != null ? row["Company"].ToString() : string.Empty;
                            contact.JobTitle = row["JobTitle"] != null ? row["JobTitle"].ToString() : string.Empty;
                            contact.MobilePhone = row["MobilePhone"] != null ? row["MobilePhone"].ToString() : string.Empty;
                            contact.Birthday = row["Birthday"] != null ?(row["Birthday"]).ToString() : string.Empty;
                            contact.Email = row["Email"] != null ? row["Email"].ToString() : string.Empty;
                            contact.Address = row["Address"] != null ? row["Address"].ToString() : string.Empty;
                            contact.Notes = row["Notes"] != null ? row["Notes"].ToString() : string.Empty;
                            list.Add(contact);
                        }
                    }
                }
            }
            return list;
        }

        public IContact GetContactById(int id)
        {
            Contact contact = null;
            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sqlinsert = $@"SELECT * FROM Contact WHERE Id='{id}'";
                using(SQLiteCommand cmd = new SQLiteCommand(sqlinsert, conn))
                {
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        contact = new Contact();
                        contact.FirstName = dr["FirstName"].ToString();
                        contact.LastName = dr["LastName"] != null ? dr["LastName"].ToString() : string.Empty;
                        contact.Company = dr["Company"] != null ? dr["Company"].ToString() : string.Empty;
                        contact.JobTitle = dr["JobTitle"] != null ? dr["JobTitle"].ToString() : string.Empty;
                        contact.MobilePhone = dr["MobilePhone"] != null ? dr["MobilePhone"].ToString() : string.Empty;
                        contact.Birthday = dr["Birthday"] != null ? (dr["Birthday"]).ToString() : string.Empty;
                        contact.Email = dr["Email"] != null ? dr["Email"].ToString() : string.Empty;
                        contact.Address = dr["Address"] != null ? dr["Address"].ToString() : string.Empty;
                        contact.Notes = dr["Notes"] != null ? dr["Notes"].ToString() : string.Empty;
                    }
                }
            }
            return contact;
        }

        public bool Insert(IContact contact)
        {
            string sqlInsert = $@"INSERT INTO Contact ( Id, FirstName, LastName, Company, JobTitle, MobilePhone, Birthday, Email, Address, Notes) VALUES (
                '{contact.Id}',
                '{contact.FirstName}',
                '{contact.LastName}',
                '{contact.Company}',
                '{contact.JobTitle}',
                '{contact.MobilePhone}',
                '{contact.Birthday}',
                '{contact.Email}',
                '{contact.Address}',
                '{contact.Notes}')";
            return ExeNonQueryCommand(sqlInsert);
        }

        public bool Update(IContact contact)
        {
            string sqlUpdate = $@"UPDATE Contact SET
                FirstName='{contact.FirstName}',
                LastName='{contact.LastName}',
                Company='{contact.Company}',
                JobTitle='{contact.JobTitle}',
                MobilePhone='{contact.MobilePhone}',
                Birthday='{contact.Birthday}',
                Email='{contact.Email}',
                Address='{contact.Address}',
                Notes='{contact.Notes}'
                WHERE Id='{contact.Id}'";
            return ExeNonQueryCommand(sqlUpdate);
        }

        private bool ExeNonQueryCommand(string sqlCommand)
        {
            bool isSuccess = false;

            using(SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using(SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                {
                    isSuccess = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            return isSuccess;
        }
    }
}
