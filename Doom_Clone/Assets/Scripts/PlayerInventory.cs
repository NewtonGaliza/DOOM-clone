using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasRed, hasBlue, hasGreen;

    // Start is called before the first frame update
    void Start()
    {
        CanvasManager.Instance.ClearKey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
