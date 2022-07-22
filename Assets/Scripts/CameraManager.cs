using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform Target;

    private void Update()
    {
        transform.position = Target.transform.position;
    }
}
