using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyLog.Models;

public class Veiculo
{
    [Key]
    [Required]
    public long Id {get; set;}

    [Required(ErrorMessage = "O Modelo é obrigatório")]
    public string Modelo {get; set;}

    [Required(ErrorMessage = "O Cor é obrigatório")]
    [MaxLength(15, ErrorMessage = "A cor não pode exceder 15 caracteres")]
    public string Cor { get; set; }

    [Required(ErrorMessage = "O Ano de Fabricação é obrigatório")]
    public DateTime AnoFabricacao { get; set; }

    [Required(ErrorMessage = "O Ano de Aquisição é obrigatório")]
    public DateTime AnoAquisicao { get; set; }

    [Required(ErrorMessage = "O Valor de Aquisição é obrigatório")]
    [Range(80000, 1000000, ErrorMessage = "Aquisição liberada para valores entre R$ 80.000,00 a R$ 1.000.000,00")]
    public long ValorAquisicao { get; set; }
    public bool StatusVeiculo { get; set; }

    [JsonIgnore]
    public virtual List<Frete> Fretes { get; set; }


}
 
