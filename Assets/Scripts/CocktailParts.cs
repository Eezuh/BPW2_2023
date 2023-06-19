using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocktailParts : MonoBehaviour
{
     public GameObject Glass;
     public GameObject Fluid;
     public GameObject Dec1;
     public GameObject Dec2;
   

    private void Start()
    {
        this.Glass.SetActive(false);
        this.Fluid.SetActive(false);
        this.Dec1.SetActive(false);
        this.Dec2.SetActive(false);
    }
    public void AddItem(GameObject item)
    {
        //based on another function that keeps track of the items to add while mixing
        if (item.activeSelf == true)
        {
            item.SetActive(false);
        }
        else
        {
            item.SetActive(true);
        }
        
    }
}
