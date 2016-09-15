using System;
using Assignment_1.IO;

namespace Assignment_1
{
    public class MatchingStrategy1 : MatchAlgorithms
    {
        private LoadSaveStrategy storage;
        public LoadSaveStrategy Storage
        {
            get { return storage; }
            set { storage = value; }
        }


        private string inputFile { get; set; }
        public string InputFile
        {
            get { return inputFile; }
            set { inputFile = value; }
        }

        string MatchAlgorithms.isAMatch() {
            PersonSet personSet = new PersonSet() { StorageStrategy = storage };
            personSet.Load(inputFile);

            foreach (Person person in personSet)
            {
                Console.WriteLine(person.ObjectId + "\n");
                Console.WriteLine(person.SocialSecurityNumber + "\n");
                Console.WriteLine(person.StateFileNumber + "\n");
                Console.WriteLine(person.FirstName + "\n");
                Console.WriteLine(person.MiddleName + "\n");
                Console.WriteLine(person.LastName + "\n");
                Console.WriteLine("-------------------------" + "\n\n");
            }
            // run specified algorithm

            // true
            // false
            // null (as in don't know)
            return "False";
        }
    }
}
