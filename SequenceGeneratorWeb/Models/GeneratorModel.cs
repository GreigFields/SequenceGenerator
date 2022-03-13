using Microsoft.AspNetCore.Mvc;

namespace SequenceGeneratorWeb.Models
{
    public class GeneratorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int id { get; set; }
        public string modelID { get; set; }
        public int StartingValue { get; set; }
        public int OutputResult { get; set; }
        public int OutputSum { get; set; }

        public string Load()
        {
            return ":";
        }

    }
}
