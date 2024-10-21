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
        StartCoroutine(SpawnCube());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    private IEnumerator SpawnCube()
    {
        while (true)  // döngü true 
        {
            GameObject cubeToSpawn;   // spawnlanacak cube
    
            if (_cubesCount == 8)  // eğer küp 7 ise
            {
                cubeToSpawn = _specialCubes;  // özel cube spawn et
                _cubesCount = 0;  // sayac sıfırla 
                Debug.Log("Special");   // ekrana calışıp calışmadığını dene
            }
            else
            {
                cubeToSpawn = _cubes;   // döngü karşılamazsa düz cubes spawn et
                _cubesCount++;  // 1er 1 arttır
                Debug.Log("Normal");
            }
    
            Vector2 pos = new Vector2(x: 0, y: 4.27f);  // küp pos belirle
            Instantiate(cubeToSpawn, pos, Quaternion.identity); // Instantiate et
    
    
            yield return new WaitForSeconds(5f);  // 5sn bekle yaratmak için
    
        }

    }
    
}
