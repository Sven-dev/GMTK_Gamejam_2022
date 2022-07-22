using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRotator : MonoBehaviour
{
    [SerializeField] private float Speed = 1;

    void Update()
    {
        transform.Rotate((Vector3.left + Vector3.back * 0.66f) * Speed * Time.deltaTime);
    }
}
