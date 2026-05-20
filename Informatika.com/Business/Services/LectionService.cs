using Informatika.Application.Models.Requests;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;

namespace Informatika.Application.Business.Services
{
    public class LectionService
    {
        private readonly ILectionsRepository _lectionsRepository;

        public LectionService(ILectionsRepository lectionsRepository)
        {
            _lectionsRepository = lectionsRepository;
        }
        
        public async Task<ServiceResponse<Lection>> GetByIdAsync(Guid LectionId)
        {
            try
            {
                var lection = await _lectionsRepository.GetLectionByIdAsync(LectionId);

                if(lection != null)
                {
                    return new ServiceResponse<Lection>
                    {
                        Success = true,
                        Data = lection
                    };
                }

                return new ServiceResponse<Lection>
                {
                    Success = false,
                    Error = "Лекция не найдена!"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Lection> { Error = ex.Message };
            }
        }

        public async Task<ServiceResponse<List<Lection>>> GetAllAsync()
        {
            try
            {
                var lections = await _lectionsRepository.GetLectionsListAsync();

                return new ServiceResponse<List<Lection>>
                {
                    Success = true,
                    Data = lections
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Lection>>
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<List<Lection>>> SearchAsync(string query)
        {
            try
            {
                var lections = await _lectionsRepository.SearchLections(query);

                return new ServiceResponse<List<Lection>>
                {
                    Success = true,
                    Data = lections
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Lection>>
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<Lection>> DeleteAsync(Guid Id)
        {
            try
            {
                var lection = await _lectionsRepository.GetLectionByIdAsync(Id);
                if(lection == null)
                {
                    return new ServiceResponse<Lection>
                    {
                        Success = false,
                        Error = "Лекция не найдена"
                    };
                }

                await _lectionsRepository.DeleteLectionAsync(lection);
                return new ServiceResponse<Lection>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Lection>
                {
                    Success = false,
                    Error = ex.Message
                };

            }
        }

        public async Task<ServiceResponse<Lection>> UpdateLectionAsync(Guid LectionId, LectionUpdateRequest request)
        {
            try
            {
                var lection = await _lectionsRepository.GetLectionByIdAsync(LectionId);

                if (lection != null)
                {
                    lection.Title = request.Title;
                    lection.Description = request.Description;
                    lection.LectionText = request.LectionText;

                    await _lectionsRepository.UpdateLectionAsync(lection);

                    return new ServiceResponse<Lection>
                    {
                        Success = true,
                        Data = lection
                    };
                }

                return new ServiceResponse<Lection>
                {
                    Success = false,
                    Error = "Лекция не найдена!"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Lection>
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<Lection>> AddAsync(LectionUpdateRequest request)
        {
            try
            {
                var lection = new Lection
                {
                    Title = request.Title,
                    Description = request.Description,
                    LectionText = request.LectionText
                };

                await _lectionsRepository.AddLectionAsync(lection);

                return new ServiceResponse<Lection> { Success = true, Data = lection };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Lection>
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}
