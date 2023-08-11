using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script should be attached to the user!
public class LookX : MonoBehaviour
{

    [SerializeField] float sensitivity = 4.0f; //rotational sensitivity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (!Cursor.visible) {
                //get input
                float mouseX = Input.GetAxis("Mouse X");

                transform.localEulerAngles = new Vector3(
                    //grab updated x y and z angles and save over old angles
                    transform.localEulerAngles.x,
                    transform.localEulerAngles.y + (mouseX * sensitivity),
                    transform.localEulerAngles.z
                );
            }
            
        }
        
}
