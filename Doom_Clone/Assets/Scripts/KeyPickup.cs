using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private bool isRedKey, isBlueKey, isGreenKey;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(isRedKey)
            {
                collider.GetComponent<PlayerInventory>().hasRed = true;
            }

            if(isBlueKey)
            {
                collider.GetComponent<PlayerInventory>().hasBlue = true;
            }

            if(isGreenKey)
            {
                collider.GetComponent<PlayerInventory>().hasGreen = true;
            }

            Destroy(gameObject);
        }
    }
}
