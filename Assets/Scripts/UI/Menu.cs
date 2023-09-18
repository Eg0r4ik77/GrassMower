using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    protected List<Button> buttons;

    private int _currentButtonIndex;
    private bool _canScroll = true;
    
    public Action Closed;

    private void Start()
    {
        InitializeButtons();
        SwitchButton(_currentButtonIndex);
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

    public async void SwitchButton(Vector2 direction)
    {
        if (!_canScroll)
            return;
        
        int newIndex = _currentButtonIndex + (direction.y > 0 ? -1 : 1);
        newIndex = Math.Clamp(newIndex, 0, buttons.Count - 1);

        SwitchButton(newIndex);
        
        _canScroll = false;
        await Task.Delay(500);
        _canScroll = true;
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