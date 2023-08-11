using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the user's controls and interactions.
public class User : MonoBehaviour
{
    private float speed = 8f;
    private float grav = 9.8f;
    [SerializeField] public GameObject Box;
    [SerializeField] public GameObject Contents;
    private CharacterController controller = null;
    

    void Start(){controller = GetComponent <CharacterController>();} //connect to controller via script communication
    

    //!*        Using FixedUpdate to vary update with fps.       *!//
    void FixedUpdate() 
    {
        //Only allow the user to move when the cursor is hidden 
        //(for example, freeze on the start screen)
        if (!Cursor.visible) {
            Interact();
            Move();
        }

        //PLEASE DO NOT REMOVE THIS BIT OF CODE
        //YOUR CURSOR WILL BE LOCKED AND HARD TO REGAIN !!!
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
        }
    } //End FixedUpdate()
    

    //!*        Allow the user to move around in the environment.       *!//
    private void Move() {

        //horizontal movement input 
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //programmatically apply gravity (more reliable)
        Vector3 velocity = direction * speed;
        velocity.y -= grav;

        //convert from local to world space by accessing parent of user (world)
        //just an extra safety measure
        velocity = transform.transform.TransformDirection(velocity);

        //move
        controller.Move(velocity * Time.deltaTime);

    }//End Move().


    //!*        Support user interaction with items.       *!//
    private void Interact() {
        
        if (Input.GetMouseButtonDown(0)) { //0 = left mouse click, 1 = right mouse click, etc

            Ray rayOrgin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //ray orgin at center of viewport (not screen, importantly!)

            //what have we hit?
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrgin, out hitInfo)) {
                Debug.Log("Raycast hit " + hitInfo.collider + ".");

                if (hitInfo.collider.gameObject.CompareTag("Box")) {
                    Box.SetActive(false);
                    Contents.SetActive(true);
                }
            } 

        }
    } //end Interact()

} //end class
