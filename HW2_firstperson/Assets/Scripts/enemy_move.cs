using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public Transform player;
    public float speed;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player, Vector3.up);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
