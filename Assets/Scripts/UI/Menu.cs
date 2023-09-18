using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    protected List<Button> buttons;

    private int _currentButtonIndex;
    
    private bool _canScroll = true;
    private Timer _timer;
    
    public Action Closed;

    private void Start()
    {
        InitializeButtons();
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

    protected abstract void InitializeButtons();

    public void SwitchButton(Vector2 direction)
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
            if (newIndex == buttons.Count) newIndex--;
        }
        
        SwitchButton(newIndex);
        _canScroll = false;
        _timer = new Timer(.5f, () => _canScroll = true);
    }
    

    public void ClickCurrentButton()
    {
        buttons[_currentButtonIndex].onClick?.Invoke();
    }
    
    private void SetActive(bool active)
    {
        _panel.SetActive(active);
    }
    
    private void SwitchButton(int index)
    {
        buttons[_currentButtonIndex].image.color = Color.white;
        _currentButtonIndex = index;
        buttons[_currentButtonIndex].image.color = Color.green;
    }
}