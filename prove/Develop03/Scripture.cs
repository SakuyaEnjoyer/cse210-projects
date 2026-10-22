using System;
using System.Threading.Channels;

public class Scripture
{
    private string _reference;
    private string _text;
    private List<int> hiddenWords = new List<int>();
    private List<string> newWords = new List<string>();
    public void GetRandomScripture()
    {
        var lines = File.ReadAllLines("scriptures.txt");
        List<Scripture> scriptureList = new List<Scripture>();
        foreach (var line in lines)
        {
            var parts = line.Split("|");
            if (parts.Length >= 2)
            {
                try
                {
                    scriptureList.Add(new Scripture{_reference = parts[0], _text = parts[1]});
                }
                catch
                {
                    Console.WriteLine("Failed to read scripture");
                }
            }            
        };
        Random r = new Random();
        if (scriptureList.Count == 0)
        {
            Console.WriteLine("uhhhhhhh that's not supposed to happen");
        }
        else
        {
            int select = r.Next(0,scriptureList.Count);
            Scripture selectedScripture = scriptureList[select];
            _reference = selectedScripture._reference;
            _text = selectedScripture._text;
        }
        List<string> words = new List<string>(_text.Split(" "));
        int tempIn = 0;
        foreach(string w in words)
        {
            hiddenWords.Add(tempIn);
            tempIn ++;
        }
    }
    public void HideWords()
    {
        Random r = new Random();
        if(_text != null)
        {
            for(int i = 0; i < 3; i++)//3 indicates the number of words removed per round
            {
                List<string> words = new List<string>(_text.Split(" "));
                if(hiddenWords.Count() > 0)
                {
                    int wordToRemoveIndex = r.Next(0,hiddenWords.Count());
                    int wordToRemove = hiddenWords[wordToRemoveIndex];
                    hiddenWords.RemoveAt(wordToRemoveIndex); 
                    int index = 0;
                    foreach (var word in words)
                    {
                        if(wordToRemove == index)
                        {
                            string censored = "";
                            for(int i2 = 0; i2 < word.Length; i2++)
                            {
                                censored += "_";
                            }
                            if (newWords.Count < index + 1)
                            {
                                newWords.Add(censored);
                            }
                            else
                            {
                                newWords[index] = censored;
                            }
                        }
                        else
                        {
                            string w = word;
                            if (newWords.Count < index + 1)
                            {
                                newWords.Add(w);
                            }
                            else 
                            {
                                newWords[index] = w;
                            }
                        }
                        index ++;
                    }
                }
                _text = string.Join(" ", newWords);
            }
        }
    }
    public string GetReference()
    {
        return _reference.ToString();//I understood that reference
    }
    public string GetText()
    {
        return _text.ToString();
    }
}