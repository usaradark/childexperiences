using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManagerController : MonoBehaviour
{
    public float playerHP;
    public float playerHPLoss;
    //public int playerHPLoss;
    public float momHP;
    public float momHPLoss;
    //public int momHPLoss;
    public float shelterHP;
    public float shelterHPLoss;
    //public float shelterHPLoss;

    public bool fireIsLit;
    public bool holeIsPatched;

    public int myFood;
    public int myMedicine;
    public int myWood;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //Update player HP by delta
    public void UpdatePlayerHP(float delta)
    {
        if (playerHP + delta <= 100)
            playerHP += delta;
        else
            playerHP = 100;
        UpdateUI();
    }
    public void UpdateMomHP(float delta)
    {
        if (momHP + delta <= 100)
            momHP += delta;
        else
            momHP = 100;
        UpdateUI();
    }
    public void UpdateShelterHP(float delta)
    {
        if (shelterHP + delta <= 200)
            shelterHP += delta;
        else
            shelterHP = 200;
        UpdateUI();
    }

    //Sets the desired loss rate to newLoss
    public void UpdatePlayerLossRate(float newLoss)
    {
        playerHPLoss *= newLoss;
    }
    public void UpdateMomLossRate(float newLoss)
    {
        momHPLoss *= newLoss;
    }
    public void UpdateShelterLossRate(float newLoss)
    {
        shelterHPLoss *= newLoss;
    }

    //adds newVal to the current desired inventory stat
    public void UpdateFood(int newVal)
    {
        myFood += newVal;
        UpdateUI();
    }
    public void UpdateWood(int newVal)
    {
        myWood += newVal;
        UpdateUI();
    }
    public void UpdateMedicine(int newVal)
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
        GameObject.Find("Food Value").GetComponent<TextMeshProUGUI>().text = myFood.ToString();
        GameObject.Find("Medicine Value").GetComponent<TextMeshProUGUI>().text = myMedicine.ToString();
        GameObject.Find("Wood Value").GetComponent<TextMeshProUGUI>().text = myWood.ToString();
    }
}
