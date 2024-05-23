using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.BussinessObject
{
    public class BaseObject
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedOnUTC { get; set; }

        public DateTime UpdatedOnUTC { get; set; }

        public string IPAddress { get; set; }

        public BaseObject() { }
        /// <summary>
        /// Read data common column
        /// </summary>
        /// <param name="reader"></param>
        public BaseObject(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (int)reader["Id"] : default(int);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            IPAddress = DBNull.Value != reader["IPAddress"] ? (string)reader["IPAddress"] : default(string);
            CreatedOnUTC = DBNull.Value != reader["CreatedOnUTC"] ? (DateTime)reader["CreatedOnUTC"] : default(DateTime);
            UpdatedOnUTC = DBNull.Value != reader["UpdatedOnUTC"] ? (DateTime)reader["UpdatedOnUTC"] : default(DateTime);

        }
    }
}
