using Microsoft.EntityFrameworkCore;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext db = new();
            Console.WriteLine("Albumn");
            foreach (var item in db.Albums)
            {
                Console.WriteLine($"[{item.Id}] - Albumn Name: {item.Name} - Year: {item.Year} - Artist: {item.ArtistId} - Genre: {item.GenreId} ");
            }
            string name;
            int duration;
            int albumId;
            int categoryId;
            Console.WriteLine("Enter number of tracks you want add ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write("Enter new track\n Enter Name of Track: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter Duration of Track (seconds) ");
                duration = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Album id of Track ");
                albumId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Album id of Track ");
                db.Tracks.Add(new Tracks()
                {
                    Name = name,
                    Duration = duration,
                    AlbumId = albumId
                });
            }
            db.SaveChanges();
            Console.WriteLine("Tracks");
            foreach (var item in db.Tracks)
            {
                Console.WriteLine($"[{item.Id}] - Track Name: {item.Name} - Duration: {item.Duration} seconds - Album id: {item.AlbumId}");
            }
            num = 1;
            int id;
            do
            {

                Console.WriteLine("Create new playlist - 1\nAdd tracks to an existing playlist - 2\nView playlists - 3\nExit - 0");
                num = int.Parse(Console.ReadLine());
                if(num == 1)
                {
                    Console.WriteLine("Enter name of new playlist: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter category id of playlist: ");
                    categoryId = int.Parse(Console.ReadLine());
                    Playlist playlist= new Playlist()
                    {
                        Name = name,
                        CategoryId = categoryId,
                        Tracks = new List<Tracks>()
                    };
                    Console.WriteLine("Enter number of track you want add to this playlist ");
                    int number = int.Parse(Console.ReadLine());
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Enter id of track ");
                        id = int.Parse(Console.ReadLine());
                        var track = db.Tracks.Find(id);
                        playlist.Tracks.Add(track);
                    }
                    db.Playlists.Add(playlist);
                    db.SaveChanges();
                }
                else if (num == 2)
                {
                    Console.WriteLine("Enter id of playlist: ");
                    id = int.Parse(Console.ReadLine());
                    var playlist = db.Playlists.Find(id);
                    Console.WriteLine("Enter number of track you want add to this playlist ");
                    int number = int.Parse(Console.ReadLine());
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Enter id of track ");
                        id = int.Parse(Console.ReadLine());
                        var track = db.Tracks.Find(id);
                        playlist.Tracks.Add(track);
                    }
                    db.SaveChanges();
                }
                else if (num == 3)
                {
                    Console.WriteLine("Playlist");
                    foreach (var item in db.Playlists.Include(x => x.Tracks))
                    {
                        Console.Write($"[{item.Id}] - Playlist name: {item.Name} - Category id: {item.CategoryId} ");
                            Console.Write($"Tracks: ");
                            for (int i = 0; i < item.Tracks.ToList().Count; i++)
                            {
                            Console.Write($"{item.Tracks.ToList()[i].Id}, ");
                            }
                        Console.WriteLine();
                    }
                }
                else if(num == 0)
                {
                    return;
                }
                else
                {
                    continue;
                }
            }while(num != 0);
        }
    }
}