using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
  public abstract float MovimentInput();
  public abstract bool JumpInput();
}
