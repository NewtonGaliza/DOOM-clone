using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]private bool isHealth;
    [SerializeField] private bool isArmor;
    [SerializeField] private bool isAmmo;
    [SerializeField] private int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(isHealth)
            {
                collider.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
            }

            if(isArmor)
            {
                collider.GetComponent<PlayerHealth>().GiveArmor(amount, this.gameObject);
            }

            if(isAmmo)
            {
                collider.GetComponentInChildren<Gun>().GiveAmmo(amount, this.gameObject);
            }
        }
    }
}
