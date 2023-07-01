using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Subjects
{
    public class TechnicalSubject : Subject
    {
        private const double subjectRate = 1.3;
        public TechnicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName)
        {
            this.Rate = subjectRate;
        }
    }
}
