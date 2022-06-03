using System.IO;

public class LoadAndSaceScript
{
    private struct PlayerScore
    {
        public string Name;
        public float Score;
    }

    private int _scoreBoardLength;
    private PlayerScore[] _scoreBoard;

    public void AddScore(string name)
    {
        PlayerScore[] temp = new PlayerScore[_scoreBoardLength + 1];
        for (int i = 0; i < _scoreBoard.Length; i++)
            temp[i] = _scoreBoard[i];

        temp[_scoreBoardLength] = new PlayerScore { Name = name, Score = GameManagerScript.GameScore };

        _scoreBoard = temp;
    }

    public void Save()
    {
        StreamWriter write = new StreamWriter("HighScores.txt");

        write.WriteLine(_scoreBoardLength.ToString());

        foreach(PlayerScore score in _scoreBoard)
        {
            write.WriteLine(score.Name);
            write.WriteLine(score.Score);
        }    

        write.Close();
    }

    public bool Load()
    {
        if (!File.Exists("HighScores.txt"))
            return false;

        StreamReader reader = new StreamReader("HighScores.txt");

        if (!int.TryParse(reader.ReadLine(), out _scoreBoardLength))
            return false;

        _scoreBoard = new PlayerScore[_scoreBoardLength];

        for(int i = 0; i < _scoreBoard.Length; i++)
        {
            _scoreBoard[i].Name = reader.ReadLine();

            if (float.TryParse(reader.ReadLine(), out _scoreBoard[i].Score))
                return false;
        }

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

            float currentValue = _scoreBoard[i].Score;
            if (currentValue > _scoreBoard[j].Score)
            {
                _scoreBoard[i] = _scoreBoard[j];
                _scoreBoard[j].Score = currentValue;
            }
        }
    }
}
