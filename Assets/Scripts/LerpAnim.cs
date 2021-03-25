using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnim : MonoBehaviour
{
    public Vector3 _offset;
    
    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;

    private Vector3 startMarker;
    private Vector3 endMarker;

    
    void Start()
    {
        startMarker = gameObject.transform.position + _offset;
        endMarker = gameObject.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
    }
}
