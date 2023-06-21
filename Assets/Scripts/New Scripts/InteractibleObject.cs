using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractibleObject : MonoBehaviour
{
    public string ApplianceName;
    public float OperatingTime;
    public GameObject ProgressBar;
    public Image ProgressBarFill;

    public bool NeedsToBeManned;
    public bool CanOverdo;
    public float OverdoTime;

    public bool IsBeingManned;

    private float CurrentProgress;
    private bool IsInitiated;

    private void Start()
    {
        IsInitiated = false;
    }


    private void UpdateUI()
    {
        if(OperatingTime > 0)
        {
            if(IsBeingManned || !NeedsToBeManned)
            {

            }
        }
    }


    private void InitiateUse()
    {
        ProgressBar.SetActive(true);
        IsInitiated = true;
    }

}
