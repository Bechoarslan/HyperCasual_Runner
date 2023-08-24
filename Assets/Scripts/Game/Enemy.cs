using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State{ Idle,Running}

    [Header("Settings")]
    [SerializeField] private float chaseRadius;
    [SerializeField] private float moveSpeed;
    private State state;
    private Transform targetRunner;
    public static Action onHitEnemy;

private void Update() 
{
    ManageState();
}





    private void ManageState() 
    {

        switch(state) 
        {

            case State.Idle:
            SearchForTarget();
            break;
            case State.Running:
            RunTowardsTarget();
            break;
        }
    }
    private void SearchForTarget() 
    {
        Collider[] detectedCollider = Physics.OverlapSphere(transform.position,chaseRadius);

        for (int i = 0; i < detectedCollider.Length; i++)
        {
            if(detectedCollider[i].TryGetComponent(out Runner runner)) 
            {
                if(runner.IsTarget())
                continue;
 
                runner.SetTarget();
                targetRunner = runner.transform;
                StartRunningTowardsTarget();

            }            
        }
    }

    private void StartRunningTowardsTarget() 
    {
        state = State.Running;
        GetComponent<Animator>().Play("Run");


    }

    private void RunTowardsTarget() 
    {
        if(targetRunner == null)
        return;

        transform.position = Vector3.MoveTowards(transform.position,targetRunner.position, Time.deltaTime * moveSpeed);

        if(Vector3.Distance(transform.position,targetRunner.position) < .1f) 
        {
            onHitEnemy?.Invoke();
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }



    }
}


