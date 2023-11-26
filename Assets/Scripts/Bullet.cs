using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Rigidbody rb;

   private void Awake()
   {
      rb = GetComponent<Rigidbody>();
   }
}