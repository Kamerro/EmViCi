using EmViCi.Models;
using System.Diagnostics;
namespace EmViCi.Data
{
    public class DataDogs:ISendMessage,IListOfDogs
    {
        public List<Dog> ListOfDogs { get; set; }
        private static DataDogs _dataDOgs;
        public static string[] tabOfNames = new string[] { "Kamil", "Kuba", "Max", "Bella", "Charlie",
            "Lucy", "Cooper", "Lola", "Rocky", "Sadie", "Bentley", "Molly", "Duke", "Coco", "Bear", "Ruby",
            "Tucker", "Rosie", "Oliver", "Luna", "Zeus", "Zoe", "Harley", "Maggie", "Milo", "Chloe", "Apollo",
            "Penny", "Rex", "Stella", "Winston", "Daisy", "Leo", "Lily", "Thor", "Abby", "Jack", "Maddie", "Gus",
            "Sophie", "Bruno", "Gracie", "Samson", "Cleo", "Jax", "Nala", "Cody", "Hazel", "Finn", "Ivy","Loli"};
        public delegate void OnCreating(bool variable);
        private event OnCreating onCreating_ev;
        public void OnSubscribe(OnCreating handler)
        {
            onCreating_ev += handler;
        }

        public DataDogs()
        {
            ListOfDogs = new List<Dog>();
            OnSubscribe(SendMessage);
            ListOfDogs = GetRandomListOfDogs();

        }
        //Stara naleciałość, do usunięcia:
        public static DataDogs GetInstance()
        {
            if(_dataDOgs is null)
            {
                _dataDOgs = new DataDogs(); 
            }
            return _dataDOgs;
        }
        public void SendMessage(bool generating)
        {
            if(generating)
            Debug.WriteLine("Generating random list of dogs");

            else 
            Debug.WriteLine("Returning random list of dogs");

        }
        public Dog takeDog(int id)
        {

                return ListOfDogs.FirstOrDefault(x => x.ID == id) as Dog;
            
        }

        public List<Dog>? GetRandomListOfDogs()
        {
            if (ListOfDogs.Count == 0)
            {
                onCreating_ev.Invoke(true);
                Random rand = new Random();
                int numOfDogs = rand.Next(3, 30);
                string name = String.Empty;
                for (int i = 0; i < numOfDogs; i++)
                {

                    name = tabOfNames[rand.Next(0, tabOfNames.Length)];
                    Dog dog = new Dog(i, name);
                    ListOfDogs.Add(dog);
                }
            }
            return ListOfDogs;
        }
    }
}
