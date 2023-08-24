using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BonusType { Addition, Difference, Product, Division }
public class Door : MonoBehaviour
{
  

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro    rightDoorText;
    [SerializeField] private TextMeshPro  leftDoorText;
    [SerializeField] private Collider doorCollider;

    [Header("Settings")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;


private void Start() 
{
    ConfigureDoors();
}







    private void ConfigureDoors() 
    {
        switch(rightDoorBonusType)  
        {
            case BonusType.Addition:
            rightDoorRenderer.color = bonusColor;
            rightDoorText.text = "+" + rightDoorBonusAmount;
            break;


            case BonusType.Difference:
            rightDoorRenderer.color = penaltyColor;
            rightDoorText.text = "-" + rightDoorBonusAmount;
            break;

            case BonusType.Product:
            rightDoorRenderer.color = bonusColor;
            rightDoorText.text = "X" + rightDoorBonusAmount;
            break;


            case BonusType.Division:
            rightDoorRenderer.color = penaltyColor;
            rightDoorText.text = "%" + rightDoorBonusAmount;
            break;
        }


        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;


            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "X" + leftDoorBonusAmount;
                break;


            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "%" + leftDoorBonusAmount;
                break;
        }
    }

    public int GetBonusAmount(float xPosition)
    {
        if(xPosition > 0) 
        {
            return rightDoorBonusAmount;
        }
        else 
        {
            return leftDoorBonusAmount;
        }

    }

    public BonusType GetBonusType(float xPosition) 
    {
        if(xPosition > 0) 
        {
            return rightDoorBonusType;
        }
        else 
        {
            return leftDoorBonusType;
        }
    }

    public void Disable() 
    {
        doorCollider.enabled  = false;

    }
}
