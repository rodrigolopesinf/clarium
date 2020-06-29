namespace Site.Areas.Administrativa.Models
{
    public class ViewAppMenu
    {
        public int MenuId { get; set; }
        public int MenuPaiId { get; set; }
        public int ViewId { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}