using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HighlightedInteractable : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;

    public GameObject panel;
    public Text promptLocation;

    public dialogue_option dia_opt;

    public string locationName;
    bool mouseOver = false;

    public Button yes;
    public Button no;

    Camera cam;
    public LayerMask groundLayer;
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent playerAgent;

    public GameObject[] locations;

    public Vector3 lastPosition;
    private bool isInLocation;

    #region Monobehavior API;

    private void Start()
    {
        panel.SetActive(false);
        playerAgent = player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        lastPosition = player.transform.position;
        if (lastPosition == player.transform.position && isInLocation)
        {
            panel.SetActive(true);

            promptLocation.text = locationName;
        }
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0, player.transform.eulerAngles.z);
    }

    // Start is called before the first frame update
    void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

    private void OnMouseDown()
    {

        if (this.gameObject.CompareTag("Location"))
        {
            playerAgent.SetDestination(gameObject.transform.position);

            yes.onClick.RemoveAllListeners();
            no.onClick.RemoveAllListeners();

            yes.onClick.AddListener(setLocationTagBack);
            no.onClick.AddListener(setLocationTagBack);

            yes.onClick.AddListener(dia_opt.yes);
            no.onClick.AddListener(dia_opt.no);

            setLocationTagToIgnore();
        }
    }

    // The three functions below are for the buttons on Canvas in the scene "Map"
    public void setLocationTagToIgnore()
    {
        foreach (GameObject location in locations)
        {
            location.tag = "Ignore";
        }
    }

    public void setLocationTagBack()
    {
        foreach (GameObject location in locations)
        {
            location.tag = "Location";
        }
    }

    public void disablePanel()
    {
        setLocationTagBack();
        panel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        isInLocation = true;           
    }

    private void OnTriggerExit(Collider other)
    {
        isInLocation = false;
    }

    #endregion

    

}
