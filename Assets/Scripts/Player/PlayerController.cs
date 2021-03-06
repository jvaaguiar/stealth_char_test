﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharController
{
    // ============================================================================== //
    // PROTECTED MEMBERS
    // ============================================================================== //
    override protected Vector2 GetInputDirection()
    {
        // Ref: (Vector3.forward, Vector3.right)
        Vector2 nextDirection = Vector2.zero;
        
        nextDirection.x = InputManager.GetAxisHorizontal();
        nextDirection.y = InputManager.GetAxisVertical();

        if (nextDirection != Vector2.zero)
        {
            nextDirection.Normalize();
        }
        
        Vector3 fwd     = Vector3.ProjectOnPlane(RegisterCamera.CameraNode.transform.forward, Vector3.up);
        Vector3 right   = Vector3.ProjectOnPlane(RegisterCamera.CameraNode.transform.right, Vector3.up);

        return new Vector2(nextDirection.x * right.x + nextDirection.y * fwd.x, nextDirection.x * right.z + nextDirection.y * fwd.z);
    }

    // ============================================================================== //
    override protected bool GetInputSneak()
    {
        return InputManager.GetButtonSneak();
    }
}
