using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

/*
- Максимальная длина и ширина видеокарты
 - Поддерживаемые форм-факторы материнских плат
 - Габариты
 */

public class Corpus
{
    public Corpus(
        string name,
        MaxLengthAndWidthOfTheGraphicsCard pairMaxLengthAndWidthOfTheGraphicsCard,
        TypeOfFormFactorMotherboard typeOfFormFactorMotherboard,
        TypeOfCorpus typeOfCorpus)
    {
        Name = name;
        Pair = pairMaxLengthAndWidthOfTheGraphicsCard;
        TypeOfFormFactorMotherboard = typeOfFormFactorMotherboard;
        TypeOfCorpus = typeOfCorpus;
    }

    public string Name { get; } // имя
    public MaxLengthAndWidthOfTheGraphicsCard Pair { get; } // максимальная длина и ширина видеокарты
    public TypeOfFormFactorMotherboard TypeOfFormFactorMotherboard { get; } // поддерживаемый форм-фактор материнских плат
    public TypeOfCorpus TypeOfCorpus { get; }
}