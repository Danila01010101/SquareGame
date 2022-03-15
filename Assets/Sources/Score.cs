using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    private void OnEnable()
    {
        BallTrigger.BallTriggered += IncreaseScore;
    }

    private void OnDisable()
    {
        BallTrigger.BallTriggered -= IncreaseScore;
    }
}
