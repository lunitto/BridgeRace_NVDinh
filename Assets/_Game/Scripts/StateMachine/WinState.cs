using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IState
{
    public void OnEnter(Bot bot)
    {
        bot.ChangeAnim("win");
        bot.DeactiveNavMeshAgent();

    }
    public void OnExecute(Bot bot)
    {

    }
    public void OnExit(Bot bot) { }
}
