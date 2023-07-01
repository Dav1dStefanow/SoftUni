using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Subjects
{
    public class EconomicalSubject : Subject
    {
        private const double subjectRate = 1.0;
        public EconomicalSubject(int subjectId, string subjectName)
            : base(subjectId, subjectName)
        {
            this.Rate = subjectRate;
        }
    }
}
