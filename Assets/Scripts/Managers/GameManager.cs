using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState{Menu,Game,LevelComplete,GameOver}
    public static GameManager instance;

    private GameState gameState;
    public static Action<GameState> onGameStateChanged;






    private void Awake() 
    {  if(instance !=null) 
      {
        Destroy(gameObject);
      }
      else 
      {
            instance = this;

        }
     print(GameManager.instance.gameState);
        
    }



    public void SetGameState(GameState gameState) 
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }

    public bool IsGameState() 
    {
        return gameState == GameState.Game;
    }


}
