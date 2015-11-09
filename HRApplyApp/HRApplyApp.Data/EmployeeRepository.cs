using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                // select * from employee not working because of discrepancy between SQL time and .NET time
                var employees = cn.Query<Employee>("select e.EmpID, e.FirstName, e.LastName, e.HireDate, e.LocationID, e.ManagerID, e.[Status], e.IsClockedIn from Employee e").ToList();

                return employees;
            }
        }

        public void EmployeeClockIn(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("ID", id);

                cn.Execute("dbo.ClockIn", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void EmployeeClockOut(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("ID", id);

                cn.Execute("dbo.ClockOut", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
