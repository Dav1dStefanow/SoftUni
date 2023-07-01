using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Subjects
{
    public class HumanitySubject : Subject
    {
        private const double subjectRate = 1.15;
        public HumanitySubject(int subjectId, string subjectName)
            : base(subjectId, subjectName)
        {
            this.Rate = subjectRate;
        }
    }
}
