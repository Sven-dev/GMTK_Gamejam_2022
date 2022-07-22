using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDoor : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [Space]
    [SerializeField] private Transform ClosedPivot;
    [SerializeField] private Transform OpenPivot;
    [Space]
    [SerializeField] private Transform DoorModel;
    [SerializeField] private Collider Collider;

    public bool Opened = false;

    public void Open()
    {
        Opened = true;
        Collider.enabled = false;
        StartCoroutine(_MoveDoor(ClosedPivot.position, OpenPivot.position));
    }

    public void Close()
    {
        Opened = false;
        Collider.enabled = true;
        StartCoroutine(_MoveDoor(OpenPivot.position, ClosedPivot.position));
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
