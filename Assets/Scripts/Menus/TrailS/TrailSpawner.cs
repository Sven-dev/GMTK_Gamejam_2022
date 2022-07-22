using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawner : MonoBehaviour
{
    [SerializeField] private float SpawnCooldown = 1;
    [SerializeField] private TrailRenderer Prefab;
    [Space]
    [SerializeField] private Transform StartRange;
    [SerializeField] private Transform EndRange;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Spawntrails());
    }

    private IEnumerator _Spawntrails()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnCooldown);

            float xpos = Random.Range(StartRange.position.x, EndRange.position.x);

            Vector3 spawnposition = new Vector3(xpos, StartRange.position.y, StartRange.position.z);
            Instantiate(Prefab, spawnposition, Quaternion.identity, transform);          
        }
    }
}
