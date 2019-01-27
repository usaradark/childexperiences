using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapABHandler : MonoBehaviour
{
    public bool coinFlipHeads;
    //public float charaSpeed;
    public GameObject eventHandler;
    public GameObject statManager;
    public GameObject panel;

    //private CharacterController myController;
    private EventFunctions functions;

    private StatsManagerController smc;
    private string currentTrigger;
    private bool hasBeenOutside;

    public bool canControl;

    public string currentTag;

    bool leftChoice = true;

    // Start is called before the first frame update
    void Start()
    {
        //myController = GetComponent<CharacterController>();
        functions = eventHandler.GetComponent<EventFunctions>();
        smc = statManager.GetComponent<StatsManagerController>();
        currentTrigger = "";
        canControl = true;
        hasBeenOutside = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

