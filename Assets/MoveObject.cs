using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float RotationSpeed;
    public float MoveSpeed;

    void Update()
    {
        transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0));
        transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime, 0));
    }
}
