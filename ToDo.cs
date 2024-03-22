using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GutKaz14
{
    public class ToDo
    {
        private bool _doing;
        private string _title;
        private DateTime _dateAndTime;
        private string _description;

        public ToDo(bool doing, string title, DateTime dateAndTime, string description)
        {
            _doing = doing;
            _title = title;
            _dateAndTime = dateAndTime;
            _description = description;
        }

        public bool Doing
        {
            get { return _doing; }
            set { _doing = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public DateTime DateAndTime
        {
            get { return _dateAndTime; }
            set { _dateAndTime = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
