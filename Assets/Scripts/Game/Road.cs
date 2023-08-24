using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Road : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Vector3 size;





public float GetLength() 
{
    return size.z;
}


   private void OnDrawGizmos() 
   {   Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,size);
   

    
   }
}
