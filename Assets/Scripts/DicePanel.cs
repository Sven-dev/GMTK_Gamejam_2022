using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePanel : MonoBehaviour
{
    [SerializeField] private int Number = 1;
    [SerializeField] private List<DiceDoor> DiceDoors;

    private bool Pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dice")
        {
            StartCoroutine(_CheckValue(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dice")
        {
            Pressed = false;
            foreach (DiceDoor door in DiceDoors)
            {
                if (door.Opened)
                {
                    door.Close();
                }
            }
        }
    }

    private IEnumerator _CheckValue(Collider other)
    {
        yield return new WaitForSeconds(0.5f);

        DieManager dieManager = other.GetComponentInChildren<DieManager>();
        if (dieManager.ActiveNumber == Number)
        {
            Pressed = true;
            foreach (DiceDoor door in DiceDoors)
            {
                door.Open();
            }
        }
    }
}
