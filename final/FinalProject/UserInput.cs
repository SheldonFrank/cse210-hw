public class UserInput {
    string _dealerUpcard;
    string _playerHand; //convert the list of cards to a string
    int _playerTotal;
    private Analyzer _analyzer;

    public UserInput(Analyzer analyzer) {
        _dealerUpcard = "";
        _playerHand = "";
        _playerTotal = 0;
        _analyzer = analyzer;

    }

    public void UpdateAnalyzer(Strategy strategy, string card) {

        _analyzer.SetRecommendedAction();
        _analyzer.SetPlayerHand(_playerHand);
        _analyzer.SetPlayerTotal(_playerTotal);
        _analyzer.SetTrueCount(strategy.GetTrueCount());
        _analyzer.SetRunningCount(strategy.GetRunningCount());
        _analyzer.SetLastInput(card);
        _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
        _analyzer.ResetAction();
        _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
    }

    public void Interact(Strategy strategy) {
        List <string> cards = new List<string>(["2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"]);
        string card;
        _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());

        for (int i = 0; i < 3; i++)
{

        if (i == 0)
        {   
            Console.Write("   Dealer Upcard: ");
            Console.CursorVisible = true;
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card)) {

                strategy.UpdateCount(card);

                if (card == "T" || card == "J" || card == "Q" || card == "K" || card == "A")
                {
                    _dealerUpcard = card;
                }
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _dealerUpcard = card;
                }

                _analyzer.SetDealerUpcard(_dealerUpcard);
                _analyzer.SetTrueCount(strategy.GetTrueCount());
                _analyzer.SetRunningCount(strategy.GetRunningCount());
                _analyzer.SetLastInput(card);
                _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
                _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
            }
            else
            {   Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                _analyzer.SetLastInput("Invalid");
                _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                i--;
            }

        }
        else if (i >= 1)
        {   
            Console.CursorVisible = false;
            Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
            Console.Write("     Player card: ");
            Console.CursorVisible = true;
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card))
            {
                strategy.UpdateCount(card);

                if (card == "T" || card == "J" || card == "Q" || card == "K")
                {
                    _playerHand += card;
                    _playerTotal += 10;
                }

                else if (card == "A")
                {
                    _playerHand += card;
                    _playerTotal += 1;
                }
            
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _playerHand += card;
                    _playerTotal += Convert.ToInt32(card);
                }

                _analyzer.SetPlayerHand(_playerHand);
                _analyzer.SetPlayerTotal(_playerTotal);
                _analyzer.SetTrueCount(strategy.GetTrueCount());
                _analyzer.SetRunningCount(strategy.GetRunningCount());
                _analyzer.SetLastInput(card);
                _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
                _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop); 
        
            }
            else
                {
                    _analyzer.SetLastInput("Invalid");
                    _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

                    i--;
                }  
    }
}

_analyzer.SetRecommendedAction();
_analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
bool finishedHand = false;
// while (finishedHand == false)
// {   
    Console.CursorVisible = false;

    Console.CursorVisible = true; // Read key press without displaying it

    // if (keyInfo.Key == ConsoleKey.Enter)
    // {
    //     Console.SetCursorPosition(0, Console.CursorTop);
    //     Console.BackgroundColor = ConsoleColor.Gray;
    //     Console.ForegroundColor = ConsoleColor.Black;
    //     Console.Write("Card Input");
    //     Console.ResetColor();
    //     Console.Write(":                ");
    //     break;
    // }

    
    while (finishedHand == false)
    {
        Console.Write(" Enter H to hit or S to stand ");
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        card = keyInfo.KeyChar.ToString().ToUpper();

        if (card == "H")
        {
            Console.SetCursorPosition(Console.CursorLeft - 29, Console.CursorTop);
            Console.Write("             Enter user card ");

            keyInfo = Console.ReadKey(intercept: true);
            
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card))
            {

                if (card == "T" || card == "J" || card == "Q" || card == "K")
                {
                    _playerHand += card;
                    _playerTotal += 10;
                }

                else if (card == "A")
                {
                    _playerHand += card;
                    _playerTotal += 1;
                }
                    
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _playerHand += card;
                    _playerTotal += Convert.ToInt32(card);
                }

                if (_playerTotal >= 21)
                {
                    
                UpdateAnalyzer(strategy, card);
                finishedHand = true;
                Console.SetCursorPosition(Console.CursorLeft - 29, Console.CursorTop);
                 
                }
                
                else
                {
                    
                    UpdateAnalyzer(strategy, card);
                    Console.SetCursorPosition(Console.CursorLeft - 29, Console.CursorTop);
                }
            }
        }

        else if (card == "S")
        {
            finishedHand = true;
        }
        
        else
        {
            _analyzer.SetLastInput("Invalid");
            _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
            continue;
        }
    }

// }
}
}
