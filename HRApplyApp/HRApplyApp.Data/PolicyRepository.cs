using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HrApplyApp.Models;

namespace HRApplyApp.Data
{
    public class PolicyRepository
    {
        private string _fileName
        {
            get { return RootPath + "DataFiles\\policies.txt"; }
        }

        public string RootPath { get; set; }

        public List<Policy> GetAll()
        {
            List<Policy> AllPolicies = new List<Policy>();

            if (File.Exists(_fileName))
            {
                var reader = File.ReadAllLines(_fileName);

                // read the header

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');
                    var policy = new Policy();

                    for (int j = 2; j < columns.Count() - 1; j++)
                    {
                        policy.PolicyDescription += columns[j] + ",";
                    }
                    policy.PolicyDescription = policy.PolicyDescription.TrimEnd(',');

                    policy.PolicyID = int.Parse(columns[0]);
                    policy.PolicyName = columns[1];
                    //policy.PolicyDescription = columns[columns.Count() - 2];
                    policy.Category = columns[columns.Count() - 1];

                    AllPolicies.Add(policy);
                }

         

            }

            return AllPolicies;
        }

        public List<PolicyCategory> GetAllPolicyCategories()
        {
            List<PolicyCategory> polcatlist = new List<PolicyCategory>();

            if (File.Exists(_fileName))
            {
                var reader = File.ReadAllLines(_fileName);

                // read the header

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');
                    var polcat = new PolicyCategory()
                    {
                        PolicyCategoryName = columns[3],
                    };

                    polcatlist.Add(polcat);
                }
            }

            return polcatlist;
        }

        public void Add(Policy newPolicy)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newPolicy.PolicyID = (GetAll().Any()) ? GetAll().Max(p => p.PolicyID) + 1 : 1;

            var Policies = GetAll();
            Policies.Add(newPolicy);

            WriteFile(Policies);
        }

        public void Delete(int id)
        {
            var policyList = GetAll();
            policyList.RemoveAll(p => p.PolicyID == id);
            WriteFile(policyList);

        }

        public void Edit(Policy policy)
        {
            var policyList = GetAll();
            policyList.RemoveAll(p => p.PolicyID == policy.PolicyID);
            policyList.Add(policy);
            WriteFile(policyList);

        }

        public void WriteFile(List<Policy> policies)
        {

            using (var writer = File.CreateText(_fileName))
            {
                writer.WriteLine("policyid,policyname,policydescription,category");
                foreach (Policy pol in policies)
                {
                    writer.WriteLine(
                        String.Format("{0},{1},{2},{3}",
                            pol.PolicyID, pol.PolicyName, pol.PolicyDescription, pol.Category));
                }
            }
        }

        public Policy GetPolicyById(int id)
        {
            return GetAll().FirstOrDefault(p => p.PolicyID == id);
        }
    }
}
