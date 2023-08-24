using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;




public class ShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Button purchaseButton;
    [SerializeField] private SkinButton[] skinButton;
    [Header("Skins")]
    [SerializeField] private  Sprite[] skins;
    [Header("Settings")]
    [SerializeField] private int skinPrice;
    [SerializeField] private TextMeshProUGUI skinText;

    public static Action<int> onSkinSelected;
 

    private void Awake() 
    {
        UnlockedSkin(0);
        skinText.text = skinPrice.ToString();
    }
    IEnumerator Start()
    {
        RewardedAds.onRewardedAdCompleted += RewardPlayer;
        ConfigureButtons();
        UpdatePurchase();
        yield return null;

       SelectSkin(GetSelectedLastSkin()) ;
    }
    private void OnDestroy() 
    {
        RewardedAds.onRewardedAdCompleted -= RewardPlayer;

    }

    private void RewardPlayer() 
    {
        DataManager.instance.AddCoins(150);
        UpdatePurchase();
        
    }
    

    private void ConfigureButtons()
    {
       for (var i = 0; i < skinButton.Length; i++)
       {
          bool unlocked = PlayerPrefs.GetInt("skinButton" + i) == 1;
           skinButton[i].Configure(skins[i],unlocked);
           int skinIndex = i;
           skinButton[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));

        
       }
        
    }


    public void UnlockedSkin(int skinIndex) 
    {
        PlayerPrefs.SetInt("skinButton" + skinIndex,1);
        skinButton[skinIndex].Unlock();
    }

    private void UnlockedSkin(SkinButton skinButton) 
    {
        int skinIndex = skinButton.transform.GetSiblingIndex();
        UnlockedSkin(skinIndex);

    }

    private void SelectSkin(int index) 
    {
        for (var i = 0; i < skinButton.Length; i++)
        {
            if(index == i) 
            {
                skinButton[i].Select();
            }
            else 
            {
                skinButton[i].DeSelect();
            }

           
             
        }
        onSkinSelected?.Invoke(index);
        SetLastSelectedSkin(index);

    }

    public void PurchaseSkin() 
    {
        List<SkinButton> skinButtonsList = new List<SkinButton>();
        for (var i = 0; i < skinButton.Length; i++)
        {
            if(!skinButton[i].IsUnlocked())
        skinButtonsList.Add(skinButton[i]);
            
        }
        if(skinButtonsList.Count <= 0) return;

       SkinButton randomSkinButton = skinButtonsList[Random.Range(0,skinButtonsList.Count)];
       UnlockedSkin(randomSkinButton);
       SelectSkin(randomSkinButton.transform.GetSiblingIndex());
       DataManager.instance.RemoveCoins(skinPrice);
       UpdatePurchase();
    }


    public void UpdatePurchase() 
    {
        if(DataManager.instance.GetCoins() < skinPrice)
        purchaseButton.interactable = false;
        else
        purchaseButton.interactable = true;



    }

    private int GetSelectedLastSkin() 
    {
        return PlayerPrefs.GetInt("playerSkin",0);

    }

    private void SetLastSelectedSkin(int skinIndex) 
    {
        PlayerPrefs.SetInt("playerSkin",skinIndex);

    }

    
}
