using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tracks> Tracks { get; set; } = new HashSet<Tracks>();
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
