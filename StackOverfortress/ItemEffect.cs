using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverfortress
{
    public class ItemEffect: ObservableModel
    {
        private string _description;
        private bool _positive;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public bool Positive
        {
            get { return _positive; }
            set
            {
                _positive = value;
                OnPropertyChanged();
            }
        }
    }
}
