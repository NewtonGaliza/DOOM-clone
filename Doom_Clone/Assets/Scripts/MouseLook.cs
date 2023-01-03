using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity; //1.5f
    [SerializeField] private float smoothing; //1.5f
    private float xMousePos;
    private float smoothedMousePos;
    private float curentLookingPos;

    private void Start()
    {
        //lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(a: smoothedMousePos, b: xMousePos, t: 1f/smoothing);
    }

    void MovePlayer()
    {
        curentLookingPos += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(curentLookingPos, transform.up);
    }
}
