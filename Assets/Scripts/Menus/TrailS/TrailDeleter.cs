using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDeleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 10);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
