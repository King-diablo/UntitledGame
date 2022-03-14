using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public enum FoodType
    {
        GOOD,
        BAD
    }
    public FoodType type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && type == FoodType.GOOD)
        {
            GameManager.Instance.AddPoint(10);
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Player") && type == FoodType.BAD)
        {
            GameManager.Instance.RemovePoint(30);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
