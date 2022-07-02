using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerButtonScript : MonoBehaviour
{
    [SerializeField]
    private Button A, D, Space;
    [SerializeField] float launchSpeed = 100f;
    [SerializeField] GameObject player;
    [SerializeField ] Rigidbody rigidBody;

    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody>();
       
    }

    public void MethodTurnA()
    {

    }
    public void MethodLounchSpace()
    {
        rigidBody.AddRelativeForce(Vector3.up * launchSpeed * Time.deltaTime);

    }
    public void MethodTurnD()
    {

    }
    
}
