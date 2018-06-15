using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ground trap script. Inherits from Obstacle. Specifically, it triggers the trap animation which turns on and off the collision. 
/// </summary>

public class GroundTrap : Obstacle
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void TriggerObstacle()
    {
        animator.SetTrigger("TriggerObstacle");
    }
}
