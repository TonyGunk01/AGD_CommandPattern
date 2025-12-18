using System.Collections;
using System.Collections.Generic;
using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;


public abstract class ICommand : MonoBehaviour
{
    public abstract void Execute();
}

public abstract class UnitCommand : ICommand
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;

    protected UnitController actorUnit;
    protected UnitController targetUnit;

    public abstract override void Execute();

    public abstract bool WillHitTarget();
}
