using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP02.Models
{
    public class Container
    {
        public int Id { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "O número do container deve ter exatamente 11 caracteres.", MinimumLength = 11)]
        public string Numero { get; set; }
        public ContainerType Tipo { get; set; }
        public int Tamanho { get; set; }
        public int BillId { get; set; }

        public virtual BillOfLading? Bill { get; set; }
    }
    public enum ContainerType
    {
        Dry,
        Reefer
    }
}