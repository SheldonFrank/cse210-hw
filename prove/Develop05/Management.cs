using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.IO.Enumeration;

class Management {
private double _totalPoints;
private List<Goal> _goals = new List<Goal>();

public Management(double totalPoints = 0) {

    _totalPoints = totalPoints;
}

public void RunProgram(){

    bool done = true;

    Console.Clear();
    Console.WriteLine("Welcome to the Goal Tracker System");
    
    

    while (done)
    {

    DisplayTotalPoints();
    
    Console.WriteLine("What would you like to do? \n 1. Create New Goal \n 2. List goals \n 3. Save \n 4. Load Account  \n 5. Record Event \n 6. Quit");

    
    bool check = true;
    int selection = 6;
    
    while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out selection) && selection >= 1 && selection <= 6) {check = false;}

            else {Console.WriteLine("Invalid selection, please try again"); continue;}
        }
        
    switch (selection) {

        case 1:
            NewGoalPrompt();
            break;

        case 2:
            ListGoals();
            break;

        case 3:
            SaveToAccount();
            break;

        case 4:
            LoadAccount();
            break;

        case 5:
            RecordEvent();
            break;

        case 6:
            done = false;
            break;
    }
    }

}
public void DisplayTotalPoints()
{
    Console.WriteLine($"You have {_totalPoints} points");
}

public void ListGoals(bool includeDescription = true)
{   
    if (_goals.Count == 0) {Console.WriteLine("No goals yet!\n"); return;}

    Console.WriteLine("The goals are:");

    if (includeDescription) {

        for (int i = 0; i < _goals.Count; i++) {

        Console.WriteLine($"{i+1}. {_goals[i].DisplayForList()}");

        }

        Console.WriteLine();

    }

    else {

        for (int i = 0; i < _goals.Count; i++) {

        Console.WriteLine($"{i+1}. {_goals[i].GetName()}");

        }

    }

    

}

public void RecordEvent()
{   
    bool includeDescription = false;

    if (_goals.Count == 0) {Console.WriteLine("No goals yet!\n"); return;}

    ListGoals(includeDescription);

    Console.Write("\nWhich goal did you accomplish? ");

    
    bool check = true;
    int index = 0;

        while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out index) && index >= 0 && index <= _goals.Count) {check = false; index--;}

            else {Console.WriteLine("Invalid entry, please try again"); continue;}
        }

    if (index < 0) {return;}

    else {

        if (_goals[index].GetStatus() == true) {
            
            Console.WriteLine("This goal has already been completed\n");
        }

        else {

        _goals[index].UpdateStatus();


            if (_goals[index].GetStatus() == true) {

            Console.WriteLine("Congratulations! You have completed the goal!");
            }

            Console.WriteLine($"You have been awarded {_goals[index].GetPoints()} points\n");

            AddPoints(_goals[index].GetPoints());

    }

}
}

public void AddPoints(double points){

    _totalPoints = _totalPoints + points;

}

public void AddToList(Goal goal)
{ 
    _goals.Add(goal);
}

public void ClearList() {
    
        _goals.Clear();
}

public void NewGoalPrompt()
{

    Console.WriteLine("The types of goals you can create are: \n 1. Simple Goal \n 2. Eternal Goal \n 3. Checklist Goal \n 4. Exit");
    Console.WriteLine("Please enter the number of the goal you would like to create");

    
    bool check = true;
    int selection = 4;
    while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out selection) && selection >= 1 && selection <= 4) {check = false;}

            else {Console.WriteLine("Invalid selection, please try again"); continue;}
        }

    switch (selection) {

        case 1:
            Goal simpleGoal = new SimpleGoal{};
            simpleGoal.PopulateGoalAttributes();
            AddToList(simpleGoal);
            break;
            

        case 2:
            Goal eternalGoal = new EternalGoal{};
            eternalGoal.PopulateGoalAttributes();
            AddToList(eternalGoal);
            break;

        case 3:
            Goal checklistGoal = new ChecklistGoal{};
            checklistGoal.PopulateGoalAttributes();
            AddToList(checklistGoal);
            break;

        case 4:
            break;
    }
    

}
public void LoadTotalPoints()
{

    _totalPoints = 0;

    for (int i = 0; i < _goals.Count; i++)
    {

        _totalPoints = _totalPoints + _goals[i].GetTotalPoints();
        
    }
}

public void LoadGoalsFromJson(string filename) {

    try
    {   
        ClearList();

        string jsonString = File.ReadAllText($"Accounts//{filename}");
        JsonDocument doc = JsonDocument.Parse(jsonString);
        JsonElement root = doc.RootElement;

        foreach (JsonElement element in root.EnumerateArray())
        {
            string goalType = element.GetProperty("GoalType").GetString();
            string name = element.GetProperty("Name").GetString();
            string description = element.GetProperty("Description").GetString();
            bool complete = element.GetProperty("Complete").GetBoolean();
            double points = element.GetProperty("Points").GetDouble();

            switch (goalType)
            {
                case "Simple Goal":
                    Goal simpleGoal = new SimpleGoal(name, description, points, complete);
                    AddToList(simpleGoal);
                    break;

                case "Eternal Goal":
                    double totalPoints = element.GetProperty("TotalPoints").GetDouble();
                    Goal eternalGoal = new EternalGoal(name, description, points, totalPoints);
                    AddToList(eternalGoal);
                    break;

                case "Checklist Goal":
                    int progress = element.GetProperty("Progress").GetInt32();
                    double bonus = element.GetProperty("Bonus").GetDouble();
                    int progressTotal = element.GetProperty("ProgressTotal").GetInt32();

                    double total_Points = element.GetProperty("TotalPoints").GetDouble();
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, complete, progress, bonus, total_Points, progressTotal);
                    AddToList(checklistGoal);
                    break;
            }
        }

        
        Console.Clear();

        LoadTotalPoints();

        Console.WriteLine($"{filename} successfully loaded\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while loading: {ex.Message}");
    }
}

public void LoadAccount() {

    if (Directory.GetFiles("Accounts").Length == 0)
    {
        Console.WriteLine("No accounts found, please first create an account");
        return;
    }

    string[] files = Directory.GetFiles("Accounts", "*.json");


    Console.WriteLine("Local Accounts:");

    for (int i = 0; i < files.Length; i++)
    {   
        files[i] = Path.GetFileName(files[i]);
        Console.WriteLine($"{i+1}. {files[i].Split(".")[0]}");
    }

    Console.WriteLine("\nPlease enter the account number you would like to load");

    bool check = true;
    int selection = 0;
    while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out selection) && selection >= 1 && selection <= files.Length) {check = false;}

            else {Console.WriteLine("Invalid selection, please try again"); continue;}
        }

    LoadGoalsFromJson(files[selection-1]);

}

public void CreateAccount() {

    string[] files = Directory.GetFiles("Accounts", "*.json");
    Console.WriteLine("Please enter the name of the account you would like to create");
    string accountName = Console.ReadLine();

    for (int i = 0; i < files.Length; i++)
    {
        files[i] = Path.GetFileName(files[i]);

        if (files[i].Split(".")[0] == accountName)
        {
            Console.WriteLine("\nAn account with that name already exists, please try again");
            CreateAccount();
            return;
        }

        else {continue;}

    }

    string filename = $"{accountName}.json";

    SaveGoalsToJson(filename);
}

public void SaveToAccount() {

    

    string[] files = Directory.GetFiles("Accounts", "*.json");

    if (Directory.GetFiles("Accounts").Length == 0)
    {

        CreateAccount();
        return;
    }

    else
    {

        Console.WriteLine("Local accounts:");

        for (int i = 0; i < files.Length; i++)
        {   
            files[i] = Path.GetFileName(files[i]);
            Console.WriteLine($"{i+1}. {files[i].Split(".")[0]}");
        }
    }

    Console.WriteLine("\nPlease enter the account number you would like to save to, or enter 0 to create a new account");

    bool check = true;
    int selection = 0;
    while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out selection) && selection >= 0 && selection <= files.Length) {check = false;}

            else {Console.WriteLine("Invalid selection, please try again"); continue;}
        }
    
    if (selection == 0)
    {
        CreateAccount();
    }

    else
    {
        Console.WriteLine($"Are you sure you want to overwrite {files[selection-1].Split(".")[0]} (y/n)");
        string response = Console.ReadLine();

        if (response == "y")
        {
            SaveGoalsToJson(files[selection-1]);
        }

        else
        {
            return;
        }

    }
}

public void SaveGoalsToJson(string filename)
{
    try
    {
        
        var jsonBuilder = new StringBuilder();
        jsonBuilder.AppendLine("[");
        
        for (int i = 0; i < _goals.Count; i++)
        {
            

            jsonBuilder.Append(_goals[i].ToJson());
            if (i < _goals.Count - 1)
            {
                jsonBuilder.AppendLine(",");
            }
        }
        
        jsonBuilder.AppendLine("]");

        using (StreamWriter outputFile = new StreamWriter($"Accounts//{filename}", false))
        {
        
        outputFile.WriteLine(jsonBuilder.ToString());
        }   

        Console.WriteLine($"Goals have been successfully saved to {filename}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
    }
}


}