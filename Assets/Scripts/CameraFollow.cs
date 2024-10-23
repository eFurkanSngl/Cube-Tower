using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _posIncrement = 4.5f;
    public void IncrementSpawnCameraPos()
    {
        transform.position += new Vector3(0, _posIncrement, 0) * _smoothSpeed;
    }
    
    // [SerializeField] private Transform _target;  // Takip edelicek obje
     [SerializeField] private float _smoothSpeed = 0.125f;  // Kamera hız kontrol
    // [SerializeField] private Vector3 _offset;  // Kameranın hedefe poz farkı


    // private void LateUpdate()  // Kamere hareketi görsel güncellemeler için kullanılır.
    // {
    //     if (_target != null)
    //     {
    //
    //         Vector3 deisredPos =
    //             new Vector3(transform.position.x, _target.position.y + _offset.y, transform.position.z);
    //         // X ile Z yi sabit bırakıyor , hedef Y ile kendi Ysini topluyor
    //
    //         Vector3 smoothedPos = Vector3.Lerp(transform.position, deisredPos,_smoothSpeed);
    //         // Lerp Kamerayı yumuşakca hareket ettirir ani hareketlerden kacınır, takip pürüzsüz hale gelir
    //         transform.position = smoothedPos;
    //     }
    // }
}
