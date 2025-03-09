using System.Collections;
using UnityEngine;
using static CuttingCounter;



public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;
    private FryingRecipeSO fryingRecipeSO;
    private BurningRecipeSO burningRecipeSO;

    private float fryingTimer;
    private float burningTimer;

    private enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }
    private State state;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    Frying();
                    break;
                case State.Fried:
                    Fried();
                    break;
                case State.Burned:
                    break;
            }
            Debug.Log(state);
        }

    }

    private void Frying()
    {
        fryingTimer += Time.deltaTime;

        if (fryingTimer > fryingRecipeSO.fryingTimerMax)
        {
            
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
            Debug.Log("Fried");

            
            state = State.Fried;
            burningTimer = 0f;
            burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
        }
        Debug.Log(fryingTimer);
    }

    private void Fried()
    {
        burningTimer += Time.deltaTime;

        if (burningTimer > burningRecipeSO.burningTimerMax)
        {
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(burningRecipeSO.output, this);
            Debug.Log("Burned");
            state = State.Burned;
        }
        Debug.Log(fryingTimer);
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // there is no kitchen object on the counter
            if (player.HasKitchenObject())
            {
                // player is carrying a kitchen object
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    state = State.Frying;
                    fryingTimer = 0f;    
                }
            }
            else
            {
                // player is not carrying a kitchen object
            }
        }
        else
        {
            // there is a kitchen object here
            if (player.HasKitchenObject())
            {
                // player is carrying a kitchen object

            }
            else
            {
                // player is not carrying a kitchen object
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);

        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (BurningRecipeSO burningRecipeSO in burningRecipeSOArray)
        {
            if (burningRecipeSO.input == inputKitchenObjectSO)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
