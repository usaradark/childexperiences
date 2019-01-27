using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABHandler : MonoBehaviour
{

    public float charaSpeed;
    public GameObject eventHandler;
    public GameObject statManager;
    public GameObject panel;

    private CharacterController myController;
    private EventFunctions functions;

    private StatsManagerController smc;
    private string currentTrigger;

    public bool canControl;

    public string currentTag;

    bool leftChoice = true;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        functions = eventHandler.GetComponent<EventFunctions>();
        smc = statManager.GetComponent<StatsManagerController>();
        currentTrigger = "";
        canControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (canControl)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);
            myController.SimpleMove(playerMove * charaSpeed);
        }

    }

    private void OnTriggerStay(Collider collider)
    {

        if (Input.GetKeyDown(KeyCode.E) && canControl)
        {
            Debug.Log("E pressed in Stay");
            canControl = false;
            panel.gameObject.SetActive(true);
            currentTag = collider.gameObject.tag;
            switch (currentTag)
            {
                case "Stove":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Make Food?";
                    break;
                case "Hole":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Use wood to repair hole?";
                    break;
                case "Med Cabinet":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Use medicine?";
                    break;
                case "Fire":
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Use wood to make Fire?";
                    break;
            }
        }
    }

    public void OperateOnTag(string tag)
    {
        switch (tag)
        {
            case "Stove":
                if (leftChoice)
                {
                    currentTag = "Stove2";
                    panel.transform.GetChild(0).GetComponent<Text>().text = "Feed Mom or Yourself?";
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "Stove2":
                if (leftChoice)
                {
                    functions.MomEatFood();
                }
                else
                {

                    functions.SelfEatFood();
                }
                canControl = true;
                panel.gameObject.SetActive(false);
                panel.transform.GetChild(0).GetComponent<Text>().text = "";
                currentTag = "";
                break;

            /*case "Stove3":
                if (leftChoice)
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }

                break;*/


        }

    }

    public void A()
    {
        leftChoice = true;
        OperateOnTag(currentTag);
    }

    public void B()
    {
        leftChoice = false;
        OperateOnTag(currentTag);
    }

}
