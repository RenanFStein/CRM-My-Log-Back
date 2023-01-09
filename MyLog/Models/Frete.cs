using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyLog.Models;

public class Frete
{
    [Key]
    [Required]
    public long Id {get; set;}
    
    [JsonIgnore]
    public virtual Veiculo Veiculo { get; set; }
    [Required(ErrorMessage = "O campo de {0} é obrigatório")]
    public long VeiculoId { get; set; }

    [Required(ErrorMessage = "O Valor do Frete é obrigatório")]
    public long ValorFrete {get; set;}

    [Required(ErrorMessage = "A Empresa é obrigatório")]
    public string Empresa { get; set; }

    [Required(ErrorMessage = "O Carregamento é obrigatório")]
    public string Carregamento { get; set; }

    [Required(ErrorMessage = "O Entrega é obrigatório")]
    public string Entrega { get; set; }

    public EnumStatusFrete StatusFrete { get; set; } 

    [Required(ErrorMessage = "A data é obrigatório")]
    public DateTime Data { get; set; }

}
 
