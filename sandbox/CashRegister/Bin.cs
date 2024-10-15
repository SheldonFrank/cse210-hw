class Bin
{

    //attributes
    private string _denomination;

    private int _amount;

    private float _value;


    //methods

    public Bin(string denomination, int amount, float value) {

        _denomination = denomination;
        _amount = amount;
        _value = value;
    }

    public void ModifyAmount(int amount)
    {

        _amount += amount

    }

    public float TotalValue()
    {

       return  _amount * _value;

    }

}