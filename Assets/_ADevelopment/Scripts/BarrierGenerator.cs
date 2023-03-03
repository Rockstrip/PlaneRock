using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BarrierGenerator : MonoBehaviour
{
    [SerializeField] private BarrierController barrierController;
    [SerializeField] private Transform root;
    [SerializeField] private Material background;
    [SerializeField] private float offset;
    [SerializeField] private float frequency = 5f;
    [SerializeField] private float speedMultiplayer = 1.03f;
    [SerializeField] private float speedLimit = 10f;

    private static readonly int SpeedID = Shader.PropertyToID("_Speed");

    private float _speed = 1f;
    public float Speed
    {
        get => _speed;
        private set => _speed = value < speedLimit ? value : speedLimit;
    }

    private IEnumerator Start()
    {
        StartCoroutine(IncreaseSpeed());
        while (true)
        {
            var barrier = Instantiate(barrierController, root);
            var pos = barrier.transform.position;
            var rnd = Random.Range(-offset, offset);
            barrier.transform.position = new Vector3(pos.x + rnd, pos.y, pos.z);
            barrier.barrierGenerator = this;
            
            yield return new WaitForSeconds(frequency / Speed);
        }    
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            // localSpeed *= speedMultiplayer;
            background.SetFloat(SpeedID, Speed);
            Speed += speedMultiplayer * Time.deltaTime * 0.1f;
            Debug.Log(Speed);
            yield return null;
        }
    }
}
