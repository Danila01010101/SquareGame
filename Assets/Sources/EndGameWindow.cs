using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField] private GameObject _endGameScreen;

    public void CheckIfGameIsOver()
    {
        BallTrigger[] ballTriggers = FindObjectsOfType<BallTrigger>();
        bool _isAnyBallsLeft = false;

        foreach (BallTrigger ball in ballTriggers)
        {
            if (ball.IsActive)
            {
                _isAnyBallsLeft = true;
                break;
            }
        }
        if (!_isAnyBallsLeft)
            ShowEndGameScreen();
    }

    private void ShowEndGameScreen()
    {
        _endGameScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        BallTrigger.BallTriggered += CheckIfGameIsOver;
    }

    private void OnDisable()
    {
        BallTrigger.BallTriggered -= CheckIfGameIsOver;
    }
}
