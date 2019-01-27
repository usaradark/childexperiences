using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseCharacterController : MonoBehaviour
{
    public float charaSpeed;
    public GameObject houseManager;
    public GameObject statManager;

    private CharacterController myController;
    private HouseManagerController houseController;
<<<<<<< HEAD
    private StatsManagerController smc;
    private bool waiting;
=======

    public GameObject panel;

>>>>>>> 6d10b39adec248404b4f965270def3aa1517fdba
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
            panel.gameObject.SetActive(true);
            Time.timeScale = 0;
            switch (collider.tag)
            {
                case "Door":
                    //Debug.Log("Leave?");
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Leave?";
                    break;
                case "Stove":
<<<<<<< HEAD
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
=======
                    //Debug.Log("Make food?");
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Make food?";
                    break;
                case "Hole":
                    //Debug.Log("Repairing house");
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Repairing house?";
                    houseController.RepairHouse();
                    break;
                case "Fireplace":
                    //Debug.Log("Build fire?");
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Build Fire?";
                    houseController.BuildFire();
>>>>>>> 6d10b39adec248404b4f965270def3aa1517fdba
                    break;
            }
        }
    }

    public void Nah()
    {
        panel.transform.GetChild(0).GetComponent<Text>().text = "";
        Time.timeScale = 1;
        panel.SetActive(false); 
    }

    public void Yee()
    {
        panel.transform.GetChild(0).GetComponent<Text>().text = "";
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
