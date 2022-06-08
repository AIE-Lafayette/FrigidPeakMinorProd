using System.IO;

public class LoadAndSaveScript
{
    private struct PlayerScore
    {
        public string Name;
        public float Score;

     
    }

    private int _scoreBoardLength = 0;
    private PlayerScore[] _scoreBoard = new PlayerScore[0];

    private string _path;
    public LoadAndSaveScript(string path)
    {
        _path = path;
    }

    public void AddScore(string name, float score)
    {
        PlayerScore[] temp = new PlayerScore[_scoreBoardLength + 1];
        for (int i = 0; i < _scoreBoard.Length; i++)
            temp[i] = _scoreBoard[i];
        
        temp[_scoreBoardLength] = new PlayerScore { Name = name, Score = score };

        _scoreBoardLength++;

        _scoreBoard = temp;
    }

    public void Save()
    {
        if (!File.Exists("HighScores.txt"))
        {
            StreamWriter write = File.CreateText(_path);

            write.WriteLine(_scoreBoardLength.ToString());

            foreach (PlayerScore score in _scoreBoard)
            {
                write.WriteLine(score.Name);
                write.WriteLine(score.Score);
            }

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

        if (!int.TryParse(reader.ReadLine(), out _scoreBoardLength))
            return false;

        _scoreBoard = new PlayerScore[_scoreBoardLength];

        for (int i = 0; i < _scoreBoard.Length; i++)
        {

            _scoreBoard[i].Name = reader.ReadLine();

            if (float.TryParse(reader.ReadLine(), out _scoreBoard[i].Score))
                return false;
        }
        reader.Close();

        SortArry();
            return true;
    }

    private void SortArry()
    {
        for (int i = 0; i < _scoreBoard.Length; i++)
        {
            int j = i + 1;
            if (j == _scoreBoard.Length)
                continue;

            PlayerScore currentValue = _scoreBoard[i];
            if (currentValue.Score < _scoreBoard[j].Score)
            {
                _scoreBoard[i] = _scoreBoard[j];
                _scoreBoard[j] = currentValue;
            }
            else continue;
        }
    }

    public float HighScore()
    {
        if (!File.Exists(_path))
        {
            _scoreBoardLength = 3;
            _scoreBoard = new PlayerScore[] 
            { 
                new PlayerScore { Name = "Andrzej Bargiel", Score = 8611f },
                new PlayerScore { Name = "Nirmal 'Nims' Purja", Score = 29032f },
                new PlayerScore { Name = "Denis Urubko", Score = 8000f}    
            };
        }
            SortArry();
        return _scoreBoard[0].Score;
    }
}