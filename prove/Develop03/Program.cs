using System;   
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        JsonQuery query = new JsonQuery();
        string scrip = query.QueryJson();
        Scripture scripture = new Scripture(query.GetScriptureRef());
        
        if (scrip == "QQQ"){
            return;
        }
        
        else{
        scripture.ToWordList(scrip);
        scripture.DisplayQuiz();
        }
    }
}