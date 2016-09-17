using System;
using Assignment_1.IO;
using System.Linq;
using System.Collections.Generic;

namespace Assignment_1
{
    public class MatchingStrategy2 : MatchAlgorithms
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
        public bool answer;
        bool MatchAlgorithms.isAMatch()
        {
            PersonSet personSet = new PersonSet() { StorageStrategy = storage };
            personSet.Load(inputFile);

            var adult1 = new Adult();
            var adult2 = new Adult();
            var child1 = new Child();
            var child2 = new Child();
            for (var k = 0; k < personSet.Count(); k++)
            {
                for (var i = 1; i < personSet.Count(); i++)
                {
                    bool match;
                    List<int> matchedArr = new List<int>();
                    if (personSet.ElementAt(k).GetType() == typeof(Adult) && personSet.ElementAt(i).GetType() == typeof(Adult))
                    {
                        adult1 = castAsAdult(personSet.ElementAt(k));
                        adult2 = castAsAdult(personSet.ElementAt(i));
                        match = matchAdults(adult1, adult2);
                    }
                    else if (personSet.ElementAt(k).GetType() == typeof(Adult) && personSet.ElementAt(i).GetType() == typeof(Child))
                    {
                        adult1 = castAsAdult(personSet.ElementAt(k));
                        child1 = castAsChild(personSet.ElementAt(i));
                        match = matchAdultChild(adult1, child1);
                    }
                    else if (personSet.ElementAt(k).GetType() == typeof(Child) && personSet.ElementAt(i).GetType() == typeof(Adult))
                    {
                        child1 = castAsChild(personSet.ElementAt(k));
                        adult1 = castAsAdult(personSet.ElementAt(i));
                        match = matchAdultChild(adult1, child1);
                    }
                    else
                    {
                        child1 = castAsChild(personSet.ElementAt(k));
                        child2 = castAsChild(personSet.ElementAt(i));
                        match = matchChildren(child1, child2);
                    }

                    if (match == true)
                    {

                        if (personSet.ElementAt(k) != personSet.ElementAt(i))
                        {
                            matchedArr.Add(personSet.ElementAt(k).ObjectId);
                            matchedArr.Add(personSet.ElementAt(i).ObjectId);
                        }
                        for (int j = 0; j < matchedArr.Count(); j += 2)
                        {
                            Console.WriteLine(matchedArr.ElementAt(j) + ", " + matchedArr.ElementAt(j + 1));
                            string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(strPath + @"\matchAssignment.txt", true))
                            {
                                file.WriteLine(matchedArr.ElementAt(j) + ", " + matchedArr.ElementAt(j + 1));
                            }
                        }
                        answer = true;
                    }
                    else answer = false;
                }
            }
            return answer;
        }

        bool matchAdults(Adult a1, Adult a2)
        {
            if (a1.StateFileNumber != null && a2.StateFileNumber != null && a1.StateFileNumber == a2.StateFileNumber)
            {
                if (a1.FirstName != null && a2.FirstName != null && a1.FirstName == a2.FirstName && a1.LastName != null && a2.LastName != null && a1.LastName == a2.LastName)
                    return true;
                else if (a1.MiddleName != null && a2.MiddleName != null && a1.LastName != null && a2.LastName != null && a1.MiddleName == a2.MiddleName && a1.LastName == a2.LastName)
                    return true;
                else
                    return false;
            }
            else if (a1.SocialSecurityNumber != null && a2.SocialSecurityNumber != null && a1.SocialSecurityNumber == a2.SocialSecurityNumber)
            {
                if (a1.FirstName != null && a2.FirstName != null && a1.FirstName == a2.FirstName && a1.LastName != null && a2.LastName != null && a1.LastName == a2.LastName)
                    return true;
                else if (a1.MiddleName != null && a2.MiddleName != null && a1.LastName != null && a2.LastName != null && a1.MiddleName == a2.MiddleName && a1.LastName == a2.LastName)
                    return true;
                else
                    return false;
            }
            else return false;
        }

        bool matchAdultChild(Adult a1, Child c1)
        {
            if (a1.StateFileNumber != null && c1.StateFileNumber != null && a1.StateFileNumber == c1.StateFileNumber)
            {
                if (a1.FirstName != null && c1.FirstName != null && a1.FirstName == c1.FirstName && a1.LastName != null && c1.LastName != null && a1.LastName == c1.LastName)
                    return true;
                else if (a1.MiddleName != null && c1.MiddleName != null && a1.LastName != null && c1.LastName != null && a1.MiddleName == c1.MiddleName && a1.LastName == c1.LastName)
                    return true;
                else
                    return false;
            }
            else if (a1.SocialSecurityNumber != null && c1.SocialSecurityNumber != null && a1.SocialSecurityNumber == c1.SocialSecurityNumber)
            {
                if (a1.FirstName != null && c1.FirstName != null && a1.FirstName == c1.FirstName && a1.LastName != null && c1.LastName != null && a1.LastName == c1.LastName)
                    return true;
                else if (a1.MiddleName != null && c1.MiddleName != null && a1.LastName != null && c1.LastName != null && a1.MiddleName == c1.MiddleName && a1.LastName == c1.LastName)
                    return true;
                else
                    return false;
            }
            else return false;
        }

        bool matchChildren(Child c1, Child c2)
        {
            if (c1.StateFileNumber != null && c2.StateFileNumber != null && c1.StateFileNumber == c2.StateFileNumber)
            {
                if (c1.FirstName != null && c2.FirstName != null && c1.FirstName == c2.FirstName && c1.LastName != null && c2.LastName != null && c1.LastName == c2.LastName)
                    return true;
                else if (c1.MiddleName != null && c2.MiddleName != null && c1.LastName != null && c2.LastName != null && c1.MiddleName == c2.MiddleName && c1.LastName == c2.LastName)
                    return true;
                else
                    return false;
            }
            else if (c1.SocialSecurityNumber != null && c2.SocialSecurityNumber != null && c1.SocialSecurityNumber == c2.SocialSecurityNumber)
            {
                if (c1.FirstName != null && c2.FirstName != null && c1.FirstName == c2.FirstName && c1.LastName != null && c2.LastName != null && c1.LastName == c2.LastName)
                    return true;
                else if (c1.MiddleName != null && c2.MiddleName != null && c1.LastName != null && c2.LastName != null && c1.MiddleName == c2.MiddleName && c1.LastName == c2.LastName)
                    return true;
                else
                    return false;
            }
            else if (c1.NewbornScreeningNumber != null && c1.NewbornScreeningNumber != null && c1.NewbornScreeningNumber == c2.NewbornScreeningNumber)
            {
                if (c1.FirstName != null && c2.FirstName != null && c1.FirstName == c2.FirstName && c1.LastName != null && c2.LastName != null && c1.LastName == c2.LastName)
                    return true;
                else if (c1.MiddleName != null && c2.MiddleName != null && c1.LastName != null && c2.LastName != null && c1.MiddleName == c2.MiddleName && c1.LastName == c2.LastName)
                    return true;
                else
                    return false;
            }
            else return false;
        }

        Adult castAsAdult(Person p)
        {
            Adult a = new Adult();
            a = (Adult)p;
            return a;
        }

        Child castAsChild(Person p)
        {
            Child c = new Child();
            c = (Child)p;
            return c;
        }
    }
}
