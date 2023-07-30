using EmViCi.Models;
using static EmViCi.Data.DataDogs;

namespace EmViCi.Data
{
    public interface IListOfDogs
    {
        public List<Dog>? GetRandomListOfDogs();

    }
}