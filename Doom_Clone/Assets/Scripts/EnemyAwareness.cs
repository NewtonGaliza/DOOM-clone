using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
   // [SerializeField] private Material aggroMaterial;
   public bool isAggro;
   private Transform playersTransform;
   [SerializeField] private float awarenessRadius;

    private void Start() 
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }

   private void Update()
   {
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        if(dist < awarenessRadius)
        {
            isAggro = true;
        }


        if(isAggro)
        {
            // GetComponent<MeshRenderer>().material = aggroMaterial;
        }
   }
}
