using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public static class BoardData
{
    

    
    public static Dictionary<Vector3, GameObject> grid;




    


    



    public static void PlaceUnit(GameObject unit, int x, int y)
    {
        if (x >= 0 && x < Board.Instance.width && y >= 0 && y < Board.Instance.height)
        {
            grid[new Vector3(x, 0, y)] = unit;
        }
    }

    public static void RemoveUnit(int x, int y)
    {
        if (x >= 0 && x < Board.Instance.width && y >= 0 && y < Board.Instance.height)
        {
            grid[new Vector3(x,0,y)] = null;
        }
    }

    public static GameObject GetUnit(int x, int y)
    {
        if (x >= 0 && x < Board.Instance.width && y >= 0 && y < Board.Instance.height)
        {
            return grid[new Vector3(x,0,y)];
        }

        return null;
    }





    
    public static void Init(float offset)
    {
        grid = new Dictionary<Vector3,GameObject>();

        for (int y = 0; y < Board.Instance.height; y++)
        {
            for (int x = 0; x < Board.Instance.width; x++)
            {
                grid.Add(new Vector3(x * offset, 0, y * offset), null);
            }
        }
    }

    
}
