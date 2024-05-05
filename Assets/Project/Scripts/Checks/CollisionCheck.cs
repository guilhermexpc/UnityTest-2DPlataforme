using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{   
    public bool OnGround { get; private set; }
    public float Friction { get; private set; }
    public bool OnWall { get; private set;}
    public Vector2 ContactNormal {get; private set;}  
    public Vector2 ContactNormal1;
    public Vector2 ContactNormal2;
    public Vector2 ContactPoint1;
    public Vector2 ContactPoint2;

    public List<Vector2> normal2;    
    private PhysicsMaterial2D material2D;
    public List<float> contact;
    public List<ContactPoint2D> cp2D;

    // Checagem de colisão Estudar essa parte do código
    public void EvaluateCollision(Collision2D collision) {
      ContactNormal1 = collision.GetContact(0).normal;        
      ContactNormal2 = collision.GetContact(1).normal;        
      ContactPoint1 = collision.GetContact(0).point;   
      ContactPoint2 = collision.GetContact(1).point;   
      Debug.DrawLine(ContactPoint1, ContactPoint2, Color.yellow, 1.0f);      

      for (int i = 0; i < collision.contactCount; i++)
      {        
        ContactNormal = collision.GetContact(i).normal;        
             
        OnGround |= ContactNormal.y >= 0.9f;
        OnWall = Mathf.Abs(ContactNormal.x) >= 0.9f;        
      }
    }

    


    public void CheckBoxCollision(){

    }

    private void RetrieveFriction(Collision2D collision)
    {
      material2D = collision.rigidbody.sharedMaterial;
      Friction = 0;

      if (material2D != null)
      {
        Friction = material2D.friction;  
      }
    }

    private void OnCollisionEnter2D(Collision2D collision){
      EvaluateCollision(collision);
      RetrieveFriction(collision);      
    }

    private void OnCollisionStay2D(Collision2D collision) {
      EvaluateCollision(collision);
      RetrieveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision) {
      OnGround = false;
      OnWall = false;
      Friction = 0;
    }
}
