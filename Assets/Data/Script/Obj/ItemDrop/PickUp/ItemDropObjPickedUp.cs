using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropObjPickedUp : ItemDropObjAbstract
{
    //==========================================Variable==========================================
    [Header("Item Drop Obj Picked Up")]
    [SerializeField] protected List<IItemDropObjPickedUpObserver> observers = new List<IItemDropObjPickedUpObserver>();
    public List<IItemDropObjPickedUpObserver> Observers => observers;

    //=========================================Picked Up==========================================
    protected virtual void OnPickedUp()
    {
        

        foreach (IItemDropObjPickedUpObserver observer in observers)
        {
            observer.OnItemPickedUp();
        }
    }

    //==========================================Observer==========================================
    public virtual void RegisterObserver(IItemDropObjPickedUpObserver observer)
    {
        this.observers.Add(observer);
    }
}
