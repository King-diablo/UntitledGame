using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] food;
    [SerializeField] float clampX;
    [SerializeField] float waitTime;

    private void Start()
    {
        StartCoroutine(LoopSpawning(waitTime));
    }

    private void Update()
    {

    }

    [ContextMenu("SpawnFood")]
    void SpawnFood()
    {
        if(GameManager.Instance.gameOver)
            return;

        int randomNum = Random.Range(0, food.Length);
        Vector3 position = new Vector3(Random.Range(-clampX, clampX), 7f, -4f);
        GameObject go = Instantiate(food[randomNum], position, Quaternion.identity);
        StartCoroutine(LoopSpawning(waitTime));
    }

    IEnumerator LoopSpawning(float waitTimer)
    {
        yield return new WaitForSeconds(waitTimer);
        SpawnFood();
    }
}
