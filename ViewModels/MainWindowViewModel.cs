using _7DE_Prazdnikova.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DE_Prazdnikova.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private List<Agent> _agents;
        private List<Agent> _displaingAgents;

        public List<Agent> DisplaingAgents
        {
            get => _displaingAgents;
            set => Set(ref _displaingAgents, value, nameof(DisplaingAgents));
        }

        public MainWindowViewModel()
        {
            using (PrazdnikovaDe7Context db = new PrazdnikovaDe7Context())
            {
                _agents = db.Agents
                    .Include(at => at.AgentType)
                    .Include(ps => ps.ProductSales)
                    .ThenInclude(p => p.Product)
                    .ToList();
            }

            DisplaingAgents = _agents;
        }

        // ПОИСК ТУТ 
        public void Search(string text)
        {
            using (PrazdnikovaDe7Context db = new PrazdnikovaDe7Context())
            {
                if(text == "")
                {
                    DisplaingAgents = db.Agents
                        .Include(at => at.AgentType)
                        .Include(ps => ps.ProductSales)
                        .ThenInclude(p => p.Product)
                        .ToList();
                }
                else
                {
                    DisplaingAgents = db.Agents
                        .Include(at => at.AgentType)
                        .Include(ps => ps.ProductSales)
                        .ThenInclude(p => p.Product)
                        .Where(a => a.Title.Contains(text))
                        .ToList();
                }
            }
        }
    }
}
