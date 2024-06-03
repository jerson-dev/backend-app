﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_casa_estudio")]
    public class TaakCasaEstudio
    {
        [Key]
        [Required]
        public int CasaEstudioId { get; set; }

        [Required]
        public string CasaEstudio { get; set; }
    }
}
