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

    private StatsManagerController smc;
    //private bool waiting;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        houseController = houseManager.GetComponent<HouseManagerController>();
        smc = statManager.GetComponent<StatsManagerController>();
        //waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!waiting)
        //{
            MovePlayer();
       // }
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
            panel.gameObject.SetActive(true);
            Time.timeScale = 0;
            print(panel.transform.GetChild(0).GetComponent<Text>().text);
            switch (collider.tag)
            {
                case "Door":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Leave?";
                    break;
                case "Stove":
                    if (smc.myFood > 0)
                    {
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Make food?";
                    }
                    break;
                case "Hole":
                    if (smc.myWood > 0)
                    {
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Repairing house?";
                        houseController.RepairHouse();
                    }
                    break;
                case "Fireplace":
                    if (smc.myWood > 0)
                    {
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Build Fire?";
                        houseController.BuildFire();
                    }
                    break;
            }
        }
    }

    public void No()
    {
        panel.transform.GetChild(0).GetComponent<Text>().text = "";
        Time.timeScale = 1;
        panel.SetActive(false); 
    }

    public void Yes()
    {
        panel.transform.GetChild(0).GetComponent<Text>().text = "";
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
