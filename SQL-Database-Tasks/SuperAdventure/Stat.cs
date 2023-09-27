using System.ComponentModel.DataAnnotations;

namespace SuperAdventure
{
    public class Stat
    {
        [Key]
        public int Id { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaxHitpoints { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
    }
}
