using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private GameObject areaToSpawn;
    [SerializeField] private bool requiresKey;
    [SerializeField] private bool reqRed, reqBlue, reqGreen;

    // [SerializeField] private bool isSpawner;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(requiresKey)
            {
                if(reqRed && collider.GetComponent<PlayerInventory>().hasRed)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }

                if(reqBlue && collider.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }

                if(reqGreen && collider.GetComponent<PlayerInventory>().hasGreen)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }
            }
            else
            {
                doorAnim.SetTrigger("OpenDoor");
                areaToSpawn.SetActive(true);
            }
        }
    }
}
