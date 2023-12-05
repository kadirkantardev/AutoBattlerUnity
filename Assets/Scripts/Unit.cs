using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private float attack;
    [SerializeField] private float health;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask groundLayer;

    public Vector3 resting_pos;

    public bool isDragging = false;
   

    private void Move()
    {

    }

    private void Attack()
    {

    }


    public abstract void UseUltimate();

    #region DragNDrop
    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition =  GetMouseWorldPos();
            float groundLevel = .2f;
            Vector3 dragPosition = new Vector3(newPosition.x, resting_pos.y+groundLevel, newPosition.z);

            transform.localPosition = dragPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        BoardData.RemoveUnit(Mathf.FloorToInt(resting_pos.x), Mathf.FloorToInt(resting_pos.z));

        float roundedX = Mathf.Round(transform.position.x / Board.Instance.offset) * Board.Instance.offset;
        float roundedZ = Mathf.Round(transform.position.z / Board.Instance.offset) * Board.Instance.offset;


        resting_pos = new Vector3(
            Mathf.Clamp(roundedX, 0, (Board.Instance.width - 1) * Board.Instance.offset),
            0.2f,
            Mathf.Clamp(roundedZ, 0, (Board.Instance.height - 1) * Board.Instance.offset)
        );
        transform.position = resting_pos;
        BoardData.PlaceUnit(this.gameObject, Mathf.FloorToInt(resting_pos.x),Mathf.FloorToInt(resting_pos.z));

        Console.Clear();
        foreach (KeyValuePair<Vector3, GameObject> tile in BoardData.grid)
        {
            print(string.Format("[{0}] | [{1}]", tile.Key, tile.Value));
        }

    }

    private Vector3 GetMouseWorldPos()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,groundLayer))
        {
            
            return hit.point;
        }
        
        
        return Vector3.zero;

    }
    #endregion


    
}
