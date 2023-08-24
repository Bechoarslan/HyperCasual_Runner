using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    [Header("Elements")] 
    [SerializeField] Transform localRunners;


    public void Run() 
    {
        for (var i = 0; i < localRunners.childCount; i++)
        {
            Transform runnners = localRunners.GetChild(i);
            Animator runnerAnimator = runnners.GetComponent<Runner>().GetAnimator();
            runnerAnimator.Play("Run");          
        }


    }

    public void Idle() 
    {
        for (var i = 0; i < localRunners.childCount; i++)
        {
            Transform runnners = localRunners.GetChild(i);
            Animator runnerAnimator = runnners.GetComponent<Runner>().GetAnimator();
            runnerAnimator.Play("Idle");
        }



    }
}
