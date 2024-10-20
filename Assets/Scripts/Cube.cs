using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
   private Rigidbody2D _rb;

   private void Start()
   {
      _rb =GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         _rb.gravityScale = 1;
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Ground" || (other.gameObject.tag == "Cube"))
      {
        
      }
      else
      {
         Destroy(gameObject);
         Debug.Log("Worked");
      }
   }
}
