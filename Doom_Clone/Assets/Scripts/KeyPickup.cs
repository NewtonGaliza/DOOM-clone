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
                CanvasManager.Instance.UpdateKeys("red");
            }

            if(isBlueKey)
            {
                collider.GetComponent<PlayerInventory>().hasBlue = true;
                CanvasManager.Instance.UpdateKeys("blue");
            }

            if(isGreenKey)
            {
                collider.GetComponent<PlayerInventory>().hasGreen = true;
                CanvasManager.Instance.UpdateKeys("green");
            }

            Destroy(gameObject);
        }
    }
}
