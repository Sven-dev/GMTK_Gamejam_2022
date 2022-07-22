using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private int Number = 1;

    private bool EndingLevel = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!EndingLevel && other.tag == "Dice")
        {
            StartCoroutine(_CheckValue(other));
        }
    }

    private IEnumerator _CheckValue(Collider other)
    {
        yield return new WaitForSeconds(0.5f);

        DieManager dieManager = other.GetComponentInChildren<DieManager>();
        if (dieManager.ActiveNumber == Number)
        {
            EndingLevel = true;
            StartCoroutine(_EndLevel(other));
        }
    }

    private IEnumerator _EndLevel(Collider other)
    {
        Movement.Instance.EnableRigidbody();
        yield return new WaitForSeconds(1f);

        //Swap to victory screen
        LevelManager.Instance.LoadLevel(3, Transition.Crossfade);

        float progress = 0;
        while (progress < 1)
        {
            progress = Mathf.Clamp01(progress + Time.fixedDeltaTime);

            //Start spinning,
            //Move up
            other.transform.Rotate(Vector3.up * progress * 200 * Time.fixedDeltaTime);
            other.transform.Translate(Vector3.up * progress * 30 * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }

        AudioManager.Instance.FadeOut("Music Game", 2f);
        AudioManager.Instance.FadeIn("Music Menu", 1f);
    }
}
