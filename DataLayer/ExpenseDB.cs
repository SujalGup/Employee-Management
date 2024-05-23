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
using Ubiety.Dns.Core.Records;

namespace DataLayer
{
    public class ExpenseDB
    {

        public static Logger Log = LogManager.GetLogger("Data Layer");

        /// <summary>
        /// Adding Data To Expanse Table
        /// </summary>
        /// <param name="expense"></param>
        public static void Add(Expense expense)
        {
            Log.Debug("Adding Expense to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert INTO Expense(Name, Report, Category, Amount,  CreatedBy, UpdatedBy, IPAddress, CreatedOnUTC, UpdatedOnUTC) Values(@Name, @Report, @Category, @Amount, @CreatedBy, @UpdatedBy, @IPAddress, @CreatedOnUTC, @UpdatedOnUTC)");
            db.AddInParameter(cmd, "Name", DbType.String, expense.Name);
            db.AddInParameter(cmd, "Report", DbType.String, expense.Report);
            db.AddInParameter(cmd, "Category", DbType.String, expense.Category);
            db.AddInParameter(cmd, "Amount", DbType.String, expense.Amount);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, expense.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, expense.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, expense.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, expense.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, expense.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Added Expense to DB");

        }
        /// <summary>
        /// Updating Data From Expense Table
        /// </summary>
        /// <param name="expense"></param>
        public static void Update(Expense expense)
        {
            Log.Debug("Updating Expense to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Update Expense set Name=@Name, Report=@Report, Category=@Category, Amount=@Amount,  CreatedBy=@CreatedBy, UpdatedBy=@UpdatedBy, IPAddress=@IPAddress, CreatedOnUTC=@CreatedOnUTC, UpdatedOnUTC=@UpdatedOnUTC where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.String, expense.Id);
            db.AddInParameter(cmd, "Name", DbType.String, expense.Name);
            db.AddInParameter(cmd, "Report", DbType.String, expense.Report);
            db.AddInParameter(cmd, "Category", DbType.String, expense.Category);
            db.AddInParameter(cmd, "Amount", DbType.String, expense.Amount);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, expense.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, expense.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, expense.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, expense.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, expense.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Deleting Data from Expense Table
        /// </summary>
        /// <param name="id"></param>

        public static void Delete(int id)
        {
            Log.Debug("Deleting Expense to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("delete from Expense where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Deleting Expense to DB");
        }

        /// <summary>
        /// Fetching Expenses from Table with Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Expense GetByName(string name)
        {
            Log.Debug("Fetching Expense to DB by name");
            Expense expense = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Expense where Name=@name");
            db.AddInParameter(cmd, "name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                expense = new Expense(reader);
            }
            Log.Debug("Fetching Expense to DB by Name");
            return expense;

        }

        /// <summary>
        /// Fetching Expenses from Table with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public static Expense GetById(int id)
        {
            Log.Debug("Deleting Expense to DB");
            Expense expense = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Expense where Id=@Iid");
            db.AddInParameter(cmd, "Iid", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                expense = new Expense(reader);
            }
            Log.Debug("Deleted Expense to DB");
            return expense;

        }

        /// <summary>
        /// Fetching List of Expenses
        /// </summary>
        /// <returns></returns>
        public static List<Expense> GetAll()
        {
            Log.Debug("Fetching Expense From DB");
            List<Expense> expenseList = new List<Expense>();

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Expense");
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                Expense expense = new Expense(reader);
                expenseList.Add(expense);
            }
            Log.Debug($"Fetched Record From DB count - {expenseList.Count}");
            return expenseList;

        }
    }
}
