using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource runnerDie;
    [SerializeField] private AudioSource levelComplete;
    [SerializeField] private AudioSource gameOver;


    private void Start() 
    {
        PlayerDetection.onHitSound += HitSound;
        GameManager.onGameStateChanged += GameStateChangedCallBack;
        Enemy.onHitEnemy += HitEnemySound;
    }

    private void OnDestroy() 
    {
        PlayerDetection.onHitSound -= HitSound;
        Enemy.onHitEnemy -= HitEnemySound;
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }



    private void HitSound() 
    {

        hitSound.Play();
    }

    private void GameStateChangedCallBack(GameManager.GameState state) 
    {
        if(state == GameManager.GameState.LevelComplete)
        levelComplete.Play();
        else if(state == GameManager.GameState.GameOver)
        gameOver.Play();
    }

    private void HitEnemySound() 
    {
        runnerDie.Play();
    }

    public void DisableSound() 
    {
        hitSound.volume = 0;
        runnerDie.volume = 0;
        levelComplete.volume = 0;
        gameOver.volume = 0;
        buttonSound.volume = 0;

    }

    public void EnableSound() 
    {
        hitSound.volume = 1;
        runnerDie.volume = 1;
        levelComplete.volume = 1;
        gameOver.volume = 1;
        buttonSound.volume = 1;
    }
}
