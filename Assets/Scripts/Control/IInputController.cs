using System.Collections.Generic;
using UnityEngine;

public interface IInputController {

    List<Vector3> OnTouch();

    bool IsCursorMoving();

    bool IsTouchEnd();
}

