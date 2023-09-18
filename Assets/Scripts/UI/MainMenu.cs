using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    
    private void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
        _exitButton.onClick.RemoveListener(Exit);
    }

    protected override void InitializeButtons()
    {
        buttons = new List<Button>
        {
            _playButton,
            _exitButton
        };
    }
    
    private void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void Exit()
    {
        Application.Quit();
    }
}
