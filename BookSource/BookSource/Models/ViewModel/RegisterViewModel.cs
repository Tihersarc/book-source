﻿using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookSource.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Confirma contraseña")]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
