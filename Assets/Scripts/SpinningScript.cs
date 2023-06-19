using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningScript : MonoBehaviour
{
        public float speed = 5f;
        void Update()
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
    }
