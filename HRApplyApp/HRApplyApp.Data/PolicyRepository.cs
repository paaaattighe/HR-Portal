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
                    var Policy = new Policy()
                    {
                        PolicyID = int.Parse(columns[0]),
                        PolicyName = columns[1],
                        PolicyDescription = columns[2],
                        Category = columns[3],
                    };

                    AllPolicies.Add(Policy);
                }
            }



            return AllPolicies;
        }

        public List<PolicyCategory> GetPoliciesByCategory(List<Policy> policyList)
        {
            PolicyCategory polcat = new PolicyCategory();
            List<PolicyCategory> polcatlist = new List<PolicyCategory>();
            foreach (var policy in policyList)
            {
                if (polcat.PolicyCategoryName != policy.Category)
                {
                    PolicyCategory polcat2 = new PolicyCategory();
                    polcat.PolicyCategoryName = policy.Category;
                    polcat.PolicyList = new List<Policy>();
                    polcat.PolicyList.Add(policy);
                    polcatlist.Add(polcat);
                }
                else
                {
                    PolicyCategory pppp = (PolicyCategory)from p in polcat.PolicyCategoryName where p.Equals(policy.Category) select p;
                    pppp.PolicyList.Add(policy);
                    polcatlist.Add(pppp);

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

            WriteFile(newPolicy);
        }

        public void Delete(int id)
        {
            var policyList = GetAll();
            policyList.RemoveAll(p => p.PolicyID == id);
            foreach (var policy in policyList)
            {
                WriteFile(policy);
            }
        }

        public void Edit(Policy policy)
        {
            var policyList = GetAll();
            policyList.RemoveAll(p => p.PolicyID == policy.PolicyID);
            policyList.Add(policy);
            foreach (var pol in policyList)
            {
                WriteFile(pol);
            }
        }

        public void WriteFile(Policy pol)
        {

            using (var writer = File.AppendText(_fileName))
            {

                writer.WriteLine(
                    String.Format("{0},{1},{2},{3}",
                        pol.PolicyID, pol.PolicyName, pol.PolicyDescription, pol.Category));


            }
        }
    }
}
