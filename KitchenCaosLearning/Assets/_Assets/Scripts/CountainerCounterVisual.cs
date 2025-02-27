using System;
using UnityEngine;

public class CountainerCounterVisual : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CountainerCounter countainerCounter;
    private const string OPEN_CLOSE = "OpenClose";

    private void Start()
    {
        countainerCounter.OnPlayerGrabbedObject += CountainerCounter_OnPlayerGrabbedObject;
    }

    private void CountainerCounter_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
