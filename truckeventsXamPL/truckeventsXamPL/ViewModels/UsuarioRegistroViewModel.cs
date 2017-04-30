using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.ViewModels
{
   public class UsuarioRegistroViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string RazaoSocial { get; set; }

        public string Documento { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public bool Admin { get; set; }

        public bool Organizador { get; set; }

        public bool PrincipalLoja { get; set; }

        public bool CaixaEvento { get; set; }

    }
}
