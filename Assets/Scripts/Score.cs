using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private Text _scoreText;
    private int _score;
    
    
    // Start is called before the first frame update
    void Start()
    {
       _score = 0;
    }

    public void IncreaseScore(int score)
    {
        _score+=score;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString();
        }
    }

    public void DecreaseScore(int score)
    {
        _score -= score;
        UpdateScoreText();
    }
}
