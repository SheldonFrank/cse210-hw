using System;   
using System.IO;
using System.Text.Json;

class JsonQuery {

private string _jsonFilePath;
private string _scripture;
private string _scriptureReference;

public JsonQuery(){

    _jsonFilePath = "lds-scriptures.json";

    _scripture = "";

    _scriptureReference = "";

}

public string QueryJson(){

    Console.WriteLine("Please enter the a scripture to memorize. e.g. Genesis 1:2 or Gen. 1:2. At any time enter 'q' to quit the program");
        bool b = false;

        while (b == false) 
        {

        _scriptureReference = Console.ReadLine();


        if (_scriptureReference == "q"){
            Console.WriteLine("User has quit the program");

            return "QQQ";
        }

        string jsonString = File.ReadAllText(_jsonFilePath);
        JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
        JsonElement root = jsonDoc.RootElement;

            foreach (JsonElement element in root.EnumerateArray())
            {
                // Look for the verse title property
                if (element.TryGetProperty("verse_title", out JsonElement nameElement) && element.TryGetProperty("verse_short_title", out JsonElement shortNameElement))
                {
                    //once verse title is identified, pull scripture text

                    if (nameElement.GetString() == _scriptureReference || shortNameElement.GetString() == _scriptureReference)
                        {
                            if (element.TryGetProperty("scripture_text", out JsonElement scriptureElement))
                            {
                                _scripture = scriptureElement.GetString();
                                Console.Clear();
                                Console.WriteLine(_scriptureReference);
                                Console.WriteLine(_scripture);

                                b = true;
                                
                                break;
                            }
                        }
                    
                    
                }


            }

                      if(b==false)
                      {

                        Console.WriteLine("Reference not found. Check spelling and try again.");
                      }
                    }


                return _scripture;

            }

public string GetScriptureRef(){

    return _scriptureReference;

}
            
        

}
