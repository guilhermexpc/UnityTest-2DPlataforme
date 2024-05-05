using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName ="PlayerController", menuName ="InputController/PlayerController")]
public class PlayerController : InputController
{
  public PlayerInputAction playerInputAction;
  public bool isJumping;
  public Vector2 moviment;

  private void OnEnable() 
  {
    Debug.Log("OnEnable");
    playerInputAction = new PlayerInputAction();
    playerInputAction.Gameplay.Enable();    
  }

  private void OnDisable() {  
    Debug.Log("OnDisable");
    playerInputAction.Gameplay.Disable();
    playerInputAction = null;
  }

  public override bool JumpInput()
  {
    throw new System.NotImplementedException();
  }

  public override float MovimentInput()
  {
    moviment = playerInputAction.Gameplay.Moviment.ReadValue<Vector2>();    
    return playerInputAction.Gameplay.Moviment.ReadValue<Vector2>().x;
  }


  // private void OnEnable() 
  // {
  //   Debug.Log("OnEnable");
  //   playerInputActions = new PlayerInputActions();
  //   playerInputActions.Gameplay.Enable();
  //   playerInputActions.Gameplay.Jump.started += JumpStarted;
  //   playerInputActions.Gameplay.Jump.canceled += JumpCanceled;
  // }

  // private void OnDisable() {  
  //   Debug.Log("OnDisable");
  //   playerInputActions.Gameplay.Disable();
  //   playerInputActions.Gameplay.Jump.started -= JumpStarted;
  //   playerInputActions.Gameplay.Jump.canceled -= JumpCanceled;  
  //   playerInputActions = null;
  // }

  // private void JumpCanceled(InputAction.CallbackContext context)
  // {
  //   Debug.LogWarning("JumpCanceled"); 
  //   isJumping = false;
  // }

  // private void JumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  // {
  //   Debug.LogWarning("isJumping");    
  //   isJumping = true;
  // }

 
}
