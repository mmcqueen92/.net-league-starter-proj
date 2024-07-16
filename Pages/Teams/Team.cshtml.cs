using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using League.Models;
using League.Data;

namespace League.Pages.Teams
{
  public class TeamModel : PageModel
  {
    // inject the Entity Framework context
    private readonly LeagueContext _context;

    public TeamModel(LeagueContext context)
    {
      _context = context;
    }

    // load a single team  based on Id and include the related division and players
    public Team Team { get; set; }

    public async Task OnGetAsync(string Id)
    {
      Team = await _context.Teams
      .Include(t => t.Players)
      .Include(t => t.Division)
      .AsNoTracking()
      .FirstOrDefaultAsync(t => t.TeamId == Id);
    }
  }
}