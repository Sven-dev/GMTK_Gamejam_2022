using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [SerializeField] private Transform Model;
    [Space]
    [SerializeField] private DieManager DieManager;
    
    private bool Moving = false;

    // Update is called once per frame
    void Update()
    {
        if (!Moving)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (!CheckForWall(Vector3.right))
                {
                    StartCoroutine(_Move(Vector3.right));
                }             
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (!CheckForWall(Vector3.left))
                {
                    StartCoroutine(_Move(Vector3.left));
                }
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (!CheckForWall(Vector3.forward))
                {
                    StartCoroutine(_Move(Vector3.forward));
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (!CheckForWall(Vector3.back))
                {
                    StartCoroutine(_Move(Vector3.back));
                }
            }
        }
    }

    private bool CheckForWall(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return false;
        }
    }

    private IEnumerator _Move(Vector3 direction)
    {
        Moving = true;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + direction;

        Quaternion startRotation = Model.rotation;
        Quaternion endRotation = Quaternion.Euler(direction.z * 90, direction.y * 90, -direction.x * 90) * startRotation;
        
        float progress = 0;
        while (progress <= 1)
        {
            progress += Mathf.Clamp01(Time.fixedDeltaTime * Speed);

            //Logic
            transform.position = Vector3.Lerp(startPosition, endPosition, progress);
            Model.rotation = Quaternion.Lerp(startRotation, endRotation, progress);

            yield return new WaitForFixedUpdate();
        }

        DieManager.UpdateNumber();
        Moving = false;
    }
}
