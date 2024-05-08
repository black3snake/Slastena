namespace Slastena.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        
        IEnumerable<Pie> PiesofWeek { get; }
        Pie? GetPieById(int pieId);
        IEnumerable<Pie> SearchPies(string searchQuery);


        //IPieRepository GetPieById(int pieId);

    }
}
