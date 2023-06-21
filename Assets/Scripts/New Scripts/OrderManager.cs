using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public enum Level { Level01, Level02, Level03 };
    public Level CurrentLevel;
    public int OrdersAtOnceAmount;
    public float OrderInterval;

    public IngredientManager IngredientManager;

    private List<string> IngredientList= new List<string>();
    private List<Order> CurrentOrders= new List<Order>();

    private int CurrentAmountOfOrders;

    private void Start()
    {
        InitializeLevel();
        CurrentOrders.Clear();

        StartCoroutine(GenerateOrder());
    }

    private void Update()
    {
        Debug.Log(CurrentOrders[0].ingredient01 + CurrentOrders[0].ingredient02 + CurrentOrders[0].ingredient02 + "Ice?" + CurrentOrders[0].ice + "Shaken?" + CurrentOrders[0].shaken);
    }

    private void InitializeLevel()
    {
        if(CurrentLevel == Level.Level01)
        {
            IngredientList = IngredientManager.Level01Ingredients;
            OrdersAtOnceAmount = 1;
            OrderInterval = 30; //should be special -> once completed an order
        }
        else if (CurrentLevel == Level.Level02)
        {
            IngredientList = IngredientManager.Level02Ingredients;
            OrdersAtOnceAmount = 3;
            OrderInterval= 25;
        }
        else
        {
            IngredientList = IngredientManager.Level03Ingredients;
            OrdersAtOnceAmount = 4;
            OrderInterval = 20;
        }
    }

    private IEnumerator GenerateOrder()
    {
        if(CurrentAmountOfOrders < OrdersAtOnceAmount)
        {
            Order NewOrder = new Order();
            NewOrder.ingredient01 = IngredientList[UnityEngine.Random.Range(0, IngredientList.Count)]; //right range? does it get the last one too?
            NewOrder.ingredient02 = IngredientList[UnityEngine.Random.Range(0, IngredientList.Count)];
            NewOrder.ingredient02 = IngredientList[UnityEngine.Random.Range(0, IngredientList.Count)];

            //make exceptions for certain ingredients like espresso

            NewOrder.ice = UnityEngine.Random.value < 0.5f;
            NewOrder.shaken = UnityEngine.Random.value < 0.5f;

            CurrentOrders.Add(NewOrder);
        }
        yield return new WaitForSeconds(OrderInterval); //plus or minus an interval for more randomness
        StartCoroutine(GenerateOrder());
        
    }
}
