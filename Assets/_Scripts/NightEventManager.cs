using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightEventManager : MonoBehaviour
{
    public GameObject statsManager;
    public GameObject eventFunctions;

    private StatsManagerController smc;
    private EventFunctions functions;
    // Start is called before the first frame update
    void Start()
    {
        smc = statsManager.GetComponent<StatsManagerController>();
        functions = eventFunctions.GetComponent<EventFunctions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
