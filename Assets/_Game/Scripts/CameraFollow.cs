using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    int baloCount = 0;
    public Character container;
    public Vector3 offset;
    public float space;

    private void LateUpdate()
    {
        
        baloCount = container.baloBrickObjectList.Count;
        transform.position = Vector3.Lerp(transform.position, container.transform.position + offset + offset * baloCount / 50, Time.deltaTime * speed);
        
    }
}
