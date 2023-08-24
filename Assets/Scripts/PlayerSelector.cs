using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform runners;
    [SerializeField] private RunnerSelector runnerSelectorPrefab;
  

   private void Start() 
   {
      ShopManager.onSkinSelected += SelectSkin;
   }

   private void OnDestroy() 
   {
    ShopManager.onSkinSelected -=SelectSkin;
    
   }

    public void SelectSkin(int skinIndex) 
    {
        for (var i = 0; i < runners.childCount; i++)
        {
            runners.GetChild(i).GetComponent<RunnerSelector>().SelectRunner(skinIndex);
            runnerSelectorPrefab.SelectRunner(skinIndex);
            
        }
    }
}
