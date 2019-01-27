using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseCharacterController : MonoBehaviour
{
    public float charaSpeed;
    public GameObject eventHandler;
    public GameObject statManager;
    public GameObject panel;

    private CharacterController myController;
    private EventFunctions functions;

    private StatsManagerController smc;
    private string currentTrigger;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        functions = eventHandler.GetComponent<EventFunctions>();
        smc = statManager.GetComponent<StatsManagerController>();
        currentTrigger = "";
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
            panel.SetActive(true);
            Time.timeScale = 0;
            switch (collider.tag)
            {
                case "Door":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Leave?";
                    break;
                case "Stove":
                    if (smc.myFood > 0)
                    {
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Make food?";
                        currentTrigger = "Stove";
                    }
                    break;
                case "Hole":
                    if (smc.myWood > 0)
                    {
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Repair house?";
                        currentTrigger = "Hole";
                    }
                    break;
                case "Fireplace":
                    if (smc.myWood > 0)
                    {
                        panel.transform.GetChild(0).GetComponent<Text>().text = "Build Fire?";
                        currentTrigger = "Fireplace";
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
        RunTriggerAction();
        //Time.timeScale = 1;
        //panel.SetActive(false);
    }

    public void Yourself()
    {

    }

    private void RunTriggerAction()
    {
        switch (currentTrigger)
        {
            case "Stove":
                panel.transform.GetChild(0).GetComponent<Text>().text = "Feed Mom or Yourself?";
                break;
            case "Hole":
                functions.HomeRepairRoof();
                Time.timeScale = 1;
                panel.SetActive(false);
                break;
            case "Fire":
                functions.CreateFire();
                break;
        }
        functions.UpdateAll();
    }
}
