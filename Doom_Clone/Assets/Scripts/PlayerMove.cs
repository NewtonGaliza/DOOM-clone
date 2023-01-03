using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed; //10f
    private CharacterController myCharacterController;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;

    [SerializeField] private Animator camAnim;
    private bool isWalking;
    [SerializeField] private float momentumDamping; //5f

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

        camAnim.SetBool(name: "isWalking", isWalking);
    }

    void GetInput()
    {
        //if we´re holding down wasd, then give us -1,0,1
        if(Input.GetKey(KeyCode.W) ||
           Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.S) ||
           Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(x: Input.GetAxisRaw("Horizontal"), y: 0f, z: Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {
            //if we´re not then give us whatever inputVector was at when it was last checked and lerp it towards zero
            inputVector = Vector3.Lerp(a: inputVector, b: Vector3.zero, t: momentumDamping * Time.deltaTime);

            isWalking = false;
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }
    
    void MovePlayer()
    {
        myCharacterController.Move(movementVector * Time.deltaTime);
    }
}
