using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEndspots : MonoBehaviour
{
    [SerializeField] Bot bot;
    [SerializeField] Vector3 offset;
    [SerializeField] Stage stage;
    private void Start()
    {
        offset = new Vector3(0, 5, 5);
       
    }
    void Update()
    {
        if (bot != null)
        {
            //transform.position = bot.transform.position + offset;
            if (bot.onBridge &&bot.stage == this.stage)
            {
                transform.position = bot.transform.position + offset;
            }
        }

    }
}
