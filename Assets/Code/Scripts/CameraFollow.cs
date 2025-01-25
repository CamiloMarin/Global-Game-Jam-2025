using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 _offset = new Vector3 (0, 0, -5f);
    [SerializeField] private float _smoothTime = 0.25f;
    [SerializeField] private float _decreaseDistance = 0.5f;

   
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private Transform _target;

    private void Start()
    {
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition =  new Vector3 (_target.position.x, _target.position.y, this.gameObject.transform.position.z) - _offset;
        Vector3 modifiedVelocity = _velocity - new Vector3(0, _decreaseDistance, 0);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref modifiedVelocity, _smoothTime);
    }
}
