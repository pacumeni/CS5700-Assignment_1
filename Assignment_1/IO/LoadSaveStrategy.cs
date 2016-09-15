using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment_1.IO
{
    public abstract class LoadSaveStrategy
    {
        protected StreamReader Reader { get; set; }

        protected StreamWriter Writer { get; set; }
        public abstract List<Person> Load(string filename);
        public abstract void Save(string filename, List<Person> acccounts);

        protected virtual bool OpenReader(string filename)
        {
            bool result = false;
            try
            {
                Reader = new StreamReader(filename);
                result = true;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Cannot open input file {filename}, error={err}");
            }

            return result;
        }


        protected virtual bool OpenWriter(string filename)
        {
            bool result = false;
            try
            {
                Writer = new StreamWriter(filename);
                result = true;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Cannot open output file {filename}, error={err}");
            }

            return result;
        }
    }
}
