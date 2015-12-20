using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverfortress
{
    public class ItemCounter: ObservableModel
    {
        private string _name;
        private string _count;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("FormattedDescrition");
            }
        }

        public string Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged("FormattedDescrition");
            }
        }

        public string FormattedDescrition
        {
            get { return String.Format("({0} : {1})", Name, Count); }
        }
    }
}
