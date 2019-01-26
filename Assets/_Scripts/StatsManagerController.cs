using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManagerController : MonoBehaviour
{
    public float playerHP;
    public float playerHPLoss;
    public float momHP;
    public float momHPLoss;
    public float shelterHP;
    public float shelterHPLoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Add newVal to the desired HP value
    public void AddToPlayerHP(float newVal)
    {
        playerHP += newVal;
    }
    public void AddToMomHP(float newVal)
    {
        momHP += newVal;
    }
    public void AddToShelterHP(float newVal)
    {
        shelterHP += newVal;
    }

    //Sets the desired loss rate to newLoss
    public void SetPlayerLossRate(float newLoss)
    {
        playerHPLoss = newLoss;
    }
    public void SetMomLossRate(float newLoss)
    {
        momHPLoss = newLoss;
    }
    public void SetShelterLossRate(float newLoss)
    {
        shelterHPLoss = newLoss;
    }
}
