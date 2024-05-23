using DataLayer;
using Microsoft.AspNetCore.Http.Features;

namespace Task1.AppCode
{
    public static class CommonFunction
    {
        public static List<string> GetDepartments()
        {
            List<string> items = new List<string>();
            items.Add(Constants.ITDepartment);
            items.Add(Constants.HRDepartment);
            items.Add(Constants.PayrollDepartment);
            return items;
        }

        public static List<string> GetStatusList()
        {
            List<string> items = new List<string>();
            items.Add(Constants.Active);
            items.Add(Constants.InActive);
            return items;
        }

        public static List<string> GetMandatoryList()
        {
            List<string> items = new List<string>();
            items.Add(Constants.Yes);
            items.Add(Constants.No);
            return items;
        }
        public static List<string> GetDepartmentsFromDataBase()
        {
            List<string> items = new List<string>();
            foreach (var item in DepartmentDB.GetAll()) {
            items.Add(item.Name);
            }
            return items;
        }

        public  static List<string> GetEmployeesFromDataBase()
        {
            List<string> items = new List<string>();
            foreach (var item in EmployeeDB.GetAll())
            {
                items.Add(item.Name);
            }
            return items;
        }

        public static List<string> GetReportStatusList()
        {
            List<string> items = new List<string>();
            items.Add(Constants.Complete);
            items.Add(Constants.InComplete);
            items.Add(Constants.Pending);
            return items;
        }

        public static List<string> GetCategoryFromDataBase()
        {
            List<string> items = new List<string>();
            foreach (var item in CategoryDB.GetAll())
            {
                items.Add(item.Name);
            }
            return items;
        }
        public static List<string> GetReportFromDataBase()
        {
            List<string> items = new List<string>();
            foreach (var item in ReportDB.GetAll())
            {
                items.Add(item.Name);
            }
            return items;
        }
    }
}

