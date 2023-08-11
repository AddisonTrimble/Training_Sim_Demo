using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button StartButton;
    public GameObject[] PopUps;
    public int currentPop = 0;
    [SerializeField] public GameObject canvas;
    public int ycord = 0;
    public int xcord = 0;

    //types of popup
    public GameObject startPop;

    void Start()
    {
        startPop.SetActive(true);
        Button btn = StartButton.GetComponent<Button>();
		btn.onClick.AddListener(StartSim);
    }

    void Update() { //for testing
        if(Input.GetKeyDown (KeyCode.Return))
        {
            nextPop();
        }
     }

    void StartSim(){
        Debug.Log("Starting Sim!");
        //Hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

         nextPop();
    }

    public void nextPop() {
        if (currentPop <= (PopUps.Length - 1)) {
            PopUps[currentPop].SetActive(false);
            currentPop += 1;
            PopUps[currentPop].SetActive(true);
        }
        return;
    }
} 