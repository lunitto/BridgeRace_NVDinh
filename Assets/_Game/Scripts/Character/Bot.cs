using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private List<Transform> endSpotList = new List<Transform>();
    [SerializeField] private List<Stage> stageList = new List<Stage>();
    private float minDistance;
    private Vector3 brickPosition;

    public int maxBrickCount;
    public Transform endSpot;

    public void Start()
    {
        // random color
        int randomIndex = Random.Range(3, 7);
        speed = 15f;
        while (ColorManager.instance.usedColorArray[randomIndex] == true) // tranh bots bi trung mau
        {
            randomIndex = Random.Range(3, 7);
        }
        ColorManager.instance.usedColorArray[randomIndex] = true;
        ChangeColor((MaterialType)randomIndex);
        ColorManager.instance.characterColors.Add(this.materialType);
        maxBrickCount = Random.Range(3, 6);
    }


}
