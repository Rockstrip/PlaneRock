using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float speed;
    private Camera _camera;
    private long balance;
    public UnityEvent barrierEntered;
    private TextMeshProUGUI meteorCountText;
    private void Start()
    {
        GameObject[] meteorCountObjects = GameObject.FindGameObjectsWithTag("money");
        meteorCountText = meteorCountObjects[0].GetComponent<TextMeshProUGUI>();
        _camera = Camera.main;
        balance = 1000;
        ChangeText();
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
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<BarrierController>(out var barrier))
            ChangeText();
    }
    
    void ChangeText()
    {
        balance = (long)(balance * Random.Range(1.1f, 1.6f));
        if(balance > 100000000)
            meteorCountText.text = $"<size=120><color=#088C00>$$$$$$$$$$</color></size>";
        else if(balance > 10000000)
            meteorCountText.text = $"<size=100><color=#088C00>{balance} $</color></size>";
        else if(balance > 1000000)
            meteorCountText.text = $"<size=100><color=#088C00>{balance} $</color></size>";
        else if (balance> 100000)
            meteorCountText.text = $"<size=80><color=#0CD700>{balance} $</color></size>";
        else if (balance> 10000)
            meteorCountText.text = $"<size=70><color=#5EFF56>{balance} $</color></size>";
        else if (balance> 1000)
            meteorCountText.text = $"<size=60><color=#A0FF9B>{balance} $</color></size>";
    }
    
}