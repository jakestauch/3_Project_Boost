using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    [SerializeField] Vector3 movementVector = new Vector3(0f, 10f, 0f);
    [SerializeField] float period = 2f;
    float cycles;
    [Range(0, 1)][SerializeField] float movementFactor;

    Vector3 startingPos;

    // Use this for initialization
    void Start () 
    {
        startingPos = transform.position; 
    }
    
    // Update is called once per frame
    void Update () 
    {   cycles = Time.time / period;
        float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
        movementFactor = rawSinWave / 2f + .5f;

    }
}
