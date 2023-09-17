using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    private void OnEnable()
    {
        _buttons[0].onClick.AddListener(Play);
        _buttons[1].onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _buttons[0].onClick.RemoveListener(Play);
        _buttons[1].onClick.RemoveListener(Exit);
    }

    private void Play()
    {
        Paused = false;
        SceneManager.LoadScene("GameScene");
    }

    private void Exit()
    {
        print("Quit");
        Application.Quit();
    }
}
