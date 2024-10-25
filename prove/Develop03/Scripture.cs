using System.ComponentModel.DataAnnotations;

class Scripture
{

private List<Word> _word = new List<Word>();

private string _scriptureRef;

public Scripture(string scriptureRef){

    _scriptureRef = scriptureRef;

}

public void DisplayQuiz()
{

    bool t = false;

    while (t == false ){
    
    string q = Console.ReadLine();

    if (q == "q"){
        
        Console.WriteLine("User has quit the program");
        break;
    }

    if (_word.All(w => w.GetBool()))
            {
                t = true;
            }

    Console.Clear();
    List<string> scripture = new List<string>();

    Random random = new Random();

    for (int i = 0; i < 2;)
    {
        //check to see if all word object bools are true. If so, break loop.

        if (_word.All(w => w.GetBool()))
            {
                break;
            }
        
        int i_word = random.Next(0, _word.Count);
            if (_word[i_word].GetBool() == false ){

                _word[i_word].SetBool();

                i++;
            }

    }

    foreach (Word word in _word){

        scripture.Add(word.DisplayWord());
    }

    
    Console.WriteLine(_scriptureRef);
    Console.WriteLine(String.Join(" ", scripture));
     
}
}

public List<Word> ToWordList(string scripture)
{
    string[] wordArray = scripture.Split(' ');
    foreach (string word in wordArray)
        {
            _word.Add(new Word(word));
        }
    
    return _word;
}

}