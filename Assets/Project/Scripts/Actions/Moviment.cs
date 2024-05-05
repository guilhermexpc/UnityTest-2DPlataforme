using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CollisionCheck))]
public class Moviment : MonoBehaviour
{
  public InputController inputController;

  [SerializeField, Range(0f, 20f)] private float maxSpeed = 4f;
  [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
  [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

  public Vector2 direction;
  public Vector2 desiredVelocity;
  public Vector2 currentVelocity;
  private Rigidbody2D rb2D;
  public CollisionCheck collisionCheck;

  public float maxSpeedChange;
  public float fixedDeltaTimer;
  public float deltaTimer;

  public float acceleration;
  public bool onGround;

  // Start is called before the first frame update
  void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    collisionCheck = GetComponent<CollisionCheck>();
  }

  // Update is called once per frame
  private void Update()
  {
    MovimentCalculation();
  }

  private void FixedUpdate()
  {
    onGround = collisionCheck.OnGround;
    currentVelocity = rb2D.velocity;

    acceleration = onGround ? maxAcceleration : maxAirAcceleration;
    maxSpeedChange = acceleration * Time.fixedDeltaTime;

    // Movimentação com Aceleração;
    currentVelocity.x = desiredVelocity.x == 0 ? 0f : Mathf.MoveTowards(currentVelocity.x, desiredVelocity.x, maxSpeedChange);

    // Final do processo aplica a velocity no Objeto
    rb2D.velocity = currentVelocity;
  }

  public void MovimentCalculation()
  {
    direction.x = inputController.MovimentInput();
    desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - collisionCheck.Friction, 0f);
  }



}
