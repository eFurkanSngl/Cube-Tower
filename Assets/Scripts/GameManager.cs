using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private Vector2 _startpos = new Vector2(x: 0, y:4.27f);
    
    
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
        Vector2 pos = _startpos;
        Instantiate(_cube, pos, Quaternion.identity);
    } 
}
