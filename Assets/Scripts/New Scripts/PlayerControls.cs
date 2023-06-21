using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float MovementSpeed;

    private CharacterController characterController;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) //move to the left
        {
            characterController.Move(-transform.forward * MovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) //move to the left
        {
            characterController.Move(transform.forward * MovementSpeed * Time.deltaTime);
        }




    }
}
