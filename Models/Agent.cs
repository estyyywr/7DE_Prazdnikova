using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

namespace _7DE_Prazdnikova.Models;

public partial class Agent
{
    public Agent()
    {
        AgentPriorityHistories = new HashSet<AgentPriorityHistory>();
        ProductSales = new HashSet<ProductSale>();
        Shops = new HashSet<Shop>();
    }
    private string? _logo;

    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AgentTypeId { get; set; }

    public string? Address { get; set; }

    public string Inn { get; set; } = null!;

    public string? Kpp { get; set; }

    public string? DirectorName { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }
    
    public string? Logo { get => _logo; set => _logo=value; }

    [NotMapped]
    public string? LogoPath
    {
        get => (_logo == string.Empty || _logo == null) ?
            "..\\Resources\\picture.png" :
            $"..\\Resources{_logo}";
    }

    public int Priority { get; set; }

    [NotMapped]
    public string FullName
    {
        get { return AgentType.Title + " | " + Title; }
    }

    [NotMapped]
    public int SalesPerLastYear
    {
        get
        {
            var sales = 0;

            DateTime LastYear = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);

            foreach (var ps in ProductSales)
                if (ps.SaleDate >= LastYear)
                    sales++;

            return sales;
        }
    }

    [NotMapped]
    public decimal Discount
    {
        get
        {
            decimal cost = 0;
            foreach (var ps in ProductSales)
                cost += Math.Ceiling((decimal)ps.ProductCount) * ps.Product.MinCostForAgent;

            if (cost <= 10000)
                return 0;
            else if (cost > 10000 && cost <= 50000)
                return 5;
            else if (cost > 50000 && cost <= 150000)
                return 10;
            else if (cost > 150000 && cost <= 500000)
                return 20;
            else
                return 25;
        }
    }

    public virtual ICollection<AgentPriorityHistory> AgentPriorityHistories { get; } = new List<AgentPriorityHistory>();

    public virtual AgentType AgentType { get; set; } = null!;

    public virtual ICollection<ProductSale> ProductSales { get; } = new List<ProductSale>();

    public virtual ICollection<Shop> Shops { get; } = new List<Shop>();
}
