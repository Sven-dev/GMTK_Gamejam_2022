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
            Pressed = true;
            foreach(DiceDoor door in DiceDoors)
            {
                door.ToggleState();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dice")
        {
            Pressed = false;
            foreach (DiceDoor door in DiceDoors)
            {
                door.ToggleState();
            }
        }
    }
}
