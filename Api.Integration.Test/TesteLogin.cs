using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class TesteLogin : BaseIntegration
    {
        [Fact()]
        public async Task Executa_Login()
        {
            await AdicionarToken();
        }
    }
}
