using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool Paused;
    
    [SerializeField] private GameObject _panel;
    [SerializeField] protected List<Button> _buttons;

    private int _currentButtonIndex;
    
    private bool _canScroll = true;
    private Timer _timer;

    private void Start()
    {
        SwitchButton(_currentButtonIndex);
    }

    private void Update()
    {
        if(_timer is { Started: true })
            _timer.Tick();
    }
    

    public void SwitchActive()
    {
        _panel.SetActive(!_panel.activeSelf);
        Paused = _panel.activeSelf;
    }

    public void MoveToButton(Vector2 direction)
    {
        if (!_canScroll)
            return;
        
        int newIndex = _currentButtonIndex;
        
        if (direction.y > 0)
        {
            newIndex--;
            if (newIndex == -1) newIndex++;
        }
        else
        {
            newIndex++;
            if (newIndex == _buttons.Count) newIndex--;
        }
        
        SwitchButton(newIndex);
        _canScroll = false;
        _timer = new Timer(.5f, () => _canScroll = true);
    }

    public void SwitchButton(int index)
    {
        _buttons[_currentButtonIndex].image.color = Color.white;
        _currentButtonIndex = index;
        _buttons[_currentButtonIndex].image.color = Color.green;
    }

    public void ClickCurrentButton()
    {
        _buttons[_currentButtonIndex].onClick?.Invoke();
    }
}