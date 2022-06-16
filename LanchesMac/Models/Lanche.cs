﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {        
        [Key]
        public int Id { get; private set; }
        
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do lanche")]
        [StringLength(maximumLength: 80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "DescriçãoA deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} carateres")]
        public string DescricaoCurta { get; private set; }

        [Required(ErrorMessage = "A descrição detalhada deve ser informada")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} carateres")]
        public string DescricaoDetalhada { get; private set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; private set; }

        [Display(Name = "Caminho da imagem normal")]
        [StringLength(200, ErrorMessage = ") {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; private set; }

        [Display(Name = "Caminho da imagem miniatura")]
        [StringLength(200, ErrorMessage = ") {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; private set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; private set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; private set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
