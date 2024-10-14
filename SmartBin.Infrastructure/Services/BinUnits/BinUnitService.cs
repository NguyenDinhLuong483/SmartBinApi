

using SmartBin.Infrastructure.Domain.Models.Bin;

namespace SmartBin.Infrastructure.Services.BinUnits
{
    public class BinUnitService : IBinUnitService
    {
        public IBinUnitRepository _binUnitRepository {  get; set; }
        public IMapper _mapper { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }

        public BinUnitService(IBinUnitRepository binUnitRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _binUnitRepository = binUnitRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BinUnitViewModel> GetBinUnitById(string id)
        {
            var source = await _binUnitRepository.GetBinUnitByIdAsync(id);
            var result = _mapper.Map<BinUnit, BinUnitViewModel>(source);
            return result;
        }

        public async Task<bool> UpdateBinUnit(string id, UpdateBinUnitViewModel viewModel)
        {
            var isExist = await _binUnitRepository.IsExistBinUnit(id);
            if (isExist) 
            {
                var binUnit = await _binUnitRepository.GetBinUnitByIdAsync(id);

                if (!string.IsNullOrEmpty(viewModel.FullLevel))
                {
                    binUnit.FullLevel = viewModel.FullLevel;
                }
                if (!string.IsNullOrEmpty(viewModel.EngineError))
                {
                    binUnit.EngineError = viewModel.EngineError;
                }
                if (binUnit.IsConnected != viewModel.IsConnected) 
                {
                    binUnit.IsConnected = viewModel.IsConnected;
                }
                if(!string.IsNullOrEmpty(viewModel.LastCollected.ToString()))
                {
                    binUnit.LastCollected = viewModel.LastCollected;
                    var history = new AddCollectedHistoryViewModel(id, viewModel.LastCollected);
                    var source = _mapper.Map<AddCollectedHistoryViewModel, CollectedHistory>(history);
                    await _binUnitRepository.AddCollectedHistoryAsync(source);
                }
                await _binUnitRepository.UpdateBinUnitAsync(binUnit);
                return await _unitOfWork.CompleteAsync();
            }
            else
            {
                return false;
            }
        }
    }
}
