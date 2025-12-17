using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
}