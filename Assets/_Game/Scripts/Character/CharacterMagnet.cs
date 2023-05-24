using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMagnet : MonoBehaviour
{
    [SerializeField] private Character character;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("brick"))
        {
            Brick brickComponent = other.gameObject.GetComponent<Brick>();
            if (!brickComponent.isGround)
            {
                return;
            }
            else if (brickComponent.materialType == character.materialType || brickComponent.materialType == MaterialType.Grey)
            {
                brickComponent.isGround = false;
                character.EatGroundBrick(brickComponent);
            }
        }
    }
}
