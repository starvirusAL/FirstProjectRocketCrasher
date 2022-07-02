using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[DisallowMultipleComponent]
public class MoveRocket : MonoBehaviour
{
   // [SerializeField] float speed = 3f;
    [SerializeField] Text energyText;
    [SerializeField] float rotSpeed = 100f;
    [SerializeField] float launchSpeed = 100f;
    [SerializeField] AudioClip flyAudio, finishAudio, deadAudio;
    [SerializeField] ParticleSystem flyPs, finishPs, deathPs;
    [SerializeField] int energyTotal = 999, energyApply = 30;
    [SerializeField] int fuelPlusSmall = 100, fuelPlusLarge = 300, fuelPlusMidle = 200;
    [SerializeField] Text textlevel;


    AudioSource audioSource;
    Rigidbody rigidBody;
    bool collisionOff = false;

    enum State { Playing, Dead, NextLevel };
    State state = State.Playing;
    void Start()
    {
        textlevel.text = "Level: " + (SceneManager.GetActiveScene().buildIndex).ToString();
        energyText.text = energyTotal.ToString();
        state = State.Playing;
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }


    void Update()
    {
        if (state == State.Playing)
        {
            RotateInput();
            RocketUp();
        }
        if (true)
        {
            DebugKeys();
        }
    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadedNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            LoadedFirstLevel();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            collisionOff = !collisionOff;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))  // если нажата клавиша Esc (Escape)
        {
            SceneManager.LoadScene(0);    // закрыть приложение
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Dead || collisionOff || state == State.NextLevel)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                
                break;
            case "fuelSmall":
                FuelPlus(fuelPlusSmall, collision.gameObject);
                break;
            case "fuelMidle":
                FuelPlus(fuelPlusMidle, collision.gameObject);
                break;
            case "fuelLarge":
                FuelPlus(fuelPlusLarge, collision.gameObject);
                break;
            case "Finish":
                Finish();
                break;
            default:
                Lose();
                break;
        }
    }

    void FuelPlus(int fuelPlus, GameObject Fuel)
    {
        Fuel.GetComponent<CapsuleCollider>().enabled = false;
        energyTotal += fuelPlus;
        energyText.text = energyTotal.ToString();
        Destroy(Fuel);

    }


    private void LoadedNextLevel()
    {
        
        int valueLevel = SceneManager.GetActiveScene().buildIndex;
        valueLevel++;
        if (valueLevel == SceneManager.sceneCountInBuildSettings)
        { 
            SceneManager.LoadScene(0); 
        }
        else { 
            
            SceneManager.LoadScene(valueLevel); }


        
    }
    private void LoadedFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void RotateInput()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;
        rigidBody.freezeRotation = true;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }
    public void RocketUp()
    {

        if (energyTotal > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                energyTotal -= Mathf.RoundToInt(energyApply * Time.deltaTime);
                energyText.text = energyTotal.ToString();
               
                rigidBody.AddRelativeForce(Vector3.up * launchSpeed * Time.deltaTime);
                if (audioSource.isPlaying == false)
                {
                    audioSource.PlayOneShot(flyAudio);
                    flyPs.Play();
                }

            }
            else
            {
                
                audioSource.Pause();
                flyPs.Stop();
            }
        }
        else { audioSource.Pause(); flyPs.Stop(); }

    }

    private void Finish()
    {
        
        state = State.NextLevel;
        audioSource.Stop();
        audioSource.PlayOneShot(finishAudio);
        flyPs.Stop();
        finishPs.Play();
        Invoke("LoadedNextLevel", 2f);
    }

    private void Lose()
    {

        flyPs.Stop();
        deathPs.Play();
        state = State.Dead;
        audioSource.Stop();
        audioSource.PlayOneShot(deadAudio);
        Invoke("LoadedFirstLevel", 2f);
    }
   
}



