using System;
using GameTool;
using TMPro;

public class GameMenu : SingletonUI<GameMenu>
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;

    public void Start()
    {
        scoreText.text = "Score: 0";
        highestScoreText.text = "Highest Score: " + GameData.Instance.HighestScore;
    }
    
    public void UpdateScore(int amount)
    {
        GameData.Instance.score += amount;
        scoreText.text = "Score: " + GameData.Instance.score.ToString();

        if (GameData.Instance.score > GameData.Instance.HighestScore)
        {
            GameData.Instance.HighestScore = GameData.Instance.score;
        }
    }

    public void Update()
    {
        if (GameData.Instance.score > GameData.Instance.HighestScore)
        {
            GameData.Instance.HighestScore = GameData.Instance.score;
        }
    }
}
