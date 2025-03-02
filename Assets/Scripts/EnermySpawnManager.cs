using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enermyPrefab;
    [SerializeField] int totalEnermy = 10;
    [SerializeField] float space = 2f;
    [SerializeField] float moveSpeed = 2f; // 

    [SerializeField] Vector2 startPos = new Vector2(0, 7);

    private void Start()
    {
        StartCoroutine(IEFormation());
    }

    IEnumerator IEFormation()
    {
        int rows = (int)Math.Floor(Math.Sqrt(totalEnermy));
        int columns = (int)Math.Ceiling((float)totalEnermy / rows);
        int spawned = 0;

        for (int i = -4; i <= 4  && spawned < totalEnermy; i++)
        {
            for (int j = 1 ; j <= 2 && spawned < totalEnermy; j++)
            {
                Vector2 spawnPos = new Vector2(i * space, j * space);

                // 
                GameObject newEnermy = Instantiate(enermyPrefab, startPos, Quaternion.Euler(0,0,180));

                // 
                StartCoroutine(MoveToPosition(newEnermy, spawnPos, moveSpeed));

                spawned++; // 
                yield return new WaitForSeconds(0.3f); // 
            }
        }
    }

    IEnumerator MoveToPosition(GameObject obj, Vector2 targetPos, float speed)
    {
        float elapsedTime = 0f;
        Vector2 start = obj.transform.position;
        float duration = 1f / speed; // 

        while (elapsedTime < duration && obj != null)
        {
            obj.transform.position = Vector2.Lerp(start, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       // obj.transform.position = targetPos; // 
    }

}
