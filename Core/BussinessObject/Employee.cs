using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BussinessObject
{
    public partial class Employee : BaseObject
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public string Department { get; set; } 

        public string Description { get; set; }



        public Employee()
        {

        }
/// <summary>
/// read data from employe table
/// </summary>
/// <param name="reader"></param>
        public Employee(IDataReader reader):base(reader)
        {
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default(string);
            Phone = DBNull.Value != reader["Phone"] ? (string)reader["Phone"] : default(string);
            Department = DBNull.Value != reader["Department"] ? (string)reader["Department"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            
        }
    }

    
}
