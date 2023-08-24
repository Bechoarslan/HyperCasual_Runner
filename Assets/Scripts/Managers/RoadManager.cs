using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
   public static RoadManager instance;
    [Header("Elements")] 
    [SerializeField] LevelSO[] levels;
    private GameObject finishline;
    
    private void Awake() 
    { if(instance !=null)  
    {
      Destroy(gameObject);
    }
    else 
    {
      instance = this;
    }



    }


    private void Start() 
    { 
      GenerateLevels();
      finishline = GameObject.FindWithTag("Finish");
    }


    private void GenerateLevels() 
    {
      int currentLevel = GetLevel();
      currentLevel = currentLevel % levels.Length;

      LevelSO level = levels[currentLevel];
      CreateOrderedRoad(level.roads);

   }


    private void CreateOrderedRoad(Road[] levelOfRoad) 
    {


      Vector3 roadPosition = Vector3.zero;

      for (int i = 0; i < levelOfRoad.Length; i++)
      {
         Road roadToCreate = levelOfRoad[i];

         if (i > 0)
            roadPosition.z += roadToCreate.GetLength() / 2;
         Road roadInstance = Instantiate(roadToCreate, roadPosition, Quaternion.identity, transform);
         roadPosition.z += roadInstance.GetLength() / 2;


      }

   }

   private void CreateRandomRoad(Road[] roadPrefabs) 
    {
      Vector3 roadPosition = Vector3.zero;

      for (int i = 0; i < 5; i++)
      {
         Road roadToCreate = roadPrefabs[Random.Range(0, roadPrefabs.Length)];

         if (i > 0)
            roadPosition.z += roadToCreate.GetLength() / 2;
         Road roadInstance = Instantiate(roadToCreate, roadPosition, Quaternion.identity, transform);
         roadPosition.z += roadInstance.GetLength() / 2;


      }




   }

   public float FinishLineZPosition() 
   {
      return finishline.transform.position.z;
   }

   public int GetLevel() 
   {

     return PlayerPrefs.GetInt("level",0);
   }
}
