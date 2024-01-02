using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Bird")
        {
            Debug.Log("Collide with Bird");
        }
    }
}
