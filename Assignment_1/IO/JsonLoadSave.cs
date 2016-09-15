using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Assignment_1.IO
{
    public class JsonLoadSave : LoadSaveStrategy
    {
        public override List<Person> Load(string filename)
        {
            List<Person> persons = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child) });

            if (OpenReader(filename))
            {
                persons = serializer.ReadObject(Reader.BaseStream) as List<Person>;
                Reader.Close();
            }

            return persons;
        }

        public override void Save(string filename, List<Person> persons)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child) });

            if (OpenWriter(filename))
            {
                serializer.WriteObject(Writer.BaseStream, persons);
                Writer.Close();
            }
        }
    }
}
