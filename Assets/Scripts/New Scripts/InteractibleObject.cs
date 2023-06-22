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

    protected bool IsInRange;
    public bool IsBeingManned;

    protected float CurrentProgress;
    protected bool IsInitiated;
    protected bool IsFinished;
    protected bool IsOperating;

    public GameObject ObjectToTake;
    public GameObject ObjectToGive;

    protected static float intervalAmount = 0.1f;

    protected void Start()
    {
        IsInitiated = false;
        IsFinished= false;
    }

    protected void Update()
    {
        if(CurrentProgress >= 100)
        {
            IsFinished= true;
        }

        if (IsFinished)
        {
            FinishUse();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsInRange)
            {
                Debug.Log("Pressed E");
                if (!IsInitiated)
                {
                    InitiateUse();
                }
                IsOperating = true;
            }
           

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (IsInRange)
            {
                if (NeedsToBeManned)
                {
                    IsOperating = false;
                }
            }
            


        }

    }

    protected void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("InRange");
            IsInRange= true;
        }
    }

    protected void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("OutOfRange");
            IsInRange= false;

            if (IsFinished)
            {
                //reset
            }
            if (NeedsToBeManned)
            {
                IsOperating= false;
            }
        }
    }

    protected void InitiateUse()
    {
        Debug.Log("InitiatingUse");

        if(ObjectToTake != null)
        {
            //take object
        }

        if(OperatingTime > 0)
        {
            ProgressBar.SetActive(true);
            IsInitiated = true;
            StartCoroutine(Operating(intervalAmount));
        }
        else
        {
            IsFinished= true;
        }
        
    }

    protected IEnumerator Operating(float duration)
    {
        if (IsOperating)
        {
            CurrentProgress += 100 / (duration / intervalAmount);
            ProgressBarFill.fillAmount = CurrentProgress / 100;
        }
        yield return new WaitForSeconds(intervalAmount);
        StartCoroutine(Operating(duration));
    }

    protected void FinishUse()
    {
        StopCoroutine(Operating(intervalAmount));
        Debug.Log("finished, giving item");
        //reset stuff, but is also done when leaving
    }

   

}
