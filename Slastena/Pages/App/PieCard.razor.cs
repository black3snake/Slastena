using Slastena.Models;
using Microsoft.AspNetCore.Components;

namespace Slastena.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
