using MextFullstackSaaS.Application.Common.Models.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IOpenAIService
    {
        Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto,CancellationToken cancellationToken);
    }
}
