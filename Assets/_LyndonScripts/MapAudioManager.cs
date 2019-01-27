using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapAudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip walkingOutsideClip;

    public GameObject player;
    private UnityEngine.AI.NavMeshAgent playerAgent;

    private float audioDelay;
    public float maxAudioDelay;

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = player.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerAgent.velocity != Vector3.zero && audioDelay <= 0)
        {
            audioDelay = maxAudioDelay;
            source.volume = Random.Range(0.8f, 1f);
            source.pitch = Random.Range(0.8f, 1.1f);
            source.PlayOneShot(walkingOutsideClip, 0.7f);
        }

        if (audioDelay > 0)
            audioDelay--;
    }
}
