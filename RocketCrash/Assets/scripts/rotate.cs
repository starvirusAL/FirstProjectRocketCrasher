using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField] Vector3 movePosition;
    // Start is called before the first frame update
    void Start()
    {
        float rotationSpeed = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationSpeed = speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed);

    }
}
