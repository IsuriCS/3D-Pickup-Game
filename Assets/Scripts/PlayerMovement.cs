using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    private CharacterController controller;
    private float ySpeed;

    [SerializeField]
    private Transform cameraTransform;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        controller=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput=Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");

        Vector3 movementDerection=new Vector3(horizontalInput,0,verticalInput);
        float magnitude=Mathf.Clamp01(movementDerection.magnitude)*speed;
        
        
        movementDerection=Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y,Vector3.up)*movementDerection;
        movementDerection.Normalize();

        ySpeed+=Physics.gravity.y*Time.deltaTime;

        if (controller.isGrounded)
        {
            ySpeed = 0;
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;

            }
        }

        Vector3 velocity=movementDerection*magnitude;
        velocity.y=ySpeed;  

        controller.Move(velocity*Time.deltaTime);
        
        if (movementDerection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDerection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnApplicationFocus(bool focusStatus) {
        if(focusStatus){
            Cursor.lockState=CursorLockMode.Locked;
            
        }
        else{
            Cursor.lockState=CursorLockMode.None;
        }
    }
}
