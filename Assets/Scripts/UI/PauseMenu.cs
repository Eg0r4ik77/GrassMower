using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _goToMenuButton;
    
    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(Resume);
        _goToMenuButton.onClick.AddListener(GoToMenu);
    }

    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(Resume);
        _goToMenuButton.onClick.RemoveListener(GoToMenu);
    }
    
    protected override void InitializeButtons()
    {
        buttons = new List<Button>
        {
            _resumeButton,
            _goToMenuButton
        };
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