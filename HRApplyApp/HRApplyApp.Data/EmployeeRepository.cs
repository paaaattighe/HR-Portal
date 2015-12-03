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
                var employees = cn.Query<Employee>("select e.EmpID, e.FirstName, e.LastName, e.HireDate, e.LocationID, e.ManagerID, e.[Status] from Employee e").ToList();

                return employees;
            }
        }

        public List<TimeRecord> GetTimeRecords()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var timeRecords = cn.Query<TimeRecord>("select EmpID, DateWorked, HoursWorked from HoursWorked").ToList();

                return timeRecords;
            }
        }

        public void AddTimeRecordToDB(TimeRecord tr)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("EmpID", tr.EmpID);
                p.Add("DateWorked", tr.DateWorked.ToShortDateString());
                p.Add("HoursWorked", tr.HoursWorked);

                cn.Execute("dbo.AddTimeRecord", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
