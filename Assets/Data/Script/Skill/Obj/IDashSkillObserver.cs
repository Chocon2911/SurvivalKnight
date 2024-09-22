using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashSkillObserver
{
    public abstract void OnDashStart();
    public abstract void OnDashFinished();
}
