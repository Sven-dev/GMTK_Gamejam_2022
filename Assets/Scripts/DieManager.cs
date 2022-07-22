using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : MonoBehaviour
{
    public static DieManager Instance;

    public int ActiveNumber = 1;

    public void UpdateNumber()
    {
        float x = Vector3.Dot(Vector3.up, transform.right);
        float y = Vector3.Dot(Vector3.up, transform.up);
        float z = Vector3.Dot(Vector3.up, transform.forward);

        if (x > 0.9f)
        {
            ActiveNumber = 4;
        }
        else if (x < -0.9f)
        {
            ActiveNumber = 3;
        }
        else if (y > 0.9f)
        {
            ActiveNumber = 2;
        }
        else if (y < -0.9f)
        {
            ActiveNumber = 5;
        }
        else if (z > 0.9f)
        {
            ActiveNumber = 1;
        }
        else if (z < -0.9f)
        {
            ActiveNumber = 6;
        }

        print("x: " + x + ", y: " + y + ", z: " + z);
    }
}