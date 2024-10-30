class Assignment{
    protected string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic){
        _studentName = studentName;
        _topic = topic;
    }
    
    public Assignment(string studentName){
        _studentName = studentName;
        _topic = "N/A";

    }


    public Assignment(){
        _studentName = "N/A";
        _topic = "N/A";
    }

    public void GetSummary(){
         Console.WriteLine($"{_studentName} - {_topic}");
    }

}
