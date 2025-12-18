using System.Collections;
using System.Collections.Generic;
using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;


public abstract class ICommand
{
    public abstract void Execute();
}

public struct CommandData
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;

    public CommandData(int ActorUnitID, int TargetUnitID, int ActorPlayerID, int TargetPlayerID)
    {
        this.ActorUnitID = ActorUnitID;
        this.TargetUnitID = TargetUnitID;
        this.ActorPlayerID = ActorPlayerID;
        this.TargetPlayerID = TargetPlayerID;
    }
}