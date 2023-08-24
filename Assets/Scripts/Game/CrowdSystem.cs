using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{    
    [Header("Elements")]
    [SerializeField] private Transform localRunners;
    [SerializeField] private GameObject runnerPrefab;
    [SerializeField] private PlayerAnimator playerAnimator;
    
    
    
    [Header("Settings")] 
       [SerializeField] private float angle;
       [SerializeField] private float radius;



       private void Update() 
       {
        if(!GameManager.instance.IsGameState()) return;

          PlaceRunners();
          if(localRunners.childCount <=0) 
          {
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
          }
       }

    




    private void PlaceRunners() 
    {


        for (int i = 0; i < localRunners.childCount; i++)
        {
            Vector3 childLocalPosition = GetPlayerLocalPosition(i);
            localRunners.GetChild(i).localPosition = childLocalPosition;
            playerAnimator.Run();
            
        }
    }




    private Vector3 GetPlayerLocalPosition(int index) 
    {

        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x,0,z);
    }

    public float GetCrowdRadius() 
    {
        return radius * Mathf.Sqrt(localRunners.childCount);
    }


    public void ApplyBonus(BonusType bonusType, int bonusAmount) 
    {

        switch(bonusType) 
        {
            case BonusType.Addition:
            AddRuners(bonusAmount);
            break;
            case BonusType.Product:
            int runnersToAdd = (localRunners.childCount * bonusAmount) - localRunners.childCount;
            AddRuners(runnersToAdd);
            break;
            case BonusType.Difference:
            RemoveRunners(bonusAmount);
            break;
            case BonusType.Division:
            int runnersToDivision = localRunners.childCount - (localRunners.childCount / bonusAmount);
            RemoveRunners(runnersToDivision);
            break;

        }

    }

    public void AddRuners(int bonusAmount) 
    {
        for (int i = 0; i < bonusAmount; i++)
        {
            Instantiate(runnerPrefab, localRunners);

        }


    }

    public void RemoveRunners(int bonusAmount) 
    {
        if(bonusAmount > localRunners.childCount)
         bonusAmount = localRunners.childCount;

         int runnersAmount = localRunners.childCount;

         for(int i = runnersAmount - 1; i >= runnersAmount - bonusAmount; i--) 
         {
            Transform runnerToDestroy = localRunners.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
         }


    }
}
