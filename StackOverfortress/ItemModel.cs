using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StackOverfortress
{
    public class ItemModel : ObservableModel
    {
        private string _name;
        private string _description;
        private ItemPaint _paint;
        private string _pictureUrl;
        private Color _borderColor;
        private Color _nameColor;

        public ItemModel()
        {
            Counters = new ObservableCollection<ItemCounter>();
            Effects = new ObservableCollection<ItemEffect>();
            _borderColor = Colors.LightBlue;
            _nameColor = Colors.Orange;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set
            {
                _pictureUrl = value;
                OnPropertyChanged();
            }
        }

        public ItemPaint Paint
        {
            get { return _paint; }
            set
            {
                _paint = value;
                OnPropertyChanged();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                OnPropertyChanged();
            }
        }

        public Color NameColor
        {
            get { return _nameColor; }
            set
            {
                _nameColor = value;
                OnPropertyChanged();
            }
        }


        public IEnumerable<ItemPaint> Paints
        {
            get
            {
                return Enum.GetValues(typeof(ItemPaint)) .Cast<ItemPaint>();
            }
        }

        public ObservableCollection<ItemCounter> Counters { get; set; }

        public ObservableCollection<ItemEffect> Effects { get; set; }
    }
}
