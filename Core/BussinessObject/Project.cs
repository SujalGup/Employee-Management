using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.BussinessObject
{
    public partial class Project : BaseObject
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public Project() 
        { 
        
        }
        /// <summary>
        /// Reading Data From Project Table
        /// </summary>
        /// <param name="reader"></param>

        public Project(IDataReader reader) : base(reader)
        {
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            Description = DBNull.Value != reader["Description"] ? (string)reader["Description"] : default(string);

        }
    }
}
