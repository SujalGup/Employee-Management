using Core.BussinessObject;
using Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Org.BouncyCastle.Asn1.Crmf;


namespace ServiceLayer
{
    public class CategoryManager
    {
        public static Logger Log = LogManager.GetLogger("Service Layer");
        /// <summary>
        /// Adding Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public OperationResult Add(Category category)
        {
            Log.Debug("Adding Category");
            Category CategoryAlreadyExist = GetByName(category.Name);
            if (CategoryAlreadyExist != null)
            {
                Log.Debug("Not Added Category to DB");
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.CATEGORY_ADDED_FAILURE_MESSAGE, category);
            }
            CategoryDB.Add(category);
            Log.Debug("Added Category to DB");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.CATEGORY_ADDED_SUCESS_MESSAGE, category);
        }
        /// <summary>
        /// getting Category by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Category GetByName(string name)
        {
            return CategoryDB.GetByName(name);
        }

        /// <summary>
        /// Fetching list of all Category
        /// </summary>
        /// <returns></returns>

        public List<Category> GetAll()
        {
            return CategoryDB.GetAll();
        }

        /// <summary>
        ///  Deleting Category from DB
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            CategoryDB.Delete(id);

        }

        /// <summary>
        /// Updating exixting Category
        /// </summary>
        /// <param name="category"></param>
        public void Update(Category category)
        {
            Log.Debug("Updating Category to DB");
            CategoryDB.Update(category);

        }

        /// <summary>
        /// deleting Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id)
        {
            Log.Debug("Deleting Category to DB");
            Category category = CategoryDB.GetById(id);
            Log.Debug("Deleted Category to DB");
            return category;
        }
    }
}
