using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BarrierController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> asteroids;
    [HideInInspector] public BarrierGenerator barrierGenerator;

    private void Start()
    {
        spriteRenderer.sprite = asteroids[Random.Range(0, asteroids.Count)];
        var color = Color.HSVToRGB(Random.value, 0.5f, 1f);
        spriteRenderer.color = color;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (barrierGenerator.Speed * Time.deltaTime));
    }
}
