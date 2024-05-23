using Core.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class SLConstants
    {
        public static class Messages
        {
            public const string EmployeeAddedSucessMessage = "Employee has been added Sucessfully!";
            public const string EmployeeAddedFailureMessage = "Record Can ant be added, Email Should be unique.";
            public const string EmployeeUpdatedSucessMessage = "Employee has been updated Sucessfully!";
            public const string EmployeeUpdatedFailureMessage = "Record Can ant be added, Email Should be unique.";
            public const string EmployeeDeletedSucessMessage = "Employee has been deleted Sucessfully!";
            public const string EMPLOYEE_ADDED_FAILURE_NAME_UNIQUE = "Record Can ant be added, name  Should be unique.";
            public const string EMPLOYEE_ADDED_FAILURE_PHONE_LENTH = "Record Can ant be added, length should be less than 15.";
            public const string DEPARTMENT_ADDED_FAILURE_MESSAGE = "Department already exist";
            public const string DEPARTMENT_ADDED_SUCESS_MESSAGE = "Department has been added Sucessfully";
            public const string CATEGORY_ADDED_FAILURE_MESSAGE = "Category already exist";
            public const string CATEGORY_ADDED_SUCESS_MESSAGE = "Category has been added Sucessfully";
            public const string PROJECT_ADDED_FAILURE_MESSAGE = "Project already exist";
            public const string PROJECT_ADDED_SUCESS_MESSAGE = "Project has been added Sucessfully";
            public const string REPORT_ADDED_FAILURE_MESSAGE = "Report already exist";
            public const string REPORT_ADDED_SUCESS_MESSAGE = "Report has been added Sucessfully";
            public const string EXPENSE_ADDED_FAILURE_MESSAGE = "Expense already exist";
            public const string EXPENSE_ADDED_SUCESS_MESSAGE = "Expense has been added Sucessfully";
        }
    }
}

