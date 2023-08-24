using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SoundManager soundManager;
    [SerializeField] HapticManager hapticManager;
    [SerializeField] private Sprite settingsOff;
    [SerializeField] private Sprite settingsOn;
    [SerializeField] private Image soundImage;
    [SerializeField] private Image vibrationImage;

    [Header("Settings")]
    [SerializeField]private bool isSound = true;
    private bool isVibration = true;



   private void Awake() 
   {
      isSound = PlayerPrefs.GetInt("sounds") == 1;
      isVibration = PlayerPrefs.GetInt("vibration") == 1;
   }


    private void Start() 
    {
        Setup();
        VibrationSetUp();
    }


    private void Setup() 
    {
        if(isSound)
        EnableSound();
        else 
        DisableSound();

        
    }

    private void VibrationSetUp() 
    {
        if(isVibration)
        EnableVibration();
        else
        DisableVibration();
    }


    public void ChangeSoundState() 
    {
        if(isSound)
            DisableSound();
            
        else
        EnableSound();
       
        

        isSound = !isSound;
        PlayerPrefs.SetInt("sounds",isSound ? 1 : 0);

    }

    public void ChangeVibrationState() 
    {
        if(isVibration)
            DisableVibration();
        else
        EnableVibration();

        isVibration = !isVibration;
        PlayerPrefs.SetInt("vibration",isVibration ? 1 : 0);

    }

    private void EnableSound() 
    {

        soundImage.sprite = settingsOn;
        soundManager.EnableSound();

    }

    private void DisableSound() 
    {
        soundImage.sprite = settingsOff;
        soundManager.DisableSound();

    }

    private void EnableVibration() 
    {
        vibrationImage.sprite = settingsOn;
        hapticManager.EnableVibration();

    }
    
    private void DisableVibration() 
    {
        vibrationImage.sprite = settingsOff;
        hapticManager.DisableVibration();

    }
}
