using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3 (0, 0, -5f);
    [SerializeField] private float _smoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private Transform _target;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition =  new Vector3 (this.gameObject.transform.position.x, _target.position.y, this.gameObject.transform.position.z) - _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
