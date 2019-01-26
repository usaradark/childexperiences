using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManagerController : MonoBehaviour
{
    public GameObject statManager;

    private StatsManagerController smc;
    // Start is called before the first frame update
    void Start()
    {
        smc = statManager.GetComponent<StatsManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //list of actions to be done in the house
    public void RepairHouse()
    {
        smc.SetShelterLossRate(smc.shelterHPLoss / 2);
    }
}
