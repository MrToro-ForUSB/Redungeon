using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GazeSelection))]
public class Treasure : MonoBehaviour
{
    // —————————— fields
    private GameSys _gameSys;
    private GazeSelection _selection;


    // —————————— unity methods
    private void Start()
    {
        GameObject gameSysGameObject = GameObject.FindWithTag("GameController");
        _gameSys = gameSysGameObject.GetComponent<GameSys>();
        _gameSys.AddCount();

        _selection = GetComponent<GazeSelection>();
        _selection.OnSelected.AddListener(Open);
    }


    
    // —————————— class methods
    public void Open()
    {
        _gameSys.Collect();
        Destroy(gameObject);
    }
}
