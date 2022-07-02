using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundValueControllerComponent : MonoBehaviour
{
    [Header("Components")]
    
    [SerializeField] private Slider sliderMusic;
    // [SerializeField] private Slider sliderSound;

    [Header("Key")]
    [SerializeField] private string saveValueSoundKey;

    [Header("Tag")]

    [SerializeField] private string sliderTag;

    [Header("Value")]
    [SerializeField] private float volume;
    // [SerializeField] private float volumeSound;


    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey(saveValueSoundKey))
        {
            this.volume = PlayerPrefs.GetFloat(saveValueSoundKey);
            this.GetComponent<AudioSource>().volume = this.volume;
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.sliderMusic = sliderObj.GetComponent<Slider>();
                this.sliderMusic.value = this.volume;
            }
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
        if (sliderObj != null) { 
        sliderMusic = sliderObj.GetComponent<Slider>();
        this.volume = sliderMusic.value;
        if (this.GetComponent<AudioSource>().volume != this.volume)
        {
            PlayerPrefs.SetFloat(this.saveValueSoundKey, this.volume);
        }
        this.volume = this.volume / 100;
        this.GetComponent<AudioSource>().volume = (this.volume);
        }
    }
}

