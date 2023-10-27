using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class CorpusFactory : FactoryBase<Corpus>
{
    public CorpusFactory(IList<Corpus> componentList)
        : base(componentList)
    {
    }
}