using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyndonPlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Canvas E;

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.gameObject.transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        this.gameObject.transform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            E.gameObject.SetActive(true);
            Debug.Log("Press F to pay respects");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        E.gameObject.SetActive(false);
    }
}
