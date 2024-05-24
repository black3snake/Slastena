namespace Slastena.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieById(int pieId);
        IEnumerable<Pie> SearchPies(string searchQuery);


        //IPieRepository GetPieById(int pieId);

    }
}
