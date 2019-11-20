using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityQuiz
{
    public interface IMarvelDataService
    {
        Task<IEnumerable<Comic>> GetComicsBySeries(int seriesId, string orderBy = null);
    }
}
