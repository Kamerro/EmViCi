namespace EmViCi.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Dog(int ID, string name)
        {
            Name = name;
            this.ID = ID;
        }

    }
}
