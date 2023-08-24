using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Elements")]
    [SerializeField] private float speed;
    [SerializeField] private CrowdSystem crowdSystem;
    [SerializeField] private PlayerAnimator playerAnimator;
    private bool canMove;
    [Header("Controller")] 
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;
    private float roadWith = 10;

    private void Awake() 
    {
        if(instance != null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }
        
    }

    private void Start() 
    {
        GameManager.onGameStateChanged += GameStateChangedCallBack;


    }

    private void OnDestroy() 
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;

    }
    private void Update() 
    {
        if(canMove) 
        {
            MoveForward();
            ManageController();

        }
        

    }

    private void PlayerMove() 
    {
        canMove = true;
        playerAnimator.Run();

    }

    private void PlayerStop() 
    {
        canMove = false;
        playerAnimator.Idle();



    }

    private void GameStateChangedCallBack(GameManager.GameState gameState) 
    {
        if(gameState == GameManager.GameState.Game)
        {
            PlayerMove();

        }
        else if(gameState == GameManager.GameState.GameOver || gameState == GameManager.GameState.LevelComplete) 
        {
            PlayerStop();
        }
       

    }

    private void MoveForward() 
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    private void ManageController() 
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0)) 
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            position.x = Mathf.Clamp(position.x, -roadWith / 2 + crowdSystem.GetCrowdRadius(),roadWith / 2 - crowdSystem.GetCrowdRadius());
            transform.position = position;
            


        }
    }
}
