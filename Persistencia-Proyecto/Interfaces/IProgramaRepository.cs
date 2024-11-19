using Entities;

namespace Persistencia.Interface
{
    public interface IProgramaDepRepository
    {
        Task<List<ProgramaDep>> GetAllProgramaDepsAsync();
        Task<ProgramaDep> GetProgramaDepByIdAsync(int id);
        Task CreateProgramaDepAsync(ProgramaDep ProgramaDep);
        Task<bool> UpdateProgramaDepAsync(ProgramaDep ProgramaDep);
        Task<bool> DeleteProgramaDepAsync(int id);
    }
}