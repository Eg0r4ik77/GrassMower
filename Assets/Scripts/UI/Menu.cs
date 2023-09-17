using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool Paused;
    
    [SerializeField] private GameObject _panel;
    [SerializeField] protected List<Button> _buttons;

    private int _currentButtonIndex;
    
    private bool _canScroll = true;
    private Timer _timer;
    
    public Action Closed;

    private void Start()
    {
        SwitchButton(_currentButtonIndex);
    }

    private void Update()
    {
        if(_timer is { Started: true })
            _timer.Tick();
    }

    public void Open()
    {
        SetActive(true);
    }

    protected void Close()
    {
        Closed?.Invoke();
        SetActive(false);
    }

    public void SwitchButton(Vector2 direction)
    {
        print($"Scroll: {_canScroll}");
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
    

    public void ClickCurrentButton()
    {
        _buttons[_currentButtonIndex].onClick?.Invoke();
    }
    
    private void SetActive(bool active)
    {
        _panel.SetActive(active);
        Paused = active;
    }
    
    private void SwitchButton(int index)
    {
        _buttons[_currentButtonIndex].image.color = Color.white;
        _currentButtonIndex = index;
        _buttons[_currentButtonIndex].image.color = Color.green;
    }
}