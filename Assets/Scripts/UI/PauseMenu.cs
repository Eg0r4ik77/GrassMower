using UnityEngine.SceneManagement;

public class PauseMenu : Menu
{
    private void OnEnable()
    {
        _buttons[0].onClick.AddListener(Resume);
        _buttons[1].onClick.AddListener(GoToMenu);
    }

    private void OnDisable()
    {
        _buttons[0].onClick.RemoveListener(Resume);
        _buttons[1].onClick.RemoveListener(GoToMenu);
    }

    private void Resume()
    {
        Close();
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}