using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampNameHome : MonoBehaviour
{
    public GameObject interText;
    // Start is called before the first frame update
    void Start()
    {
        interText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        interText.transform.position = namePos;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("E");
    }

    void OnTriggerStay(Collider other)
    {
        print("E");
        interText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interText.SetActive(false);
    }
}
