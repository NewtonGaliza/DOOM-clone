using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private BoxCollider gunTrigger;
    [SerializeField] private float range; //20f
    [SerializeField] private float verticalRange; //20f
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private float fireRate;
    private float nextTimeToFire;
    [SerializeField] private float bigDamage;
    [SerializeField] private float smallDamage;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private float gunShotRadius; //20f
    [SerializeField] private LayerMask enemyLayerMask;


    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(x: 1, y: verticalRange, z: range);
        gunTrigger.center = new Vector3(x: 0, y: 0, z: range * 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Enemy enemy = collider.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
         Enemy enemy = collider.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;

            if(Physics.Raycast(transform.position, dir, out hit, range * 15f, raycastLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    //range check
                    float dist = Vector3.Distance(a: enemy.transform.position, b: transform.position);

                    if(dist > range * 0.5f)
                    {
                        enemy.TakeDamage(smallDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(bigDamage);
                    }
                }
            }
        }


        nextTimeToFire = Time.time * fireRate;
    }
}
