using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_option : MonoBehaviour
{
    public string goodDialogue_1 = "";
    public string badDialogue_1 = "";
    public string goodDialogue_2 = "";
    public string badDialogue_2 = "";
    public Text text;

    public Button option1;
    public Button option2;

    public GameObject panel;

    public void yes()
    {
        string dialogue = "";
        int num = Random.Range(0, 2);

        if (num == 0)
            dialogue = badDialogue_1;
        else
            dialogue = goodDialogue_1;
        //option1.gameObject.SetActive(false);
        //option2.gameObject.SetActive(false);
        //StartCoroutine(TypeSentence(dialogue));
        panel.SetActive(false);
    }

    public void no()
    {
        string dialogue = "";
        int num = Random.Range(0, 2);

        if (num == 0)
            dialogue = badDialogue_2;
        else
            dialogue = goodDialogue_2;

        //option1.gameObject.SetActive(false);
        //option2.gameObject.SetActive(false);
        panel.SetActive(false);
        //StartCoroutine(TypeSentence(dialogue));
    }

    IEnumerator TypeSentence(string dialogue)
    {
        text.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            text.text += letter;
            yield return null;
        }
    }
}
