using System;

namespace BoxBack.Application.ViewModels
{
    public class ChaveApiTerceiroViewModel
    {
        public Guid? Id { get; set; }

        public string ApiTerceiro { get; set; }
        public string Key { get; set; }
        public string Descricao { get; set; }
        public string DataValidade { get; set; }
        public string Status { get; set; }
    }
}