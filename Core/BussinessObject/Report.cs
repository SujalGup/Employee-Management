using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Core.BussinessObject
{
    public partial class Report : BaseObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Employee {  get; set; }

        public string Status { get; set; }

        public Report() 
        { 

        }

        /// <summary>
        /// Reading Data From Report Table
        /// </summary>
        /// <param name="reader"></param>
        public Report(IDataReader reader) : base(reader)
        {
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            Description = DBNull.Value != reader["Description"] ? (string)reader["Description"] : default(string);
            Employee = DBNull.Value != reader["Employee"] ? (string)reader["Employee"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);

        }
    }
}
