using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
   [SerializeField] private float _speed = 1f;
   [SerializeField] private float _distance = 3f;
    private float _dir = 1f;
    
    private Rigidbody2D _rb;
    private Vector3 _startPos;  // küpün başlangıç noktası
    private bool _isFalling = false;  // Küpün düşüp düşmediğini kontrol edecek.
    private Score _scoreManager;  // Score classından türüyor
    private GameManager _gameManager;
    private CameraFollow _camera;
    
    private HashSet<int> _collideCubes = new HashSet<int>(); // Çarpşıan küplerin ID lerini saklayacak
    
   private void Start()
   {

      _scoreManager = FindObjectOfType<Score>();  // burada bir kez almamız performans açasından önemli
      _gameManager = FindObjectOfType<GameManager>();
      _camera = FindObjectOfType<CameraFollow>();
      
      _startPos = transform.position;  // oyun başladığında başlangıç noktasını alıyor
      _rb =GetComponent<Rigidbody2D>();

      if (_rb == null)
      {
         _rb = gameObject.AddComponent<Rigidbody2D>();   
      }
      // Eğer Rb boşsa o gameObjeye compenenti ekler.
      _rb.gravityScale = 0;
      _rb.isKinematic = true;  // fizik simülasyonundan etkilenmemek için.

   }

   private void Update()
   {
      if (!_isFalling)  // küp düşmüyorsa hareketi devam et
      {
         float movement = Mathf.Sin(Time.time * _speed) * _distance * _dir;
         //bu satırda  Time.Time zamanla hızı çarpar Sinüs fonk ne kadar hızlı değişeceini belirler
         // Mathf.Sin  -1 ile 1 arasında değişken değer üretir bu hareketin yumuşak ve periyodik olmasını sağlar
         // distance Sinüs değerini mesafe ile çarpar ne  kadar uzağa gideceğini belirler
         // dir yöne değeri ile çapılır ya 1 dönecek ya da -1 dönecek Sinden 
         transform.position = _startPos + Vector3.right * movement;
         // startPos küpün başlangıç noktasını belirler 
         // vector3.right (1,0,0)  x eksenin de 1 birimlik hareket 
         // Vector3.right * movement; X e hepsaladığı değeri uygular
         // _startPos + dönen değeri başlagnıça ekler

         if (Input.GetMouseButtonDown(0))
         {
          StartFalling();   //Kinematic kapanacak hareket etmeyecek ve fizeğe maruz kalacak.
         }
      }
     
   }

   

   public void StartFalling()
   {
      _isFalling = true;
      _rb.gravityScale = 1;
      _rb.isKinematic = false;
   }
   
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Cube")) // Tagden compareTag geçerek performans attırdık
      {
         int otherId = other.gameObject.GetInstanceID(); // çarpışan nesnelerin ID lerini aldık

         if (!_collideCubes.Contains(otherId))  // eğer otherId YANİ çarpışan küp ıd Listede yoksa 
         {
            _collideCubes.Add(otherId);  // Listeye ekledik

            if (transform.position.y > other.transform.position.y)  // eğer bunun trasnformu diğerinden büyükse 
            {
               _scoreManager.IncreaseScore(); // Score artırıcaz.
               _gameManager.IncrementSpawnPos();
                _camera.IncrementSpawnCameraPos();
            }
         }
      }
      
      else if (other.gameObject.CompareTag("DestroyGround"))
      {
         Destroy(gameObject);
         _scoreManager.DecreaseScore();
      }
   }
}
