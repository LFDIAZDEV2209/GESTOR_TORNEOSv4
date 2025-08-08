namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DorsalNumber { get; set; }
    public DateTime BirthDate { get; set; } 
    public decimal MarketValue { get; set; }

    public Player(int id, string name, int dorsalNumber, DateTime birthDate, decimal marketValue)
    {
        Id = id;
        Name = name;
        DorsalNumber = dorsalNumber;
        BirthDate = birthDate;
        MarketValue = marketValue;
    }

    public Player()
    {
    }

    public override string ToString()
    {
        return $"Player [Id={Id}, Name={Name}, DorsalNumber={DorsalNumber}, BirthDate={BirthDate.ToShortDateString()}, MarketValue={MarketValue}]";
    }
}
