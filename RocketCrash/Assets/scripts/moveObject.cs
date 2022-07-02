using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]

public class moveObject : MonoBehaviour
{
    [SerializeField] Vector3 movePosition;
    [SerializeField] [Range (0,1)] float moveProgress;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float limitTime = 0;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("MoveObject", limitTime);
       
    }

   void MoveObject()
    {
        moveProgress = Mathf.PingPong((Time.time * moveSpeed), 1);
        Vector3 offsett = movePosition * moveProgress;
        transform.position = startPosition + offsett;
    }
}
