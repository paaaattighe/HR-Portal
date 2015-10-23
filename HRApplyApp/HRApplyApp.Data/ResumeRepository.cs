using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrApplyApp.Models;

namespace HRApplyApp.Data
{
    public class ResumeRepository : IResumeRepository
    {
        private string _fileName
        {
            get
            {
                return RootPath + "DataFiles\\resumes.txt";
            }
        }
        public string RootPath { get; set; }

        public List<Resume> GetAll()
        {
            List<Resume> AllResumes = new List<Resume>();

            if (File.Exists(_fileName))
            {
                var reader = File.ReadAllLines(_fileName);

                // read the header

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');
                    var resume = new Resume()
                    {
                        ApplicantId = int.Parse(columns[0]),
                        FirstName = columns[1],
                        LastName = columns[2],
                        StreetAddress = columns[3],
                        City = columns[4],
                        Zipcode = columns[5],
                        State = columns[6],
                        Country = columns[7],
                        Email = columns[8],
                        ConfirmEmail = columns[9],
                        PhoneNumber = columns[10],
                        SkypeName = columns[11],
                        WorkHistory = columns[12],
                        Education = columns[13],
                        Position = columns[14],
                        Salary = columns[15],
                        DateofApplication = DateTime.Parse(columns[16])
                    };

                    AllResumes.Add(resume);
                }
            }



            return AllResumes;
        }

        public void Add(Resume newResume)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newResume.ApplicantId = (GetAll().Any()) ? GetAll().Max(r => r.ApplicantId) + 1 : 1;

            var resumes = GetAll();
            resumes.Add(newResume);

            WriteFile(resumes);
        }

        private void WriteFile(List<Resume> resumes)
        {
            using (var writer = File.CreateText(_fileName))
            {
                writer.WriteLine(
                    "ApplicantId,FirstName,LastName,StreetAddress,City,Zipcode,State,Country,Email,ConfirmEmail,PhoneNumber,SkypeName,WorkHistory,Education,Position,Salary,DateOfApplication");

                foreach (Resume res in resumes)
                {
                    writer.WriteLine(
                        String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}",
                            res.ApplicantId, res.FirstName, res.LastName, res.StreetAddress, res.City, res.Zipcode,
                            res.State, res.Country, res.Email, res.ConfirmEmail, res.PhoneNumber, res.SkypeName,
                            res.WorkHistory, res.Education, res.Position, res.Salary, res.DateofApplication));
                }
            }
        }
    }
}
