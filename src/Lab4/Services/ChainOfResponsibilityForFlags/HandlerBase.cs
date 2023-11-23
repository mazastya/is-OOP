using System;
using System.Windows.Input;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exception;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public abstract class HandlerBase : IHandler
{
    private IHandler? _nextHandler;

    public void SetNextHandler(IHandler? handler)
    {
        _nextHandler = handler;
    }

    public string HandleRequest(string[] request)
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

        return "act complete";
    }

    protected abstract bool CanHandle(string[] request);
    protected abstract ICommand Handle(string[] request);
}