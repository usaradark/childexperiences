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

    Camera cam;
    public LayerMask groundLayer;
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent playerAgent;

    public GameObject[] locations;

    public Vector3 lastPosition;
    private bool isInLocation;

    public Text interact;

    #region Monobehavior API;

    private void Start()
    {
        panel.SetActive(false);
        interact.gameObject.SetActive(false);
        playerAgent = player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        lastPosition = player.transform.position;

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
        playerAgent.SetDestination(gameObject.transform.position);
    }

    // The three functions below are for the buttons on Canvas in the scene "Map"

    public void disablePanel()
    {
        panel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        isInLocation = true;
        interact.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(true);

            promptLocation.text = locationName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInLocation = false;
        interact.gameObject.SetActive(false);
    }

    #endregion

    

}
