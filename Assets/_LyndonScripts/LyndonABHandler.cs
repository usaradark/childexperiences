using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyndonABHandler : MonoBehaviour
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

    public AudioClip audioWalking;
    public AudioSource audioSource;
    public float audioDelay = 45.0f;
    public float maxAudioDelay = 45.0f;

    public Animator animator;
    private bool playerMoving;
    private Vector3 lastMove;

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
            playerMoving = false;
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);

            audioSource.clip = audioWalking;

            if (Mathf.Abs(moveX) > 0 || Mathf.Abs(moveY) > 0)
            {
                playerMoving = true;

                if (audioDelay <= 0)
                {
                    audioDelay = maxAudioDelay;
                    audioSource.volume = Random.Range(0.8f, 1f);
                    audioSource.pitch = Random.Range(0.8f, 1.1f);
                    audioSource.PlayOneShot(audioWalking, 0.7f);

                    lastMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                }
            }
            if(audioDelay > 0)
                audioDelay--;

            myController.SimpleMove(playerMove * charaSpeed);
            animator.SetFloat("horizontal", moveX);
            animator.SetFloat("vertical", moveY);
            animator.SetBool("isMoving", playerMoving);
            animator.SetFloat("lastHorizontal", lastMove.x);
            animator.SetFloat("lastVertical", lastMove.y);

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

            //OperateOnTag(collider.gameObject.tag);

            //print(panel.transform.GetChild(0).GetComponent<Text>().text);

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
                    panel.transform.GetChild(0).GetComponent<Text>().text = "STOVE2";
                    //new stove
                    Debug.Log("STOVE2");
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
                    currentTag = "Stove3";
                    panel.transform.GetChild(0).GetComponent<Text>().text = "STOVE3";
                    Debug.Log("STOVE3");
                }
                else
                {
                    panel.gameObject.SetActive(false);
                    panel.transform.GetChild(0).GetComponent<Text>().text = "";
                    currentTag = "";
                    canControl = true;
                }
                break;

            case "Stove3":
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

                break;


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
