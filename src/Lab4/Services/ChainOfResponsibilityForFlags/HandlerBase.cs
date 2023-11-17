using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exception;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public abstract class HandlerBase : IHandler
{
    private IHandler? _nextHandler;

    public void SetNextHandler(IHandler? handler)
    {
        _nextHandler = handler;
    }

    public virtual void HandleRequest(string[] request)
    {
        if (CanHandle(request))
        {
            Handle(request);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
        else
        {
            throw new RequestCannotBeHandledException("Request cannot be handled!");
        }
    }

    protected abstract bool CanHandle(string[] request);
    protected abstract void Handle(string[] request);
}