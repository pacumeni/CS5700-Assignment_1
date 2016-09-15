using System.Collections;
using System.Collections.Generic;
using Assignment_1.IO;

namespace Assignment_1
{
    public class PersonSet : IEnumerable<Person>
    {
        private List<Person> _accounts = new List<Person>();

        public LoadSaveStrategy StorageStrategy { get; set; }

        public void Add(Person account)
        {
            if (account != null)
                _accounts.Add(account);
        }

        public void Load(string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && StorageStrategy != null)
                _accounts = StorageStrategy.Load(filename);
        }

        public void Save(string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && StorageStrategy != null)
                StorageStrategy.Save(filename, _accounts);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonEnum(_accounts.ToArray());
        }
    }

    public class PersonEnum : IEnumerator
    {
        private readonly Person[] _accounts;
        private int _currentPosition = -1;

        public PersonEnum(Person[] accounts)
        {
            _accounts = accounts;
        }

        public bool MoveNext()
        {
            return (++_currentPosition < _accounts.Length);
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
                return (_currentPosition >= 0 && _currentPosition < _accounts.Length) ? _accounts[_currentPosition] : null;
            }
        }
    }
}
