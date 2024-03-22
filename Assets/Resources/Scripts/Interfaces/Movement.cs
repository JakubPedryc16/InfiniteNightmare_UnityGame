using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Movement
{
    public void Move();
    public float MvModifier { get; set; }
    public float MvAmplifier { get; set; }
    
    public float MovementSpeed { get; set; }
}
