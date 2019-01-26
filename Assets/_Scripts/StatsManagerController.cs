using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManagerController : MonoBehaviour
{
    public float playerHP;
    public float playerHPGain;
    public float playerHPLoss;
    public float momHP;
    public float momHPGain;
    public float momHPLoss;
    public float shelterHP;
    public float shelterHPGain;
    public float shelterHPLoss;

    public int myFood;
    public int myWood;
    public int myMedicine;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
    //move to after any call that alters values
        
    }
    
    //Increases player HP by playerHPGain value
    public void IncreasePlayerHP()
    {
        playerHP += playerHPGain;
        UpdateUI();
    }
    public void IncreaseMomHP()
    {
        momHP += momHPGain;
        UpdateUI();
    }
    public void IncreaseShelterHP()
    {
        shelterHP += shelterHPGain;
        UpdateUI();
    }

    //Decrease player HP by playerHPLoss value
    public void DecreasePlayerHP()
    {
        playerHP -= playerHPLoss;
        UpdateUI();
    }
    public void DecreaseMomHP()
    {
        momHP -= momHPLoss;
        UpdateUI();
    }
    public void DecreaseShelterHP()
    {
        shelterHP -= shelterHPLoss;
        UpdateUI();
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

    //adds newVal to the current desired inventory stat
    public void AddToFood(int newVal)
    {
        myFood += newVal;
        UpdateUI();
    }
    public void AddToWood(int newVal)
    {
        myWood += newVal;
        UpdateUI();
    }
    public void AddToMedicine(int newVal)
    {
        myMedicine += newVal;
        UpdateUI();
    }


    public void UpdateUI()
    {
        GameObject.Find("MomHealth").GetComponent<Slider>().value = momHP;
        GameObject.Find("MomHealth").transform.GetChild(3).GetComponent<Slider>().value = momHP - momHPLoss;
        GameObject.Find("SelfHealth").GetComponent<Slider>().value = playerHP;
        GameObject.Find("SelfHealth").transform.GetChild(3).GetComponent<Slider>().value = playerHP - playerHPLoss;
        GameObject.Find("Shelter").GetComponent<Slider>().value = shelterHP;
        GameObject.Find("Shelter").transform.GetChild(3).GetComponent<Slider>().value = shelterHP - shelterHPLoss;
    }
}
