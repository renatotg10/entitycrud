using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Recebedor!!")]
        public string Recebedor { get; set; }

        [Required(ErrorMessage = "Digite o nome do Fornecedor!!")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "Digite o nome do Livro!!")]
        public string NomeDoLivro { get; set; }
        public DateTime DataUltimaAtualizacao {  get; set; } = DateTime.Now;

        public DateTime DataDevolucaoPrevista { get; set; }

        [Required(ErrorMessage = "Digite o status do empréstimo!!")]
        public string StatusEmprestimo { get; set; }



    }
}
