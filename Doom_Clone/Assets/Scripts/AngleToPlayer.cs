 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPosition;
    private Vector3 targetDirection;

    public float angle;
    [SerializeField] public int lastIndex;

    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // get target position and direction
        targetPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        targetDirection = targetPosition - transform.position;

        // get angle
        // signedangle(vector3 from, vector3 to, vector3 axis)
        angle = Vector3.SignedAngle(targetDirection, transform.position, Vector3.up);

        Vector3 tempScale = Vector3.one;
        if(angle > 0)
        {
            tempScale.x *= -1f;
        }


        lastIndex = GetIndex(angle);

    }

    private int GetIndex(float angle)
    {
        // front
        if(angle > -22.5f && angle < 22.6f)
        {
            return 0;
        }
        if(angle >= 22.5f && angle < 67.5f)
        {
            return 7;
        }
        if(angle >= 67.5f && angle < 112.5f)
        {
            return 6;
        }
        if(angle >= 112.5f && angle < 157.5f)
        {
            return 5;
        }

        // back
        if(angle <= -157.5f || angle >=157.5f)
        {
            return 4;
        }
        if(angle >= -157.4f && angle < -112.5f)
        {
            return 3;
        }
        if(angle >= -112.5f && angle < -67.5f)
        {
            return 2;
        }
        if(angle >= -67.5f && angle <= -22.5f)
        {
            return 1;
        }

        return lastIndex;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPosition);
    }
}
