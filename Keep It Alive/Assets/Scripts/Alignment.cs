using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum Alignment
{
    Hero = 1 << 0,
    Skeleton = 1 << 1,
    Orc = 1 << 2
}
