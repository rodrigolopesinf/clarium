namespace Millenium_Model
{
    public interface IMenu
    {
        int Id { get; }
        int SecMenu { get; }
        int? MenuPaiId { get; }
        string Url { get; }
        string Descricao { get; }
        string Controller { get; }
        string Route { get; }
        string Action { get; }
    }
}
