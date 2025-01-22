using bank_management.dto;

namespace bank_management.repo.account
{
    public interface Iaccountrepo
    {
        List<dtoaddaccount> Getall();
        void addaccount(accountadddto accountadddto);
        bool deleteaccount(int id);
        bool updateaccount(int id, updateaccountdto updateaccountdto);
    }
}
