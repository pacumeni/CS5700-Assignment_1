using System.Collections;
using System.Collections.Generic;
using Assignment_1.IO;

namespace Assignment_1
{
    public class PersonSet : IEnumerable<Person>
    {
        private List<Person> _persons = new List<Person>();

        public LoadSaveStrategy StorageStrategy { get; set; }

        public void Add(Person person)
        {
            if (person != null)
                _persons.Add(person);
        }

        public void Load(string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && StorageStrategy != null)
                _persons = StorageStrategy.Load(filename);
        }

        public void Save(string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && StorageStrategy != null)
                StorageStrategy.Save(filename, _persons);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return _persons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonEnum(_persons.ToArray());
        }
    }

    public class PersonEnum : IEnumerator
    {
        private readonly Person[] _persons;
        private int _currentPosition = -1;

        public PersonEnum(Person[] persons)
        {
            _persons = persons;
        }

        public bool MoveNext()
        {
            return (++_currentPosition < _persons.Length);
        }

        public void Reset()
        {
            _currentPosition = -1;
        }

        object IEnumerator.Current { get { return Current; } }

        public Person Current
        {
            get
            {
                return (_currentPosition >= 0 && _currentPosition < _persons.Length) ? _persons[_currentPosition] : null;
            }
        }
    }
}
