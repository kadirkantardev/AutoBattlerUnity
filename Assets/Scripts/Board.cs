using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] Transform tilePrefab;
    public float offset = 2;

    public static Board Instance { get; private set; }

    public int width, height;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate instance of Board found. Destroying the new one.");
            Destroy(gameObject);
        }
    }


    void Start()
    {
        BoardData.Init(offset);

        foreach (KeyValuePair<Vector3, GameObject> tile in BoardData.grid)
        {
            var cell = Instantiate(tilePrefab, tile.Key, Quaternion.identity);
            cell.parent = transform;
        }

        var obj = Instantiate(GameAssets.Instance.cyborgUnit);
        obj.resting_pos = transform.position;

       

        
    }


    
}
