using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runners;


    private void Update() 
    {
        crowdCounterText.text = runners.childCount.ToString();
        if(runners.childCount <= 0)
        Destroy(gameObject);
    }
}
