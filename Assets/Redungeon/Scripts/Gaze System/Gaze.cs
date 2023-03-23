using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Gaze : MonoBehaviour
{
    // —————————— propierties
    public UnityEvent<GameObject> OnPointerEnter
    {
        get => _onPointerEnter;
        set => _onPointerEnter = value;
    }
    public UnityEvent<GameObject> OnPointerStay
    {
        get => _onPointerStay;
        set => _onPointerStay = value;
    }
    public UnityEvent<GameObject> OnPointerExit
    {
        get => _onPointerExit;
        set => _onPointerExit = value;
    }
    public Image LoadingBar
    {
        get => loadingBar;
        set => loadingBar = value;
    }

    

    // —————————— fields
    private const float MaxDistance = 5;
    private GameObject _gazedAtObject = null;

    private UnityEvent<GameObject> _onPointerEnter = new();
    private UnityEvent<GameObject> _onPointerStay = new();
    private UnityEvent<GameObject> _onPointerExit = new();
    
    [SerializeField]
    private Image loadingBar;
    


    // —————————— unity methods
    private void Start()
    {
        
    }
    private void Update()
    {
        Watch();
    }


    
    // —————————— class methods
    private void Watch()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance))
        {
            // Se encuentra un nuevo objeto al frente de la cámara.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // El objeto anterior sale.
                _onPointerExit.Invoke(_gazedAtObject);
                
                // El nuevo objeto entra.
                _gazedAtObject = hit.transform.gameObject;
                _onPointerEnter.Invoke(_gazedAtObject);
            }
            else
            {
                // Es el mismo objeto
                _onPointerStay.Invoke(_gazedAtObject);
            }
        }
        else
        {
            // No se detecta ningun objeto, entonces el objeto actual sale.
            _onPointerExit.Invoke(_gazedAtObject);
            _gazedAtObject = null;
        }
    }
}
