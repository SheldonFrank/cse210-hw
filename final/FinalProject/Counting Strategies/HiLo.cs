public class HiLo : Strategy {
    public HiLo(int deckCount) : base(deckCount) {
        _name = "Hi-Lo";
        _runningCount = 0;
        _trueCount = 0;
        _cardCount = 0;
    }

    public override void UpdateCount(string card) {
        if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6") {
            _runningCount++;
        } else if (card == "T" || card == "J" || card == "Q" || card == "K" || card == "A") {
            _runningCount--;
        }

        _trueCount = Math.Round(_runningCount / _deckCount);

        _cardCount++;
    
    }

}