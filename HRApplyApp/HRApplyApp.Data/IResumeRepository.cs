using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrApplyApp.Models;

namespace HRApplyApp.Data
{
    public interface IResumeRepository
    {
        List<Resume> GetAll();
        void Add(Resume newResume);
    }

}