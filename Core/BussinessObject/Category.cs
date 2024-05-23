using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.BussinessObject
{
    public partial class Category : BaseObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Mandatory { get; set; }
        public Category()
        {
        
        }
        /// <summary>
        /// Reading Data From Category Table
        /// </summary>
        /// <param name="reader"></param>
        public Category(IDataReader reader) : base(reader)
        {
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            Description = DBNull.Value != reader["Description"] ? (string)reader["Description"] : default(string);
            Mandatory = DBNull.Value != reader["Mandatory"] ? (string)reader["Mandatory"] : default(string);

        }
    }
}
