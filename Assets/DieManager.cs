using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : MonoBehaviour
{
    public int ActiveNumber = 1;

    public void UpdateNumber()
    {
        int x = (int)Vector3.Dot(Vector3.up, transform.right);
        int y = (int)Vector3.Dot(Vector3.up, transform.up);
        int z = (int)Vector3.Dot(Vector3.up, transform.forward);

        if (x == 1)
        {
            ActiveNumber = 4;
        }
        else if (x == -1)
        {
            ActiveNumber = 3;
        }
        else if (y == 1)
        {
            ActiveNumber = 2;
        }
        else if (y == -1)
        {
            ActiveNumber = 5;
        }
        else if (z == 1)
        {
            ActiveNumber = 1;
        }
        else if (z == -1)
        {
            ActiveNumber = 6;
        }

        print("x: " + x + ", y: " + y + ", z: " + z);
    }
}
