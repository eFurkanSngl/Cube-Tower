using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private Text _scoreText;
    private int score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = score.ToString();
        }
    }

    public void DecreaseScore()
    {
        score--;
        UpdateScoreText();
    }
}
