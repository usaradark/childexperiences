using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyndonPlayer : MonoBehaviour
{
    float speed = 5.0f;
    public Canvas interact_canvas;
    public GameObject sceneInteract;


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.gameObject.transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        this.gameObject.transform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interact_canvas.gameObject.SetActive(true);
        }

        if (Input.GetAxis("Interact") == 1)
        {
            sceneInteract.GetComponent<SceneInteract>().load("Church");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interact_canvas.gameObject.SetActive(false);
        }
    }
}
