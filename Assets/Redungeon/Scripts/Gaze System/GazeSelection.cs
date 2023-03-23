using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Events;
using Image = UnityEngine.UI.Image;

public class GazeSelection : MonoBehaviour
{
    // —————————— propierties
    public UnityEvent OnSelected
    {
        get => _onSelected;
        set => _onSelected = value;
    }

    

    // —————————— fields
    private Gaze _gaze;

    private bool _isLoading;
    private bool _isSelected;
    private UnityEvent _onSelected = new();

    [SerializeField, Header("Selection")]
    private bool singleSelection;

    [SerializeField]
    private float duration = 5;
    private float _timer;
    private int _loadingValue;

    private Image loadingBar;


    // —————————— unity methods
    private void Start()
    {
        _gaze = Camera.main.GetComponent<Gaze>();
        _gaze.OnPointerEnter.AddListener(PointerEnter);
        _gaze.OnPointerExit.AddListener(PointerExit);

        loadingBar = _gaze.LoadingBar;
    }
    private void FixedUpdate()
    {
        if (_isSelected && singleSelection)
            return;
        
        Load();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }


    // —————————— class methods
    private void PointerEnter(GameObject gazedAtObject)
    {
        if (gazedAtObject != gameObject)
            return;

        _isLoading = true;
    }
    private void PointerExit(GameObject gazedAtObject)
    {
        if (gazedAtObject != gameObject)
            return;

        SetLoadingValue(0);
        _timer = 0;
        _isLoading = false;
    }
    private void Load()
    {
        if (!_isLoading)
            return;

        _timer += Time.fixedDeltaTime;
        SetLoadingValue((int) ((_timer / duration) * 100));

        if (_loadingValue >= 100)
        {
            SetLoadingValue(0);
            _timer = 0;
            
            _isLoading = false;
            _isSelected = true;
            _onSelected?.Invoke();
        }
        
        Debug.Log($"Loading Value {_loadingValue}");
    }

    private void SetLoadingValue(int value)
    {
        _loadingValue = value;
        loadingBar.fillAmount = (_loadingValue / 100f);
    }
    private void RemoveListeners()
    {
        _gaze.OnPointerEnter.RemoveListener(PointerEnter);
        _gaze.OnPointerExit.RemoveListener(PointerExit);
    }
}
