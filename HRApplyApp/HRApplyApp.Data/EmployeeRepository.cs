using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HrApplyApp.Models;
using HRApplyApp.Data.Config;

namespace HRApplyApp.Data
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var employees = cn.Query<Employee>("SELECT * FROM Employee").ToList();

                return employees;
            }
        } 
    }
}
