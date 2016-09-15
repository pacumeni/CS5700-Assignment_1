using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assignment_1.IO
{
    public class XmlLoadSave : LoadSaveStrategy
    {

        public override List<Person> Load(string filename)
        {
            List<Person> persons = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child) });

            if (OpenReader(filename))
            {
                persons = serializer.Deserialize(Reader) as List<Person>;
                Reader.Close();
            }

            return persons;
        }

        public override void Save(string filename, List<Person> persons)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child) });

            if (OpenWriter(filename))
            {
                serializer.Serialize(Writer, persons);
                Writer.Close();
            }
        }
    }
}
