using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctions : MonoBehaviour
{
    private StatsManagerController existingValues;

    public GameObject statsManager;
    public int deltaFood;
    public int deltaMedicine;
    public int deltaWood;
    public int deltaMomHealth;
    public float deltaMomHealthDecreaseRate;
    public int deltaSelfHealth;
    public float deltaSelfHealthDecreaseRate;
    public int deltaShelterHealth;
    public float deltaShelterHealthDecreaseRate;
    public bool nextRepairTwiceAsEffective;

    public void ZeroAll()
    {
        deltaFood = 0;
        deltaMedicine = 0;
        deltaWood = 0;
        deltaMomHealth = 0;
        deltaMomHealthDecreaseRate = 1;
        deltaSelfHealth = 0;
        deltaSelfHealthDecreaseRate = 1;
        deltaShelterHealth = 0;
        deltaShelterHealthDecreaseRate = 1;
        nextRepairTwiceAsEffective = false;
    }

    public void UpdateAll()
    {
        existingValues.UpdatePlayerHP(deltaSelfHealth);
        existingValues.UpdateMomHP(deltaMomHealth);
        existingValues.UpdateShelterHP(deltaShelterHealth);
        existingValues.UpdatePlayerLossRate(deltaSelfHealthDecreaseRate);
        existingValues.UpdateMomLossRate(deltaMomHealthDecreaseRate);
        existingValues.UpdateShelterLossRate(deltaShelterHealthDecreaseRate);
        existingValues.UpdateFood(deltaFood);
        existingValues.UpdateWood(deltaWood);
        existingValues.UpdateMedicine(deltaMedicine);
        ZeroAll();
    }

    public void ChurchA1()
    {
        ZeroAll();
        deltaWood = 2;
        deltaSelfHealth = -10;
    }

    public void ChurchA2()
    {
        ZeroAll();
        deltaFood = 1;
    }

    public void ChurchB1()
    {
        ZeroAll();
        deltaFood = 1;
        deltaMedicine = 1;
    }

    public void ChurchB2()
    {
        ZeroAll();
        deltaWood = 3;
    }

    public void HarborA1()
    {
        ZeroAll();
        deltaWood = 1;
    }

    public void HarborA2()
    {
        ZeroAll();
        deltaSelfHealth = 10;
    }

    public void HarborB1()
    {
        ZeroAll();
        deltaWood = -2;
        deltaFood = 4;
    }

    public void HarborB2()
    {
        ZeroAll();
        deltaFood = 1;
    }

    public void HospitalA1()
    {
        ZeroAll();
        deltaSelfHealth = 40;
    }

    public void HospitalA2()
    {
        ZeroAll();
        deltaFood = -1;
        deltaMedicine = 2;
    }

    public void HospitalB1()
    {
        ZeroAll();
        deltaFood = 1;
    }

    public void HospitalB2()
    {
        ZeroAll();
        deltaMedicine = 2;
    }

    public void HardwareA1()
    {
        ZeroAll();
        deltaWood = 3;
    }

    public void HardwareA2()
    {
        ZeroAll();
        nextRepairTwiceAsEffective = true;
        
    }

    public void HardwareB1()
    {
        ZeroAll();
        deltaWood = 4;
    }

    public void HardwareB2()
    {
        ZeroAll();
        deltaFood = 2;
    }

    public void ForestA1()
    {
        ZeroAll();
        deltaFood = 2;
    }

    public void ForestA2()
    {
        ZeroAll();
        deltaWood = 2;
    }

    public void ForestB1()
    {
        ZeroAll();
        deltaFood = 1;
    }

    public void ForestB2()
    {
        ZeroAll();
        deltaWood = 2;
    }

    public void GroceryA1()
    {
        ZeroAll();
        deltaFood = 3;
    }

    public void GroceryA2()
    {
        ZeroAll();
        deltaWood = 1;
        deltaMedicine = 1;
    }

    public void GroceryB1()
    {
        ZeroAll();
        deltaMedicine = -1;
        deltaFood = 3;
    }

    public void GroceryB2()
    {
        ZeroAll();
        deltaWood = -1;
        deltaFood = 3;
    }

    public void HomeRepairRoof()
    {
        ZeroAll();
        deltaWood = -2;
        deltaShelterHealthDecreaseRate = .5f;
    }

    public void CreateFire()
    {
        ZeroAll();
        deltaWood = -2;
        deltaShelterHealth = 35;
    }

    public void SelfEatFood()
    {
        ZeroAll();
        deltaSelfHealth = 25;
        deltaFood = -1;
    }

    public void MomEatFood()
    {
        ZeroAll();
        deltaMomHealth = 25;
        deltaFood = -1;
    }

    public void SelfTakeMedicine()
    {
        ZeroAll();
        deltaSelfHealthDecreaseRate = .5f;
        deltaMedicine = -1;
    }

    public void MomTakeMedicine()
    {
        ZeroAll();
        deltaMomHealthDecreaseRate = .5f;
        deltaMedicine = -1;
    }

    public void HeavyRain()
    {
        ZeroAll();
        deltaSelfHealth = -10;
        deltaMomHealth = -10;
    }

    public void SnowStorm()
    {
        ZeroAll();
        if (existingValues.fireIsLit)
        {
            
        }
        else
        {
            deltaShelterHealth = -20;
        }

    }



    public void MomExtraSick()
    {
        ZeroAll();
        if(existingValues.fireIsLit == true)
        {

        }
        else
        {
            deltaMomHealth = -10;
        }
    }

    public void Burglar()
    {
        ZeroAll();
        if(existingValues.holeIsPatched)
        {
            
        }
        else
        {
            deltaFood = -1;
            deltaMedicine = -1;
        }
    }

    public void Nomads()
    {
        ZeroAll();
        deltaFood = 1;
    }

    public void QuietNight()
    {
        ZeroAll();
    }


    // Start is called before the first frame update
    void Start()
    {
        existingValues = statsManager.GetComponent<StatsManagerController>();
        ZeroAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
