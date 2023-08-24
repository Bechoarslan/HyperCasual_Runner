using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSelector : MonoBehaviour
{
    [SerializeField] private Runner runner;




    public void SelectRunner(int index) 
    {

        for (var i = 0; i < transform.childCount; i++)
        {
            if(i == index) 
            {
                transform.GetChild(i).gameObject.SetActive(true);
                runner.SetAnimator(transform.GetChild(i).gameObject.GetComponent<Animator>());
            }
            else  
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    } 
}
