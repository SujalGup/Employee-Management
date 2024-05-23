using Core.BussinessObject;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryDB
    {
        public static Logger Log = LogManager.GetLogger("Data Layer");

        /// <summary>
        /// Adding Data to Category Table
        /// </summary>
        /// <param name="category"></param>
        public static void Add(Category category)
        {
            Log.Debug("Adding {category.Name} in Category Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert INTO Category(Name, Description, Mandatory, CreatedBy, UpdatedBy,  CreatedOnUTC, UpdatedOnUTC ,IPAddress) Values(@Name,  @Description, @Mandatory,  @CreatedBy, @UpdatedBy, @CreatedOnUTC, @UpdatedOnUTC,  @IPAddress); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "Name", DbType.String, category.Name);
            db.AddInParameter(cmd, "Description", DbType.String, category.Description);
            db.AddInParameter(cmd, "Mandatory", DbType.String, category.Mandatory);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, category.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, category.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, category.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, category.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, category.UpdatedOnUTC);
            category.Id = int.Parse(db.ExecuteScalar(cmd).ToString());
            Log.Debug("Added {category.Name} in Category Db");


        }

        /// <summary>
        /// Updating Data of Category Table
        /// </summary>
        /// <param name="category"></param>


        public static void Update(Category category)
        {
            Log.Debug("Updating category having {category.Id} in Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Update Category set Name=@Name, Description=@Description,  Mandatory=@Mandatory,  CreatedBy=@CreatedBy, UpdatedBy=@UpdatedBy, IPAddress=@IPAddress, CreatedOnUTC=@CreatedOnUTC, UpdatedOnUTC=@UpdatedOnUTC where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.String, category.Id);
            db.AddInParameter(cmd, "Name", DbType.String, category.Name);
            db.AddInParameter(cmd, "Description", DbType.String, category.Description);
            db.AddInParameter(cmd, "Mandatory", DbType.String, category.Mandatory);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, category.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, category.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, category.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, category.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, category.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Updated category having {category.Id} in Db");
        }
        /// <summary>
        ///  Delete Data of Category Table
        /// </summary>
        /// <param name="category"></param>


        public static void Delete(int id)
        {
            Log.Debug("Deleting category to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("delete from Category where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Deleting category to DB");
        }

        /// <summary>
        /// Fetching Data by name from Category Table
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Category GetByName(string name)
        {
            Log.Debug("Fetching Category to DB by name");
            Category category = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Category where Name=@name");
            db.AddInParameter(cmd, "name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                category = new Category(reader);
            }
            Log.Debug("Fetching Category to DB by Name");
            return category;

        }

        /// <summary>
        /// Fetching Data by id from Category Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        public static Category GetById(int id)
        {
            Log.Debug("Deleting Category to DB");
            Category category = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from category where Id=@Iid");
            db.AddInParameter(cmd, "Iid", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                category = new Category(reader);
            }
            Log.Debug("Deleted Category to DB");
            return category;

        }
        /// <summary>
        /// Fetching List of Category
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetAll()
        {
            Log.Debug("Fetching Record From DB");
            List<Category> categoryList = new List<Category>();

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Category");
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                Category category = new Category(reader);
                categoryList.Add(category);
            }
            Log.Debug($"Fetched Record From DB count - {categoryList.Count}");
            return categoryList;

        }

    }
}
