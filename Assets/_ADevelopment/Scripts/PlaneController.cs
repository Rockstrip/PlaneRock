using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float speed;
    private Camera _camera;

    public UnityEvent barrierEntered;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount <= 0) return;
        
        var touchX = Input.touches[0].position.x;
        var planeX = _camera.WorldToScreenPoint(transform.position).x;

        var diff = touchX - planeX;
        transform.Translate(Vector3.right * (speed * diff * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<BarrierController>(out var barrier))
        {
            barrierEntered?.Invoke();
        }
    }
}