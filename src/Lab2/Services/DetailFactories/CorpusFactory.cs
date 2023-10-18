using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;

public class CorpusFactory : IFactory<Corpus>
{
    private readonly IList<Corpus> _corpusList;

    public CorpusFactory(IList<Corpus> corpusList)
    {
        if (corpusList.Count == 0)
            throw new ArgumentException("Value cannot be an empty collection", nameof(corpusList));
        _corpusList = corpusList ?? throw new ArgumentNullException(nameof(corpusList));
    }

    public Corpus? CreateComponentByName(string name)
    {
        Corpus? corpus =
            _corpusList.FirstOrDefault(corpus => corpus.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return corpus ?? throw new ArgumentNullException("This component is not on the parts list", nameof(corpus));
    }
}