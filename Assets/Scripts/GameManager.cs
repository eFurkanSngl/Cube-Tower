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
    private Vector2 _spawnPs = new Vector2(0, 3.50f);
    [SerializeField] private float _posIncrement = 3f;  // Poz artış miktarı
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCube());
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

            Vector2 pos = _spawnPs;
            Instantiate(cubeToSpawn, pos, Quaternion.identity); // Instantiate et
    
    
            yield return new WaitForSeconds(5f);  // 5sn bekle yaratmak için
    
        }
    }

    public void IncrementSpawnPos()
    {
        _spawnPs.y += _posIncrement;  // Y poz 1 birim kadar yukarı cıkacak.
    }
}
