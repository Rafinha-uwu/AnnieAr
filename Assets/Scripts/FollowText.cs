using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowText : MonoBehaviour
{
    Transform Cam;

    Transform Card;

    Transform Canvas;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main.transform;
        Card = transform.parent;
        Canvas = GameObject.FindAnyObjectByType<Canvas>().transform;

        transform.SetParent(Canvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Cam.transform.position);
        transform.position = Card.position + offset;
    }
}
