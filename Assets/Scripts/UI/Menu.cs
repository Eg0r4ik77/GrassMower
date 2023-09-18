using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _scrollButtonSecondsDelay = 0.3f;

    [SerializeField] private Color _defaultColor = Color.white;
    [SerializeField] private Color _focusColor = Color.green;
    
    protected List<Button> buttons;
    private int _currentButtonIndex;
    
    private bool _canScroll = true;
    
    public Action Closed;

    private void Start()
    {
        InitializeButtons();
        SetDefaultColorToButtons();
        SwitchButton(_currentButtonIndex);
    }
    
    protected abstract void InitializeButtons();

    public void Open()
    {
        SetActive(true);
    }

    protected void Close()
    {
        Closed?.Invoke();
        SetActive(false);
    }

    public async void TrySwitchButton(Vector2 direction)
    {
        if (!_canScroll || direction == Vector2.zero)
            return;

        int indexStep = direction.y > 0 ? -1 : 1;
        int newIndex = _currentButtonIndex + indexStep;
        
        newIndex = Math.Clamp(newIndex, 0, buttons.Count - 1);

        SwitchButton(newIndex);
        await BlockScrollingForDelay();
    }
    
    public void ClickCurrentButton()
    {
        buttons[_currentButtonIndex].onClick?.Invoke();
    }
    
    private void SetActive(bool active)
    {
        _panel.SetActive(active);
    }

    private async Task BlockScrollingForDelay()
    {
        _canScroll = false;
        await Task.Delay((int)(_scrollButtonSecondsDelay * 1000));
        _canScroll = true;
    } 
    
    private void SetDefaultColorToButtons()
    {
        buttons.ForEach(button => button.image.color = _defaultColor);
    }
    
    private void SwitchButton(int index)
    {
        SetCurrentButtonColor(_defaultColor);
        _currentButtonIndex = index;
        SetCurrentButtonColor(_focusColor);
    }

    private void SetCurrentButtonColor(Color color)
    {
        buttons[_currentButtonIndex].image.color = color;
    }
}