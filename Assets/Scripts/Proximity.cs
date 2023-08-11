using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{

    public GameObject popUpManagerObj;
    [SerializeField] public GameObject Box;
    public PopUpManager popUpManager;

    // Start is called before the first frame update
    void Start()
    {
        PopUpManager popUpManager = popUpManagerObj.GetComponent<PopUpManager>();
    }

    public void OnTriggerEnter(Collider other) {
        PopUpManager popUpManager = popUpManagerObj.GetComponent<PopUpManager>();

        if(other.tag == "Player") {
            popUpManager.nextPop();

            //var outline = Box.AddComponent<Outline>();
            //outline.OutlineColor = Color.blue;
            //outline.OutlineWidth = 5f;
        }
    }
}
