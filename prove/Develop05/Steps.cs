using System;


public class Step
{
    private string _step;
    private bool _isComplete;

    public Step (string step, bool isComplete)
    {
        _step = step;
        _isComplete = isComplete;
    }

    public string GetStep()
    {
        return _step;
    }
    public void SetName(string s)
    {
        _step = s;
    }
    public bool GetStatus()
    {
        return _isComplete;
    }
    public void Complete()
    {
        _isComplete = true;
    }
}