using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CuttingCounter cuttingCounter;
    private const string CUT = "Cut";

    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
