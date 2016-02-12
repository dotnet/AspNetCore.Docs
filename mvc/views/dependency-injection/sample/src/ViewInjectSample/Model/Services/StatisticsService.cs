using System.Linq;
using System.Threading.Tasks;
using ViewInjectSample.Interfaces;

namespace ViewInjectSample.Model.Services
{
    public class StatisticsService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public StatisticsService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<int> GetCount()
        {
            return await Task.FromResult(_toDoItemRepository.List().Count());
        }

        public async Task<int> GetCompletedCount()
        {
            return await Task.FromResult(
              _toDoItemRepository.List().Count(x => x.IsDone));
        }

        public async Task<double> GetAveragePriority()
        {
            if (_toDoItemRepository.List().Count() == 0)
            {
                return 0.0;
            }

            return await Task.FromResult(
              _toDoItemRepository.List().Average(x => x.Priority));
        }
    }
}
