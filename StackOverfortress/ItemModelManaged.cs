using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace StackOverfortress
{
    public class ItemModelManaged: ObservableModel
    {
        private ICommand _saveCommand;
        private ICommand _openCommand;
        private ItemModel _item;
        private ICommand _newCmd;

        public ItemModelManaged()
        {
            _openCommand = new CommandBase(Open);
            _saveCommand = new CommandBase(Save);
            _newCmd = new CommandBase((o) => Item = new ItemModel());
            
            Item = new ItemModel();
        }

        public ItemModel Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCmd
        {
            get { return _saveCommand; }            
        }

        public ICommand OpenCmd
        {
            get { return _openCommand; }            
        }

        public ICommand NewCmd
        {
            get { return _newCmd; }            
        }

        private void Save(object parameter)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.Filter = "Json|*.txt";
            if (sfd.ShowDialog() != true)
                return;

            var json = new JavaScriptSerializer().Serialize(Item);

            using (var sr = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
            {
                sr.WriteLine(json);
            }
        }

        private void Open(object parameter)
        {
            string fileName = (string) parameter;
            if (String.IsNullOrWhiteSpace(fileName))
            {
                var ofd = new OpenFileDialog();
                ofd.InitialDirectory = Directory.GetCurrentDirectory();
                ofd.Filter = "Json|*.txt";
                if (ofd.ShowDialog() != true)
                    return;
                fileName = ofd.FileName;
            }

            if (File.Exists(fileName) == false)
                return;

            string json;
            using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open), Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            try
            {
                var item = new JavaScriptSerializer().Deserialize<ItemModel>(json);
                Item = item;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Could not load item description.", "Invalid format", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
