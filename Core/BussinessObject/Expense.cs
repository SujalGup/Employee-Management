using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.BussinessObject
{
    public partial class Expense : BaseObject
    {
        public string Name { get; set; }
        public string Report { get; set; }

        public string Category { get; set; }

        public string Amount { get; set; }


        public Expense() 
        {
        }
        /// <summary>
        /// Reading Data From Expense Table
        /// </summary>
        /// <param name="reader"></param>
        public Expense(IDataReader reader) : base(reader)
        {
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            Report = DBNull.Value != reader["Report"] ? (string)reader["Report"] : default(string);
            Category = DBNull.Value != reader["Category"] ? (string)reader["Category"] : default(string);
            Amount = DBNull.Value != reader["Amount"] ? (string)reader["Amount"] : default(string);

        }
    }
}
