using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampAnim : MonoBehaviour
{
    public Vector3 _originOfset;
    public float _smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private Vector3 target;
    void Start()
    {
        target = gameObject.transform.position;
        transform.position = target + _originOfset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, _smoothTime);
    }
}
