using System.Collections.Generic;
using Game.Core.Mortal;
using UnityEngine;

public class MortalActionsManager : MonoBehaviour
{
    public Queue<IAction> ActionsList = new Queue<IAction>();
    
    public void QueueAction(IAction action)
    {
        ActionsList.Enqueue(action);
    }

    public void MakeChoice()
    {
        //examine surroundings and see what they advertise
        //score ads according to your needs
        //get the best ad and gget its action sequence
        //push sequence to queue
    }
}
