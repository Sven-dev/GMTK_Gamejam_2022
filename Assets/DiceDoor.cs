using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDoor : MonoBehaviour
{
    [SerializeField] private Transform ClosedPivot;
    [SerializeField] private Transform OpenPivot;
    [SerializeField] private Transform DoorModel;
    [Space]
    [SerializeField] private float Speed = 1;

    private bool Open = false;

    public void ToggleState()
    {
        if (Open)
        {
            Open = false;
            StartCoroutine(_MoveDoor(OpenPivot.position, ClosedPivot.position));
        }
        else
        {
            Open = true;
            StartCoroutine(_MoveDoor(ClosedPivot.position, OpenPivot.position));
        }
    }

    private IEnumerator _MoveDoor(Vector3 from, Vector3 to)
    {
        float progress = 0;
        while (progress <= 1)
        {
            progress += Mathf.Clamp01(Time.fixedDeltaTime * Speed);

            //Logic
            DoorModel.position = Vector3.Lerp(from, to, progress);

            yield return new WaitForFixedUpdate();
        }
    }
}
