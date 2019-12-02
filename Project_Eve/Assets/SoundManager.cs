using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource source;
    [SerializeField] AudioClip[] sounds;
    int initial;

    [SerializeField] AudioSource music;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == FindObjectOfType<Movement>().gameObject)
        {
            source.clip = sounds[initial];
            source.Play();
            Destroy(GetComponent<Collider>());
            Invoke("playMusic", 6f);
        }
    }

    public void playSound(int index)
    {
        source.clip = sounds[index];
        source.Play();
    }

    private void Update()
    {
        if (source.isPlaying)
        {
            music.volume = 0.2f;
        }
        else
        {
            music.volume = 0.5f;
        }
    }

    void playMusic()
    {
        if (music != null)
        {

            music.Play();
        }
    }





}
