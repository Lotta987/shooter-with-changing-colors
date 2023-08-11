using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _targets;
    [SerializeField] private float _spawnTime;
    private SpawnZone _spawnZone;

    private void Awake()
    {
        _spawnZone = GetComponent<SpawnZone>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnTarget()
    {
        Vector3 randomPoint =  _spawnZone.GetRandomPointInZone();
        int randomTarget = Random.Range(0, _targets.Length);
        Instantiate(_targets[randomTarget], randomPoint, Quaternion.identity);
    }
    private IEnumerator AutoSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            SpawnTarget();
        }
    }

}
