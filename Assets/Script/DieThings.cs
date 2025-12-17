using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieThings : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.SetDie();
            UIController.Instance.SetFalse(); 
        }
    }
}
