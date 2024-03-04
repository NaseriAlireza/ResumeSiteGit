using resume.Domain.Entities.Education;
using resume.Domain.Entities.MySkills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resume.Application.DTO.Home_Index
{
	public class MyskillsandEducation
	{
        public List<Education> educationslist { get; set; }
        public List<MySkills> myskillslist { get; set; }
    }
}
