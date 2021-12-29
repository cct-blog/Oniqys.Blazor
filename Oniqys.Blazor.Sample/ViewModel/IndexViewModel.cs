using Oniqys.Blazor.ViewModel;
using System.Collections.Generic;

namespace Oniqys.Blazor.Sample.ViewModel
{
    public class IndexViewModel : ContentBase
    {
        private IndexModel _indexModel;

        public Selectable<string> TestItem { get; set; } = new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "チェックボックス１" };


        private object _testItem2;
        public object TestItem2 { 
            get => _testItem2; 
            set => ObjectChangeProcess(ref _testItem2, value); 
        }

        private int _dataTemplateTestItemsIndex = 0;

        private object[] _dataTemplateTestItems = new object[] {
            new Selectable<string> { IsSelected = true, IsEnabled = true, Content = "チェックボックス２" },
            new Selectable<string> { IsSelected = true, IsEnabled = false, Content = "チェックボックス３" },
            "ラベル",
        };

        public ContentCollection<Selectable<string>> Items { get; set; } = new ContentCollection<Selectable<string>>();

        public ContentCollection<string> SelectedItems { get; set; } = new ContentCollection<string>();


        public Clickable ChangeDataButton { get; init; }

        public Clickable AddLineButton { get; init; }

        private string _animalName;
        public string AnimalName {
            get => _animalName; 
            set 
            {
                _animalName = value;
                AddLineButton.IsEnabled = !string.IsNullOrWhiteSpace(_animalName);
            }
        }

        public IndexViewModel(IndexModel indexModel)
        {
            _indexModel = indexModel;

            indexModel.AnimalsChanged += (s, e) => Refresh();

            AddLineButton = new Clickable { 
                Command = new Command(() => _indexModel.UpdateAnimal(AnimalName, false)),
                IsEnabled = !string.IsNullOrWhiteSpace(AnimalName) };


            TestItem2 = _dataTemplateTestItems[_dataTemplateTestItemsIndex];
            ChangeDataButton = new Clickable {
                Command = new Command(() => TestItem2 = _dataTemplateTestItems[(++_dataTemplateTestItemsIndex) % _dataTemplateTestItems.Length]),
                IsEnabled = true };

            Refresh();
        }

        private void Refresh()
        {
            Items.Clear();
            Items.AddRange(_indexModel.Animals.Select(animal =>
            {
                var item = new Selectable<string> { IsSelected = animal.Value, IsEnabled = true, Content = animal.Key };
                item.PropertyChanged += (o, e) => { _indexModel.UpdateAnimal(animal.Key, item.IsSelected); };
                return item;
            }));

            SelectedItems.Clear();
            SelectedItems.AddRange(Items.Where(item => item.IsSelected).Select(item => item.Content));

        }
    }
}
