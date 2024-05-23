using Core.BussinessObject;
using Core;
using DataLayer;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer
{
    public class ExpenseManager
    {
        public static Logger Log = LogManager.GetLogger("Service Layer");

        /// <summary>
        /// Adding Expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        public OperationResult Add(Expense expense)
        {
            Log.Debug("Adding Expense");
            Expense ExpenseAlreadyExist = GetByName(expense.Name);
            if (ExpenseAlreadyExist != null)
            {
                Log.Debug("Not Added Expense to DB");
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EXPENSE_ADDED_FAILURE_MESSAGE, expense);
            }
            ExpenseDB.Add(expense);
            Log.Debug("Added expense to DB");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.EXPENSE_ADDED_SUCESS_MESSAGE, expense);
        }

        /// <summary>
        /// getting Expense by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Expense GetByName(string name)
        {
            return ExpenseDB.GetByName(name);
        }

        /// <summary>
        /// Fetching list of all Expense
        /// </summary>
        /// <returns></returns>
        public List<Expense> GetAll()
        {
            return ExpenseDB.GetAll();
        }


        /// <summary>
        /// Deleting Expense from DB
        /// </summary>
        /// <param name="id"></param>

        public void Delete(int id)
        {
            ExpenseDB.Delete(id);

        }

        /// <summary>
        ///  Updating exixting Expense
        /// </summary>
        /// <param name="expense"></param>

        public void Update(Expense expense)
        {
            Log.Debug("Updating expense to DB");
            ExpenseDB.Update(expense);

        }

        /// <summary>
        /// deleting Expense by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Expense GetById(int id)
        {
            Log.Debug("Deleting Expense to DB");
            Expense expense = ExpenseDB.GetById(id);
            Log.Debug("Deleted Expense to DB");
            return expense;
        }
    }
}
