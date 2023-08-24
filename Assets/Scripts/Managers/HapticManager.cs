using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticManager : MonoBehaviour
{
    private bool isHaptic;
    
    private void Start()
    {
        PlayerDetection.onHitSound += VibrationPhone;
        Enemy.onHitEnemy += VibrationPhone;
        GameManager.onGameStateChanged += GameStateChangedCallBack;

        
    }

    private void  OnDestroy() 
    {
        PlayerDetection.onHitSound -= VibrationPhone;
        Enemy.onHitEnemy -= VibrationPhone;
        GameManager.onGameStateChanged -= GameStateChangedCallBack;

    }

    private void GameStateChangedCallBack(GameManager.GameState gameState) 
    {
        if(gameState == GameManager.GameState.LevelComplete)
            VibrationPhone();

        else if(gameState == GameManager.GameState.GameOver)
            VibrationPhone();
    }

    private void VibrationPhone() 
    {
        if(isHaptic)
        Vibration.Vibrate();

    }

    public void DisableVibration() 
    {
        isHaptic = false;


    }

    public void EnableVibration() 
    {
        isHaptic = true;


    }



    
}
