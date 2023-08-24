using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] ShopManager shopManager;
    [Header("Elements")] 
    [SerializeField] private GameObject menuTab;
    [SerializeField] private GameObject settingsTab;
    [SerializeField]private Slider progressBar;
    [SerializeField] private GameObject gameTab;
    [SerializeField] private GameObject gameOverTab;
    [SerializeField] private GameObject gameCompleteTab;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject shopTab;
    
    private void Start() 
    {
        progressBar.value = 1f;
        gameTab.SetActive(false);

       levelText.text = "Level " +  (RoadManager.instance.GetLevel() + 1);
       gameOverTab.SetActive(false);
       gameCompleteTab.SetActive(false);
       settingsTab.SetActive(false);
       HideShop();
       GameManager.onGameStateChanged += GameStateChangedCallBack;
        
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;

    }


    private void Update() 
    {
        if(!GameManager.instance.IsGameState()) return;
        ProggresBarSlider();
        
    }

    private void GameStateChangedCallBack(GameManager.GameState gameState) 
    {
        if(gameState == GameManager.GameState.GameOver) 
        {
            GameOverScreen();
        }
        else if(gameState == GameManager.GameState.LevelComplete)
        {
            GameCompleteScreen();
        }

    }

  





    public void PressedPlayButton() 
    {

        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menuTab.SetActive(false);
        gameTab.SetActive(true);
    }

    public void PressedRetryButton() 
    {
        InterstitialAd.instance.ShowAd();
        
        SceneManager.LoadScene(0);
        
        
        
        
    }

    public void GameOverScreen() 
    {
        gameOverTab.SetActive(true);
        gameTab.SetActive(false);
    }

    public void PressedCompleteButton() 
    {

    }
    public void GameCompleteScreen() 
    {
        gameCompleteTab.SetActive(true);
        gameTab.SetActive(false);
    }


    public void ProggresBarSlider() 
    {

        float progress = PlayerController.instance.transform.position.z  / RoadManager.instance.FinishLineZPosition();
        progressBar.value = progress;
    }

    public void ShowSettingsPanel() 
    {
        settingsTab.SetActive(true);

    }
    public void HideSettingsButton() 
    {
        settingsTab.SetActive(false);
    }

    public void ShowShop() 
    {
        shopTab.SetActive(true);
        shopManager.UpdatePurchase();
      

    }

    public void HideShop() 
    {
        shopTab.SetActive(false);

    }
}
