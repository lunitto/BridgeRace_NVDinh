using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public List<Brick> groundBrickObjectList = new List<Brick>();
    [SerializeField] private GameObject brickTile;
    [SerializeField] private ColorManager colorManager;


    public void Start()
    {
        int randomIndex = 0;
        //initial list of ground bricks
        for (int i = 0; i < brickTile.transform.childCount; i++)
        {
            Brick brickComponent = brickTile.transform.GetChild(i).GetComponent<Brick>();
            randomIndex = Random.Range(0, ColorManager.instance.characterColors.Count);
            
            brickComponent.ChangeColor((MaterialType)ColorManager.instance.characterColors[randomIndex]);
           
            // tat physics cua brick
            brickComponent.TurnOffPhysics();


            groundBrickObjectList.Add(brickComponent);
            brickComponent.HideRenderer(); // giau cac brick cho den khi character di vao stage

        }

    }
}
