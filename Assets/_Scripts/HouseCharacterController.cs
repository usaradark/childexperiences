using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCharacterController : MonoBehaviour
{
    public float charaSpeed;
    public GameObject houseManager;

    private CharacterController myController;
    private HouseManagerController houseController;
    
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        houseController = houseManager.GetComponent<HouseManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (collider.tag)
            {
                case "Door":
                    Debug.Log("Leave?");
                    break;
                case "Stove":
                    Debug.Log("Make food?");
                    break;
                case "Hole":
                    Debug.Log("Repairing house");
                    houseController.RepairHouse();
                    break;
                case "Fireplace":
                    Debug.Log("Build fire?");
                    houseController.BuildFire();
                    break;
            }
        }
    }
}
