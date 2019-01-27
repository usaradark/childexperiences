using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioPlayer != null)
        {
            Slider VolSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
            if(VolSlider != null)
            {
                audioPlayer.volume = VolSlider.value;
            }
        }
    }
}
