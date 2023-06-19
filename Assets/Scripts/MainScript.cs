using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScript : MonoBehaviour
{
    public GameObject InGameCocktail; //do you need this one?
    public GameObject Customer;
    private string CocktailGlass;

    public GameObject Longdrink;
    public GameObject bowl;
    public GameObject cone;
    public GameObject tumbler; 
    public GameObject goblet;

    public ProgressBar sweet;
    public ProgressBar sour;
    public ProgressBar salty;
    public ProgressBar bitter;
    public ProgressBar umami;
    public ProgressBar character;

    public string CharacterName;

    int[] tastes = new int[5];
    int[] profile = new int[7]; //becomes more once you add more profiles !!! 0 is nothing !!!

    int floralLvl;
    int metallicLvl;
    int fruityLvl;
    //etc

    int color; //and other visual characteristics

    string MainTasteName;
    string SecondaryTasteName;
    string CharacterProfileName;
    string finalname;

    public TextMeshProUGUI CocktailName;

    private void Start()
    {
        int i;

        for (i = 1; i < tastes.Length; i++)
        {
            tastes[i] = 0;
        }

        for (i = 1; i < profile.Length; i++)
        {
            tastes[i] = 0;
        }

        CharacterName = "None";
    }

    private void Updatebars()
    {
        sweet.CurrentValueUpdate(tastes[0]);
        sour.CurrentValueUpdate(tastes[1]);
        salty.CurrentValueUpdate(tastes[2]);
        bitter.CurrentValueUpdate(tastes[3]);
        umami.CurrentValueUpdate(tastes[4]);
    }

    public void addIngredient(int sweet, int sour, int salty, int bitter, int umami, int character, int characterLvl)
    {
        tastes[0] += sweet;
        tastes[1] += sour;
        tastes[2] += salty;
        tastes[3] += bitter;
        tastes[4] += umami;

        if (character != 0)
        {
            profile[character] += characterLvl;
        }

        Updatebars();
    }

    public void resetIngredients() 
    {
        tastes[0] = 0;
        tastes[1] = 0;
        tastes[2] = 0;
        tastes[3] = 0;
        tastes[4] = 0;
        profile[0] = 0;
        profile[1] = 0;
        profile[2] = 0;
        profile[3] = 0;
        profile[4] = 0;
        profile[5] = 0;

        Updatebars();
    }

    public void LevelsUpdate()
    {   
        int first = 0;
        int firstValue = 0;
        int second = int.MinValue;
        int secondValue = 0;
        int mainCharacter = 0;
        int i;

        for (i = 0; i < tastes.Length; i++) //these return the index where the highest value is in
        {
            if (tastes[i] >= firstValue)
            {
                secondValue = firstValue;
                firstValue = tastes[i];
                second = first;
                first = i;
            }
            else if (tastes[i] > secondValue)
            {
                secondValue = tastes[i];
                second = i;
            }
        }
        for (i = 0; i < profile.Length; i++)
        {
            if (profile[i] > profile[mainCharacter])
            {
                mainCharacter = i;
            }
            else if (profile[i] == profile[mainCharacter])
            {
                if (profile[mainCharacter] == 3)
                {
                    mainCharacter = 6;
                    profile[mainCharacter] = 3;
                }
            }
        }

        Debug.Log("main ingredient is:" + first + "with level" + firstValue); 
        Debug.Log("second ingredient is:" + second + "with level" + secondValue);

        GenerateName(first, second, mainCharacter);
        DisplayCocktail(first, second);
        CocktailName.text = finalname;
        Customer.GetComponent<OrderScript>().CheckOrder(first, firstValue, second, secondValue, mainCharacter);

    }

    void DisplayCocktail(int mainIngredient, int secondaryIngredient)
    {
        GameObject glass = null;

        switch (mainIngredient)
        {
            case 0:
                Longdrink.SetActive(true);
                glass = Longdrink;
            break;

            case 1:
                bowl.SetActive(true);
                glass = bowl;
                break;
                
            case 2:
                cone.SetActive(true);
                glass = cone;
                break;
            case 3:
                tumbler.SetActive(true);
                glass = tumbler;
                break;
            case 4:
                goblet.SetActive(true);
                glass = goblet;
                break;
        }

        switch (secondaryIngredient)
        {
            case 0:
                glass.transform.Find("Cherry").gameObject.SetActive(true);
                break;

            case 1:
                glass.transform.Find("Lemon").gameObject.SetActive(true);
                break;

            case 2:
                glass.transform.Find("Sardine").gameObject.SetActive(true);
                break;
            case 3:
                glass.transform.Find("Olive").gameObject.SetActive(true);
                break;
            case 4:
                glass.transform.Find("Cheese").gameObject.SetActive(true);
                break;
        }
    }

    void GenerateName(int index1, int index2, int index3)
    {
     switch (index2)
        {
            case 0:
                if(tastes[index2] > 4)
                {
                    SecondaryTasteName = "Sugarbomb" ;
                }
                else
                {
                    SecondaryTasteName = "Sweet ";
                }
            break;


            case 1:
                if (tastes[index2] > 4)
                {
                    SecondaryTasteName = "Acidic ";
                }
                else
                {
                    SecondaryTasteName = "Sour ";
                }
                break;

            case 2:
                if (tastes[index2] > 4)
                {
                    SecondaryTasteName = "Pickled "; 
                }
                else
                {
                    SecondaryTasteName = "Saline "; 
                }
                break;

            case 3:
                if (tastes[index2] > 4)
                {
                    SecondaryTasteName = "Pungent ";
                }
                else
                {
                    SecondaryTasteName = "Bitter ";
                }
                break;

            case 4:
                if (tastes[index2] > 4)
                {
                    SecondaryTasteName = "Starchy ";
                }
                else
                {
                    SecondaryTasteName = "Savoury ";
                }
                break;
        }

        switch (index3)
        {
            case 0: //nothing
                if (profile[index3] > 2) 
                {
                    CharacterProfileName = "";
                }
                break;


            case 1:
                if (profile[index3] > 2)
                {
                    CharacterProfileName = "Metallic ";
                }
                break;

            case 2:
                if (profile[index3] > 2)
                {
                    CharacterProfileName = "Citric ";
                }
                break;

            case 3:
                if (profile[index3] > 2)
                {
                    CharacterProfileName = "Bloody ";
                }
                break;

            case 4:
                if (profile[index3] > 2)
                {
                    CharacterProfileName = "Sea-";
                }
                break;

            case 5:
                if (profile[index3] > 2)
                {
                    CharacterProfileName = "Floral ";
                }
                break;

            case 6:
                if (profile[index3] > 2)
                {
                    CharacterProfileName = "Muddy ";
                }
                break;
        }

        switch (index1)
        {
            case 0:
                if (tastes[index1] > 4)
                {
                    MainTasteName = "Sugarbomb";
                }
                else
                {
                    MainTasteName = "Lemonade";
                }
                break;


            case 1:
                if (tastes[index1] > 4)
                {
                    MainTasteName = "Acid";
                }
                else
                {
                    MainTasteName = "Juice";
                }
                break;

            case 2:
                if (tastes[index1] > 4)
                {
                    MainTasteName = "Seawater";
                }
                else
                {
                    MainTasteName = "Brine";
                }
                break;

            case 3:
                if (tastes[index1] > 4)
                {
                    MainTasteName = "Concentrate";
                }
                else
                {
                    MainTasteName = "Shot";
                }
                break;

            case 4:
                if (tastes[index1] > 4)
                {
                    MainTasteName = "Pulp";
                }
                else
                {
                    MainTasteName = "Shake";
                }
                break;
        }
        finalname = SecondaryTasteName + CharacterProfileName + MainTasteName;
        Debug.Log(finalname);
    }
}
