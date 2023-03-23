using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GazeSelection))]
public class Door : MonoBehaviour
{
    // —————————— fields
    private GazeSelection _selection;
    
    [SerializeField]
    private GameObject doorOpened;


    // —————————— unity methods
    private void Start()
    {
        _selection = GetComponent<GazeSelection>();
        _selection.OnSelected.AddListener(Open);
    }


    
    // —————————— class methods
    public void Open()
    {
        Transform spawn = transform;
        Instantiate(doorOpened, spawn.position, spawn.rotation);
        
        Destroy(gameObject);
    }
}
