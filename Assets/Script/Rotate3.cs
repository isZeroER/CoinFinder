using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3 : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
    }
}