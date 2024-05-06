using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
  // Settings
  [SerializeField] private InputController inputController = null;
  [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
  [SerializeField, Range(0f, 5)] private int maxAirjump = 0;
  [SerializeField, Range(0f, 5f)] private float downwardMovimentMultiplier = 3f;
  [SerializeField, Range(0f, 5f)] private float upwardMovimentMultiplier = 1.7f;

  private Rigidbody2D rb2D;
  private CollisionCheck collisionCheck;
  public Vector2 velocity;

  private int jumpPhase;
  private float defaultGravityScale;
  private float jumpSpeed;
  public bool onGround, desiredJump, isJumping, isJumpReset;

  // Start is called before the first frame update
  void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    collisionCheck = GetComponent<CollisionCheck>();

  }

  // Update is called once per frame
  void Update()
  {
    desiredJump = inputController.JumpInput();
  }

  void FixedUpdate()
  {
    velocity = rb2D.velocity;
    onGround = collisionCheck.OnGround;

    if (IsIdleJump())
    {
      isJumping = false;
    }

    if (desiredJump)
    {
      desiredJump = false;
      JumpAction();
    }
    rb2D.velocity = velocity;
  }

  private void JumpAction()
  {
    if (onGround || (jumpPhase < maxAirjump && isJumping))
    {
      Debug.LogWarning("Jumping");
      if (isJumping)
      {
        jumpPhase += 1;
      }

      // Calculo Cientifico do pulo. -2 * aceleração * deslocamento.
      jumpSpeed = PhisichsJump();
      isJumping = true;

      if (velocity.y > 0)
      {
        jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0);
      }

      velocity.y = jumpSpeed;
    }
  }

  private bool IsIdleJump()
  {
    return !(onGround && rb2D.velocity.y == 0);
  }

  private float PhisichsJump()
  {
    return Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight * upwardMovimentMultiplier);
  }
}
