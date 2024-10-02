using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Deaktiviert eine Kugel wenn sie in einem Loch landet
        if (other.CompareTag("Kugel"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.BallHoled();
        }
    }
}
