using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;
    public static Action onHitSound;
    
    private void Update() 
    {
        if(GameManager.instance.IsGameState())
        DetectDoors();
       
        
    }

    

    private void DetectDoors() 
    {

        Collider[] detectedCollider = Physics.OverlapSphere(transform.position,crowdSystem.GetCrowdRadius());
        
        for (int i = 0; i < detectedCollider.Length; i++)
        {
            if(detectedCollider[i].TryGetComponent(out Door doors))
            {
                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);

                doors.Disable();
                onHitSound?.Invoke();

                crowdSystem.ApplyBonus(bonusType,bonusAmount);
            }

            else if (detectedCollider[i].tag == "Finish") 
            {
                PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level") + 1);
                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
                
                //SceneManager.LoadScene(0);
                
                
                



            }
            else if (detectedCollider[i].tag == "Coin") 
            {
                Destroy(detectedCollider[i].gameObject);
                DataManager.instance.AddCoins(100);
                
                
               
            }
            
        }
    }
}
