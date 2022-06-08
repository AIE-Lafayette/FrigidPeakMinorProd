using System.IO;

public class Highscore
{
    //current highscore
    private int _currentHighscore;
    private string _path;

    //proporty for the current so that anyone assessing it only gets and not make any changes to the highscore
    public int CurrentHighscore { get => _currentHighscore; }
    //Contructor for the highscore
    public Highscore(int highscore, string path)
    {
        _currentHighscore = highscore;
        _path = path; 
    }

    /// <summary>
    /// Changes the highscore once the score is greater then the current highscore
    /// </summary>
    /// <param name="newscore">new score </param>
    public void NewScore(int newscore)
    {
        //If the new score is greater then the current highscore 
        if (newscore >= _currentHighscore)
            //makes the new score be that of the new score 
            _currentHighscore = newscore;
    }

    public void Save()
    {
            StreamWriter write = File.CreateText(_path);
        if (!File.Exists(_path))
        {
            write.WriteLine(_currentHighscore.ToString());
            write.Close();
        }
        else
            File.AppendText(_path);
    }


    public bool Load()
    {
        if (!File.Exists(_path))
            return false;

        StreamReader reader = new StreamReader(_path);


        if (!int.TryParse(reader.ReadLine(), out _currentHighscore))
            return false;

        reader.Close();

        return true;
    }

}