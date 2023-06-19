using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public int MainIngredient;
    public int MainIngredientMaxStrenght;
    public int SecondaryIngredient; //5 is for doesnt matter
    public int SecondaryIngredientMaxStrenght;
    public int Character; //5 is for doesnt matter
    public TextMeshProUGUI OrderText;
    public Material mat;

    public string order;
    public string success;
    public string fail;

    private bool accepted = true;

    public void StartOrder()
    {
        OrderText.text = order;
    }

    public void CompleteOrder()
    {

        if (accepted == true)
        {
            OrderText.text = success;
            mat.SetColor("_Color", Color.green);
        }
        else
        {
            OrderText.text = fail;
            mat.SetColor("_Color", Color.red);
        }
        
    }

    public void CheckOrder(int first, int firstvalue, int second, int secondvalue, int character)
    {
      //  if (MainIngredient != 5)
       // {
            if (MainIngredient != first || firstvalue > MainIngredientMaxStrenght)
            {
                accepted = false;
            }
       // }
       // if (SecondaryIngredient != 5)
       // {
       //     if (SecondaryIngredient != second || secondvalue > SecondaryIngredientMaxStrenght)
       //     {
       //         accepted = false;
       //     }
       // }
        //if (Character != 5)
       // {
            if (Character != character)
            {
                accepted = false;
            }
       // }
    }
}
