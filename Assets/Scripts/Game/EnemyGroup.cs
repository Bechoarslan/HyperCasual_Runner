using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Elements")] 
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemiesParent;


    [Header("Settings")]
    [SerializeField] private int enemyAmount;
    [SerializeField] private float angle;
    [SerializeField] private float radius;



   private void Start() 
   {
     GenerateEnemies();
   }





    private void GenerateEnemies() 
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Vector3 localEnemyPosition = GetPlayerLocalPosition(i);
            Vector3 enemyWorldPosition = transform.TransformPoint(localEnemyPosition);
            Instantiate(enemyPrefab,enemyWorldPosition,enemiesParent.rotation,enemiesParent);
            
        }


    }






    private Vector3 GetPlayerLocalPosition(int index)
    {

        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x, 0, z);
    }
}
