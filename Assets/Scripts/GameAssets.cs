using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }


    public Unit criminalUnit;
    public Unit cyborgUnit;

    public List<Unit> pool;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate instance of GameAssets found. Destroying the new one.");
            Destroy(gameObject);
        }

        
    }
}
