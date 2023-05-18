using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ParameterSelector<T> : MonoBehaviour where T : IMove
{
    public event Action OnCompletion;

    public virtual void Init() {}
    public void StartSelecting(T parameter)
    {
        enabled = true;
        AfterStart(parameter);
    }

    protected virtual void AfterStart(T parameter) {}

    public async Task StartSelectingAsync(T parameter, CancellationToken token)
    {
        if(token.IsCancellationRequested)
            return;

        var tcs = new TaskCompletionSource<object>();
        Action handler = () => tcs.TrySetResult(null);

        token.Register( () => tcs.TrySetCanceled());
        token.Register( () => Exit());

        try
        {
            OnCompletion += handler;
            StartSelecting(parameter);
            await tcs.Task;
        }
        finally
        {
            OnCompletion -= handler;
        }
    }

    protected void Exit()
    {
        BeforeExit();
        enabled = false;
        OnCompletion?.Invoke();
    }

    protected virtual void BeforeExit() {}
}