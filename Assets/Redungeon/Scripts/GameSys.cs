using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSys : MonoBehaviour
{
    // —————————— fields
    private int discoveredTreasures;
    private int treasuresCount;


    
    // —————————— class methods
    public void AddCount()
    {
        treasuresCount++;
    }
    public void Collect()
    {
        discoveredTreasures++;
        Debug.Log($"Treasures: {discoveredTreasures}");

        if (discoveredTreasures == treasuresCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
