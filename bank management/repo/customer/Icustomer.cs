using bank_management.dto;

namespace bank_management.repo.customer
{
    public interface Icustomer
    {
        List<getcustomerDto> Getall();
        void addcustomer(getcustomerDto getcustomerDto);
        getcustomerDto Get(int id);
    }
}
