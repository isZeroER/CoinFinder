using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyTrigger : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
           rb.useGravity = true; 
        }
    }
}
