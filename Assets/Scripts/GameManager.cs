using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubes;
    [SerializeField] private GameObject _specialCubes;
    private int _cubesCount;
    
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnCube",2,2);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SpawnCube()
    {

        GameObject cubeToSpawn;
        if (_cubesCount == 6)
        {
            cubeToSpawn = _specialCubes;
            _cubesCount = 0;
            Pause();
            Debug.Log("++");
        }
        else
        {
            cubeToSpawn = _cubes;
            _cubesCount++;
            Debug.Log("+");
        }

        

        Vector2 pos = new Vector2(x: 0, y: 4.27f);
        Instantiate(cubeToSpawn, pos, quaternion.identity);
    }

    public void Pause()
    {
        CancelInvoke("SpawnCube");
    }

}
