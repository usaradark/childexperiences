using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCharacterController : MonoBehaviour
{
    public float charaSpeed;
    public GameObject houseManager;
    public GameObject statManager;

    private CharacterController myController;
    private HouseManagerController houseController;
    private StatsManagerController smc;
    private bool waiting;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        houseController = houseManager.GetComponent<HouseManagerController>();
        smc = statManager.GetComponent<StatsManagerController>();
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);
        myController.SimpleMove(playerMove * charaSpeed);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && !waiting)
        {
            switch (collider.tag)
            {
                case "Door":
                    Debug.Log("Leave?");
                    break;
                case "Stove":
                    if (smc.myFood > 0)
                    {
                        Debug.Log("Make food?");
                        waiting = true;
                    }
                    break;
                case "Hole":
                    if (smc.myWood > 0)
                    {
                        Debug.Log("Repairing house");
                        houseController.RepairHouse();
                    }
                    break;
                case "Fireplace":
                    if (smc.myWood > 0)
                    {
                        Debug.Log("Building fire");
                        houseController.BuildFire();
                    }
                    break;
            }
        }
    }
}
