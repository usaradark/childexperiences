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
        smc.AddToWood(-1);
        Debug.Log(smc.myWood.ToString());
    }

    public void BuildFire()
    {
        smc.IncreaseShelterHP();
        smc.AddToWood(-1);
    }

    public void HealSelf()
    {
        smc.SetPlayerLossRate(smc.playerHPLoss / 2);
        smc.AddToMedicine(-1);
    }

    public void FeedSelf()
    {
        smc.IncreasePlayerHP();
        smc.AddToFood(-1);
    }

    public void HealMom()
    {
        smc.SetMomLossRate(smc.momHPLoss / 2);
        smc.AddToMedicine(-1);
    }

    public void FeedMom()
    {
        smc.IncreasePlayerHP();
        smc.AddToFood(-1);
    }
}
