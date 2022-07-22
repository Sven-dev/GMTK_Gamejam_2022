using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;

    public bool Moving = false;
    public bool Paused = false;
    public bool AllowedToMove = false;

    [SerializeField] private float Speed = 1;
    [SerializeField] private Transform Model;
    [Space]
    [SerializeField] private DieManager DieManager;
    [SerializeField] private Rigidbody Rigidbody;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke("DisableRigidbody", 2f);
        Invoke("PlaySound", 1.4f);
        print("Moving:" + Moving);
    }

    public void DisableRigidbody()
    {
        Rigidbody.useGravity = false;
        Rigidbody.isKinematic = true;

        AllowedToMove = true;
    }

    public void EnableRigidbody()
    {
        Rigidbody.useGravity = true;
        Rigidbody.isKinematic = false;

        AllowedToMove = false;
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlayRandom("DiceLand");
    }

    // Update is called once per frame
    void Update()
    {
        if (Paused || !AllowedToMove)
        {
            return;
        }

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
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 1, layerMask))
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

        bool soundplayed = false;

        float progress = 0;
        while (progress < 1f)
        {
            progress = Mathf.Clamp01(progress + Time.fixedDeltaTime * Speed);

            //Logic
            transform.position = Vector3.Lerp(startPosition, endPosition, progress);
            Model.rotation = Quaternion.Lerp(startRotation, endRotation, progress);

            if (!soundplayed && progress > 0.7f)
            {
                soundplayed = true;
                AudioManager.Instance.PlayRandom("DiceLand");
            }

            yield return new WaitForFixedUpdate();
        }

        DieManager.UpdateNumber();
        ScoreManager.Instance.Moves++;
        Moving = false;
    }
}
