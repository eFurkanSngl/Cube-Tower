using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _posIncrement = 2.5f;
    private Vector3 _offset;  // Kameranın hedefe poz farkı
    [SerializeField] private float _smoothSpeed = 0.125f;  // Kamera hız kontrol
    Vector3 startPos = new Vector3(0, 0, -10);
    
     public void IncrementSpawnCameraPos()
     {
         Vector3 newPos = new Vector3(x: 0, transform.position.y + _posIncrement, z:-10);
          Vector3 smoothedPos = Vector3.Lerp(transform.position, startPos + newPos, _smoothSpeed);
          transform.position = smoothedPos;
          // Lerp kullanarak Kameramızın geçiş hareketini hızını yumuşattık
     }

  
     // public void IncrementSpawnCameraPos()
     // {
     //     transform.position += new Vector3(0, _posIncrement, 0) * _smoothSpeed;
     // }  Eski hali.
    
}
