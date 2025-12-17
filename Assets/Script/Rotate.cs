using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSPeed;
    private void Update()
    {
        transform.Rotate(0, rotateSPeed * Time.deltaTime, 0);
    }
}
