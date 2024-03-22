using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Mediator
{
    void Notify(string sender, float current, float max);
}
