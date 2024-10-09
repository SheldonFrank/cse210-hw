using System.IO;
using System.Xml.Linq;
class Journal {
    public List<string> _entries = new List<string>();
    public string _filename;

    public void Display()
    {
       for (int i = 0; i < _entries.Count; i++)
       {
            Console.WriteLine(_entries[i]);
       }
    }

    public void save(List<string> _entries)
    {
        Console.WriteLine ("What is the name of the file you would like to save to?");
        _filename = Console.ReadLine();

        try
        {
            File.WriteAllLines(_filename, _entries);
            Console.WriteLine("Entries saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

       
    }

    public List<string> Load()
        { 
            Console.WriteLine ("What is the name of the file you would like to load?");
            _filename = Console.ReadLine();
            
        try
        {
            List<string> _entries = File.ReadAllLines(_filename).ToList();
            
            Console.WriteLine("File loaded successfully.");

            return  _entries;

        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

            return _entries;
        }

        

        }

    }