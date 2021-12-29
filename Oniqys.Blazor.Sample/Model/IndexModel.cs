namespace Oniqys.Blazor.Sample
{
    public class IndexModel
    {
        public EventHandler AnimalsChanged;

        public Dictionary<string, bool> Animals = new Dictionary<string, bool> {
            ["いぬ"] = true, ["ねこ"] = false,
        };

        public void UpdateAnimal(string animal, bool check)
        {
            if (string.IsNullOrWhiteSpace(animal))
                return;

            Animals[animal] = check;
            AnimalsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
