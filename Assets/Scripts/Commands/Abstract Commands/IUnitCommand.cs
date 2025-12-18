using Command.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;

    public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;
}
