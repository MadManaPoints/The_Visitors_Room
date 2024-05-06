using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHolder : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        transform.position = pos;
        pos.y = player.position.y + offset.y;
    }
}
