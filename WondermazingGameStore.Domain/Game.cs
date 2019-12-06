using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WondermazingGameStore.Domain
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Price { get; set; }
        public string ReleaseDate { get; set; }
    }
}
