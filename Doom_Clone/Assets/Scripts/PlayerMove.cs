using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float playerSpeed = 20;
    private CharacterController myCharacterController;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;

    [SerializeField] private Animator camAnim;
    private bool isWalking;


    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBob();

        camAnim.SetBool(name: "isWalking", isWalking);
    }

    void GetInput()
    {
        inputVector = new Vector3(x: Input.GetAxisRaw("Horizontal"), y: 0f, z: Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }
    
    void MovePlayer()
    {
        myCharacterController.Move(movementVector * Time.deltaTime);
    }

    void CheckForHeadBob()
    {
        if(myCharacterController.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
