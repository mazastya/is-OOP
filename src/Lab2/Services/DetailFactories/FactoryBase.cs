using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using IComponent = Itmo.ObjectOrientedProgramming.Lab2.Entities.IComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class FactoryBase<T> : IFactory<T>
    where T : IComponent
{
    private readonly IList<T> _componentList;

    public FactoryBase(IList<T> componentList)
    {
        if (componentList.Count == 0)
            throw new ArgumentException("Value cannot be an empty collection.", nameof(componentList));
        _componentList = componentList ?? throw new ArgumentNullException(nameof(componentList));
    }

    public T? CreateComponentByName(string name)
    {
        T? componentName = _componentList.FirstOrDefault(component =>
        component.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return componentName ??
               throw new ComponentDoesntExistException("This component is not on the parts list");
    }
}