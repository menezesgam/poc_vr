using UnityEngine;
using System.Collections;

/*
    T: type of parameter used as input
    (ex: vector3 as mousespeed)
    Extend this class and name it following:
    ActionActorInteraction (ex: MoveMouseSpeedInteraction)

    Action: The action to perform (ex: Move, Rotate)
    Actor: The actor used to interact (ex: MouseSpeed, MouseWheel, Keyboard)
    Interaction: Add the suffix Interaction todentify the class as an AbstractInteraction
*/
public abstract class AbstractInteraction<T> : MonoBehaviour
{

    /*
        Implement this method with the interaction to perform
        T input: the input obtained with GetInput()
    */
    public abstract void Interact(T input);

    /* 
        Method to toggle isInteracting to on and off. Make sure to implement a way to activate both states (true or false) 
    */
    protected abstract bool ToggleIsInteracting();
    protected bool isInteracting;

    /* 
        Method to get interaction input return the type used as parameter to interact with object
    */
    protected abstract T GetInput();

    /*
        Not virtual so these methods cannot be overridden and mess with workflow
    */

    public void Update()
    {
        isInteracting = ToggleIsInteracting();
        //broadcast to deactivate other interactions. study this possibility
        if (isInteracting)
        {
            Interact(GetInput());
        }
        FrameUpdate();
    }

    public void Start()
    {
        Init();
    }

    /*
        Override this method with any update implementations
    */
    public virtual void FrameUpdate() { }

    /*
        Override this method with any start implementations
    */
    public virtual void Init() { }
}
