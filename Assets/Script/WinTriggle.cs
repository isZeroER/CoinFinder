using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        if (!p) return;
        
        UIController.Instance.SetWin();
    }
}
