using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovt : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController CharacterController; // object specifically for character, can be edited with script

    private Vector3 moveInput;

    public Transform cameraTransform; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical"); // Input.GetAxis("Vertical") is a method in Unity that gets the value of the vertical input axis. Fwd/Bck.
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal"); // 

        moveInput = horizontalMove + verticalMove;
       // moveInput.Normalize(); // so that diagnol movement is equal to the ver and hor movet, pythagoras. 1.41 ~ 1
        moveInput = moveInput * moveSpeed; 
  
        CharacterController.Move(moveInput * Time.deltaTime); // Time.deltaTime, you ensure that the object moves at a consistent speed regardless of the frame rate. FR = images/sec
        // The method takes a Vector3 parameter, which specifies the direction and distance to move the character.
    
        //camera rotation 
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
    
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
        
    
    }
}
