using truckeventsXamPL.Models.Enums;

namespace truckeventsXamPL.Models
{
    public class Token
    {
        public string access_token { get; set; } = null;
        public ContaTipo TipoConta { get; set; }
        public string Id_usuario { get; set; } = null;
        public Evento EventoPrincipal { get; set; }
        public int Expirese_in { get; set; }
        public string TipoFuncionario { get; set; }
    }
}
