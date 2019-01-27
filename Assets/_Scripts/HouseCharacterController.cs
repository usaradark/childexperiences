using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseCharacterController : MonoBehaviour
{
    public float charaSpeed;
    public GameObject houseManager;

    private CharacterController myController;
    private HouseManagerController houseController;

    public GameObject panel;

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
            panel.gameObject.SetActive(true);
            Time.timeScale = 0;
            switch (collider.tag)
            {
                case "Door":
                    //Debug.Log("Leave?");
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Leave?";
                    break;
                case "Stove":
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
