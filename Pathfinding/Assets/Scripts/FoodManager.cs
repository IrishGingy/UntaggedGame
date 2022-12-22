using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodManager : GameManager
{
    public TextMeshProUGUI foodCollectedUI;
    public int foodPickedUp;

    public void IncreaseAmountOfFood()
    {
        foodPickedUp++;
        int numFood = int.Parse(foodCollectedUI.text);
        numFood++;
        foodCollectedUI.text = numFood.ToString();
    }

    public void DecreaseAmountOfFood()
    {
        foodPickedUp--;
    }
}
