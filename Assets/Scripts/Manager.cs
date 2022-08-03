using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private float _enemyPrefab;
    private float _enemycontainer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemycontainer.trnasform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    public void PlayerOnDeath()
    {
        _stopSpawning = true;
    }
}
