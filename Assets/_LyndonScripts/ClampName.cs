using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ClampName : MonoBehaviour
{
    public GameObject interText;
    public Text nameLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Vector3 namePos = this.transform.position;
        //Debug.Log(namePos);

        if (this.GetComponentInParent<NavMeshAgent>().velocity.magnitude == 0)
        {
            interText.SetActive(true);
        }
        else
        {
            interText.SetActive(false);
        }
        interText.transform.position = namePos;
    }
}
