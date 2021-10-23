using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Lesson
    {
        int _lenght;
        int _classNumber;
        DateTime _finishDate;

        protected void Start()
        {
        }

        public int ClassNumber
        {
            get { return _classNumber; }
            set { _classNumber = value; }
        }
        public DateTime StartDate { get; set; }       

        public void Finish(DateTime finishDate)
        {
            _finishDate = finishDate;
        }

        public DateTime GetFinishDate()
        {
            return _finishDate;
        }
    }
}
