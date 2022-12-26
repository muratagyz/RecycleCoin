using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecycleCoin.UI.Models;

public class CarbonAddViewModel
{
    public List<Aluminum> Aluminums { get; set; }
    public Double AluminsNumber { get; set; }
    public decimal AluminsValue { get; set; }
    public List<Iron> Irons { get; set; }
    public Double IronsNumber { get; set; }
    public decimal IronsValue { get; set; }
    public List<Paper> Papers { get; set; }
    public Double PapersNumber { get; set; }
    public decimal PapersValue { get; set; }
    public List<Pine> Pines { get; set; }
    public Double PinesNumber { get; set; }
    public decimal PinesValue { get; set; }
    public List<Plastic> Plastics { get; set; }
    public Double PlasticsNumber { get; set; }
    public decimal PlasticsValue { get; set; }
    public string Identity { get; set; }
}